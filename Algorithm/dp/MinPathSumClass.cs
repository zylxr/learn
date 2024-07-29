using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class MinPathSumClass
    {
        //给定一个包含非负整数的 m x n 网格 grid ，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
        //说明：每次只能向下或者向右移动一步。
        //示例 1：
        //输入：grid = [[1,3,1],[1,5,1],[4,2,1]]
        //输出：7
        //解释：因为路径 1→3→1→1→1 的总和最小。
        //示例 2：
        //输入：grid = [[1,2,3],[4,5,6]]
        //输出：12
        public int MinPathSum(int[][] grid)
        {
            var n = grid.Length;
            if (n == 0 || grid[0].Length == 0) return 0;
            var m = grid[0].Length;
            var dp = new int[n, m];
            for (var i = 0; i < n; i++)
            {
                dp[i, 0] = grid[i][0];
                if (i == 0) continue;
                dp[i, 0] += dp[i - 1, 0];
            }
            for (var j = 0; j < m; j++)
            {
                dp[0, j] = grid[0][j];
                if (j == 0) continue;
                dp[0, j] += dp[0, j-1];
            }
            for (var i=1;i<n;i++)
            {
                for(var j =1;j<m;j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                }
            }
            return dp[n - 1, m - 1];
        }
    }
}
