import tensorflow as tf

#张量是一种多维数组，可以表示单个数字、向量、矩阵以及更高维度的数据结构。张量是 tensorflow 架构中核心数据结构之一
#创建一个标量
scalar = tf.constant(5)
print(scalar)

#创建一个向量
vector = tf.constant([1.0,2.0,3.0])
print(vector)

#创建一个矩阵
matrix = tf.constant([[1,2],[3,4]])
print(matrix)

#如下示例代码：定义一个简单的线性模型，并通过计算损失和调用优化器来更新权重 weights
#创建一个可训练的变量做为模型的参数
weights = tf.Variable(tf.random.normal([2,1]),dtype=tf.float32)
print(weights)

#定义一个简单的线性模型
def model(inputs):
    return tf.matmul(inputs,weights)

#创建一些输入数据
inputs = tf.constant([[1,2],[3,4]],dtype=tf.float32)

#计算预测输出
predictions = model(inputs)

#定义损失函数
target = tf.constant([[3.0],[7.0]])
loss = tf.reduce_mean(tf.square(predictions-target))

#使用优化器来更新权重
optimizer = tf.keras.optimizers.Adam();

# 训练步数
num_steps = 10

for step in range(num_steps):
    # 使用 GradientTape 来自动跟踪梯度
    with tf.GradientTape() as tape:
        predictions = model(inputs)
        loss_value = tf.reduce_mean(tf.square(predictions - target))

    # 计算梯度
    gradients = tape.gradient(loss_value, weights)

    # 应用梯度
    optimizer.apply_gradients([(gradients, weights)])

    # 输出当前损失和权重
    print(f"Step {step}: Loss = {loss_value.numpy()}, Weights = {weights.numpy()}")

#输出更新后的权重
print(weights)