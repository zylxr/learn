using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class SwimInWaterClass
    {
        //778. 水位上升的泳池中游泳
        //在一个 n x n 的整数矩阵 grid 中，每一个方格的值 grid[i][j] 表示位置(i, j) 的平台高度。

        //当开始下雨时，在时间为 t 时，水池中的水位为 t 。你可以从一个平台游向四周相邻的任意一个平台，但是前提是此时水位必须同时淹没这两个平台。假定你可以瞬间移动无限距离，也就是默认在方格内部游动是不耗时的。当然，在你游泳的时候你必须待在坐标方格里面。

        //你从坐标方格的左上平台(0，0) 出发。返回 你到达坐标方格的右下平台(n-1, n-1) 所需的最少时间 。



        //示例 1:



        //输入: grid = [[0, 2],[1, 3]]
        //输出: 3
        //解释:
        //时间为0时，你位于坐标方格的位置为(0, 0)。
        //此时你不能游向任意方向，因为四个相邻方向平台的高度都大于当前时间为 0 时的水位。
        //等时间到达 3 时，你才可以游向平台(1, 1). 因为此时的水位是 3，坐标方格中的平台没有比水位 3 更高的，所以你可以游向坐标方格中的任意位置
        //示例 2:



        //输入: grid = [[0, 1, 2, 3, 4],[24, 23, 22, 21, 5],[12, 13, 14, 15, 16],[11, 17, 18, 19, 20],[10, 9, 8, 7, 6]]
        //输出: 16
        //解释: 最终的路线用加粗进行了标记。
        //我们必须等到时间为 16，此时才能保证平台(0, 0) 和(4, 4) 是连通的


        //提示:

        //n == grid.length
        //n == grid[i].length
        //1 <= n <= 50
        //0 <= grid[i][j] < n2
        //grid[i][j]
        //中每个值 均无重复
        public int SwimInWater(int[][] grid)
        {
            var n = grid.Length;
            var pq = new PriorityQueue<int[], int>();
            var dirs = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
            pq.Enqueue(new int[] { grid[0][0], 0 }, grid[0][0]);
            var visited = new bool[n, n];
            var res = 0;
            visited[0, 0] = true;
            while (pq.Count > 0)
            {
                var item = pq.Dequeue();
                var i = item[1] / n;
                var j = item[1] % n;
                var cur = item[0];
                visited[i, j] = true;
                res = Math.Max(res, cur);
                if (i == n - 1 && j == n - 1) break;
                foreach (var dir in dirs)
                {
                    var nx = i + dir[0];
                    var ny = j + dir[1];
                    if (nx < 0 || nx > n - 1 || ny < 0 || ny > n - 1 || visited[nx, ny]) continue;
                    pq.Enqueue(new int[] { grid[nx][ny],nx*n+ny }, grid[nx][ny]);

                }
            }
            return res;
        }
    }
}
