#保证先安装了必需的库，如果未安装，使用如下命令：
# pip install opencv-python
import cv2

# 初始化摄像头
cap = cv2.VideoCapture(0)

# 定义编码格式及创建VideoWriter对象
fourcc = cv2.VideoWriter_fourcc(*'mp4v')  # 使用mp4v编解码器
out = cv2.VideoWriter('张三.mp4', fourcc, 20.0, (640, 480))

print("开始录制视频，请将摄像头对准目标...")
# 录制15秒的视频
for _ in range(300):  # 假设每秒20帧，则录制15秒
    ret, frame = cap.read()
    if ret:
        out.write(frame)
    else:
        break

# 释放资源
cap.release()
out.release()
cv2.destroyAllWindows()
print("视频录制完毕")