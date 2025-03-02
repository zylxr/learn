import os, sys, glob, shutil, json
import cv2

from PIL import Image
import numpy as np

import torch
import torch.nn as nn
import torch.optim as optim
from torch.utils.data.dataset import Dataset
import torchvision.transforms as transforms

import logging

# 使用 GPU
device = torch.device("cuda" if torch.cuda.is_available() else "cpu")

# 配置日志
logging.basicConfig(level=logging.INFO, format='[%(asctime)s] - [%(levelname)s] - %(message)s')

class SVHNDataset(Dataset):
    def __init__(self, img_path, img_label, transform=None):
        self.img_path = img_path
        self.img_label = img_label 
        if transform is not None:
            self.transform = transform
        else:
            self.transform = None

    def __getitem__(self, index):
        img = Image.open(self.img_path[index]).convert('RGB')

        if self.transform is not None:
            img = self.transform(img)
        
        # 原始SVHN中类别10为数字0
        lbl = np.array(self.img_label[index], dtype=int)
        lbl = list(lbl)  + (6 - len(lbl)) * [10]
        
        return img, torch.from_numpy(np.array(lbl[:6]))

    def __len__(self):
        return len(self.img_path)
    
data_aug_transform = transforms.Compose([
    transforms.Resize((64, 128)),
    transforms.ColorJitter(0.3, 0.3, 0.2),
    transforms.RandomRotation(5),
    transforms.ToTensor(),
    transforms.Normalize([0.485, 0.456, 0.406], [0.229, 0.224, 0.225])
])

# 加载训练数据
train_path = glob.glob('./input/mchar_train/*.png')
train_path.sort()
train_json = json.load(open('./input/mchar_train.json'))
train_label = [train_json[x]['label'] for x in train_json]
train_dataset = SVHNDataset(train_path, train_label, data_aug_transform)

# 加载验证数据
val_path = glob.glob('./input/mchar_val/*.png')
val_path.sort()
val_json = json.load(open('./input/mchar_val.json'))
val_label = [val_json[x]['label'] for x in val_json]
val_dataset = SVHNDataset(val_path, val_label, data_aug_transform)

# 数据加载器
train_loader = torch.utils.data.DataLoader(
    train_dataset, 
    batch_size=10, # 每批样本个数
    shuffle=True, # 是否打乱顺序
    num_workers=10, # 读取的线程个数
)

val_loader = torch.utils.data.DataLoader(
    val_dataset, 
    batch_size=10, # 每批样本个数
    shuffle=False, # 是否打乱顺序
    num_workers=10, # 读取的线程个数
)

# 定义模型
class SVHN_Model(nn.Module):
    def __init__(self):
        super(SVHN_Model, self).__init__()
        # CNN提取特征模块
        self.cnn = nn.Sequential(
            nn.Conv2d(3, 16, kernel_size=(3, 3), stride=(2, 2)),
            nn.ReLU(),  
            nn.MaxPool2d(2),
            nn.Conv2d(16, 32, kernel_size=(3, 3), stride=(2, 2)),
            nn.ReLU(), 
            nn.MaxPool2d(2),
        )
        # 全连接层
        self.fc1 = nn.Linear(32*3*7, 11)
        self.fc2 = nn.Linear(32*3*7, 11)
        self.fc3 = nn.Linear(32*3*7, 11)
        self.fc4 = nn.Linear(32*3*7, 11)
        self.fc5 = nn.Linear(32*3*7, 11)
        self.fc6 = nn.Linear(32*3*7, 11)
    
    def forward(self, img):        
        feat = self.cnn(img)
        feat = feat.view(feat.shape[0], -1)
        c1 = self.fc1(feat)
        c2 = self.fc2(feat)
        c3 = self.fc3(feat)
        c4 = self.fc4(feat)
        c5 = self.fc5(feat)
        c6 = self.fc6(feat)
        return c1, c2, c3, c4, c5, c6

