import seaborn as sns
import pandas as pd
import scipy.io as sio
import matplotlib.pyplot as plt

mat = sio.loadmat('./data/ex7data1.mat')
mat.keys()

data1 = pd.DataFrame(mat.get('X'), columns=['X1', 'X2'])
data1.head()

sns.set(context="notebook", style="white")

sns.lmplot(x='X1', y='X2', data=data1, fit_reg=False)
plt.show()

mat = sio.loadmat('./data/ex7data2.mat')
data2 = pd.DataFrame(mat.get('X'), columns=['X1', 'X2'])
data2.head()

sns.lmplot(x='X1', y='X2', data=data2, fit_reg=False)
plt.show()