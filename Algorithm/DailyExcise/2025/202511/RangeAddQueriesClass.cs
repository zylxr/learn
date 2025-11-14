using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RangeAddQueriesClass
    {
        //2536. 子矩阵元素加 1
        //给你一个正整数 n ，表示最初有一个 n x n 、下标从 0 开始的整数矩阵 mat ，矩阵中填满了 0 。

        //另给你一个二维整数数组 query 。针对每个查询 query[i] = [row1i, col1i, row2i, col2i] ，请你执行下述操作：

        //找出 左上角 为(row1i, col1i) 且 右下角 为(row2i, col2i) 的子矩阵，将子矩阵中的 每个元素 加 1 。也就是给所有满足 row1i <= x <= row2i 和 col1i <= y <= col2i 的 mat[x][y] 加 1 。
        //返回执行完所有操作后得到的矩阵 mat 。




        //示例 1：



        //输入：n = 3, queries = [[1, 1, 2, 2],[0, 0, 1, 1]]
        //输出：[[1, 1, 0],[1, 2, 1],[0, 1, 1]]
        //解释：上图所展示的分别是：初始矩阵、执行完第一个操作后的矩阵、执行完第二个操作后的矩阵。
        //- 第一个操作：将左上角为(1, 1) 且右下角为(2, 2) 的子矩阵中的每个元素加 1 。 
        //- 第二个操作：将左上角为(0, 0) 且右下角为(1, 1) 的子矩阵中的每个元素加 1 。 
        //示例 2：



        //输入：n = 2, queries = [[0, 0, 1, 1]]
        //输出：[[1, 1],[1, 1]]
        //解释：上图所展示的分别是：初始矩阵、执行完第一个操作后的矩阵。 
        //- 第一个操作：将矩阵中的每个元素加 1 。


        //提示：

        //1 <= n <= 500
        //1 <= queries.length <= 104
        //0 <= row1i <= row2i<n
        //0 <= col1i <= col2i<n

        public int[][] RangeAddQueries(int n, int[][] queries)
        {
            var diff = new int[n + 1][];
            for (var i = 0; i <= n; i++)
                diff[i] = new int[n + 1];
            foreach(var q in queries)
            {
                int row1 = q[0], col1 = q[1],row2 = q[2],col2= q[3];
                diff[row1][col1] += 1;
                diff[row2 + 1][col1] -= 1;
                diff[row1][col2 + 1] -= 1;
                diff[row2 + 1][col2 + 1] += 1;
            }
            var mat = new int[n][];
            for(var i = 0; i < n; i++) mat[i] = new int[n];
            for(var i=0;i<n;i++)
            {
                for(var j=0;j<n;j++)
                {
                    var x1 = (i == 0) ? 0 : mat[i - 1][j];
                    var x2 = j == 0 ? 0 : mat[i][j - 1];
                    var x3 = (i == 0 || j == 0) ? 0 : mat[i - 1][j - 1];
                    mat[i][j] = diff[i][j] + x1 + x2 - x3;
                }
                
            }
            return mat;
        }
    }
}
