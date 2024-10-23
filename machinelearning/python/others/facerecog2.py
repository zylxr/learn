#使用OpenCV和深度学习模型（如Dlib库中的预训练模型）来实现人脸识别的完整示例。
# 我们将使用Dlib库中的预训练模型来提取人脸特征，并使用这些特征来识别特定的人
#pip install opencv-python dlib numpy scikit-learn

# 数据准备
# 确保你的训练数据文件夹结构如下：
# train_directory/
    # 张三/
    #     image1.jpg
    #     image2.jpg
    #     ...
    # 李四/
    #     image1.jpg
    #     image2.jpg
    #     ...
# 确保你的训练数据文件夹结构如下：

import cv2
import dlib
import numpy as np
from sklearn.svm import SVC
from sklearn.preprocessing import LabelEncoder
import os
import matplotlib.pyplot as plt

model_path = r'shape_predictor_68_face_landmarks.dat'
print("Model path:", model_path)

# 尝试使用 os.open 打开文件
try:
    with open(model_path, 'rb') as file:
        # 读取文件的前几个字节以确认文件可以被读取
        content = file.read(10)
        print("File opened successfully. First 10 bytes:", content)
except IOError as e:
    print("Error opening file:", e)
    exit(1)  # 退出程序，因为文件无法打开

# 初始化人脸检测器和特征提取器
detector = dlib.get_frontal_face_detector()
try:
    # 初始化形状预测器
    sp = dlib.shape_predictor(model_path)
    print("Shape predictor loaded successfully.")
except Exception as e:
    print("Error loading shape predictor:", e)
facerec = dlib.face_recognition_model_v1('dlib_face_recognition_resnet_model_v1.dat')

# 准备训练数据
def load_faces_from_directory(directory):
    labels = []
    features = []
    for label in os.listdir(directory):
        label_dir = os.path.join(directory, label)
        if os.path.isdir(label_dir):
            for filename in os.listdir(label_dir):
                img_path = os.path.join(label_dir, filename)
                img = cv2.imread(img_path)
                gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
                faces = detector(gray)
                if len(faces) > 0:
                    shape = sp(gray, faces[0])
                    face_descriptor = facerec.compute_face_descriptor(img, shape)
                    features.append(face_descriptor)
                    labels.append(label)
    return features, labels

# 加载训练数据
train_dir = './traindata/'
features, labels = load_faces_from_directory(train_dir)

# 打印部分数据以检查
print("Features (前5个):")
for feature in features[:5]:
    print(feature)

print("\nLabels (前5个):")
print(labels[:5])

# 可视化部分特征向量
fig, axes = plt.subplots(nrows=2, ncols=5, figsize=(15, 6))
for ax, feature in zip(axes.flatten(), features[:10]):
    ax.plot(feature)
    ax.set_title('Feature Vector')
plt.tight_layout()
plt.show()

# 可视化标签分布
plt.figure(figsize=(10, 5))
plt.hist(labels, bins=len(set(labels)), edgecolor='black')
plt.xlabel('Label')
plt.ylabel('Frequency')
plt.title('Label Distribution')
plt.show()

# 将标签转换为数字
le = LabelEncoder()
labels = le.fit_transform(labels)
print(labels)

# 训练SVM分类器
clf = SVC(kernel='linear', probability=True)
clf.fit(features, labels)


# 识别特定的人
def recognize_face(image, clf, le):
    gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    faces = detector(gray)
    for face in faces:
        shape = sp(gray, face)
        face_descriptor = facerec.compute_face_descriptor(image, shape)
        face_descriptor = np.array(face_descriptor).reshape(1, -1)
        pred_label = clf.predict(face_descriptor)
        pred_prob = clf.predict_proba(face_descriptor)
        confidence = pred_prob[0][pred_label[0]]
        
        # 绘制人脸框和标签
        x, y, w, h = face.left(), face.top(), face.width(), face.height()
        cv2.rectangle(image, (x, y), (x + w, y + h), (255, 0, 0), 2)
        name = le.inverse_transform(pred_label)[0]
        cv2.putText(image, f'{name} ({confidence:.2f})', (x, y - 10), cv2.FONT_HERSHEY_SIMPLEX, 0.9, (255, 255, 255), 2)

    return image

# 测试识别功能
test_image_path = 'songjiang.jpg'
test_image = cv2.imread(test_image_path)
recognized_image = recognize_face(test_image, clf, le)
cv2.imshow('Recognized Face', recognized_image)
cv2.waitKey(0)
cv2.destroyAllWindows()