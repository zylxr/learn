using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class CountSquaresClass
    {
        //1277. 统计全为 1 的正方形子矩阵
        //给你一个 m* n 的矩阵，矩阵中的元素不是 0 就是 1，请你统计并返回其中完全由 1 组成的 正方形 子矩阵的个数。



        //示例 1：

        //输入：matrix =
        //[
        //[0, 1, 1, 1],
        //[1, 1, 1, 1],
        //[0, 1, 1, 1]
        //]
        //输出：15
        //解释： 
        //边长为 1 的正方形有 10 个。
        //边长为 2 的正方形有 4 个。
        //边长为 3 的正方形有 1 个。
        //正方形的总数 = 10 + 4 + 1 = 15.
        //示例 2：

        //输入：matrix = 
        //[
        //[1, 0, 1],
        //[1, 1, 0],
        //[1, 1, 0]
        //]
        //输出：7
        //解释：
        //边长为 1 的正方形有 6 个。 
        //边长为 2 的正方形有 1 个。
        //正方形的总数 = 6 + 1 = 7.


        //提示：

        //1 <= arr.length <= 300
        //1 <= arr[0].length <= 300
        //0 <= arr[i][j] <= 1

        public int CountSquares(int[][] matrix)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var dp = new int[m, n];
            var ans = 0;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = matrix[i][j];
                    }
                    else if (matrix[i][j] == 0) dp[i, j] = 0;
                    else
                    {
                        dp[i,j] = Math.Min(Math.Min(dp[i - 1, j - 1], dp[i - 1, j]),dp[i,j-1])+1;
                    }
                    ans += dp[i, j];
                }
            }
            return ans;
        }
    }
}
