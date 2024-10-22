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
fprintf('Press any key to show gray image... \n');
pause;
close all;

%如果需要使用自适应阈值，可以使用 adaptthresh 方法
imgData = imread('test.jpg'); 
grayImg = rgb2gray(imgData);
imshow(grayImg);
fprintf('Press any key to binary with local threshhold... \n');
pause;
bw =  adaptive_binarize(grayImg, 31); % 调用自适应二值化函数
fprintf('Press any key to show local binary image... \n');

imshow(bw);
fprintf('Press any key to close local binary image \n');
pause;
close all;

% 反转处理是指将图像中白色（1）和黑色（0）互换。
% 在 MATLAB 中，可以通过简单的逻辑运算实现反转。
invbw = ~bw; % 反转， 0，1 互换
imshow(invbw);%反转后图像
fprintf('press any key to close inverse local binary image.\n');

