import matplotlib.pyplot as plt
import seaborn as sns
sns.set(context="notebook", style="white", palette=sns.color_palette("RdBu"))

import numpy as np
import pandas as pd
import scipy.io as sio
from scipy.optimize import minimize

def cost(params, Y, R, num_features, learning_rate):
    Y = np.matrix(Y)  # (1682, 943)
    R = np.matrix(R)  # (1682, 943)
    num_movies = Y.shape[0]
    num_users = Y.shape[1]
    
    # reshape the parameter array into parameter matrices
    X = np.matrix(np.reshape(params[:num_movies * num_features], (num_movies, num_features)))  # (1682, 10)
    Theta = np.matrix(np.reshape(params[num_movies * num_features:], (num_users, num_features)))  # (943, 10)
    
    # initializations
    J = 0
    X_grad = np.zeros(X.shape)  # (1682, 10)
    Theta_grad = np.zeros(Theta.shape)  # (943, 10)
    
    # compute the cost
    error = np.multiply((X * Theta.T) - Y, R)  # (1682, 943)
    squared_error = np.power(error, 2)  # (1682, 943)
    J = (1. / 2) * np.sum(squared_error)
    
    # add the cost regularization
    J = J + ((learning_rate / 2) * np.sum(np.power(Theta, 2)))
    J = J + ((learning_rate / 2) * np.sum(np.power(X, 2)))
    
    # calculate the gradients with regularization
    X_grad = (error * Theta) + (learning_rate * X)
    Theta_grad = (error.T * X) + (learning_rate * Theta)
    
    # unravel the gradient matrices into a single array
    grad = np.concatenate((np.ravel(X_grad), np.ravel(Theta_grad)))
    
    return J, grad

### 协同过滤
movies_mat = sio.loadmat('./data/ex8_movies.mat')
Y, R = movies_mat.get('Y'), movies_mat.get('R')

print("YShape:{},RShape:{}".format(Y.shape, R.shape))

m, u = Y.shape
# m: how many movies
# u: how many users

n = 10  # how many features for a movie

param_mat = sio.loadmat('./data/ex8_movieParams.mat')
theta, X = param_mat.get('Theta'), param_mat.get('X')

print("theta shape:{},X shape:{}".format(theta.shape, X.shape))

#使用少量数据验证一下
users = 4
movies = 5
features = 3

X_sub = X[:movies, :features]
Theta_sub = theta[:users, :features]
Y_sub = Y[:movies, :users]
R_sub = R[:movies, :users]

params = np.concatenate((np.ravel(X_sub), np.ravel(Theta_sub)))
J,_ = cost(params, Y_sub, R_sub, features,0)
print("cost(params, Y_sub, R_sub, features,0):{}".format(J))
#22.224603725685675

movie_idx = {}
f = open('data/movie_ids.txt',encoding= 'gbk')
for line in f:
    tokens = line.split(' ')
    tokens[-1] = tokens[-1][:-1]
    movie_idx[int(tokens[0]) - 1] = ' '.join(tokens[1:])


ratings = np.zeros((1682, 1))

ratings[0] = 4
ratings[6] = 3
ratings[11] = 5
ratings[53] = 4
ratings[63] = 5
ratings[65] = 3
ratings[68] = 5
ratings[97] = 2
ratings[182] = 4
ratings[225] = 5
ratings[354] = 5

print('Rated {} with {} stars.'.format(movie_idx[0], ratings[0]))
print('Rated {} with {} stars.'.format(movie_idx[6], ratings[6]))
print('Rated {} with {} stars.'.format(movie_idx[11], ratings[11]))
print('Rated {} with {} stars.'.format(movie_idx[53], ratings[53]))
print('Rated {} with {} stars.'.format(movie_idx[63], ratings[63]))
print('Rated {} with {} stars.'.format(movie_idx[65], ratings[65]))
print('Rated {} with {} stars.'.format(movie_idx[68], ratings[68]))
print('Rated {} with {} stars.'.format(movie_idx[97], ratings[97]))
print('Rated {} with {} stars.'.format(movie_idx[182], ratings[182]))
print('Rated {} with {} stars.'.format(movie_idx[225], ratings[225]))
print('Rated {} with {} stars.'.format(movie_idx[354], ratings[354]))


#Rated Toy Story (1995) with 4 stars.
#Rated Twelve Monkeys (1995) with 3 stars.
#Rated Usual Suspects, The (1995) with 5 stars.
#Rated Outbreak (1995) with 4 stars.
#Rated Shawshank Redemption, The (1994) with 5 stars.
#Rated While You Were Sleeping (1995) with 3 stars.
#Rated Forrest Gump (1994) with 5 stars.
#Rated Silence of the Lambs, The (1991) with 2 stars.
#Rated Alien (1979) with 4 stars.
#Rated Die Hard 2 (1990) with 5 stars.
#Rated Sphere (1998) with 5 stars.

R = movies_mat['R']
Y = movies_mat['Y']

Y = np.append(Y, ratings, axis=1)
R = np.append(R, ratings != 0, axis=1)

print("Y.Shape:{}, R.Shape:{},ratings.Shape:{}".format(Y.shape, R.shape, ratings.shape))

print("First Movie Rate:{}".format(Y[1,np.where(R[1,:]==1)[0]].mean()))
#3.2061068702290076


#可视化数据
fig, ax = plt.subplots(figsize=(12,12))
ax.imshow(Y)
ax.set_xlabel('Users')
ax.set_ylabel('Movies')
fig.tight_layout()
plt.show()

movies = Y.shape[0]  # 1682
users = Y.shape[1]  # 944
features = 10
learning_rate = 10.

X = np.random.random(size=(movies, features))
Theta = np.random.random(size=(users, features))
params = np.concatenate((np.ravel(X), np.ravel(Theta)))

print("X.shape:{}, Theta.shape:{}, params.shape:{}".format(X.shape, Theta.shape, params.shape))

#((1682, 10), (944, 10), (26260,))

Ymean = np.zeros((movies, 1))
Ynorm = np.zeros((movies, users))

for i in range(movies):
    idx = np.where(R[i,:] == 1)[0]
    Ymean[i] = Y[i,idx].mean()
    Ynorm[i,idx] = Y[i,idx] - Ymean[i]

print("Ynorm.mean:{},Ymean.mean():{}".format(Ynorm.mean(),Ymean.mean()))
#5.5070364565159845e-19


fmin = minimize(fun=cost, x0=params, args=(Ynorm, R, features, learning_rate), 
                method='CG', jac=True, options={'maxiter': 100})
fmin

X = np.matrix(np.reshape(fmin.x[:movies * features], (movies, features)))
Theta = np.matrix(np.reshape(fmin.x[movies * features:], (users, features)))

print("X.shape:{}, Theta.shape:{}".format(X.shape, Theta.shape))
#((1682, 10), (944, 10))


predictions = X * Theta.T 
my_preds = predictions[:, -1] + Ymean

print("my_preds.shape:{}".format(my_preds.shape))
#(1682, 1)

idx = np.argsort(my_preds, axis=0)[::-1]
print("idx:{},idx shape:{}".format(idx,idx.shape))

print("Top 10 movie predictions:")
for i in range(10):
    print("idx[{}]:{}".format(i,idx[i]))
    j = int(idx[i,0])
    print('Predicted rating of {} for movie {}.'.format(int(my_preds[j,0]), movie_idx[j]))