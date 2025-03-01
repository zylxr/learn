using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class ModifiedMatrixClass
    {
        //给你一个下标从 0 开始、大小为 m x n 的整数矩阵 matrix ，新建一个下标从 0 开始、名为 answer 的矩阵。使 answer 与 matrix 相等，接着将其中每个值为 -1 的元素替换为所在列的 最大 元素。
        //返回矩阵 answer 。
        //示例 1：
        //输入：matrix = [[1, 2, -1],[4, -1, 6],[7, 8, 9]]
        //输出：[[1, 2, 9],[4, 8, 6],[7, 8, 9]]
        //解释：上图显示了发生替换的元素（蓝色区域）。
        //- 将单元格[1][1] 中的值替换为列 1 中的最大值 8 。
        //- 将单元格[0][2] 中的值替换为列 2 中的最大值 9 。
        //示例 2：
        //输入：matrix = [[3, -1],[5, 2]]
        //输出：[[3, 2],[5, 2]]
        //解释：上图显示了发生替换的元素（蓝色区域）。

        //提示：

        //m == matrix.length
        //n == matrix[i].length
        //2 <= m, n <= 50
        //-1 <= matrix[i][j] <= 100
        //测试用例中生成的输入满足每列至少包含一个非负整数。
        public int[][] ModifiedMatrix(int[][] matrix)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var newMatrix = new int[m][];
            for(var i=0;i<m;i++)
            {
                newMatrix[i] = new int[n];
            }
            for(var i=0;i<n;i++)
            {
                var maxCol = -1;
                for(var j=0;j<m;j++)
                {
                    maxCol = Math.Max(maxCol, matrix[j][i]);
                }
                for(var j=0;j<m;j++)
                {
                    if (matrix[j][i] == -1)
                    {
                        matrix[j][i] = maxCol;
                        newMatrix[j][i] = maxCol;
                    }else
                        newMatrix[j][i] = matrix[j][i];
                }
            }
            return matrix;
        }
    }
}
