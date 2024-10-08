function visualizeBoundary(X, y, model, varargin)
%VISUALIZEBOUNDARY plots a non-linear decision boundary learned by the SVM
%   VISUALIZEBOUNDARYLINEAR(X, y, model) plots a non-linear decision 
%   boundary learned by the SVM and overlays the data on it

% Plot the training data on top of the boundary
plotData(X, y)

% Make classification predictions over a grid of values
x1plot = linspace(min(X(:,1)), max(X(:,1)), 100)';
x2plot = linspace(min(X(:,2)), max(X(:,2)), 100)';
[X1, X2] = meshgrid(x1plot, x2plot);
vals = zeros(size(X1));
for i = 1:size(X1, 2)
   this_X = [X1(:, i), X2(:, i)];
   vals(:, i) = svmPredict(model, this_X);
end

% Plot the SVM boundary
hold on
% 使用 [-0.001, 0.001] 的目的是为了捕捉接近于 0 的等高线。由于浮点数的精度问题，
% vals 矩阵中的值可能不会恰好等于 0，而是非常接近 0。
% 通过指定一个小范围 [-0.001, 0.001]，你可以确保绘制出这些接近于 0 的等高线。
contour(X1, X2, vals, [-0.001, 0.001], 'LineColor', 'b');
hold off;

end
