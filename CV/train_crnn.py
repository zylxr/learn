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
from SVHN_ModelCRNN import SVHN_Model

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

        if self.transform is not None:
            img = self.transform(img)
        
        # 提取文件名（不含路径）
        file_name = os.path.basename(img_path)
        
        # 从字典中获取标签
        label = self.img_json[file_name]['label']  # 获取标签
        
        # 将原始SVHN中类别10映射为数字0
        label = [x if x != 10 else 0 for x in label]
        k = len(label)  # 字符数
        padded_label = label + [-1] * (6 - len(label))  # 填充到6个字符，无效位置为-1
        padded_label = padded_label[:6]  # 确保长度为6
        
        return img, torch.tensor(padded_label), k  # 返回图像、填充后的标签和字符数

    def __len__(self):
        return len(self.img_paths)
    
# 数据增广
data_aug_transform = transforms.Compose([
    transforms.Resize((64, 128)),
    transforms.RandomCrop((64, 128), padding=4,pad_if_needed=True),
    transforms.RandomAffine(degrees=5, translate=(0.1, 0.1), scale=(0.9, 1.1)),
    transforms.ColorJitter(brightness=0.2, contrast=0.2, saturation=0.2),
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
scheduler = torch.optim.lr_scheduler.ReduceLROnPlateau(optimizer, 'min', patience=3, factor=0.5)

# 训练函数
def train(train_loader, model, criterion, optimizer, epoch):
    model.train()
    train_loss = 0.0
    valid_total = 0
    for i, (data, target, k) in enumerate(train_loader):
        data, target, k = data.to(device), target.to(device), k.to(device)
        optimizer.zero_grad()
        outputs,length_logits  = model(data)
        valid_mask = target != -1  # 形状为 (batch, 6)
        valid_outputs = outputs[valid_mask]  # 形状为 (num_valid_samples, 11)
        valid_target  = target[valid_mask]  # 形状为 (num_valid_samples)
         # 字符分类损失（同之前）
        # 字符分类损失
        if valid_outputs.numel() > 0:
            char_loss = criterion(valid_outputs, valid_target)
        else:
            char_loss = 0.0
        
        # 长度预测损失
        length_loss = criterion(length_logits, k.clamp(max=6))  # k是实际长度
        total_loss = char_loss + 0.5 * length_loss  # 加权融合

        # 如果所有损失项都无效，则跳过该批次
        if total_loss == 0:
            logging.warning(f'Epoch {epoch}, Batch {i+1}: All loss terms are invalid, skipping this batch.')
            continue
        total_loss = total_loss / target.size(0)  # 平均损失
        
        total_loss.backward()
        optimizer.step()
        
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
num_epochs = 100

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