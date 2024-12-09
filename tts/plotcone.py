import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D

#定义网格的范围和密度
x=np.linspace(-2,2,400)
y=np.linspace(-2,2,400)
x,y = np.meshgrid(x,y)

z=2*x**2+y**2

#创建一个新的图形
fig=plt.figure(figsize=(10,7))
#添加3d轴
ax=fig.add_subplot(111,projection='3d')

#绘制曲面
surf=ax.plot_surface(x,y,z,cmap='viridis')

#添加颜色条
fig.colorbar(surf)

#设置标题和坐标轴标签
ax.set_title('3D surface plot of $z=2x^2+y^2$')
ax.set_xlabel('X axis')
ax.set_ylabel('Y axis')
ax.set_zlabel('Z axis')

#显示图形
plt.show()