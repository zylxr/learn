using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class GenerateMatrixClass
    {
        //59. 螺旋矩阵 II
        //给你一个正整数 n ，生成一个包含 1 到 n2 所有元素，且元素按顺时针顺序螺旋排列的 n x n 正方形矩阵 matrix 。




        //示例 1：


        //输入：n = 3
        //输出：[[1, 2, 3],[8, 9, 4],[7, 6, 5]]
        //示例 2：

        //输入：n = 1
        //输出：[[1]]


        //提示：

        //1 <= n <= 20
        public int[][] GenerateMatrix(int n)
        {
            var maxNum = n * n;
            var curNum = 1;
            var matrix = new int[n][];
            for (var i = 0; i < n; i++)
                matrix[i] = new int[n];
            var row = 0;
            var col = 0;
            var directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            var directionIndex = 0;
            while (curNum <= maxNum)
            {
                matrix[row][col] = curNum;
                curNum++;
                var nextRow = row + directions[directionIndex][0];
                var nextCol = col + directions[directionIndex][1];
                if (nextRow < 0 || nextRow >= n || nextCol <0 || nextCol >=n || matrix[nextRow][nextCol] != 0)
                {
                    directionIndex = (directionIndex + 1) % 4;
                }
                row += directions[directionIndex][0];
                col += directions[directionIndex][1];
            }
            return matrix;
        }

        public int[][] GenerateMatrix2(int n)
        {
            var num = 1;
            var matrix = new int[n][];
            for (var i = 0; i < n; i++)
                matrix[i] = new int[n];
            var left = 0;
            var right = n - 1;
            var top = 0;
            var bottom = n - 1;
            while (left <= right && top <= bottom)
            {
                for (var col = left; col <= right; col++)
                {
                    matrix[top][col] = num;
                    num++;
                }
                for (var row = top + 1; row <= bottom; row++)
                {
                    matrix[row][right] = num;
                    num++;
                }
                if (left < right && top < bottom)
                {
                    for (var col = right - 1; col > left; col--)
                    {
                        matrix[bottom][col] = num;
                        num++;
                    }
                    for (var row = bottom; row > top; row--)
                    {
                        matrix[row][left] = num;
                        num++;
                    }
                }
                left++;
                right--;
                top++;
                bottom--;
            }
                
            return matrix;
        }
    }
}
