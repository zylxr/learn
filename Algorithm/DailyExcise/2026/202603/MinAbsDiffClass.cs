using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinAbsDiffClass
    {
        //3567. 子矩阵的最小绝对差
        //给你一个 m x n 的整数矩阵 grid 和一个整数 k。

        //对于矩阵 grid 中的每个连续的 k x k 子矩阵，计算其中任意两个 不同值 之间的 最小绝对差 。

        //返回一个大小为(m - k + 1) x(n - k + 1) 的二维数组 ans，其中 ans[i][j] 表示以 grid 中坐标(i, j) 为左上角的子矩阵的最小绝对差。

        //注意：如果子矩阵中的所有元素都相同，则答案为 0。

        //子矩阵(x1, y1, x2, y2) 是一个由选择矩阵中所有满足 x1 <= x <= x2 且 y1 <= y <= y2 的单元格 matrix[x][y] 组成的矩阵。



        //示例 1：

        //输入： grid = [[1, 8],[3, -2]], k = 2

        //输出： [[2]]

        //解释：

        //只有一个可能的 k x k 子矩阵：[[1, 8], [3, -2]]。
        //子矩阵中的不同值为[1, 8, 3, -2]。
        //子矩阵中的最小绝对差为 |1 - 3| = 2。因此，答案为[[2]]。
        //示例 2：

        //输入： grid = [[3, -1]], k = 1

        //输出： [[0, 0]]

        //解释：

        //每个 k x k 子矩阵中只有一个不同的元素。
        //因此，答案为[[0, 0]]。
        //示例 3：

        //输入： grid = [[1, -2, 3],[2, 3, 5]], k = 2

        //输出： [[1, 2]]

        //解释：

        //有两个可能的 k × k 子矩阵：
        //以(0, 0) 为起点的子矩阵：[[1, -2], [2, 3]]。
        //子矩阵中的不同值为[1, -2, 2, 3]。
        //子矩阵中的最小绝对差为 |1 - 2| = 1。
        //以(0, 1) 为起点的子矩阵：[[-2, 3], [3, 5]]。
        //子矩阵中的不同值为[-2, 3, 5]。
        //子矩阵中的最小绝对差为 |3 - 5| = 2。
        //因此，答案为[[1, 2]]。


        //提示：

        //1 <= m == grid.length <= 30
        //1 <= n == grid[i].length <= 30
        //-105 <= grid[i][j] <= 105
        //1 <= k <= min(m, n)
        public int[][] MinAbsDiff(int[][] grid, int k)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var res = new int[m - k + 1][];
            for (var i = 0; i < m - k + 1; i++) res[i] = new int[n - k + 1];
            var max = grid[0][0];
            var min = max;
            for (var i = 0; i < m - k + 1; i++)
            {
                for (var j = 0; j < n - k + 1; j++)
                {
                    var kgrid = new List<int>();
                    for (var x = i; x < i + k; x++)
                        for (var y = j; y < j + k; y++) kgrid.Add(grid[x][y]);
                    var kmin = int.MaxValue;
                    kgrid.Sort();
                    for (var t = 1; t < kgrid.Count; t++)
                    {
                        if (kgrid[t] == kgrid[t - 1]) continue;
                        kmin = Math.Min(kmin, kgrid[t] - kgrid[t - 1]);
                    }
                    if (kmin != int.MaxValue) res[i][j] = kmin;
                }
            }
            return res;
        }
    }
}
