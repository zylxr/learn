using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class NumberOfPathsClass
    {
        //2435. 矩阵中和能被 K 整除的路径
        //给你一个下标从 0 开始的 m x n 整数矩阵 grid 和一个整数 k 。你从起点(0, 0) 出发，每一步只能往 下 或者往 右 ，你想要到达终点(m - 1, n - 1) 。

        //请你返回路径和能被 k 整除的路径数目，由于答案可能很大，返回答案对 109 + 7 取余 的结果。




        //示例 1：



        //输入：grid = [[5, 2, 4],[3, 0, 5],[0, 7, 2]], k = 3
        //输出：2
        //解释：有两条路径满足路径上元素的和能被 k 整除。
        //第一条路径为上图中用红色标注的路径，和为 5 + 2 + 4 + 5 + 2 = 18 ，能被 3 整除。
        //第二条路径为上图中用蓝色标注的路径，和为 5 + 3 + 0 + 5 + 2 = 15 ，能被 3 整除。
        //示例 2：


        //输入：grid = [[0, 0]], k = 5
        //输出：1
        //解释：红色标注的路径和为 0 + 0 = 0 ，能被 5 整除。
        //示例 3：


        //输入：grid = [[7, 3, 4, 9],[2, 3, 6, 2],[2, 3, 7, 0]], k = 1
        //输出：10
        //解释：每个数字都能被 1 整除，所以每一条路径的和都能被 k 整除。


        //提示：

        //m == grid.length
        //n == grid[i].length
        //1 <= m, n <= 5 * 104
        //1 <= m* n <= 5 * 104
        //0 <= grid[i][j] <= 100
        //1 <= k <= 50
        public int NumberOfPaths(int[][] grid, int k)
        {
            this.grid = grid;
            this.k = k;
            var sum = 0;
            this.ans = 0;
            Dfs(0, 0, sum);
            return ans;
        }
        private int ans;
        private int[][] grid;
        private int k;
        public void Dfs(int x, int y, int sum)
        {
            sum = (sum + this.grid[x][y]) % (1_000_000_007);
            if (x == this.grid.Length - 1 && y == this.grid[0].Length - 1)
            {
                ans += sum % this.k == 0 ? 1 : 0;
                return;
            }

            if (x < this.grid.Length - 1) Dfs(x + 1, y, sum);
            if (y < this.grid[0].Length - 1) Dfs(x, y + 1, sum);
        }

        public int NumberOfPaths2(int[][] grid, int k)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var ans = 0;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    grid[i][j] %= k;
                }
            }
            var df = new int[m][][];
            for (var i = 0; i < m; i++)
            {
                df[i] = new int[n][];
                for (var j = 0; j < n; j++)
                {
                    df[i][j] = new int[k];
                }
            }
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {

                    var t = grid[i][j] % k;
                    if (i == 0 && j == 0)
                    {
                        df[i][j][t] = 1;
                        continue;
                    }
                    for (var q = 0; q < k; q++)
                    {
                        var newq = (t + q) % k;
                        if (i > 0 && j == 0) df[i][j][newq] = df[i - 1][j][q];
                        else if (j > 0 && i == 0) df[i][j][newq] = df[i][j - 1][q];
                        else df[i][j][newq] = (df[i - 1][j][q] + df[i][j - 1][q]) % 1_000_000_007;
                    }


                }
            }
            return df[m - 1][n - 1][0];
        }
    }
}
