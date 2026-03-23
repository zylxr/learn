using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxProductPathClass
    {
        //1594. 矩阵的最大非负积
        //给你一个大小为 m x n 的矩阵 grid 。最初，你位于左上角(0, 0) ，每一步，你可以在矩阵中 向右 或 向下 移动。

        //在从左上角(0, 0) 开始到右下角(m - 1, n - 1) 结束的所有路径中，找出具有 最大非负积 的路径。路径的积是沿路径访问的单元格中所有整数的乘积。

        //返回 最大非负积 对 109 + 7 取余 的结果。如果最大积为 负数 ，则返回 -1 。

        //注意，取余是在得到最大积之后执行的。



        //示例 1：


        //输入：grid = [[-1,-2,-3],[-2,-3,-3],[-3,-3,-2]]
        //输出：-1
        //解释：从(0, 0) 到(2, 2) 的路径中无法得到非负积，所以返回 -1 。
        //示例 2：


        //输入：grid = [[1, -2, 1],[1, -2, 1],[3, -4, 1]]
        //输出：8
        //解释：最大非负积对应的路径如图所示(1 * 1 * -2 * -4 * 1 = 8)
        //示例 3：


        //输入：grid = [[1, 3],[0, -4]]
        //输出：0
        //解释：最大非负积对应的路径如图所示(1 * 0 * -4 = 0)



        //提示：

        //m == grid.length
        //n == grid[i].length
        //1 <= m, n <= 15
        //-4 <= grid[i][j] <= 4
        public int MaxProductPath(int[][] grid)
        {
            var MOD = 1_000_000_007;
            var res = 0;
            var m = grid.Length;
            var n = grid[0].Length;
            var dp = new long[m, n, 2];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (j == 0)
                    {
                        if (i == 0)
                        {
                            dp[i, j, 0] = grid[i][j];
                            dp[i, j, 1] = grid[i][j];
                        }
                        else
                        {
                            var m1 = dp[i - 1, j, 0] * grid[i][j];
                            var m2 = dp[i - 1, j, 1] * grid[i][j];
                            dp[i, j, 0] = Math.Min(m1, m2);
                            dp[i, j, 1] = Math.Max(m1, m2);
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            var m1 = dp[i, j - 1, 0] * grid[i][j];
                            var m2 = dp[i, j - 1, 1] * grid[i][j];
                            dp[i, j, 0] = Math.Min(m1, m2);
                            dp[i, j, 1] = Math.Max(m1, m2);
                        }
                        else
                        {
                            var m1 = Math.Min(dp[i, j - 1, 0], dp[i - 1, j, 0]) * grid[i][j];
                            var m2 = Math.Max(dp[i, j - 1, 1], dp[i - 1, j, 1]) * grid[i][j];
                            dp[i, j, 0] = Math.Min(m1, m2);
                            dp[i, j, 1] = Math.Max(m1, m2);
                        }
                    }
                }
            }
            if (dp[m - 1, n - 1, 1] < 0) return -1;
            return (int)(dp[m - 1, n - 1, 1] % MOD);
        }
    }
}
