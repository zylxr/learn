using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxSideLengthClass
    {
        //1292. 元素和小于等于阈值的正方形的最大边长
        //给你一个大小为 m x n 的矩阵 mat 和一个整数阈值 threshold。

        //请你返回元素总和小于或等于阈值的正方形区域的最大边长；如果没有这样的正方形区域，则返回 0 。


        //示例 1：



        //输入：mat = [[1, 1, 3, 2, 4, 3, 2],[1, 1, 3, 2, 4, 3, 2],[1, 1, 3, 2, 4, 3, 2]], threshold = 4
        //输出：2
        //解释：总和小于或等于 4 的正方形的最大边长为 2，如图所示。
        //示例 2：

        //输入：mat = [[2, 2, 2, 2, 2],[2, 2, 2, 2, 2],[2, 2, 2, 2, 2],[2, 2, 2, 2, 2],[2, 2, 2, 2, 2]], threshold = 1
        //输出：0


        //提示：

        //m == mat.length
        //n == mat[i].length
        //1 <= m, n <= 300
        //0 <= mat[i][j] <= 104
        //0 <= threshold <= 105 
        public int MaxSideLength(int[][] mat, int threshold)
        {
            var m = mat.Length;
            var n = mat[0].Length;
            var dp = new int[m, n];
            this.threshold = threshold;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0) dp[i, j] = mat[i][j] > threshold ? 0 : 1;
                    else
                    {
                        var l = Math.Max(Math.Max(dp[i - 1, j - 1], dp[i - 1, j]), dp[i, j - 1]);
                        if (Check(i, j, l + 1, mat)) dp[i, j] = l + 1;
                        else dp[i, j] = l;
                    }
                }
            }
            return dp[m - 1, n - 1];
        }
        private int threshold;
        private bool Check(int i, int j, int w, int[][] mat)
        {
            if (mat[i][j] > threshold || i < w - 1 || j < w - 1) return false;
            var sum = 0;
            for (var i1 = i; i1 > i - w; i1--)
            {
                for (var j1 = j; j1 > j - w; j1--)
                {
                    sum += mat[i1][j1];
                    if (sum > threshold) return false;
                }
            }
            return true;
        }

        public int MaxSideLength2(int[][] mat, int threshold)
        {
            var m = mat.Length;
            var n = mat[0].Length;
            var presum = new int[m + 1, n + 1];
            var dp = new int[m + 1, n + 1];
            for (var i = 1; i <= m; i++)
            {
                for (var j = 1; j <= n; j++)
                {
                    presum[i, j] = presum[i - 1, j] + presum[i, j - 1] - presum[i - 1, j - 1] + mat[i - 1][j - 1];
                    var maxl = Math.Max(Math.Max(dp[i - 1, j - 1], dp[i - 1, j]), dp[i, j - 1]);
                    if (mat[i - 1][j - 1] > threshold || i < maxl + 1 || j < maxl + 1) dp[i, j] = maxl;
                    else
                    {
                        var sum = presum[i, j] + presum[i - maxl - 1, j - maxl - 1] - presum[i - maxl - 1, j] - presum[i, j - maxl - 1];
                        dp[i, j] = sum > threshold ? maxl : (maxl + 1);
                    }

                }
            }
            return dp[m, n];
        }
    }
}
