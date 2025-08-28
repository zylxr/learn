using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class SortMatrixClass
    {
        //3446. 按对角线进行矩阵排序
        //给你一个大小为 n x n 的整数方阵 grid。返回一个经过如下调整的矩阵：

        //左下角三角形（包括中间对角线）的对角线按 非递增顺序 排序。
        //右上角三角形 的对角线按 非递减顺序 排序。



        //示例 1：

        //输入： grid = [[1, 7, 3],[9, 8, 2],[4, 5, 6]]

        //输出： [[8, 2, 3],[9, 6, 7],[4, 5, 1]]

        //解释：



        //标有黑色箭头的对角线（左下角三角形）应按非递增顺序排序：

        //[1, 8, 6] 变为[8, 6, 1]。
        //[9, 5] 和[4] 保持不变。
        //标有蓝色箭头的对角线（右上角三角形）应按非递减顺序排序：

        //[7, 2] 变为[2, 7]。
        //[3] 保持不变。
        //示例 2：

        //输入： grid = [[0, 1],[1, 2]]

        //输出： [[2, 1],[1, 0]]

        //解释：



        //标有黑色箭头的对角线必须按非递增顺序排序，因此[0, 2] 变为[2, 0]。其他对角线已经符合要求。

        //示例 3：

        //输入： grid = [[1]]

        //输出： [[1]]

        //解释：

        //只有一个元素的对角线已经符合要求，因此无需修改。



        //提示：

        //grid.length == grid[i].length == n
        //1 <= n <= 10
        //-105 <= grid[i][j] <= 105

        public int[][] SortMatrix(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var diaNum = m + n - 1;
            for(var d=0;d<diaNum;d++)
            {
                if(d<m)
                {
                    var j = 0;
                    var i = d;
                    for(;i<m && j<n;i++,j++)
                    {
                        var tmp = grid[i][j];
                        var it = i;
                        var jt = j;
                        while(it>=1 && jt>=1 && tmp > grid[it - 1][jt-1])
                        {
                            grid[it][jt] = grid[--it][--jt];
                        }
                        grid[it][jt] = tmp;
                    }
                }else
                {
                    var i = 0;
                    var j = (d+1)%m;
                    for(;i<m && j<n;j++,i++)
                    {
                        var tmp = grid[i][j];
                        var it = i;
                        var jt = j;
                        while(it>=1 && jt>=1 && tmp< grid[it-1][jt-1])
                        {
                            grid[it][jt] = grid[--it][--jt];
                        }
                        grid[it][jt] = tmp;
                    }
                }
            }
            return grid;
        }

        public int[][] SortMatrix2(int[][] grid)
        {
            var n = grid.Length;
            for(var i=0;i<n;i++)
            {
                var tmp = new List<int>();
                for (var j = 0; j < n-i; j++) tmp.Add(grid[i + j][j]);
                tmp.Sort((a,b)=>b.CompareTo(a));
                for (var j = 0; j < n - i; j++)
                    grid[i + j][j] = tmp[j];
            }
            for(var j=1;j<n;j++)
            {
                var tmp = new List<int>();
                for (var i = 0; i < n-j; i++) tmp.Add(grid[i][j+i]);
                tmp.Sort();
                for (var i = 0; i < n - j; i++) grid[i][j + i] = tmp[i];
            }
            return grid;
        }
    }
}
