import numpy as np
import matplotlib.pyplot as plt
from sklearn.mixture import GaussianMixture

# 生成模拟数据
np.random.seed(0)
n_samples = 500
C = np.array([[0., -0.7], [3.5, .7]])
X = np.dot(np.random.randn(n_samples, 2), C)

# 创建并训练高斯混合模型
gmm = GaussianMixture(n_components=2, random_state=0)
gmm.fit(X)

# 获取模型参数
means = gmm.means_
covariances = gmm.covariances_
weights = gmm.weights_

# 预测每个数据点的组件
labels = gmm.predict(X)

# 绘制数据点和高斯组件
plt.figure(figsize=(10, 8))
colors = ['blue', 'green']
for i in range(gmm.n_components):
    # 绘制数据点
    plt.scatter(X[labels == i, 0], X[labels == i, 1], color=colors[i], label=f'Component {i+1}')
    
    # 绘制高斯椭圆
    eigenvalues, eigenvectors = np.linalg.eigh(covariances[i])
    angle = np.degrees(np.arctan2(eigenvectors[1, 0], eigenvectors[0, 0]))
    width, height = 2 * np.sqrt(eigenvalues)
    ellipse = plt.matplotlib.patches.Ellipse(means[i], width, height, angle=angle, edgecolor='black', facecolor='none', linestyle='--')
    plt.gca().add_patch(ellipse)

# 添加标题和标签
plt.title('Gaussian Mixture Model')
plt.xlabel('Feature 1')
plt.ylabel('Feature 2')
plt.legend()
plt.show()