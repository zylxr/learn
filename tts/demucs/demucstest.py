import argparse
from demucs import separate
import torch
def main():
    # 创建 ArgumentParser 对象
    parser = argparse.ArgumentParser(description='Use Demucs to separate audio tracks.')

    # 添加命令行参数
    parser.add_argument('input_file', type=str, help='Path to the input audio file.')
    parser.add_argument('-o', '--output_dir', type=str, default='separated_audio', help='Output directory for separated tracks.')
    parser.add_argument('--device', type=str, default='cuda' if torch.cuda.is_available() else 'cpu', help='Device to use (cpu or cuda).')

    # 解析命令行参数
    args = parser.parse_args()

    # 打印输入参数
    print(f"Input file: {args.input_file}")
    print(f"Output directory: {args.output_dir}")
    print(f"Device: {args.device}")

    # 设置环境变量（可选）
    if args.device == 'cuda':
        import os
        os.environ['CUDA_VISIBLE_DEVICES'] = '0'  # 指定使用第一个 GPU

    # 调用 Demucs 分离函数
    separate.main(['--out', args.output_dir, '--device', args.device, args.input_file])

if __name__ == '__main__':
    main()