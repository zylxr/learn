using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxScoreClass2
    {
        //矩阵中的最大得分
        //给你一个由 正整数 组成、大小为 m x n 的矩阵 grid。你可以从矩阵中的任一单元格移动到另一个位于正下方或正右侧的任意单元格（不必相邻）。从值为 c1 的单元格移动到值为 c2 的单元格的得分为 c2 - c1 。

        //你可以从 任一 单元格开始，并且必须至少移动一次。

        //返回你能得到的 最大 总得分。

        //示例 1：
        //输入：grid = [[9, 5, 7, 3],[8, 9, 6, 1],[6, 7, 14, 3],[2, 5, 3, 1]]

        //输出：9

        //解释：从单元格(0, 1) 开始，并执行以下移动：
        //- 从单元格(0, 1) 移动到(2, 1)，得分为 7 - 5 = 2 。
        //- 从单元格(2, 1) 移动到(2, 2)，得分为 14 - 7 = 7 。
        //总得分为 2 + 7 = 9 。

        //示例 2：
        //输入：grid = [[4, 3, 2],[3, 2, 1]]

        //输出：-1

        //解释：从单元格(0, 0) 开始，执行一次移动：从(0, 0) 到(0, 1) 。得分为 3 - 4 = -1 。
        //提示：

        //m == grid.length
        //n == grid[i].length
        //2 <= m, n <= 1000
        //4 <= m* n <= 105
        //1 <= grid[i][j] <= 105

        //https://oi-wiki.org/basic/prefix-sum/?query=%E5%89%8D%E7%BC%80%E5%92%8C#%E4%BA%8C%E7%BB%B4%E5%A4%9A%E7%BB%B4%E5%89%8D%E7%BC%80%E5%92%8C
        public int MaxScore1(IList<IList<int>> grid)
        {
            var m = grid.Count;
            var n = grid[0].Count;
            var prerow = new int[m][];
            var precol = new int[m][];
            var f = new int[m][];
            for(var i=0;i<m;i++)
            {
                precol[i] = new int[n];
                prerow[i] = new int[n];
                f[i] = new int[n];
                Array.Fill(f[i], int.MinValue);
            }
            var ans = int.MinValue;
            for(var i=0;i<m;i++)
            {
                for(var j=0;j<n;j++)
                {
                    if (i > 0)
                        f[i][j] = Math.Max(f[i][j], grid[i][j] + precol[i - 1][j]);
                    if (j > 0)
                        f[i][j] = Math.Max(f[i][j], grid[i][j] + prerow[i][j - 1]);
                    ans = Math.Max(ans, f[i][j]);
                    prerow[i][j] = precol[i][j] = Math.Max(f[i][j],0)-grid[i][j];
                    if (i > 0)
                        precol[i][j] = Math.Max(precol[i][j], precol[i - 1][j]);
                    if (j > 0)
                        prerow[i][j] = Math.Max(prerow[i][j], prerow[i][j - 1]);
                }
            }
            return ans;
        }

        public int MaxScore2(IList<IList<int>> grid)
        {
            var m = grid.Count;
            var n = grid[0].Count;
            var precol = new int[n];
            Array.Fill(precol, int.MinValue);
            var ans = int.MinValue;
            for(var i=0;i<m;i++)
            {
                var prerow = int.MinValue;
                for(var j=0;j<n;j++)
                {
                    var f = int.MinValue;
                    if (i > 0)
                        f = Math.Max(f, grid[i][j] + precol[j]);
                    if (j > 0)
                        f = Math.Max(f, grid[i][j] + prerow);
                    ans = Math.Max(ans, f);
                    precol[j] = Math.Max(precol[j], Math.Max(f, 0) - grid[i][j]);
                    prerow = Math.Max(prerow, Math.Max(f,0)-grid[i][j]);
                }
            }
            return ans;
        }

        public int MaxScore3(IList<IList<int>> grid)
        {
            var m = grid.Count;
            var n = grid[0].Count;
            var premin = new int[m][];
            for (var i = 0; i < m; i++)
            {
                premin[i] = new int[n];
                Array.Fill(premin[i], int.MinValue);
            }
            var ans = int.MinValue;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    var pre = int.MaxValue;
                    if (i > 0)
                        pre = Math.Min(pre, premin[i - 1][j]);
                    if (j > 0)
                        pre = Math.Min(pre, premin[i][j - 1]);
                    //i=j=0 时没有转移
                    if (i + j > 0)
                        ans = Math.Max(ans, grid[i][j] - pre);
                    premin[i][j] = Math.Min(pre, grid[i][j]);
                }
            }
            return ans;
        }

        public int MaxScore4(IList<IList<int>> grid)
        {
            var m = grid.Count;
            var n = grid[0].Count;
            var premin = new int[2][];
            for(var i=0;i<2;i++)
            {
                premin[i] = new int[n];
                Array.Fill(premin[i], int.MaxValue);
            }
            var ans = int.MinValue;
            for(var i=0;i<m;i++)
            {
                Array.Fill(premin[i & 1], int.MaxValue);
                for(var j=0;j<n;j++)
                {
                    var pre = int.MaxValue;
                    if (i > 0)
                        pre = Math.Min(pre, premin[(i - 1) & 1][j]);
                    if (j > 0)
                        pre = Math.Min(pre, premin[i & 1][j - 1]);
                    if (i + j > 0)
                        ans = Math.Max(ans, grid[i][j] - pre);
                    premin[i & 1][j] = Math.Min(pre, grid[i][j]);
                }
            }
            return ans;
        }
    }
}
