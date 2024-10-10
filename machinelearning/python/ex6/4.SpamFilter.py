from sklearn import svm
from sklearn import metrics
from sklearn.linear_model import LogisticRegression

import scipy.io as sio

# I think the hard part is how to vecotrize emails.  
# Using this preprocessed data set is cheating XD

mat_tr = sio.loadmat('data/spamTrain.mat')
mat_tr.keys()

X, y = mat_tr.get('X'), mat_tr.get('y').ravel()
X.shape, y.shape

mat_test = sio.loadmat('data/spamTest.mat')
mat_test.keys()

test_X, test_y = mat_test.get('Xtest'), mat_test.get('ytest').ravel()
test_X.shape, test_y.shape


svc = svm.SVC()
svc.fit(X, y)

pred = svc.predict(test_X)
print(metrics.classification_report(test_y, pred))

#线性回归
logit = LogisticRegression()
logit.fit(X, y)

pred = logit.predict(test_X)
print(metrics.classification_report(test_y, pred))