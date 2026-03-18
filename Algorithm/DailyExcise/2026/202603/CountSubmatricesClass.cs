using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class CountSubmatricesClass
    {
        //3070. 元素和小于等于 k 的子矩阵的数目
        //给你一个下标从 0 开始的整数矩阵 grid 和一个整数 k。

        //返回包含 grid 左上角元素、元素和小于或等于 k 的 子矩阵的数目。




        //示例 1：


        //输入：grid = [[7, 6, 3],[6, 6, 1]], k = 18
        //输出：4
        //解释：如上图所示，只有 4 个子矩阵满足：包含 grid 的左上角元素，并且元素和小于或等于 18 。
        //示例 2：


        //输入：grid = [[7, 2, 9],[1, 5, 0],[2, 6, 6]], k = 20
        //输出：6
        //解释：如上图所示，只有 6 个子矩阵满足：包含 grid 的左上角元素，并且元素和小于或等于 20 。
 

        //提示：

        //m == grid.length
        //n == grid[i].length
        //1 <= n, m <= 1000 
        //0 <= grid[i][j] <= 1000
        //1 <= k <= 109
        public int CountSubmatrices(int[][] grid, int k)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var cols = new int[n];
            var res = 0;
            for (var i = 0; i < m; i++)
            {
                var rows = 0;
                for (var j = 0; j < n; j++)
                {
                    cols[j] += grid[i][j];
                    rows += cols[j];
                    if (rows <= k) res++;
                }
            }
            return res;
        }
    }
}
