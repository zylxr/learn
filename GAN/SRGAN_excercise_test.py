import math
import torch
from torch import nn


# 生成模型
class Generator(nn.Module):
    def __init__(self, scale_factor):
        upsample_block_num = int(math.log(scale_factor, 2))

        super(Generator, self).__init__()
        # 第一个卷积层，卷积核大小为9×9，输入通道数为3，输出通道数为64
        self.block1 = nn.Sequential(nn.Conv2d(3, 64, kernel_size=9, padding=4),
                                    nn.PReLU())
        # 6个残差模块
        self.block2 = ResidualBlock(64)
        self.block3 = ResidualBlock(64)
        self.block4 = ResidualBlock(64)
        self.block5 = ResidualBlock(64)
        self.block6 = ResidualBlock(64)
        self.block7 = nn.Sequential(
            nn.Conv2d(64, 64, kernel_size=3, padding=1), nn.BatchNorm2d(64))
        # upsample_block_num个上采样模块，每一个上采样模块恢复2倍的上采样倍率
        block8 = [UpsampleBLock(64, 2) for _ in range(upsample_block_num)]
        # 最后一个卷积层，卷积核大小为9×9，输入通道数为64，输出通道数为3
        block8.append(nn.Conv2d(64, 3, kernel_size=9, padding=4))
        self.block8 = nn.Sequential(*block8)

    def forward(self, x):
        block1 = self.block1(x)
        block2 = self.block2(block1)
        block3 = self.block3(block2)
        block4 = self.block4(block3)
        block5 = self.block5(block4)
        block6 = self.block6(block5)
        block7 = self.block7(block6)
        block8 = self.block8(block1 + block7)

        return (torch.tanh(block8) + 1) / 2


# 残差模块
class ResidualBlock(nn.Module):
    def __init__(self, channels):
        super(ResidualBlock, self).__init__()
        # 两个卷积层，卷积核大小为3×3，通道数不变
        self.conv1 = nn.Conv2d(channels, channels, kernel_size=3, padding=1)
        self.bn1 = nn.BatchNorm2d(channels)
        self.prelu = nn.PReLU()
        self.conv2 = nn.Conv2d(channels, channels, kernel_size=3, padding=1)
        self.bn2 = nn.BatchNorm2d(channels)

    def forward(self, x):
        residual = self.conv1(x)
        residual = self.bn1(residual)
        residual = self.prelu(residual)
        residual = self.conv2(residual)
        residual = self.bn2(residual)

        return x + residual


# 上采样模块，每一个恢复分辨率为2
class UpsampleBLock(nn.Module):
    def __init__(self, in_channels, up_scale):
        super(UpsampleBLock, self).__init__()
        # 卷积层，输入通道数为in_channels，输出通道数为in_channels * up_scale ** 2
        self.conv = nn.Conv2d(in_channels,
                              in_channels * up_scale**2,
                              kernel_size=3,
                              padding=1)
        # PixelShuffle上采样层，来自于后上采样结构
        self.pixel_shuffle = nn.PixelShuffle(up_scale)
        self.prelu = nn.PReLU()

    def forward(self, x):
        x = self.conv(x)
        x = self.pixel_shuffle(x)
        x = self.prelu(x)
        return x
    
    
import torch
from PIL import Image
from torch.autograd import Variable
from torchvision.transforms import ToTensor, ToPILImage


UPSCALE_FACTOR = 4 ##上采样倍率
TEST_MODE = True ## 使用GPU进行测试

IMAGE_NAME = "./dataset/val/3.jpg"  # 测试图片路径

MODEL_NAME = './epochs/netG_epoch_4_5.pth' ##模型路径
model = Generator(UPSCALE_FACTOR).eval() ##设置验证模式
if TEST_MODE:
    model.cuda()
    model.load_state_dict(torch.load(MODEL_NAME))
else:
    model.load_state_dict(torch.load(MODEL_NAME, map_location=lambda storage, loc: storage))

image = Image.open(IMAGE_NAME) ##读取图片
#image = image.crop((500, 700, 820, 1020))  # 对于图片，需要确保其大小为 3 通道 320*320 大小，故大的图片需要裁剪才能使用
image = Variable(ToTensor()(image), volatile=True).unsqueeze(0) ##图像预处理
print(image.shape)
if TEST_MODE:
    image = image.cuda()

with torch.no_grad():
    RESULT_NAME = "out_srf_" + str(UPSCALE_FACTOR) + "_" + IMAGE_NAME.split("/")[-1]
    out = model(image)
    out_img = ToPILImage()(out[0].data.cpu())
    out_img.save(RESULT_NAME)
