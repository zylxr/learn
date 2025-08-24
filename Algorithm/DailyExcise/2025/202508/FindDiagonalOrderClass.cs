using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class FindDiagonalOrderClass
    {
        //498. 对角线遍历
        //给你一个大小为 m x n 的矩阵 mat ，请以对角线遍历的顺序，用一个数组返回这个矩阵中的所有元素。



        //示例 1：


        //输入：mat = [[1, 2, 3],[4, 5, 6],[7, 8, 9]]
        //输出：[1, 2, 4, 7, 5, 3, 6, 8, 9]
        //示例 2：

        //输入：mat = [[1, 2],[3, 4]]
        //输出：[1, 2, 3, 4]


        //提示：

        //m == mat.length
        //n == mat[i].length
        //1 <= m, n <= 104
        //1 <= m* n <= 104
        //-105 <= mat[i][j] <= 105

        public int[] FindDiagonalOrder(int[][] mat)
        {
            var m = mat.Length;
            var n = mat[0].Length;
            var ret = new List<int>();
            int i = 0, j = 0;
            var cnt = 0;
            ret.Add(mat[i][j]);
            while (i < m && j < n)
            {
                cnt++;
                if (cnt % 2 == 1)
                {
                    if (j < n - 1) j++;
                    else i++;
                    if (i > m - 1) break;
                    ret.Add(mat[i][j]);
                    while (j > 0 && i < m-1)
                    {
                        i++;
                        j--;
                        ret.Add(mat[i][j]);
                    }
                }
                else
                {
                    if (i < m - 1) i++;
                    else j++;
                    if (j > n - 1) break;
                    ret.Add(mat[i][j]);
                    while (i > 0 && j < n-1)
                    {
                        i--;
                        j++;
                        ret.Add(mat[i][j]);
                    }
                }
            }
            return ret.ToArray();
        }

        public int[] FindDiagonalOrder2(int[][] mat)
        {
            var m = mat.Length;
            var n = mat[0].Length;
            var res = new int[m * n];
            var pos = 0;
            for(var i=0;i<m+n-1;i++)
            {
                if(i%2==1)
                {
                    var x = i < n ? 0 : i - n + 1;
                    var y = i < n ? i : n - 1;
                    while(x<m && y>=0)
                    {
                        res[pos] = mat[x][y];
                        pos++;
                        x++;
                        y--;
                    }
                }else
                {
                    var x = i < m ? i : m-1;
                    var y = i < m ? 0 : i - m + 1;
                    while(x>=0 && y<n)
                    {
                        res[pos] = mat[x][y];
                        pos++;
                        x--;
                        y++;
                    }
                }
            }
            return res;
        }
    }

}
