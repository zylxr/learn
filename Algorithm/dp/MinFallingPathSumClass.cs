using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class MinFallingPathSumClass
    {
        //给你一个 n x n 的 方形 整数数组 matrix ，请你找出并返回通过 matrix 的下降路径 的 最小和 。
        //下降路径 可以从第一行中的任何元素开始，并从每一行中选择一个元素。在下一行选择的元素和当前行所选元素最多相隔一列（即位于正下方或者沿对角线向左或者向右的第一个元素）。具体来说，位置(row, col) 的下一个元素应当是(row + 1, col - 1)、(row + 1, col) 或者(row + 1, col + 1) 。
        //示例 1：
        //输入：matrix = [[2,1,3],[6,5,4],[7,8,9]]
        //输出：13
        //解释：如图所示，为和最小的两条下降路径
        //示例 2：
        //输入：matrix = [[-19,57],[-40,-5]]
        //输出：-59
        //解释：如图所示，为和最小的下降路径
        //提示：
        //n == matrix.length == matrix[i].length
        //1 <= n <= 100
        //-100 <= matrix[i][j] <= 100
        public int MinFallingPathSum(int[][] matrix)
        {
            var n = matrix.Length;
            var dp = new int[n,n];
            for(var i=n-1;i>=0;i--)
            {
                for(var j=0;j<n;j++)
                {
                    if(i ==n-1)
                    {
                        dp[i,j]= matrix[i][j];
                    }else
                    {
                        var tmp = dp[i+1,j];
                        if(j<n-1)
                            tmp = Math.Min(tmp, dp[i+1,j + 1]);
                        if (j > 0)
                        {
                            tmp = Math.Min(dp[i+1,j - 1], tmp);
                        }
                        dp[i,j] = tmp + matrix[i][j];
                    }
                    
                }
            }
            var minSum = dp[0, 0];
            for(var i=0;i<n;i++)
                minSum = Math.Min(dp[0,i],minSum);
            return minSum;
        }
    }
}
