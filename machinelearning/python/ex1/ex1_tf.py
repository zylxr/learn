# linear regreesion（线性回归）
#注意：python版本为3.12.3，
#安装TensorFlow的方法：pip install tensorflow

import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plot
import tensorflow as tf
import numpy as np
import datetime
from sklearn import linear_model #pip install scikit-learn
import tensorflow as tf

df = pd.read_csv('ex1data1.txt',names=['population','profit']) #读取数据并赋予列名

print(df.head(5)) #看前五行

df.info()

# # 看下原始数据
# sns.lmplot(x='population',y='profit',data=df,height=6,fit_reg=False)
# plot.show()


def get_X(df): #读取特征
# """
# use contact to add intersect feature to avoid side effect
# not efficient for big dataset though
# """
    ones = pd.DataFrame({'ones':np.ones(len(df))}) #ones 是m 行 1 列的 dataframe
    data = pd.concat([ones, df],axis=1) # 合并数据，根据列合并
    return data.iloc[:, :-1].to_numpy() #返回 ndarray,不是矩阵

def get_y(df): #读取标签
#   ''' assume the last column is the target '''
    return np.array(df.iloc[:,-1]) #df.iloc[:,-1] 指df 的最后一列

def normalize_feature(df):
#   """ Applies function along input axis(default 0) of DataFrame """
    return df.apply(lambda column:(column-column.mean())/column.std()) #特征缩放



def linear_regression(X_data, y_data, alpha, epoch, optimizer):
    # Define variables using tf.Variable
    W = tf.Variable(tf.zeros([X_data.shape[1], 1],dtype=tf.float64), name="weights")  # n*1
   
    # Define the prediction and loss functions
    @tf.function
    def compute_loss(X, y, W):
        y_pred = tf.matmul(X, W)
        loss = 1 / (2 * len(X_data)) * tf.reduce_sum(tf.square(y_pred - y))
        return loss
    
    
    # Initialize variables
    loss_data = []
    for i in range(epoch):
        with tf.GradientTape() as tape:
            loss_val = compute_loss(X_data, y_data, W)
        gradients = tape.gradient(loss_val, W)
        optimizer.apply_gradients([(gradients, W)])
        
        loss_data.append(loss_val.numpy())
        
        if len(loss_data) > 1 and np.abs(loss_data[-1] - loss_data[-2]) < 1e-9:  # Early break when it's converged
            break
    
    return {'loss': loss_data, 'parameters': W.numpy().reshape(1, -1)}  # Return in row vector format



def lr_cost(theta, X, y):
# """
# X:R(m*n),m 样本数,n 特征数
# y:R(m)
# theta: R(n),线性回归的参数
# """
    m = X.shape[0]#m为样本数
    inner = X @ theta -y # R(m*1), X@ theta 等价于 X.dot(theta)

    # 1*m @ m*1 = 1*1 in matrix multiplication
    square_sum = inner.T @inner
    cost = square_sum/(2*m)

    return cost

def gradient(theta, X, y):
    m = X.shape[0]
    inner = X.T@(X@theta-y) # (m,n).T @(m,1) ->(n,1), X @ theta 等价于 X.dot(theta)
    return inner/m

#批量梯度下降函数
def batch_gradient_descent(theta, X, y, epoch, alpha=0.01):
#   """
# 拟合线性回归，返回 参数和代价
#   epoch: 批处理的轮数
#   """
    cost_data = [lr_cost(theta,X,y)]
    _theta = theta.copy() #拷贝一份，不和原来的 theta 混淆
    for _ in range(epoch):
        _theta = _theta - alpha * gradient(_theta, X,y)
        cost_data.append(lr_cost(_theta,X,y))
    return _theta,cost_data

data = normalize_feature(df)
X=get_X(data)
y=get_y(data)
theta = np.zeros(X.shape[1]) # X.shape[1]=2,代表特征数 n
jCost = lr_cost(theta,X,y) #
print(f"Cost:{jCost}")

epoch = 500
final_theta, cost_data = batch_gradient_descent(theta,X,y,epoch)
print(f"{final_theta=}\n")
#print(f" {cost_data=} \n")

# #visualize cost data(代价数据可视化)
cdf = pd.DataFrame({
    'epoch':np.arange(epoch+1),
    'cost': cost_data
})
plot.figure(figsize=(10,6))
ax = sns.lineplot(data=cdf, x='epoch',y='cost')
#ax = sns.lineplot(x=cost_data, y=np.arange(epoch+1))
ax.set_xlabel('epoch')
ax.set_ylabel('cost')
plot.show()

b = final_theta[0]; #intercept , Y 轴上的截距
m = final_theta[1]; # slope ,斜率
plot.scatter(df.population,df.profit,label="Training data")
plot.plot(df.population,df.population*m+b,label="Prediction")
plot.legend(loc=2)
plot.show()

# learning rate （学习率）
base = np.logspace(-3,-1,num=4)
candidate = np.sort(np.concatenate((base,base*3)))
epoch = 50
fig,ax = plot.subplots(figsize=(16,9))
for alpha in candidate:
    _,cost_data = batch_gradient_descent(theta,X,y, epoch, alpha=alpha)
    ax.plot(np.arange(epoch+1),cost_data,label=f"{alpha:.2e}")

