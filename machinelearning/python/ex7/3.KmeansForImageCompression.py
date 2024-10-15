import matplotlib.pyplot as plt
import seaborn as sns

import numpy as np
import pandas as pd
from skimage import io  # 需要安装scikit-image，执行： pip install scikit-image
from sklearn.cluster import KMeans
from sklearn.decomposition import PCA
from sklearn.preprocessing import StandardScaler


# 加载图片并将其像素值归一化到 [0, 1] 范围
pic = io.imread('data/bird_small.png') / 255.

# 使用 imshow 函数显示图片
io.imshow(pic)

# 必须调用 show 函数来展示窗口
io.show()

# serialize data
data = pic.reshape(128*128, 3)

model = KMeans(n_clusters=16, n_init=100)
model.fit(data)

centroids = model.cluster_centers_
print(centroids.shape)

C = model.predict(data)
print(C.shape)
centroids[C].shape
#(16, 3)
#(16384,)
#(16384, 3)

compressed_pic = centroids[C].reshape((128,128,3))
fig, ax = plt.subplots(1, 2)
ax[0].imshow(pic)
ax[1].imshow(compressed_pic)
plt.show()

#绘图 3D & 2D
K=16
# Setup Color Palette
palette = plt.get_cmap('hsv')(np.linspace(0, 1, K))
colors = palette[C]

# Visualize the data and centroid memberships in 3D
fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')
ax.scatter(data[:, 0], data[:, 1], data[:, 2], c=colors, s=10)
ax.set_title('Pixel dataset plotted in 3D. Color shows centroid memberships')
plt.show()

# Plot in 2D
# Subtract the mean to use PCA
scaler = StandardScaler()
X_norm = scaler.fit_transform(data)

# PCA and project the data to 2D
pca = PCA(n_components=2)
Z = pca.fit_transform(X_norm)
plt.figure()
for i in range(K):
    plt.scatter(Z[(C == i), 0], Z[(C == i), 1], color=palette[i], label=f'Centroid {i}')
plt.legend()
plt.title('PCA Projection of Pixel Dataset to 2D')
plt.show()