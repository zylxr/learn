using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class MaximalSquareClass
    {
        //在一个由 '0' 和 '1' 组成的二维矩阵内，找到只包含 '1' 的最大正方形，并返回其面积。
        //示例 1：
        //输入：matrix = [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]
        //输出：4
        //示例 2：
        //输入：matrix = [["0","1"],["1","0"]]
        //输出：1
        //示例 3：
        //输入：matrix = [["0"]]
        //输出：0
        //提示：
        //m == matrix.length
        //n == matrix[i].length
        //1 <= m, n <= 300
        //matrix[i][j] 为 '0' 或 '1'
        public int MaximalSquare(char[][] matrix)
        {
            var m = matrix.Length;
            if (m == 0 || matrix[0].Length == 0) return 0;
            var n = matrix[0].Length;
            var dp = new int[m, n];
            var maxEdge = 0;
            for (var i=0;i<m;i++)
            {
                if (matrix[i ][0] == '1') {dp[i, 0] = 1; maxEdge= Math.Max(maxEdge, dp[i, 0]); }
            }
            for(var j=0;j<n;j++)
            {
                if (matrix[0][j] == '1') { dp[0, j] = 1; maxEdge = Math.Max(maxEdge, dp[0, j]); }

                }
           ;
            for(var i=1;i<m ; i++)
            {
                for(var j=1;j <n ; j++)
                {
                    if (matrix[i][j] == '0')
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j - 1], dp[i - 1, j]), dp[i, j - 1]) + 1;
                        maxEdge = Math.Max(maxEdge, dp[i, j]);
                    }
                    
                }
            }
            return maxEdge*maxEdge;
        }
    }
}
