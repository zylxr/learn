import json
import os
import argparse
from PIL import Image  # 使用 Pillow 获取图像尺寸

def convert_json_to_yolo(json_file_path, output_base_dir, split_type):
    """
    将 JSON 标注文件转换为 YOLO 格式的标注文件，并动态获取图像尺寸。

    参数:
        json_file_path (str): 输入的 JSON 标注文件路径。
        output_base_dir (str): 输出的基本目录（train 或 val 的父目录）。
        split_type (str): 数据集类型，"train" 或 "val"。
    """
    # 确保输出目录存在
    output_dir = os.path.join(output_base_dir, split_type)
    os.makedirs(output_dir, exist_ok=True)

    # 加载 JSON 文件
    with open(json_file_path, 'r') as f:
        annotations = json.load(f)

    # 遍历每个图像的标注
    for image_name, annotation in annotations.items():
        # 动态获取图像尺寸
        image_path = os.path.join(IMAGE_ROOT, image_name)  # 假设图像存储在 images/train/ 或 images/val/ 目录下
        try:
            with Image.open(image_path) as img:
                image_width, image_height = img.size
        except FileNotFoundError:
            print(f"Warning: Image file {image_path} not found. Skipping this annotation.")
            continue

        label_filename = os.path.splitext(image_name)[0] + '.txt'  # 生成对应的 .txt 文件名
        label_filepath = os.path.join(output_dir, label_filename)
        
        with open(label_filepath, 'w') as label_file:
            for i in range(len(annotation['label'])):  # 遍历每个目标框
                class_id = annotation['label'][i]  # 类别索引从 0 开始
                left = annotation['left'][i]
                top = annotation['top'][i]
                width = annotation['width'][i]
                height = annotation['height'][i]
                
                # 计算归一化坐标
                x_center = (left + width / 2) / image_width
                y_center = (top + height / 2) / image_height
                width_norm = width / image_width
                height_norm = height / image_height
                
                # 写入 YOLO 格式
                line = f"{class_id} {x_center:.6f} {y_center:.6f} {width_norm:.6f} {height_norm:.6f}\n"
                label_file.write(line)

    print(f"JSON to YOLO conversion completed for {split_type} set!")

if __name__ == "__main__":
    # 创建命令行参数解析器
    parser = argparse.ArgumentParser(description="Convert JSON annotations to YOLO format with dynamic image size.")
    
    # 添加命令行参数
    parser.add_argument("--json_file", type=str, required=True, help="Path to the input JSON annotation file.")
    parser.add_argument("--output_dir", type=str, required=True, help="Base directory for output labels (e.g., 'labels/').")
    parser.add_argument("--split", type=str, choices=["train", "val"], required=True, help="Dataset split type: 'train' or 'val'.")
    parser.add_argument("--image_root", type=str, default="images", help="Root directory where images are stored.")

    # 解析命令行参数
    args = parser.parse_args()

    # 更新图像路径前缀
    IMAGE_ROOT = args.image_root

    # 调用转换函数
    convert_json_to_yolo(
        json_file_path=args.json_file,
        output_base_dir=args.output_dir,
        split_type=args.split
    )