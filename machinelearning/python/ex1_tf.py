# linear regreesion（线性回归）
#注意：python版本为3.12.3，
#安装TensorFlow的方法：pip install tensorflow

import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plot
import tensorflow as tf
import numpy as np

df = pd.read_csv('ex1data1.txt',names=['population','profit']) #读取数据并赋予列名

print(df.head(5)) #看前五行

df.info()

# 看下原始数据
sns.lmplot(x='population',y='profit',data=df,height=6,fit_reg=False)
#plot.show()

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

def linear_regression(X_data, y_data, alpha,epoch):
        #placeholder for graph input
    X = tf.placeholder(tf.float32,shape=X_data.shape)
    y = tf.placeholder(tf.float32, shape=y_data.shape)
    optimizer=tf.keras.Optimizer.SGD(learning_rate=alpha,momentum=0.0)
    #construct the graph
    with tf.variable_scope('linear-regression'):
        W = tf.get_variable("weights",
                            (X_data.shape[1],1),
                            initializer=tf.constant_initializer()) #n*1
        y_pred = tf.matmul(X,W) # m*n @n*1->m*1

        loss = 1/(2*len(X_data))*tf.matmul((y_pred-y),(y_pred),transpose_a=True) #(m*1).T@m*1=1*1                    
    opt = optimizer(learning_rate=alpha)
    opt_operation = opt_minimize(loss)

    #run the session
    with tf.Session() as sess:
        sess.run(tf.global_variables_initializer())
        loss_data = []

        for i in range(epoch):
            _,loss_val, W_val = sess.run([opt_operation, loss,W],feed_dict={X:X_data,y:y_data})
            loss_data.append(loss_val[0,0]) # because every loss_val is 1*1 
            
            if len(loss_data) > 1 and np.abs(loss_data[-1]-loss_data[-2])<10 ** -9: #early break when it's converged
                #print ('Converged at epoch {}'.format(i))
                break
    #clear the graph
    tf.reset_default_graph()
    return {'loss':loss_data,'parameters':W_val} #just want to return in row vector format

X=get_X(df)
print(X.shape,type(X))
ones1 = pd.DataFrame({'ones':np.ones(len(df))})
data1 = pd.concat([ones1,df],axis=1)
data2 = data1.iloc[:5,[True,False,True]]
print(data2)