import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns
from scipy.stats import gaussian_kde

# 设置样式
sns.set_theme(style="whitegrid")

# 生成示例数据
np.random.seed(0)
mean1 = [0, 0]  # 第一个分布的均值
cov1 = [[1, 0.5], [0.5, 1]]  # 第一个分布的协方差矩阵
data1 = np.random.multivariate_normal(mean1, cov1, 200)

mean2 = [10, 0]  # 第二个分布的均值
cov2 = [[1, -0.5], [-0.5, 1]]  # 第二个分布的协方差矩阵
data2 = np.random.multivariate_normal(mean2, cov2, 200)

# 组合两个数据集
data = np.vstack([data1, data2])

# 创建网格并绘制以找到拟合双变量正态分布的边界
x, y = np.mgrid[-1:15:.1, -3:3:.1]
positions = np.vstack([x.ravel(), y.ravel()])

# 计算核密度估计
values = np.vstack([data[:, 0], data[:, 1]])
kernel = gaussian_kde(values)
f = np.reshape(kernel(positions).T, x.shape)

# 绘制密度估计图
fig, ax = plt.subplots(figsize=(6, 6))

# 轮廓填充图
ax.contourf(x, y, f, cmap='Blues')

# 绘制数据点
ax.plot(data1[:, 0], data1[:, 1], 'o', markersize=2, color='red', alpha=0.5, label='Data 1')
ax.plot(data2[:, 0], data2[:, 1], 'o', markersize=2, color='green', alpha=0.5, label='Data 2')

# 添加标签和标题
ax.set_xlabel('RA (ms/V)')
ax.set_ylabel('AF ($10^3$kHz)')
ax.set_title('Stage I')

# 添加图例
ax.legend()

# 显示图形
plt.show()