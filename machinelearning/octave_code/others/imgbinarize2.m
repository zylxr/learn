pkg load image;

function BW = adaptive_binarize(I, windowSize)
    % I: 输入的灰度图像
    % windowSize: 局部窗口大小，通常为奇数

    % 检查窗口大小是否合理
    if windowSize > min(size(I))
        error('windowsize should not great than the min size of the image');
    end

    % 边界填充
    padSize = (windowSize - 1) / 2;
    I_padded = padarray(I, [padSize, padSize], 'replicate');

    % 计算局部平均值
    meanImg = ordfilt2(I_padded, ceil((windowSize^2)/2), ones(windowSize));

    % 计算局部标准差
    stdImg = sqrt(ordfilt2(I_padded.^2, ceil((windowSize^2)/2), ones(windowSize)) - meanImg.^2);

    % 移除填充部分
    meanImg = meanImg(padSize+1:end-padSize, padSize+1:end-padSize);
    stdImg = stdImg(padSize+1:end-padSize, padSize+1:end-padSize);

    % 设置阈值，这里使用了一个简单的策略：局部平均值减去 k 倍的标准差
    % k 是一个常数，可以根据实际情况调整
    k = 0.5;
    T = meanImg - k * stdImg;

    % 应用阈值
    BW = I > T;
end



img = imread('test.jpg'); %读取图像
imshow(img);
fprintf('Press any key to convert to gray ,then to binary using global threshhold... \n');
pause;
grayImg = rgb2gray(img); % 转换为 灰度图像
level = graythresh(grayImg); % 使用Otsu 方法计算全局阈值
imgBw = im2bw(grayImg,level); % 使用计算出的阈值将灰度图像转为二值图像
imshow(imgBw); % 显示图像
fprintf('Press any key to close binary image and show inverse image... \n');
pause;
close all;


% 反转处理是指将图像中白色（1）和黑色（0）互换。
% 在 MATLAB 中，可以通过简单的逻辑运算实现反转。
invbw = ~imgBw; % 反转， 0，1 互换
imshow(invbw);%反转后图像
fprintf('press any key to close inverse  binary image.\n');
pause
close all

% 对应 matlab : se = strel('disk', 5);
radius = 5;
[x, y] = meshgrid(-radius:radius, -radius:radius);
se = double(x.^2 + y.^2 <= radius^2);

%膨胀
dilatedImg = imdilate(imgBw, se);

%腐蚀
erodedImg = imerode(imgBw,se);

%开运算
openedImg = imopen(imgBw, se);

 %闭运算
closedImg = imclose(imgBw, se);

% 显示图像
figure;
subplot(2,2,1),imshow(dilatedImg),title('dilation');
subplot(2,2,2),imshow(erodedImg),title('erode');
subplot(2,2,3),imshow(openedImg),title('open');
subplot(2,2,4),imshow(closedImg),title('close');

% 进行标记
[L, num] = bwlabel(imgBw);

% 显示标记结果
imshow(label2rgb(L));
title(['标记的图像, 物体个数: ', num2str(num)]);


% 统计物体个数
stats = regionprops(L, 'Area');
areaCounts = [stats.Area]; % 获取每个物体的面积
disp(['物体个数: ', num2str(num)]);
disp('每个物体的面积:');
disp(areaCounts);

% 在二值图像中，物体占据的像素为 1，背景为 0，因此可以直接统计像素数量

% 显示每个物体的面积
for k = 1:num
 fprintf('物体 %d 的面积为: %.2f 像素\n', k, stats(k).Area);
end

% 计算每个物体的质心
stats = regionprops(L, 'Centroid');
% 显示每个物体的质心
for k = 1:num
 fprintf(' 物 体 %d 的质心坐标为 : (%.2f, %.2f)\n', k, stats(k).Centroid(1), 
stats(k).Centroid(2));
 % 在原图上标记质心
 hold on;
 plot(stats(k).Centroid(1), stats(k).Centroid(2), 'r*', 'MarkerSize', 10);
end
% 显示标记后的图像
title('物体质心标记');
hold off;