def train(train_loader, model, criterion, optimizer, epoch):
    # 切换模型为训练模式
    model.train()

    train_loss = 0.0
    for i, (data, target) in enumerate(train_loader):
        data, target = data.to(device), target.to(device)  # 移动数据到 GPU
        logging.info(f'Epoch {epoch}, Batch {i}, Data Shape: {data.shape}, Target Shape: {target.shape}')
        c0, c1, c2, c3, c4, c5 = model(data)
        loss = criterion(c0, target[:, 0]) + \
               criterion(c1, target[:, 1]) + \
               criterion(c2, target[:, 2]) + \
               criterion(c3, target[:, 3]) + \
               criterion(c4, target[:, 4]) + \
               criterion(c5, target[:, 5])
        loss /= 6
        optimizer.zero_grad()
        loss.backward()
        optimizer.step()
        train_loss += loss.item()
    
        # 每10个批次打印一次损失
        if (i+1) % 10 == 0:
            logging.info(f'Epoch {epoch}, Batch {i+1}, Loss: {loss.item():.4f}')
    
    return train_loss / len(train_loader)

def validate(val_loader, model, criterion):
    # 切换模型为预测模型
    model.eval()
    val_loss = []
    correct = 0
    total = 0

    # 不记录模型梯度信息
    with torch.no_grad():
        for i, (data, target) in enumerate(val_loader):
            data, target = data.to(device), target.to(device)  # 移动数据到 GPU
            logging.info(f'Validation Batch {i}, Data Shape: {data.shape}, Target Shape: {target.shape}')
            c0, c1, c2, c3, c4, c5 = model(data)
            loss = criterion(c0, target[:, 0]) + \
                   criterion(c1, target[:, 1]) + \
                   criterion(c2, target[:, 2]) + \
                   criterion(c3, target[:, 3]) + \
                   criterion(c4, target[:, 4]) + \
                   criterion(c5, target[:, 5])
            loss /= 6
            val_loss.append(loss.item())
            # 计算准确率
            _, pred0 = c0.max(1)
            _, pred1 = c1.max(1)
            _, pred2 = c2.max(1)
            _, pred3 = c3.max(1)
            _, pred4 = c4.max(1)
            _, pred5 = c5.max(1)
            pred = torch.stack([pred0, pred1, pred2, pred3, pred4, pred5], dim=1)
            correct += (pred == target).all(dim=1).sum().item()
            total += target.size(0)
        accuracy = correct / total
        logging.info(f'Validation Accuracy: {accuracy * 100:.2f}%')
    
    return np.mean(val_loss), accuracy

model = SVHN_Model()
model.to(device)  # 将模型移动到 GPU

criterion = nn.CrossEntropyLoss(reduction='sum').to(device)  # 使用 GPU
optimizer = optim.Adam(model.parameters(), 0.001)
best_loss = 1000.0

for epoch in range(5):
    logging.info(f'[Epoch {epoch}] Training...')
    train_loss = train(train_loader, model, criterion, optimizer, epoch)
    logging.info(f'[Epoch {epoch}] Training Loss: {train_loss:.4f}')
    
    logging.info(f'[Epoch {epoch}] Validating...')
    val_loss, accuracy = validate(val_loader, model, criterion)
    
    # 保存每轮模型
    torch.save(model.state_dict(), f'./user_data/model_data/model_epoch_{epoch}.pt')
    logging.info(f'[Epoch {epoch}] Saved model for epoch {epoch}: ./user_data/model_data/model_epoch_{epoch}.pt')
    
    # 记录下验证集精度
    if val_loss < best_loss:
        best_loss = val_loss
        torch.save(model.state_dict(), './user_data/model_data/model.pt')
        logging.info(f'[Epoch {epoch}] Saved best model with Val Loss: {val_loss:.4f}, Val Accuracy: {accuracy:.4f}')
    
    logging.info(f'[Epoch {epoch}] Val Loss: {val_loss:.4f}, Val Accuracy: {accuracy:.4f}')