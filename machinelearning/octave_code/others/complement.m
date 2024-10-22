% 创建一个示例图像
I = uint8([50, 100, 150; 200, 250, 255; 0, 50, 100]);

% 计算补图像
J = 255 - I;

% 显示原始图像和补图像
figure;
subplot(1, 2, 1);
imshow(I);
title('Original Image');

subplot(1, 2, 2);
imshow(J);
title('Complement Image');