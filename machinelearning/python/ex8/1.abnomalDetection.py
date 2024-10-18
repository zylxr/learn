import matplotlib.pyplot as plt
import seaborn as sns
sns.set(context="notebook", style="white", palette=sns.color_palette("RdBu"))

import numpy as np
import pandas as pd
import scipy.io as sio
from scipy import stats

def estimate_gaussian(X):
    """Estimate parameters of a Gaussian distribution."""
    mu = np.mean(X, axis=0)
    sigma2 = np.var(X, axis=0, ddof=0)  # Population variance (unbiased=False)
    return mu, sigma2

def multivariate_gaussian(X, mu, sigma2):
    """Compute the probability density function of the multivariate Gaussian distribution."""
    sigma2_matrix = np.diag(sigma2)  # Convert variances into a diagonal covariance matrix
    rv = stats.multivariate_normal(mean=mu, cov=sigma2_matrix)
    p = rv.pdf(X)
    return p

def select_threshold(pval, yval):
    best_epsilon = 0
    best_f1 = 0
    f1 = 0
    step = (pval.max() - pval.min()) / 1000
    for epsilon in np.arange(pval.min(), pval.max()+step, step):# np.arange 方法不包括上界，故要包含上界，需要适当扩展上界
        preds = (pval < epsilon).astype(int)  # 将布尔值转换为整数（0 和 1）
        preds = preds[:, np.newaxis]  # 将 preds 转换为 (n, 1) 形状的数组

        tp = np.sum(np.logical_and(preds == 1, yval == 1)).astype(float)
        fp = np.sum(np.logical_and(preds == 1, yval == 0)).astype(float)
        fn = np.sum(np.logical_and(preds == 0, yval == 1)).astype(float)
        
        print("tp:{},yval:{},preds:{},predsshape:{},yvalshape:{}".format(tp,np.sum(yval==1),np.sum(preds==0),preds.shape,yval.shape))

        # 防止除以零的情况
        if (tp + fp) == 0 or (tp + fn) == 0:
            print("tp + fp:{},tp + fn:{}".format(tp + fp,tp + fn))            
            continue
        
        precision = tp / (tp + fp)
        recall = tp / (tp + fn)
        
        f1 = (2 * precision * recall) / (precision + recall)
     
        if f1 > best_f1:
            best_f1 = f1
            best_epsilon = epsilon
    
    return best_epsilon, best_f1


mat = sio.loadmat('./data/ex8data1.mat')
mat.keys()
X = mat.get('X')

Xval = mat['Xval']
yval = mat['yval']

Xval.shape, yval.shape

sns.regplot(x='Latency', y='Throughput',
           data=pd.DataFrame(X, columns=['Latency', 'Throughput']), 
           fit_reg=False,
           scatter_kws={"s":20,
                        "alpha":0.5})
plt.show()


# estimate multivariate Gaussian parameters $\mu$ and $\sigma^2$
#> according to data, X1, and X2 is not independent

mu = X.mean(axis=0)
print(mu, '\n')

cov = np.cov(X.T)
print(cov)

#协方差的另一种计算方式
X_norm = X-mu
conv1 = np.dot(X_norm.T, X_norm)/X_norm.shape[0]
print(conv1)


#[ 14.11222578  14.99771051] 

#[[ 1.83862041 -0.22786456]
# [-0.22786456  1.71533273]]

#[[ 1.83862041 -0.22786456]
# [-0.22786456  1.71533273]]

# example of creating 2d grid to calculate probability density


mu, sigma2 = estimate_gaussian(X)
print("mu:{},sigma:{}".format(mu, sigma2))
# 创建网格数据
X1, X2 = np.meshgrid(np.arange(0, 35.5, 0.5), np.arange(0, 35.5, 0.5))

# 将网格数据展平并计算高斯分布的概率密度
positions = np.vstack([X1.ravel(), X2.ravel()])
rv = stats.multivariate_normal(mu, cov)
Z = rv.pdf(positions.T)

# 将 Z 重新调整为与 X1 和 X2 相同的形状
Z = Z.reshape(X1.shape)

# 绘制散点图
plt.plot(X[:, 0], X[:, 1], 'bx')

# 如果 Z 中没有无穷大值，则绘制等高线图
if not np.any(np.isinf(Z)):
    # 使用 logspace 生成等比序列
    levels = np.logspace(-20, 0, num=(0 - (-20)) // 3 + 1)
    plt.contour(X1, X2, Z, levels=levels)

# 设置图形界限，确保等高线不会与坐标轴相交
plt.xlim(X1.min(), X1.max())
plt.ylim(X2.min(), X2.max())

plt.xlabel('X1')
plt.ylabel('X2')
plt.title('Contour Plot')
plt.show()


# select threshold $\epsilon$
#1. use training set $X$ to model the multivariate Gaussian
#2. use cross validation set $(Xval, yval)$ to find the best $\epsilon$ by finding the best `F-score`

# 计算训练集的概率密度函数值
p = multivariate_gaussian(X, mu, sigma2)

# 计算交叉验证集的概率密度函数值
pval = multivariate_gaussian(Xval, mu, sigma2)
print(pval)

print("p:{}".format(p.shape))
print("pval:{},pval-max:{},pval-min:{}".format(pval.shape,max(pval),min(pval)))

epsilon, f1 = select_threshold(pval, yval)
print("Epsilon:{},F1:{}".format(epsilon, f1))

# indexes of the values considered to be outliers
outliers = np.where(p < epsilon)
print(outliers)

fig, ax = plt.subplots(figsize=(12,8))
ax.scatter(X[:,0], X[:,1],color='b')
ax.scatter(X[outliers[0],0], X[outliers[0],1], s=50, color='r', marker='x')
plt.show()
