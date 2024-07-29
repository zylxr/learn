using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class TrapRainWaterCube
    {
        //给你一个 m x n 的矩阵，其中的值均为非负整数，代表二维高度图每个单元的高度，请计算图中形状最多能接多少体积的雨水。
        //示例 1:
        //输入: heightMap = [[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]]
        //输出: 4
        //解释: 下雨后，雨水将会被上图蓝色的方块中。总的接雨水量为1+2+1=4。

        //示例 2:
        //输入: heightMap = [[3,3,3,3,3],[3,2,2,2,3],[3,2,1,2,3],[3,2,2,2,3],[3,3,3,3,3]]
        //输出: 10
        //提示:

        //m == heightMap.length
        //n == heightMap[i].length
        //1 <= m, n <= 200
        //0 <= heightMap[i][j] <= 2 * 104

        //方法一：最小堆
        //思路与算法
        //本题为经典题目，解题的原理和方法都可以参考「42.接雨水」，本题主要从一维数组变成了二维数组。
        //首先我们思考一下什么样的方块一定可以接住水：

        //该方块不为最外层的方块；
        //该方块自身的高度比其上下左右四个相邻的方块接水后的高度都要低；
        //我们假设方块的索引为 (i,j)，方块的高度为 heightMap[i][j]，方块接水后的高度为 water[i][j]。则我们知道方块 (i,j) 的接水后的高度为：

        //water[i][j]=max⁡(heightMap[i][j],min⁡(water[i−1][j],water[i+1][j],water[i][j−1],water[i][j+1]))
        //我们知道方块 (i,j) 实际接水的容量计算公式为 water[i][j]−heightMap[i][j]。
        //首先我们可以确定的是，矩阵的最外层的方块接水后的高度就是方块的自身高度，因为最外层的方块无法接水，
        //因此最外层的方块 water[i][j]=heightMap[i][j]。
        //根据木桶原理，接到的雨水的高度由这个容器周围最短的木板来确定的。我们可以知道容器内水的高度取决于最外层高度最低的方块，
        //我们假设已经知道最外层的方块接水后的高度的最小值，则此时我们根据木桶原理，肯定可以确定最小高度方块的相邻方块的接水高度。
        //我们同时更新最外层的方块标记，我们在新的最外层的方块再次找到接水后的高度的最小值，同时确定与其相邻的方块的接水高度
        //然后再次更新最外层，依次迭代直到求出所有的方块的接水高度，即可知道矩阵中的接水容量。

        public int TrapRainWaterByMinHeap(int[][] heightMap)
        {
            if (heightMap.Length <= 2 || heightMap[0].Length <= 2) return 0;
            var m = heightMap.Length;
            var n = heightMap[0].Length;
            bool[,] visit = new bool[m, n];
            var queue = new PriorityQueue<(int,int),int>();

            for(var i=0;i<m;i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (i == 0 || i == m - 1 || j == 0||j == n - 1)
                    {
                        queue.Enqueue((i * n + j, heightMap[i][j]), heightMap[i][j]);
                        visit[i, j] = true;
                    }
                }
            }
            var res = 0;
            var diffs = new int[] { 0,-1,0,1,0 };
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                var x = curr.Item1 / n;
                var y = curr.Item1 % n;
                for(var k=0;k<4;k++)
                {
                    var dx = x+diffs[k];
                    var dy = y+diffs[k+1];
                    if(dx>=0 && dy>=0 && dx<m && dy<n && !visit[dx,dy])
                    {
                        if(curr.Item2 > heightMap[dx][dy])
                        {
                            res += curr.Item2 - heightMap[dx][dy];
                        }
                        visit[dx,dy] = true;
                        var maxHeight = Math.Max(heightMap[dx][dy], curr.Item2);
                        queue.Enqueue((dx * n + dy, maxHeight), maxHeight);
                    }
                }

            }
            return res;
        }

        //我们假设初始时矩阵的每个格子都接满了水，
        //且高度均为 maxHeight，其中 maxHeight为矩阵中高度最高的格子。
        //我们知道方块接水后的高度为 water[i][j]，方块 (i,j) 的接水后的高度为：
        //water[i][j]=max⁡(heightMap[i][j],min⁡(water[i−1][j],water[i+1][j],water[i][j−1],water[i][j+1])

        //我们知道方块 (i,j) 实际接水的容量计算公式为 water[i][j]−heightMap[i][j]。
        //我们首先假设每个方块 (i,j) 的接水后的高度均为 water[i][j]=maxHeight，
        //首先我们知道最外层的方块的肯定不能接水，所有的多余的水都会从最外层的方块溢出，
        //我们每次发现当前方块 (i,j) 的接水高度 water[i][j] 小于与它相邻的 4 个模块的接水高度时，则我们将进行调整接水高度，
        //我们将其相邻的四个方块的接水高度调整与 (i,j)的高度保持一致，我们不断重复的进行调整，直到所有的方块的接水高度不再有调整时即为满足要求。

        public int TrapRainWaterByBFS(int[][] heightMap)
        {
            if (heightMap.Length <= 2 || heightMap[0].Length <= 2) return 0;
            var m = heightMap.Length;
            var n = heightMap[0].Length;
            var water = new int[m, n];
            var maxHeight = 0;
            for (var i = 0; i < m; i++)
            {
                for(var j=0;j<n;j++)
                {
                    maxHeight = Math.Max(maxHeight, heightMap[i][j]);
                }
            }
            for(var i=0;i<m;i++)
            {
                for(var j=0;j<n;j++)
                {
                    water[i, j] = maxHeight;
                }
            }

            var queue = new Queue<(int, int)>();
            for(var i=0;i<m;i++)
            {
                for(var j=0;j<n;j++)
                {
                    if((i==0||i==m-1||j==0||j==n-1)&& water[i, j] > heightMap[i][j])
                    {
                        water[i,j] = heightMap[i][j];
                        queue.Enqueue((i, j));
                    }
                }
            }
            var diffs = new int[] { -1,0,1,0,-1 };
            while(queue.Count > 0)
            {
                var curr = queue.Dequeue();
                var x = curr.Item1;
                var y = curr.Item2;
                for (var k = 0; k < 4; k++)
                {
                    var dx = x + diffs[k];
                    var dy = y + diffs[k+1];
                    if (dx < 0 || dy < 0 || dx >= m || dy >= n) continue;
                    if (water[dx, dy] > water[x, y] && water[dx, dy] > heightMap[dx][dy])
                    {
                        water[dx, dy] = Math.Max(heightMap[dx][dy], water[x,y]);
                        queue.Enqueue((dx, dy));
                    }
                }
            }

            var res = 0;
            for(var i=0;i<m;i++)
            {
                for(var j=0;j<n;j++)
                {
                    res += water[i, j] - heightMap[i][j];
                }
            }
            return res;
        }
    }
}
