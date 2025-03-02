1. train.py  --  定长6个字符，识别率60%， 且对于不足6个字符的，会附加错误的数字
2. train_crnn.py -- 结合 CNN,RNN, 识别率60%, RNN 识别数字数目，最多6个，在识别数字长度的前提下，组合 CNN 识别数字，识别效果优于前者，但还是偏低。
2. train_crnn2.py -- 结合 CNN,RNN, 识别率53%, RNN 识别数字数目，最多6个，在识别数字长度的前提下，组合 CNN 识别数字，识别效果优于前者，但还是偏低。主要区别在于训练时使用了 json 的坐标数据，根据坐标将训练图片做了扩增。识别效果没有之前的好。
3. train_yolo.py -- 使用 yolo (you only look once)模型进行目标检测和字符识别. 训练时精度显示能超过90%， 但用测试集发现识别效果还不如前两个
    3.1.   data.yaml 内容如下：
        train: ../input/images/train
        val: ../input/images/val

        nc: 10  # 类别数（SVHN 包含 0-9 十个数字）
        names: ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9']

    3.2. 安装 yolov5
        # 克隆 YOLOv5 仓库
        git clone https://github.com/ultralytics/yolov5.git
        cd yolov5

        # 安装依赖
        pip install -r requirements.txt

        # 开始训练
        python train.py --img 640 --batch 16 --epochs 50 --data ../data.yaml --weights yolov5s.pt --cache
        或者
        train_yolo.py 在 yolov5 目录下执行
        如果自动下载模型缓慢，可以手动下载，再上传：
        wget https://github.com/ultralytics/yolov5/releases/download/v7.0/yolov5s.pt
        训练好的模型：best.pt,
        运行时，根据 文件 test_yolo.py 的设置放置该模型文件，默认路径是：yolov5/yolov5_runs/exp3/weights/best.pt

        y

# RNN 被用来预测字符长度的主要原因包括：

序列建模能力：RNN 天然适合处理序列数据，并能捕捉序列中的长期依赖关系。在 SVHN 数据集中，字符的排列顺序具有一定的结构化信息，RNN 可以很好地学习这种模式。
全局特征提取：通过双向LSTM 和平均池化操作，RNN 能够生成一个包含整个序列信息的全局特征向量，这正是字符长度预测所需要的。
多任务学习的优势：在该模型中，RNN 不仅用于预测字符本身（通过 output），还用于预测字符长度（通过 length_logits）。这种多任务学习方式可以提高模型的整体性能，因为不同的任务可以共享底层特征并互相促进。

1. 长短期记忆网络（LSTM）：通过引入门控机制（输入门、遗忘门、输出门），LSTM可以更好地捕捉长距离依赖。
2. 门控循环单元（GRU）：GRU是LSTM的简化版本，通过合并遗忘门和输入门为更新门，减少了参数数量。
3. 双向RNN（Bi-RNN）：结合了正向和反向两个方向的信息，可以同时利用过去和未来的信息。
4. 深度RNN：通过堆叠多层RNN，增强模型的表达能力。