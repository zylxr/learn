# linear regreesion（线性回归）
#注意：python版本为3.12.3，
#安装TensorFlow的方法：pip install tensorflow

import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plot
import tensorflow as tf
import numpy as np
import datetime
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

import tensorflow as tf
import numpy as np

def linear_regression(X_data, y_data, alpha, epoch, optimizer):
    # Define variables using tf.Variable
    W = tf.Variable(tf.zeros([X_data.shape[1], 1]), name="weights")  # n*1
    
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
        
        loss_data.append(loss_val.numpy()[0, 0])
        
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
