import os
import glob
import json
import logging
import torch
import torch.nn as nn
import torch.optim as optim
from torch.utils.data import Dataset, DataLoader
import torchvision.transforms as transforms
from torchvision.transforms import Compose
from PIL import Image
import numpy as np
from SVHN_ModelCRNN2 import SVHN_Model
from torch.cuda.amp import autocast, GradScaler
from torch.optim.lr_scheduler import CosineAnnealingLR


# 使用 GPU
device = torch.device("cuda" if torch.cuda.is_available() else "cpu")

# 配置日志
logging.basicConfig(level=logging.INFO, format='[%(asctime)s] - [%(levelname)s] - %(message)s')

class SVHNDataset(Dataset):
    def __init__(self, img_paths, img_json, transform=None):
        self.img_paths = img_paths
        self.img_json = img_json 
        self.transform = transform

    def __getitem__(self, index):
        img_path = self.img_paths[index]
        img = Image.open(img_path).convert('RGB')

        # 提取文件名（不含路径）
        file_name = os.path.basename(img_path)
        
        # 获取 JSON 中的标注信息
        label_info = self.img_json[file_name]
        label = label_info['label']
        left = label_info['left']
        top = label_info['top']
        width = label_info['width']
        height = label_info['height']
        
        # 将原始SVHN中类别10映射为数字0
        label = [x if x != 10 else 0 for x in label]
        k = len(label)  # 字符数
        padded_label = label + [-1] * (6 - len(label))  # 填充到6个字符，无效位置为-1
        padded_label = padded_label[:6]  # 确保长度为6
        
        # 自定义数据扩增逻辑
        if self.transform is not None:
            img = self.custom_augmentation(img, left, top, width, height)
        
        return img, torch.tensor(padded_label), k  # 返回图像、填充后的标签和字符数

    def custom_augmentation(self, img, left, top, width, height):
        # 转换为 NumPy 数组以便操作
        img_np = np.array(img)
        h, w, _ = img_np.shape  # 获取图像的高度和宽度

        # 随机调整字符间距
        new_left = [l + np.random.randint(-5, 5) for l in left]
        new_top = [t + np.random.randint(-5, 5) for t in top]

        # 模拟部分遮挡
        for i in range(len(left)):
            if np.random.rand() < 0.3:  # 30%概率遮挡某个字符
                x1 = max(0, min(int(new_left[i]), w - 1))
                y1 = max(0, min(int(new_top[i]), h - 1))
                x2 = max(x1, min(int(x1 + width[i]), w))
                y2 = max(y1, min(int(y1 + height[i]), h))

                if np.random.rand() < 0.5:  # 随机颜色遮挡
                    img_np[y1:y2, x1:x2] = np.random.randint(0, 255, size=(y2-y1, x2-x1, 3))
                else:  # 条纹遮挡
                    for j in range(y1, y2):
                        if j % 2 == 0:
                            img_np[j, x1:x2] = 0

        # 转回 PIL 图像
        img_augmented = Image.fromarray(img_np)

        # 应用标准扩增
        img_augmented = self.transform(img_augmented)

        return img_augmented
    def __len__(self):
        return len(self.img_paths)
    
# 数据增广
data_aug_transform = transforms.Compose([
    transforms.Resize((64, 128)),
    transforms.RandomResizedCrop((64, 128), scale=(0.9, 1.1), ratio=(0.9, 1.1)),
    transforms.RandomRotation(10),
    transforms.ColorJitter(brightness=0.3, contrast=0.3, saturation=0.3, hue=0.1),
    transforms.GaussianBlur(kernel_size=3, sigma=(0.1, 2.0)),
    transforms.ToTensor(),
    transforms.Normalize([0.485, 0.456, 0.406], [0.229, 0.224, 0.225])
])


# 加载数据
def load_datasets(train_dir, val_dir):
    # 加载训练数据
    train_path = glob.glob(train_dir)
    train_json = json.load(open(os.path.join(train_dir.split('*')[0], '..', 'mchar_train.json')))
    train_dataset = SVHNDataset(train_path, train_json, transform=data_aug_transform)

    # 加载验证数据
    val_path = glob.glob(val_dir)
    val_json = json.load(open(os.path.join(val_dir.split('*')[0], '..', 'mchar_val.json')))
    val_dataset = SVHNDataset(val_path, val_json, transform=data_aug_transform)

    return train_dataset, val_dataset

train_dataset, val_dataset = load_datasets('./input/mchar_train/*.png', './input/mchar_val/*.png')

# 数据加载器
train_loader = DataLoader(
    train_dataset, 
    batch_size=16,  # 调整批次大小
    shuffle=True, 
    num_workers=4  # 根据实际情况调整线程数
)

val_loader = DataLoader(
    val_dataset, 
    batch_size=16, 
    shuffle=False, 
    num_workers=4
)


model = SVHN_Model().to(device)  # 将模型移动到 GPU

# 损失函数和优化器
criterion = nn.CrossEntropyLoss(ignore_index=-1).to(device)
optimizer = optim.Adam(model.parameters(), lr=0.001, weight_decay=1e-6)

