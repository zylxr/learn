import matplotlib.pyplot as plt
import numpy as np
import scipy.io as sio
import matplotlib
import scipy.optimize as opt
from sklearn.metrics import classification_report #这个包是评价报告

def load_data(path ,transpose =True):
    data = sio.loadmat(path)
    y = data.get('y')
    y = y.reshape(y.shape[0])
    
    X = data.get('X')
    
    if transpose:
        X = np.array([im.reshape((20,20)).T for im in X])
        X = np.array([im.reshape(400) for im in X])
        
    return X,y

def plot_an_image(image):
        fig,ax = plt.subplots()
        ax.matshow(image.reshape((20,20)),cmap = matplotlib.cm.binary)
        plt.xticks(np.array([])) # just get rid of ticks
        plt.yticks(np.array([]))
        
X,y = load_data('ex3data1.mat')
print(X.shape)
print(y.shape)

pick_one = np.random.randint(0,5000)
plot_an_image(X[pick_one,:])
plt.show()


def plot_100_image(X):
    size = int(np.sqrt(X.shape[1]))
    sample_idx = np.random.choice(np.arange(X.shape[0]),100)
    sample_images = X[sample_idx,:]
    
    fig,ax_array = plt.subplots(nrows=10, ncols=10,sharey=True,sharex=True,figsize=(8,8))
    for r in range(10):
        for c in range(10):
            ax_array[r,c].matshow(sample_images[10*r+c].reshape((size,size)),cmap=matplotlib.cm.binary)
            
            plt.xticks(np.array([]))
            plt.yticks(np.array([]))
            
plot_100_image(X)
plt.show()

X = np.insert(X,0,values=np.ones(X.shape[0]),axis=1)
y_matrix = []
for k in range(1,11):
    y_matrix.append((y==k).astype(int))
    
y_matrix = [y_matrix[-1]]+y_matrix[:-1]
y=np.array(y_matrix)

def cost(theta, X,y):
    return np.mean(-y * np.log(sigmoid(X@theta))-(1-y)*np.log(1-sigmoid(X@theta)))

def regularized_cost(theta, X,y,l=1):
    theta_j1_to_n = theta[1:]
    regularized_term =(l/(2*len(X))) * np.power(theta_j1_to_n,2).sum()
    return cost(theta,X,y) +regularized_term

def regularized_gradient(theta, X, y, l=1):
    theta_j1_to_n =  theta[1:]
    regularized_theta = (1/len(X)) * theta_j1_to_n
    regularized_term = np.concatenate([np.array([0]), regularized_theta])
    
    return gradient(theta,X,y) + regularized_term

def sigmoid(z):
    return 1/(1+np.exp(-z))

def gradient(theta, X, y):
    return (1/len(X)) * X.T @(sigmoid(X@theta) -y)
            
            

def logistic_regression (X, y, l=1):
    theta = np.zeros(X.shape[1])
    res = opt.minimize(fun=regularized_cost, 
                       x0 = theta,
                       args = (X,y,l),
                       method = 'TNC',
                       jac = regularized_gradient,
                       options={'disp':True})
    final_theta = res.x
    
    return final_theta

def predict(x,theta):
    prob = sigmoid(x@theta)
    return (prob>=0.5).astype(int)

t0 = logistic_regression(X,y[0])
print (t0.shape)
y_pred = predict(X,t0)

print("Accuracy={}".format(np.mean(y[0] == y_pred)))

# train k model（训练k维模型）
k_theta = np.array([logistic_regression(X,y[k]) for k in range(10)])
print(k_theta.shape)

# # 进行预测
# * think about the shape of k_theta, now you are making $X\times\theta^T$
# > $(5000, 401) \times (10, 401).T = (5000, 10)$
# * after that, you run sigmoid to get probabilities and for each row, you find the highest prob as the answer
prob_matrix = sigmoid(X@k_theta.T)
np.set_printoptions(suppress=True)
prob_matrix

y_pred = np.argmax(prob_matrix,axis=1) # 返回沿轴 axis 最大值的索引， axis =1 代表行

y_answer = y.copy()
y_answer[y_answer==10] = 0

#神经网络模型图示
def load_weight(path):
    data = sio.loadmat(path)
    return data['Theta1'],data['Theta2']

theta1, theta2 = load_weight('ex3weights.mat')

X,y = load_data('ex3data1.mat',transpose=False)
X = np.insert(X,0, values= np.ones(X.shape[0]),axis=1)

# feed forward prediction（前馈预测）
a1 = X
z2 = a1 @ theta1.T

z2 = np.insert(z2,0,values = np.ones(z2.shape[0]),axis= 1)

a2 = sigmoid(z2)

z3 =  a2 @theta2.T

a3 = sigmoid(z3)

y_pred =  np.argmax(a3,axis=1)+1
print(y_pred.shape)
print(y.shape)
print(classification_report(y,y_pred))

