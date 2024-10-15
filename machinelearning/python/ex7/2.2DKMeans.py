import matplotlib.pyplot as plt
import seaborn as sns

import numpy as np
import pandas as pd
import scipy.io as sio

from sklearn.cluster import KMeans

def random_init(x,k):
    m = x.shape[0]
    idx = np.random.choice(m,k,replace=False) # 默认 replace=True, 表示一旦某个元素被选择之后，还可以放回并可能被再次选择，故导致重复选择。replace=False，排除重复选择索引
    return x.iloc[idx].values
mat = sio.loadmat('./data/ex7data2.mat')
data2 = pd.DataFrame(mat.get('X'), columns=['X1', 'X2'])
sns.lmplot(x='X1', y='X2', data=data2, fit_reg=False)

#random init centroids
init_centroids =random_init(data2, 3)
init_centroids

#测试
x = np.array([1, 1])
fig, ax = plt.subplots(figsize=(6,4))
ax.scatter(init_centroids[:, 0], init_centroids[:, 1])

for i, node in enumerate(init_centroids):
    ax.annotate('{}: ({},{})'.format(i, node[0], node[1]), node)
    
ax.scatter(x[0], x[1], marker='x', s=200)
plt.show()

#使用 sklearn kmeans
sk_kmeans = KMeans(n_clusters=3, init=init_centroids, n_init=1)
sk_kmeans.fit(data2)
sk_C = sk_kmeans.predict(data2)
print("Cluster Labels:\n", sk_C)

# 将预测结果添加到数据框中
data2['Cluster'] = sk_C

# 绘制带有颜色标识的簇
plt.figure(figsize=(8, 6))
sns.scatterplot(x='X1', y='X2', hue='Cluster', data=data2, palette='viridis', s=100)
plt.scatter(sk_kmeans.cluster_centers_[:, 0], sk_kmeans.cluster_centers_[:, 1], c='red', marker='X', s=200, label='Centroids')
plt.title('K-Means Clustering')
plt.xlabel('X1')
plt.ylabel('X2')
plt.legend()
plt.show()


#手动迭代
def find_closest_centroids(X, centroids):
    """为每个样本找到最近的质心"""
    m = X.shape[0]
    k = centroids.shape[0]
    idx = np.zeros(m, dtype=int)
    
    for i in range(m):
        min_dist = float('inf')
        for j in range(k):
            dist = np.sum((X[i] - centroids[j]) ** 2)
            if dist < min_dist:
                min_dist = dist
                idx[i] = j
    return idx

def compute_centroids(X, idx, k):
    """基于当前的样本分配计算新的质心"""
    m, n = X.shape
    centroids = np.zeros((k, n))
    
    for i in range(k):
        points_in_cluster = X[idx == i]
        centroids[i] = np.mean(points_in_cluster, axis=0)
    return centroids



mat = sio.loadmat('./data/ex7data2.mat')
data22 = pd.DataFrame(mat.get('X'), columns=['X1', 'X2'])
init_centroids =random_init(data22, 3)
# 记录质心的历史位置
centroid_history = [init_centroids]
# 执行 K-means 迭代
centroids = init_centroids.copy()
for iteration in range(10):
    print(f"Iteration {iteration + 1}")
    idx = find_closest_centroids(data22.values, centroids)
    centroids = compute_centroids(data22.values, idx, 3)
    centroid_history.append(centroids.copy())
    print("Updated Centroids:\n", centroids)

# 将预测结果添加到数据框中
data22['Cluster'] = idx

# 绘制带有颜色标识的簇
plt.figure(figsize=(8, 6))
sns.scatterplot(x='X1', y='X2', hue='Cluster', data=data22, palette='viridis', s=100)
# 绘制质心移动轨迹
colors = ['r', 'g', 'b']
for i in range(len(centroid_history) - 1):
    for j in range(3):  # 假设我们有3个质心
        plt.plot(
            [centroid_history[i][j][0], centroid_history[i + 1][j][0]],
            [centroid_history[i][j][1], centroid_history[i + 1][j][1]],
            color=colors[j],
            linestyle='--',
            marker='o'
        )

# 绘制最终质心位置
final_centroids = centroid_history[-1]
plt.scatter(final_centroids[:, 0], final_centroids[:, 1], c='black', marker='X', s=200, label='Final Centroids')
plt.title('K-Means Clustering')
plt.xlabel('X1')
plt.ylabel('X2')
plt.legend()
plt.show()