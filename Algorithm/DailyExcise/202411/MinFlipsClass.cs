using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinFlipsClass
    {
        //3239. 最少翻转次数使二进制矩阵回文 I
        //给你一个 m x n 的二进制矩阵 grid 。

        //如果矩阵中一行或者一列从前往后与从后往前读是一样的，那么我们称这一行或者这一列是 回文 的。

        //你可以将 grid 中任意格子的值 翻转 ，也就是将格子里的值从 0 变成 1 ，或者从 1 变成 0 。

        //请你返回 最少 翻转次数，使得矩阵 要么 所有行是 回文的 ，要么所有列是 回文的 。




        //示例 1：

        //输入：grid = [[1, 0, 0],[0, 0, 0],[0, 0, 1]]

        //输出：2

        //解释：



        //将高亮的格子翻转，得到所有行都是回文的。

        //示例 2：

        //输入：grid = [[0, 1],[0, 1],[0, 0]]

        //输出：1

        //解释：



        //将高亮的格子翻转，得到所有列都是回文的。

        //示例 3：

        //输入：grid = [[1],[0]]

        //输出：0

        //解释：

        //所有行已经是回文的。



        //提示：

        //m == grid.length
        //n == grid[i].length
        //1 <= m* n <= 2 * 105
        //0 <= grid[i][j] <= 1
        public int MinFlips(int[][] grid)
        {
            var rowCnt = 0;
            var colCnt = 0;
            var m = grid.Length;
            var n = grid[0].Length;
            for(var i =0;i<m;i++)
            {
                for(int j1=0,j2= n-1;j1<j2;j1++,j2--)
                {
                    if ((grid[i][j1] ^ grid[i][j2]) != 0)
                        rowCnt++;
                }
            }
            for(var j=0;j<n;j++)
            {
                for(int i1=0,i2=m-1;i1<i2;i1++,i2--)
                {
                    if ((grid[i1][j] ^ grid[i2][j]) != 0)
                        colCnt++;
                }
            }
            return Math.Min(rowCnt, colCnt);
        }
    }
}
