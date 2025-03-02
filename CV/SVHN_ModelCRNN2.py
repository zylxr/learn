import torch
import torch.nn as nn
import torchvision.models as models
class SVHN_Model(nn.Module):
    def __init__(self):
        super(SVHN_Model, self).__init__()
        resnet = models.resnet18(pretrained=True)
        self.cnn = nn.Sequential(*list(resnet.children())[:-2])  # 移除最后两层
        
        
        # 双向LSTM
        self.rnn = nn.LSTM(
            input_size=128 * 4,  # 输入特征维度需匹配CNN输出
            hidden_size=256,
            num_layers=2,
            bidirectional=True,
            batch_first=True
        )
        # 新增长度预测头
        self.len_fc = nn.Sequential(
            nn.Linear(512, 64),
            nn.ReLU(),
            nn.Linear(64, 7)  # 预测长度0~6
        )
        # 全连接层调整为每个时间步输出11类
        self.fc = nn.Linear(512, 11)  # 双向LSTM的hidden_size*2

    def forward(self, img):
        batch_size = img.size(0)
        # CNN提取特征
        cnn_feat = self.cnn(img)  # 输出形状: (batch, 128, 4, 8)
        
        # 调整维度适应RNN输入 (batch, seq_len, features)
        cnn_feat = cnn_feat.permute(0, 3, 2, 1)  # (batch, width=8, height=4, channels=128)
        cnn_feat = cnn_feat.reshape(batch_size, -1, 512)  #  (batch, seq_len, features)
        
        # RNN处理序列
        rnn_out, _ = self.rnn(cnn_feat)  # 输出形状: (batch, seq_len, hidden_size*2)
        
        # 取前6个时序步作为字符输出
        output = self.fc(rnn_out[:, :6, :])  # 形状变为 (batch, 6, 11)
        
         # 长度预测
        rnn_feat = rnn_out.mean(dim=1)  # 取全局特征，形状 (batch, 512)
        length_logits = self.len_fc(rnn_feat)  # 形状 (batch, 7)
        
        return output,length_logits