from pathlib import Path
import yaml
from utils.general import check_requirements, increment_path
from train import run

# Step 1: 定义数据集配置文件 (data.yaml)
data_yaml = {
    'train': '../input/images/train/',  # 训练集图像路径
    'val': '../input/images/val/',      # 验证集图像路径
    'nc': 10,                          # 类别数量
    'names': ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9']  # 类别名称
}

# 将数据配置保存为 YAML 文件
data_yaml_path = 'data.yaml'
with open(data_yaml_path, 'w') as f:
    yaml.dump(data_yaml, f)

# Step 2: 设置训练参数
project_name = 'yolov5_runs'  # 项目目录
experiment_name = 'exp'       # 实验名称
weights = 'yolov5s.pt'        # 预训练权重文件
epochs = 50                   # 训练轮数
batch_size = 16               # 批量大小
imgsz = 640                   # 输入图像尺寸
device = 'cuda:0'               # 使用 GPU ('cpu' 表示 CPU)

# Step 3: 创建保存结果的目录
save_dir = increment_path(Path(project_name) / experiment_name, exist_ok=False)
save_dir.mkdir(parents=True, exist_ok=True)

# Step 4: 检查依赖项
check_requirements(exclude=('tensorboard', 'thop'))

# Step 5: 启动训练
run(
    data=data_yaml_path,          # 数据配置文件路径
    weights=weights,              # 权重文件路径
    epochs=epochs,                # 训练轮数
    batch_size=batch_size,        # 批量大小
    imgsz=imgsz,                  # 图像尺寸
    device=device,                # 使用的设备
    project=project_name,         # 项目目录
    name=experiment_name,         # 实验名称
    exist_ok=False,                # 是否覆盖已有实验
    workers=0,  # 减少多进程数量
    pin_memory=False,
    accumulate=4  # 梯度累积步数
)

print(f"Training completed. Results saved in {save_dir}")