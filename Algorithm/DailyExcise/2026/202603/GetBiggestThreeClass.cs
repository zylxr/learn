using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class GetBiggestThreeClass
    {
        //1878. 矩阵中最大的三个菱形和
        //给你一个 m x n 的整数矩阵 grid 。

        //菱形和 指的是 grid 中一个正菱形 边界 上的元素之和。本题中的菱形必须为正方形旋转45度，且四个角都在一个格子当中。下图是四个可行的菱形，每个菱形和应该包含的格子都用了相应颜色标注在图中。




        //注意，菱形可以是一个面积为 0 的区域，如上图中右下角的紫色菱形所示。

        //请你按照 降序 返回 grid 中三个最大的 互不相同的菱形和 。如果不同的和少于三个，则将它们全部返回。



        //示例 1：


        //输入：grid = [[3, 4, 5, 1, 3],[3, 3, 4, 2, 3],[20, 30, 200, 40, 10],[1, 5, 5, 4, 1],[4, 3, 2, 2, 5]]
        //输出：[228, 216, 211]
        //解释：最大的三个菱形和如上图所示。
        //- 蓝色：20 + 3 + 200 + 5 = 228
        //- 红色：200 + 2 + 10 + 4 = 216
        //- 绿色：5 + 200 + 4 + 2 = 211
        //示例 2：


        //输入：grid = [[1, 2, 3],[4, 5, 6],[7, 8, 9]]
        //输出：[20, 9, 8]
        //解释：最大的三个菱形和如上图所示。
        //- 蓝色：4 + 2 + 6 + 8 = 20
        //- 红色：9 （右下角红色的面积为 0 的菱形）
        //- 绿色：8 （下方中央面积为 0 的菱形）
        //示例 3：

        //输入：grid = [[7, 7, 7]]
        //输出：[7]
        //解释：所有三个可能的菱形和都相同，所以返回[7] 。


        //提示：

        //m == grid.length
        //n == grid[i].length
        //1 <= m, n <= 100
        //1 <= grid[i][j] <= 105
        public int[] GetBiggestThree(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var sum1 = new int[m+1,n+2];
            var sum2 = new int[m+1,n+2];
            for(var i=1;i<=m;i++)
            {
                for(var j=1;j<=n;j++)
                {
                    sum1[i, j] = sum1[i - 1, j - 1] + grid[i-1][j-1];
                    sum2[i, j] = sum2[i - 1, j + 1] + grid[i-1][j-1];
                }
            }
            var ans = new Answer();
            for(var i=0;i<m;i++)
            {
                for(var j=0;j<n;j++)
                {
                    ans.Put(grid[i][j]);
                    for(var k=i+2;k<m;k+=2)
                    {
                        var ux = i;
                        var uy = j;
                        var dx = k;
                        var dy = j;
                        var lx = (i + k) / 2;
                        var ly = j - (k - i) / 2;
                        var rx = (i + k) / 2;
                        var ry = j + (k - i) / 2;
                        if (ly < 0 || ry >= n) break;
                        var sum = (sum2[lx + 1, ly + 1] - sum2[ux, uy + 2]) +
                            (sum1[rx + 1, ry + 1] - sum1[ux, uy]) +
                            (sum1[dx + 1, dy + 1] - sum1[lx, ly]) +
                            (sum2[dx + 1, dy + 1] - sum2[rx, ry + 2]) -
                            (grid[ux][uy] + grid[dx][dy] + grid[lx][ly] + grid[rx][ry]);
                        ans.Put(sum);
                    }
                }
            }
            var resultList = ans.Get();
            return resultList.ToArray();
        }
        
    }
    public class Answer
    {
        private int[] ans;
        public Answer()
        {
            ans = new int[3];
        }

        public void Put(int x)
        {
            if (x > ans[0])
            {
                ans[2] = ans[1];
                ans[1] = ans[0];
                ans[0] = x;
            }
            else if (x != ans[0] && x > ans[1])
            {
                ans[2] = ans[1];
                ans[1] = x;
            }
            else if (x != ans[0] && x != ans[1] && x > ans[2])
                ans[2] = x;
        }
        public List<int> Get()
        {
            var ret = new List<int>();
            foreach (var num in ans) if (num != 0) ret.Add(num); 
            return ret;
        }
    }
}
