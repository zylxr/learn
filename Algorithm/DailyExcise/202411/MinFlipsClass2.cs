using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinFlipsClass2
    {
        //3240. 最少翻转次数使二进制矩阵回文 II
        //给你一个 m x n 的二进制矩阵 grid 。

        //如果矩阵中一行或者一列从前往后与从后往前读是一样的，那么我们称这一行或者这一列是 回文 的。

        //你可以将 grid 中任意格子的值 翻转 ，也就是将格子里的值从 0 变成 1 ，或者从 1 变成 0 。

        //请你返回 最少 翻转次数，使得矩阵中 所有 行和列都是 回文的 ，且矩阵中 1 的数目可以被 4 整除 。



        //示例 1：

        //输入：grid = [[1, 0, 0],[0, 1, 0],[0, 0, 1]]

        //输出：3

        //解释：



        //示例 2：

        //输入：grid = [[0, 1],[0, 1],[0, 0]]

        //输出：2

        //解释：



        //示例 3：

        //输入：grid = [[1],[1]]

        //输出：2

        //解释：





        //提示：

        //m == grid.length
        //n == grid[i].length
        //1 <= m* n <= 2 * 105
        //0 <= grid[i][j] <= 1
        public int MinFlips(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var ans = 0;
            var cnt1 = 0;
            for(var i=0;i<m/2;i++)
            {
                for(var j=0;j<n/2;j++)
                {
                    cnt1 = grid[i][j] + grid[i][n - 1 - j] + grid[m - 1 - i][j] + grid[m - 1 - i][n - 1 - j];
                    ans += Math.Min(cnt1, 4 - cnt1);
                }
            }
            var diff = 0;
            cnt1 = 0;
            if(m%2== 1)
            {
                for(var j=0;j<n/2;j++)
                {
                    if ((grid[m / 2][j] ^ grid[m / 2][n - 1 - j]) != 0)
                        diff++;
                    else
                        cnt1 += grid[m / 2][j] * 2;
                }
            }
            if (m % 2 == 1 && n % 2 == 1)
                ans += grid[m / 2][n / 2];
            if (diff > 0) ans += diff;
            else ans += cnt1 % 4;

            return ans;
        }

        public int MinFlips2(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var f = new int[4];
            Array.Fill(f, int.MaxValue / 2);
            f[0] = 0;
            for(var i=0;i<(m+1)/2;i++)
            {
                for(var j=0;j<(n+1)/2;j++)
                {
                    var ones = grid[i][j];
                    var cnt = 1;
                    if(j != n-1-j)
                    {
                        ones += grid[i][n - 1 - j];
                        cnt++;
                    }
                    if (i != m - 1 - i)
                    {
                        ones += grid[m - 1 - i][j];
                        cnt++;
                    }
                    if(i!=m-1-i && j!=n-1-j)
                    {
                        ones += grid[m - 1 - i][n - 1 - j];
                        cnt++;
                    }
                    var cnt1 = cnt - ones;
                    var cnt0 = ones;
                    var tmp = new int[4];
                    for(var k=0;k<4;k++)
                    {
                        tmp[k] = f[k] + cnt0;
                    }
                    for(var k=0;k<4;k++)
                    {
                        tmp[(k + cnt) % 4] = Math.Min(tmp[(k + cnt) % 4], f[k] + cnt1);
                    }
                    f = tmp;
                }
            }
            return f[0];
        }
    }
}
