import matplotlib.pyplot as plt
import seaborn as sns
sns.set(context="notebook", style="white")

import numpy as np
import pandas as pd
import scipy.io as sio

def pca(X):
    # normalize the features
    X = (X - X.mean()) / X.std()
    
    # compute the covariance matrix
    X = np.matrix(X)
    cov = (X.T * X) / X.shape[0]
    
    # perform SVD
    U, S, V = np.linalg.svd(cov)
    
    return U, S, V
def normalize(x):
    return (x-x.mean())/x.std()

def project_data(X, U, k):
    U_reduced = U[:,:k]
    return np.dot(X, U_reduced)

def recover_data(Z, U, k):
    U_reduced = U[:,:k]
    return np.dot(Z, U_reduced.T)
def plot_n_image(X, n):
    """ plot first n images
    n has to be a square number
    """
    pic_size = int(np.sqrt(X.shape[1]))
    grid_size = int(np.sqrt(n))

    first_n_images = X[:n, :]

    fig, ax_array = plt.subplots(nrows=grid_size, ncols=grid_size,
                                    sharey=True, sharex=True, figsize=(8, 8))

    for r in range(grid_size):
        for c in range(grid_size):
            ax_array[r, c].imshow(first_n_images[grid_size * r + c].reshape((pic_size, pic_size)))
            plt.xticks(np.array([]))
            plt.yticks(np.array([]))

mat = sio.loadmat('./data/ex7faces.mat')
print(mat.keys())

X = np.array([x.reshape((32, 32)).T.reshape(1024) for x in mat.get('X')])
print(X.shape)
plot_n_image(X, n=64)
plt.show()

U, _, _ = pca(X)

print(U.shape)
plot_n_image(U, n=36)
plt.show()

Z = project_data(X, U, k=100)
plot_n_image(Z, n=64)
plt.show()

# recover from `k=100`
#you lost some detail, but.. they are strikingly similar
X_recover = recover_data(Z, U,100)
plot_n_image(X_recover, n=64)
plt.show()

# sklearn pca
from sklearn.decomposition import PCA
sk_pca = PCA(n_components=100)
Z = sk_pca.fit_transform(X)
print("sklearn Z:",Z.shape)
plot_n_image(Z, 64)
plt.show()

X_recover = sk_pca.inverse_transform(Z)
X_recover.shape

plot_n_image(X_recover, n=64)
plt.show()