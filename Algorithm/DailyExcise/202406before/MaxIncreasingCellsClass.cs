using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxIncreasingCellsClass
    {
        //给你一个下标从 1 开始、大小为 m x n 的整数矩阵 mat，你可以选择任一单元格作为 起始单元格 。
        //从起始单元格出发，你可以移动到 同一行或同一列 中的任何其他单元格，但前提是目标单元格的值 严格大于 当前单元格的值。
        //你可以多次重复这一过程，从一个单元格移动到另一个单元格，直到无法再进行任何移动。
        //请你找出从某个单元开始访问矩阵所能访问的 单元格的最大数量 。
        //返回一个表示可访问单元格最大数量的整数。

        //示例 1：
        //输入：mat = [[3, 1],[3, 4]]
        //输出：2
        //解释：上图展示了从第 1 行、第 2 列的单元格开始，可以访问 2 个单元格。可以证明，无论从哪个单元格开始，最多只能访问 2 个单元格，因此答案是 2 。 

        //示例 2：
        //输入：mat = [[1, 1],[1, 1]]
        //输出：1
        //解释：由于目标单元格必须严格大于当前单元格，在本示例中只能访问 1 个单元格。 

        //示例 3：
        //输入：mat = [[3, 1, 6],[-9,5,7]]
        //输出：4
        //解释：上图展示了从第 2 行、第 1 列的单元格开始，可以访问 4 个单元格。可以证明，无论从哪个单元格开始，最多只能访问 4 个单元格，因此答案是 4 。  


        //提示：
        //m == mat.length
        //n == mat[i].length 
        //1 <= m, n <= 105
        //1 <= m* n <= 105
        //-105 <= mat[i][j] <= 105
        public int MaxIncreasingCells(int[][] mat)
        {
            var m = mat.Length;
            var n = mat[0].Length;
            var row = new int[m];
            var col = new int[n];
            var dict = new Dictionary<int, List<int[]>>();
            for(var i=0;i<m;i++)
            {
                for(var j=0;j<n;j++)
                {
                    dict.TryAdd(mat[i][j], new List<int[]> ());
                    dict[mat[i][j]].Add(new int[] { i, j });
                }    
            }
            var keys = dict.Keys.Order();
            foreach(var key in keys)
            {
                var items = dict[key];
                var res = new List<int>();
                foreach(var item in items)
                {
                    var max = Math.Max(row[item[0]], col[item[1]]) + 1;
                    res.Add(max);
                }
                for(var i=0;i<items.Count;i++)
                {
                    var item = items[i];
                    var d = res[i];
                    row[item[0]] = Math.Max(row[item[0]], d);
                    col[item[1]] = Math.Max(col[item[1]], d);
                }
            }
            

            return row.Max();


        }

    }
}
