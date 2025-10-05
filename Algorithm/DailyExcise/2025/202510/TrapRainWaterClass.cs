using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class TrapRainWaterClass
    {
        //407. 接雨水 II
        //给你一个 m x n 的矩阵，其中的值均为非负整数，代表二维高度图每个单元的高度，请计算图中形状最多能接多少体积的雨水。



        //示例 1:



        //输入: heightMap = [[1, 4, 3, 1, 3, 2],[3, 2, 1, 3, 2, 4],[2, 3, 3, 2, 3, 1]]
        //输出: 4
        //解释: 下雨后，雨水将会被上图蓝色的方块中。总的接雨水量为1+2+1=4。
        //示例 2:



        //输入: heightMap = [[3, 3, 3, 3, 3],[3, 2, 2, 2, 3],[3, 2, 1, 2, 3],[3, 2, 2, 2, 3],[3, 3, 3, 3, 3]]
        //输出: 10


        //提示:

        //m == heightMap.length
        //n == heightMap[i].length
        //1 <= m, n <= 200
        //0 <= heightMap[i][j] <= 2 * 104

        public int TrapRainWater(int[][] heightMap)
        {
            var ans = 0;
            var m = heightMap.Length;
            var n = heightMap[0].Length;
            var visited = new bool[m, n];
            var queue = new PriorityQueue<int[],int>();
            for (var i = 0; i < m; i++)
            {
                queue.Enqueue(new int[] { i * n, heightMap[i][0] }, heightMap[i][0]);
                visited[i, 0] = true;
                queue.Enqueue(new int[] { i * n + n - 1, heightMap[i][n - 1] }, heightMap[i][n - 1]);
                visited[i, n - 1] = true;
            }
            for (var j = 1; j < n - 1; j++)
            {
                queue.Enqueue(new int[] { j, heightMap[0][j] }, heightMap[0][j]);
                visited[0, j] = true;
                queue.Enqueue(new int[] { (m - 1) * n + j, heightMap[m - 1][j] }, heightMap[m - 1][j]);
                visited[m - 1, j] = true;
            }
            var dirs = new int[][]{
            new int[]{-1,0},
            new int[]{1,0},
            new int[]{0,-1},
            new int[]{0,1}
        };
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                var i = item[0] / n;
                var j = item[0] % n;
                var cur = item[1];
                foreach (var dir in dirs)
                {
                    var nextx = dir[0] + i;
                    var nexty = dir[1] + j;
                    if (nextx < 0 || nextx > m-1 || nexty < 0 || nexty > n-1) continue;
                    if (visited[nextx, nexty]) continue;
                    
                    if (heightMap[nextx][nexty] <= cur)
                    {
                        ans += cur - heightMap[nextx][nexty];
                        
                    }
                    var p = Math.Max(heightMap[nextx][nexty], cur);
                    queue.Enqueue(new int[] { nextx * n + nexty, p},p);
                    visited[nextx, nexty] = true;
                }
            }
            return ans;
        }
    }
}
