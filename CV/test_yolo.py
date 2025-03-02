import torch
from PIL import Image
import cv2
import numpy as np
import os

# 加载训练好的模型
model = torch.hub.load('ultralytics/yolov5', 'custom', path='./yolov5/yolov5_runs/exp3/weights/best.pt')

# 设置设备
device = torch.device('cuda' if torch.cuda.is_available() else 'cpu')
model.to(device)
model.eval()

# 定义测试图像路径
test_image_dir = 'tcdata/街景识别/'
output_dir = 'prediction_result/'
tsv_file_path = output_dir+'result.tsv'

# 确保输出目录存在
os.makedirs(output_dir, exist_ok=True)
def detect_numbers_in_svhn_image(image_path, model, device="cpu"):
    # 加载图像
    img = Image.open(image_path).convert("RGB")

    # 进行推理
    results = model(img)  # 或者 model([img])

    # 提取数字
    digits = []
    for detection in results.pred[0]:
        x_min, y_min, x_max, y_max, conf, cls = detection[:6]
        if conf > 0.4:
            digits.append(int(cls.item()))
    
    digits = ''.join(map(str, digits))
    return digits
# 打开 TSV 文件以写入结果
with open(tsv_file_path, 'w', encoding='utf-8') as tsv_file:
    # 写入表头
    tsv_file.write("图像名\t识别数字\n")

    # 遍历测试图像
    for image_name in os.listdir(test_image_dir):
        image_path = os.path.join(test_image_dir, image_name)
        
        # 读取图像
        img = cv2.imread(image_path)
        if img is None:
            print(f"无法读取图像: {image_name}")
            continue
        
        img_rgb = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
        
        # 推理
        results = model(img_rgb)
        
        # 提取检测到的数字（假设模型输出中包含类别信息）
        detections = results.pandas().xyxy[0]  # 获取检测结果的 Pandas DataFrame
        detected_numbers = [int(row['class']) for _, row in detections.iterrows()]  # 假设类别索引代表数字
        
        # 如果没有检测到任何数字，默认值为空字符串
        detected_numbers_str = ''.join(map(str, detected_numbers)) if detected_numbers else ""
        
        # 将结果写入 TSV 文件
        tsv_file.write(f"{image_name}\t{detected_numbers_str}\n")
        
        print(f"Processed {image_name}, detected numbers: {detected_numbers_str}")

print(f"所有处理完成，结果已保存到 {tsv_file_path}")