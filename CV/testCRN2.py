import os
import glob
import torch
from PIL import Image
import torch.nn as nn
from torch.utils.data import Dataset, DataLoader
import torchvision.transforms as transforms
import logging
from SVHN_ModelCRNN2 import SVHN_Model

# 配置日志
logging.basicConfig(level=logging.INFO, format='[%(asctime)s] - [%(levelname)s] - %(message)s')
device = torch.device("cuda" if torch.cuda.is_available() else "cpu")

# 数据预处理，与训练时一致，但去掉数据增强（test时不使用随机变换）
test_transform = transforms.Compose([
    transforms.Resize((64, 128)),
    transforms.ToTensor(),
    transforms.Normalize([0.485, 0.456, 0.406], [0.229, 0.224, 0.225])
])

class TestDataset(Dataset):
    def __init__(self, img_path, transform=None):
        self.img_path = img_path
        self.transform = transform

    def __getitem__(self, index):
        img = Image.open(self.img_path[index]).convert('RGB')
        if self.transform is not None:
            img = self.transform(img)
        return img

    def __len__(self):
        return len(self.img_path)

# 创建结果保存目录
os.makedirs('prediction_result', exist_ok=True)

def main():
    # 加载测试数据
    test_path = glob.glob('tcdata/街景识别/*.png')
    test_path.sort()
    test_dataset = TestDataset(test_path, test_transform)
    test_loader = DataLoader(
        test_dataset,
        batch_size=10,
        shuffle=False,
        num_workers=4
    )

    # 加载模型
    model = SVHN_Model().to(device)  # 将模型移动到 GPU
    model.load_state_dict(torch.load('./user_data/model_data/model_best.pt', map_location=device))
    model.eval()  # 设置模型为评估模式

    # 预测并保存结果
    def predict(model, test_loader, test_path):
        result = []
        with torch.no_grad():  # 禁用梯度计算
            for i, (input_data) in enumerate(test_loader):
                input_data = input_data.to(device)  # 将数据移动到 GPU
                outputs, length_logits = model(input_data)  # 模型返回 (output, length_logits)
                
                # 获取字符预测结果
                char_preds = outputs.argmax(dim=-1).cpu().numpy()  # (batch_size, 6)
                
                # 获取长度预测结果
                pred_lengths = length_logits.argmax(dim=-1).cpu().numpy()  # (batch_size)
                
                # 批量处理输出
                for j in range(input_data.size(0)):
                    # 根据预测的长度裁剪字符
                    pred_length = pred_lengths[j]
                    pred_chars = char_preds[j, :pred_length]
                    
                    # 将类别10替换为0
                    pred_chars[pred_chars == 10] = 0
                    
                    # 转换为字符串
                    pred_label = ''.join(map(str, pred_chars))
                    
                    # 添加到结果列表
                    result.append([os.path.basename(test_path[i*10 + j]), pred_label])
                logging.info(f'Testing Batch {i+1}/{len(test_loader)}')
        # 保存结果到文件
        with open('prediction_result/result.tsv', 'w') as f:
            for line in result:
                f.write(f"{line[0]}\t{line[1]}\n")
        logging.info(f'Test Completed! Results saved to prediction_result/result.tsv')

    predict(model, test_loader, test_path)

if __name__ == '__main__':
    main()