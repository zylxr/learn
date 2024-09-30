
function [error_train, error_val] = ...
    randomLearnCurve(X, y, Xval, yval, lambda)
% Number of training examples
m = size(X, 1);

% You need to return these values correctly
error_train = zeros(m, 1);
error_val   = zeros(m, 1);
for k = 1:50
    for i =1:m
        idx =randperm(m,i);
        xsub = X(idx,:);
        ysub = y(idx);
        idxval = randperm(size(Xval,1),i);
        xvalsub = Xval(idxval,:);
        yvalsub = yval(idxval);
        theta = trainLinearReg(xsub,ysub,lambda);
        error_train(i) = linearRegCostFunction(xsub,ysub,theta,0);
        error_val(i) = linearRegCostFunction(xvalsub,yvalsub,theta,0);
    end
end