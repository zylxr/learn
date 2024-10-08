% 生成示例数据
X = [1, 2; 2, 3; 3, 1; 6, 5; 7, 4; 5, 6];
y = [1; 1; 1; -1; -1; -1];

% 定义高斯核函数
sigma = 1.0;
kernelFunction = @(x, y) exp(-sum((x - y).^2) / (2 * sigma^2));

% 计算核矩阵
K = zeros(size(X, 1), size(X, 1));
for i = 1:size(X, 1)
    for j = 1:size(X, 1)
        K(i, j) = kernelFunction(X(i, :), X(j, :));
    end
end

% 使用 SVM 进行分类
% 假设 svmTrain 是已定义的函数
model = svmTrain(X, y, C=1, kernelFunction)

% 绘制数据点
function plotData1(X, y)
    pos = find(y == 1); % 正类索引
    neg = find(y == -1); % 负类索引
    
    % 绘制数据点
    scatter(X(pos, 1), X(pos, 2), 50, 'MarkerFaceColor', 'b', 'MarkerEdgeColor', 'k');
    hold on;
    scatter(X(neg, 1), X(neg, 2), 50, 'MarkerFaceColor', 'r', 'MarkerEdgeColor', 'k');
    hold off;
    
    % 添加图例
    legend('Positive', 'Negative');
    xlabel('Feature 1');
    ylabel('Feature 2');
end

% 定义 svmPredict 函数
function pred = svmPredict1(model, X)
    % SVMPREDICT returns a vector of predictions using a trained SVM model
    % (svmTrain). 
    %   pred = SVMPREDICT(model, X) returns a vector of predictions using a 
    %   trained SVM model (svmTrain). X is a mxn matrix where there each 
    %   example is a row. model is a svm model returned from svmTrain.
    %   predictions pred is a m x 1 column of predictions of {0, 1} values.
    
    % Check if we are getting a column vector, if so, then assume that we only
    % need to do prediction for a single example
    if (size(X, 2) == 1)
        % Examples should be in rows
        X = X';
    end
    
    % Dataset 
    m = size(X, 1);
    p = zeros(m, 1);
    pred = zeros(m, 1);
    
    if strcmp(func2str(model.kernelFunction), 'linearKernel')
        % We can use the weights and bias directly if working with the 
        % linear kernel
        p = X * model.w + model.b;
    elseif strfind(func2str(model.kernelFunction), 'gaussianKernel')
        % Vectorized RBF Kernel
        % This is equivalent to computing the kernel on every pair of examples
        X1 = sum(X.^2, 2);
        X2 = sum(model.X.^2, 2)';
        K = bsxfun(@plus, X1, bsxfun(@plus, X2, - 2 * X * model.X'));
        K = model.kernelFunction(1, 0) .^ K;
        K = bsxfun(@times, model.y', K);
        K = bsxfun(@times, model.alphas', K);
        p = sum(K, 2);
    else
        % Other Non-linear kernel
        for i = 1:m
            prediction = 0;
            for j = 1:size(model.X, 1)
                prediction = prediction + ...
                    model.alphas(j) * model.y(j) * ...
                    model.kernelFunction(X(i,:)', model.X(j,:)');
            end
            p(i) = prediction + model.b;
        end
    end
    
    % Convert predictions into 0 / 1
    pred(p >= 0) =  1;
    pred(p <  0) =  -1;  % 修改预测值为 {-1, 1}
end

% 定义 plotDecisionBoundary 函数
function plotDecisionBoundary(model, X)
    % 生成网格点
    x1plot = linspace(min(X(:,1)), max(X(:,1)), 100);
    x2plot = linspace(min(X(:,2)), max(X(:,2)), 100);
    [X1, X2] = meshgrid(x1plot, x2plot);
    
    % 计算网格点的预测值
    vals = zeros(size(X1));
    for i = 1:size(X1, 1)
        for j = 1:size(X1, 2)
            x = [X1(i, j), X2(i, j)];
            vals(i, j) = svmPredict1(model, x);  
        end
    end
    
    % 绘制决策边界
    contour(X1, X2, vals, [0 0], 'LineColor', 'b');  % 使用 LineColor 设置线条颜色
end

% 绘制数据点
figure;
plotData1(X, y);

% 绘制决策边界
hold on;
plotDecisionBoundary(model, X);
hold off;