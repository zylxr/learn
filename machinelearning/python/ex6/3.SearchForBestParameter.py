from sklearn import svm
from sklearn.model_selection import GridSearchCV
from sklearn import metrics
from sklearn.svm import SVC

import numpy as np
import pandas as pd
import scipy.io as sio

#load data
mat = sio.loadmat('./data/ex6data3.mat')
print(mat.keys())


training = pd.DataFrame(mat.get('X'), columns=['X1', 'X2'])
training['y'] = mat.get('y')

cv = pd.DataFrame(mat.get('Xval'), columns=['X1', 'X2'])
cv['y'] = mat.get('yval')

# manual grid search for $C$ and $\sigma$
# http://scikit-learn.org/stable/modules/generated/sklearn.svm.SVC.html#sklearn.svm.SVC

candidate = [0.01, 0.03, 0.1, 0.3, 1, 3, 10, 30, 100]
# gamma to comply with sklearn parameter name
combination = [(C, gamma) for C in candidate for gamma in candidate]
len(combination)

search = []

for C, gamma in combination:
    svc = svm.SVC(C=C, gamma=gamma)
    svc.fit(training[['X1', 'X2']], training['y'])
    search.append(svc.score(cv[['X1', 'X2']], cv['y']))
    
best_score = search[np.argmax(search)]
best_param = combination[np.argmax(search)]

print(best_score, best_param)
#0.965 (0.3, 100)

best_svc = svm.SVC(C=100, gamma=0.3)
best_svc.fit(training[['X1', 'X2']], training['y'])
ypred = best_svc.predict(cv[['X1', 'X2']])

print(metrics.classification_report(cv['y'], ypred))


# sklearn `GridSearchCV`
# http://scikit-learn.org/stable/modules/generated/sklearn.grid_search.GridSearchCV.html#sklearn.grid_search.GridSearchCV

parameters = {'C': candidate, 'gamma': candidate}

# 创建SVC模型实例
svc = svm.SVC()

# 使用GridSearchCV进行交叉验证
clf = GridSearchCV(svc, parameters, n_jobs=-1) #n_jobs=-1 表示使用所有可用的CPU核心
clf.fit(training[['X1', 'X2']], training['y'])

# GridSearchCV(cv=None, error_score='raise',
#        estimator=SVC(C=1.0, cache_size=200, class_weight=None, coef0=0.0,
#   decision_function_shape=None, degree=3, gamma='auto', kernel='rbf',
#   max_iter=-1, probability=False, random_state=None, shrinking=True,
#   tol=0.001, verbose=False),
#        n_jobs=-1,
#        param_grid={'C': [0.01, 0.03, 0.1, 0.3, 1, 3, 10, 30, 100], 'gamma': [0.01, 0.03, 0.1, 0.3, 1, 3, 10, 30, 100]},
#        pre_dispatch='2*n_jobs', refit=True, scoring=None, verbose=0)

print(clf.best_params_)
#{'C': 30, 'gamma': 3}

print(clf.best_score_)
#0.9194905869324475

ypred = clf.predict(cv[['X1', 'X2']])
print(metrics.classification_report(cv['y'], ypred))
