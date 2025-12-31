using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class LatestDayToCrossClass
    {
        //1970. 你能穿过矩阵的最后一天
        //给你一个下标从 1 开始的二进制矩阵，其中 0 表示陆地，1 表示水域。同时给你 row 和 col 分别表示矩阵中行和列的数目。

        //一开始在第 0 天，整个 矩阵都是 陆地 。但每一天都会有一块新陆地被 水 淹没变成水域。给你一个下标从 1 开始的二维数组 cells ，其中 cells[i] = [ri, ci] 表示在第 i 天，第 ri 行 ci 列（下标都是从 1 开始）的陆地会变成 水域 （也就是 0 变成 1 ）。

        //你想知道从矩阵最 上面 一行走到最 下面 一行，且只经过陆地格子的 最后一天 是哪一天。你可以从最上面一行的 任意 格子出发，到达最下面一行的 任意 格子。你只能沿着 四个 基本方向移动（也就是上下左右）。

        //请返回只经过陆地格子能从最 上面 一行走到最 下面 一行的 最后一天 。




        //示例 1：


        //输入：row = 2, col = 2, cells = [[1, 1],[2, 1],[1, 2],[2, 2]]
        //输出：2
        //解释：上图描述了矩阵从第 0 天开始是如何变化的。
        //可以从最上面一行到最下面一行的最后一天是第 2 天。
        //示例 2：


        //输入：row = 2, col = 2, cells = [[1, 1],[1, 2],[2, 1],[2, 2]]
        //输出：1
        //解释：上图描述了矩阵从第 0 天开始是如何变化的。
        //可以从最上面一行到最下面一行的最后一天是第 1 天。
        //示例 3：


        //输入：row = 3, col = 3, cells = [[1, 2],[2, 1],[3, 3],[2, 2],[1, 1],[1, 3],[2, 3],[3, 2],[3, 1]]
        //输出：3
        //解释：上图描述了矩阵从第 0 天开始是如何变化的。
        //可以从最上面一行到最下面一行的最后一天是第 3 天。


        //提示：

        //2 <= row, col <= 2 * 104
        //4 <= row* col <= 2 * 104
        //cells.length == row* col
        //1 <= ri <= row
        //1 <= ci <= col
        //cells 中的所有格子坐标都是 唯一 的。
        public int LatestDayToCross(int row, int col, int[][] cells)
        {
            var l = 0;
            var r = row * col;
            var ans = 0;
            while(l<=r)
            {
                var mid = (l+r)/2;
                var grid = new int[row][];
                for(var i=0;i<row;i++)
                {
                    grid[i] = new int[col];
                    Array.Fill(grid[i], 1);
                }
                for (var i = 0; i < mid; i++) grid[cells[i][0] - 1][cells[i][1] - 1] = 0;
                var q = new Queue<int[]>();
                for(var i=0;i<col;i++)
                {
                    if (grid[0][i] == 1)
                    {
                        q.Enqueue(new int[] { 0,i});
                        grid[0][i] = 0;
                    }
                }

                var found = false;
                while (q.Count > 0)
                {
                    var cell = q.Dequeue();
                    var x = cell[0];
                    var y = cell[1];
                    foreach (var dir in dirs)
                    {
                        var nx = x + dir[0];
                        var ny = y + dir[1];
                        if (nx >= 0 && nx < row && ny >= 0 && ny < col && grid[nx][ny] == 1)
                        {
                            if(nx==row-1)
                            {
                                found = true; break;
                            }
                            q.Enqueue(new int[] { nx, ny });
                            grid[nx][ny] = 0;
                        }
                    }
                    if (found) break;
                }
                if (found)
                {
                    ans = mid;
                    l = mid + 1;
                }
                else r = mid - 1;
            }
            return ans;
        }
        private static readonly int[][] dirs = new int[][] { 
            new int[]{ -1,0},
            new int[]{ 1,0},
            new int[]{ 0,-1},
            new int[]{ 0,1}
        };
    }
}
