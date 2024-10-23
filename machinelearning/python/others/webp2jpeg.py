from PIL import Image
import sys
import os

def convert_webp_to_jpeg(input_path):
    # 确保输入路径存在
    if not os.path.exists(input_path):
        print("输入的文件路径不存在，请检查后重试。")
        return

    # 获取文件的目录和文件名（不含扩展名）
    directory, filename = os.path.split(input_path)
    filename_without_extension, _ = os.path.splitext(filename)

    # 设置输出文件的路径
    output_path = os.path.join(directory, f"{filename_without_extension}.jpg")

    # 打开 WebP 图像
    try:
        img = Image.open(input_path)
    except IOError:
        print("无法打开图像文件，请确保它是一个有效的 WebP 文件。")
        return

    # 保存为 JPEG
    img.save(output_path, 'JPEG')
    print(f"图像已成功转换并保存为：{output_path}")

if __name__ == "__main__":
    if len(sys.argv) != 2:
        print("请提供一个 WebP 文件路径作为参数。")
    else:
        input_webp_path = sys.argv[1]
        convert_webp_to_jpeg(input_webp_path)