ax.set_xlabel('epoch',fontsize=18)
ax.set_ylabel('cost',fontsize=18)
ax.legend(bbox_to_anchor=(1.05,1),loc=2,borderaxespad=0.)
ax.set_title('learning rate',fontsize=18)
plot.show()

# normal equation (正规方程)
def normalEqn(X,y):
    theta = np.linalg.inv(X.T@X)@X.T@y #X.T@X 等价于 X.T.dot(X)
    return theta

final_theta2 = normalEqn(X,y)
print(f"{final_theta2=}")

#run the tensor flow graph over several optimizer
# 1. 'GD': tf.keras.optimizers.SGD
#       SGD（随机梯度下降）是最基本的优化算法之一。它通过沿着梯度方向调整权重来最小化损失函数。
#       在传统的批量梯度下降（Batch Gradient Descent）中，每次更新都基于整个训练集的梯度，
#       而在 SGD 中，每次更新通常是基于单个样本（或一个小批量样本）。这种方法有助于快速收敛，但路径可能会比较不稳定。
# 2. 'Adagrad': tf.keras.optimizers.Adagrad
#       Adagrad 是一种自适应学习率的方法，它根据每个参数的历史梯度来调整学习率。
#       随着迭代次数增加，Adagrad 的学习率会逐渐减小，这对稀疏数据集特别有效。然而，学习率的单调递减有时会导致学习过早停止。
# 3. 'Adam': tf.keras.optimizers.Adam
#       Adam（自适应矩估计）结合了 Momentum 和 RMSProp 的优点。它维护了梯度的一阶动量（移动平均）和二阶动量（未经中心化的方差），
#       并且在初始阶段进行偏差校正。Adam 通常能提供较好的收敛性能，并且在实践中表现得非常好。
# 4. 'Ftrl': tf.keras.optimizers.Ftrl
#       FTRL（跟随正则化的领导者）是一种优化算法，特别适合于稀疏数据。它结合了在线凸优化的思想，能够有效地处理大量特征，
#       并且对于稀疏数据集具有良好的表现。FTRL 可以看作是 Adagrad 和 RDA（Regularized Dual Averaging）的组合。
# 5. 'RMS': tf.keras.optimizers.RMSprop
#       RMSprop 是为了改进 Adagrad 的一些缺点而设计的。Adagrad 的学习率随着迭代减少，
#       而 RMSprop 使用了一个滑动窗口的梯度平方的平均值来动态调整学习率。这有助于在梯度稀疏的情况下保持合理的学习率，并且在实践中通常比 Adagrad 更好。
# 每种优化器都有自己的特点和适用场景，选择哪种优化器取决于特定的任务需求、数据特性和模型架构。通常情况下，
# Adam 因为其良好的通用性和较少的超参数调整要求，在很多场景下是一个不错的选择。然而，在某些情况下，
# 其他的优化器可能会有更好的表现，比如对于稀疏数据，Adagrad 或 FTRL 可能更合适。
optimizer_dict = {
    'GD': tf.keras.optimizers.SGD,
    'Adagrad':tf.keras.optimizers.Adagrad,
    'Adam':tf.keras.optimizers.Adam,
    'Ftrl':tf.keras.optimizers.Ftrl,
    'RMS': tf.keras.optimizers.RMSprop
}
results = []
alpha=0.01
X_data = get_X(df)
y_data = get_y(df).reshape(len(X_data),1) # special treatment for tensorflow input data
for name in optimizer_dict:
    optimizer = optimizer_dict[name](learning_rate = alpha)
    res = linear_regression(X_data,y_data,alpha,epoch,optimizer)
    res['name'] = name
    results.append(res)

#画图
fig,ax = plot.subplots(figsize=(16,9))
for res in results:
    loss_data = res['loss']
    ax.plot(np.arange(len(loss_data)),loss_data,label=res['name'])

ax.set_xlabel('epoch',fontsize=18)
ax.set_ylabel('cost',fontsize=18)
ax.legend(bbox_to_anchor=(1.05,1),loc=2,borderaxespad=0.)
ax.set_title('different optimizer',fontsize=18)
plot.show()

#scikit-learn 
model = linear_model.LinearRegression()
model.fit(X,y)

x11 = np.array(X[:,1])
f=model.predict(X).flatten()
fig,ax = plot.subplots(figsize=(12,8))
ax.plot(x11,f,'r',label='Prediction')
ax.scatter(df.population, df.profit,label='Training Data')
ax.legend(loc=2)
ax.set_xlabel('Populcation')
ax.set_ylabel('Profit')
ax.set_title('Predicted Profit vs. Population Size')
plot.show()

#测试 python 代码，与机器学习练习无关
ones1 = pd.DataFrame({'ones':np.ones(len(df))})
data1 = pd.concat([ones1,df],axis=1)
data2 = data1.iloc[:,[True,False,True]]
print(data2)
data2 = data1.iloc[1:5,-1]
print(data2)
print(type(data2))
data3 = df.apply(lambda col:col.mean())
print(data3)
data3 = df.apply(lambda col:col.std())
print(data3)
a1 = np.array([[1,2,3],[4,5,6]])
a2 = np.array([3,4,5])
print(a1*a2)
print(a1@a2)
print(a1.dot(a2))
print(a1.T)
print(a1)
print(a1.T@a1)
