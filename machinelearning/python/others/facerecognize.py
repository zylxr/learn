#人脸检测与特征标注
# 在进行人脸识别之前，你需要下载预训练的人脸检测模型。
# OpenCV提供了一个基于Haar特征的级联分类器，可以直接使用。这里我们使用haarcascade_frontalface_default.xml来检测正面人脸。
#https://github.com/opencv/opencv/blob/master/data/haarcascades/haarcascade_frontalface_default.xml?spm=5176.28103460.0.0.297c5d27rkg2Xv&file=haarcascade_frontalface_default.xml
# 首先确保下载了模型文件，可以从OpenCV的GitHub仓库下载：
import cv2

# 加载人脸检测模型
face_cascade = cv2.CascadeClassifier('haarcascade_frontalface_default.xml')

# 打开录制好的视频文件
video_path = '张三.mp4'
cap = cv2.VideoCapture(video_path)

while True:
    ret, frame = cap.read()
    if not ret:
        break
    
    # 转为灰度图像
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    
    # 检测人脸
    faces = face_cascade.detectMultiScale(gray, scaleFactor=1.1, minNeighbors=5, minSize=(30, 30))
    
    # 绘制人脸框
    for (x, y, w, h) in faces:
        cv2.rectangle(frame, (x, y), (x+w, y+h), (255, 0, 0), 2)
        
        # 标注特征点（简化版，仅示例）
        # 这里假设眼睛在脸的上部三分之一处，嘴巴在下部三分之一处
        eye_y = int(y + h / 3)
        mouth_y = int(y + 2 * h / 3)
        cv2.circle(frame, (x + w // 4, eye_y), 5, (0, 255, 0), -1)  # 左眼
        cv2.circle(frame, (x + 3 * w // 4, eye_y), 5, (0, 255, 0), -1)  # 右眼
        cv2.circle(frame, (x + w // 2, mouth_y), 5, (0, 0, 255), -1)  # 嘴巴
        
        # 如果是自己的脸，可以额外标注
        # 这里需要一个额外的逻辑来确定是否是自己的脸，例如通过面部识别或其他方法
        # 下面是一个简单的示例，实际应用中需要更复杂的面部识别技术
        is_my_face = True  # 这里只是一个示例，实际应用中需要更复杂的逻辑
        if is_my_face:
            cv2.putText(frame, '张三', (x, y - 10), cv2.FONT_HERSHEY_SIMPLEX, 1, (255, 255, 255), 2)
    
    # 显示结果
    cv2.imshow('Face Detection', frame)
    
    # 按q键退出循环
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

# 释放资源
cap.release()
cv2.destroyAllWindows()