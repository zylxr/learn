using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class MatrixChainMultiplication
    {
        //给定 n 个矩阵 {A1,A2,..,An},矩阵Ai的维数 pi-1xpi,i=1,2,...,n, 如何给矩阵链乘 A1xA2x...xAn 完全加上括号,使得矩阵链乘中乘法次数最少。
        //动态规划：m[i,j] = (0,i=j;min(m[i,k]+m[k+1,j]+pi-1*pk*pj,i<j)

        public int[,] MatrixChainOrder(int[] p)
        {
            var n = p.GetLength(0)-1;
            var dp = new int[n + 1, n + 1];
            var s = new int[n + 1 , n + 1];
            for(var l=2;l<=n; l++)
            {
                for(var i=1;i<=n-l+1;i++)
                {
                    var j = i + l - 1;
                    dp[i, j] = int.MaxValue;
                    for(var k=i;k<j;k++)
                    {
                        var q = dp[i, k] + dp[k + 1, j] + p[i-1] * p[k] * p[j];
                        if (dp[i,j]>q)
                        {
                            dp[i,j] = q;
                            s[i, j] = k;
                        }
                    }
                }
            }
            return s;
        }

        public void PrintMatrixChain(int[,] s, int i, int j)
        {
           
            if (i == j)
                Console.Write($"A{i}");
            else
            {
                Console.Write($"(");
                PrintMatrixChain(s, i, s[i,j]);
                PrintMatrixChain(s, s[i, j] + 1, j);
                Console.Write(")");
            }
        }
    }
}