scaler = GradScaler()
# 训练函数
def train(train_loader, model, criterion, optimizer, epoch):
    model.train()
    train_loss = 0.0
    valid_total = 0
    for i, (data, target, k) in enumerate(train_loader):
        data, target, k = data.to(device), target.to(device), k.to(device)
        optimizer.zero_grad()
        
        with autocast():  # 启用混合精度
            outputs, length_logits = model(data)
            valid_mask = target != -1
            valid_outputs = outputs[valid_mask]
            valid_target = target[valid_mask]
            char_loss = criterion(valid_outputs, valid_target)
            length_loss = criterion(length_logits, k.clamp(max=6))
            total_loss = char_loss + 0.5 * length_loss # 加权融合
        
        scaler.scale(total_loss).backward()
        scaler.step(optimizer)
        scaler.update()
        
        train_loss += total_loss.item() * target.size(0)
        valid_total += target.size(0)
        
        if (i+1) % 10 == 0:
            logging.info(f'Epoch {epoch}, Batch {i+1}, Loss: {total_loss.item():.4f}')
    
    return train_loss / valid_total

# 验证函数
def validate(val_loader, model, criterion):
    model.eval()
    val_loss = 0.0
    correct = 0
    total = 0
    with torch.no_grad():
        for i, (data, target, k) in enumerate(val_loader):
            data, target, k = data.to(device), target.to(device), k.to(device)
            outputs, length_logits = model(data)
            
            # 筛选有效目标
            valid_mask = target != -1
            valid_outputs = outputs[valid_mask]
            valid_target = target[valid_mask]
            
            # 字符分类损失
            if valid_outputs.numel() > 0:
                char_loss = criterion(valid_outputs, valid_target)
            else:
                char_loss = 0.0
            
            # 长度预测损失
            length_loss = criterion(length_logits, k.clamp(max=6))
            total_val_loss = char_loss + 0.5 * length_loss
            
            total_val_loss = total_val_loss / target.size(0)
            val_loss += total_val_loss.item() * target.size(0)
            
            # 预测与对比
            pred = outputs.argmax(dim=-1)  # (batch, 6)
            pred_length = length_logits.argmax(dim=-1)
            
            # 有效掩码
            mask = torch.arange(6, device=device).unsqueeze(0) < pred_length.unsqueeze(1)
            valid_pred = pred[mask]
            valid_target = target[mask]
            
            correct += (valid_pred == valid_target).sum().item()
            total += valid_target.numel()
    
    accuracy = correct / (total + 1e-8)
    logging.info(f'Validation Accuracy: {accuracy * 100:.2f}%')
    
    return val_loss / (len(val_loader.dataset) + 1e-8), accuracy

# 主训练循环
best_accuracy = 0.0
num_epochs = 50
scheduler = CosineAnnealingLR(optimizer, T_max=num_epochs, eta_min=1e-6)
for epoch in range(num_epochs):
    logging.info(f'[Epoch {epoch}] Training...')
    train_loss = train(train_loader, model, criterion, optimizer, epoch)
    logging.info(f'[Epoch {epoch}] Training Loss: {train_loss:.4f}')
    
    logging.info(f'[Epoch {epoch}] Validating...')
    val_loss, accuracy = validate(val_loader, model, criterion)
    scheduler.step(val_loss)
    
    # 保存模型
    torch.save(model.state_dict(), f'./user_data/model_data/model_epoch_{epoch}_{accuracy:.4f}.pt')
    logging.info(f'[Epoch {epoch}] Saved model for epoch {epoch}')
    
    # 保存最佳模型
    if accuracy > best_accuracy:
        best_accuracy = accuracy
        torch.save(model.state_dict(), './user_data/model_data/model_best.pt')
        logging.info(f'[Epoch {epoch}] Saved best model with Val Accuracy: {accuracy:.4f}')
    
    logging.info(f'[Epoch {epoch}] Val Loss: {val_loss:.4f}, Val Accuracy: {accuracy:.4f}')

logging.info('Training completed.')

# import matplotlib.pyplot as plt
# for i, (data, target, k) in enumerate(train_loader):
#     for j in range(data.shape[0]):
#         print(f'{i}:{j}:{data.shape}:{target},{k}')
#         plt.imshow(data[j][2])
#         plt.show()

# def visualize_augmented_data(dataset, num_samples=5):
#     import matplotlib.pyplot as plt
#     fig, axes = plt.subplots(1, num_samples, figsize=(15, 3))
#     for i in range(num_samples):
#         img, _, _ = dataset[np.random.randint(len(dataset))]
#         img = img.permute(1, 2, 0).numpy()  # 转换为 HWC 格式
#         img = (img * np.array([0.229, 0.224, 0.225]) + np.array([0.485, 0.456, 0.406])) * 255
#         img = img.astype(np.uint8)
#         axes[i].imshow(img)
#         axes[i].axis('off')
#     plt.show()

# # 调用可视化函数
# visualize_augmented_data(train_dataset)