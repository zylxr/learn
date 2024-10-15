import matplotlib.pyplot as plt
import seaborn as sns

import numpy as np
import pandas as pd
import scipy.io as sio

from sklearn.cluster import KMeans as km

mat = sio.loadmat('./data/ex7data2.mat')
data2 = pd.DataFrame(mat.get('X'), columns=['X1', 'X2'])

#random init centroids
init_centroids = km.random_init(data2, 3)
init_centroids