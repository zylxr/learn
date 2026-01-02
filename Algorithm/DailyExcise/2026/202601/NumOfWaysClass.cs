using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class NumOfWaysClass
    {
        //1411. 给 N x 3 网格图涂色的方案数
        //你有一个 n x 3 的网格图 grid ，你需要用 红，黄，绿 三种颜色之一给每一个格子上色，且确保相邻格子颜色不同（也就是有相同水平边或者垂直边的格子颜色不同）。

        //给你网格图的行数 n 。

        //请你返回给 grid 涂色的方案数。由于答案可能会非常大，请你返回答案对 10^9 + 7 取余的结果。



        //示例 1：

        //输入：n = 1
        //输出：12
        //解释：总共有 12 种可行的方法：

        //示例 2：

        //输入：n = 2
        //输出：54
        //示例 3：

        //输入：n = 3
        //输出：246
        //示例 4：

        //输入：n = 7
        //输出：106494
        //示例 5：

        //输入：n = 5000
        //输出：30228214


        //提示：

        //n == grid.length
        //grid[i].length == 3
        //1 <= n <= 5000
        public int NumOfWays(int n)
        {
            var mod = 1_000_000_007;
            var types = new List<int>();
            for(var i=0;i<3;i++)
            {
                for(var j=0;j<3;j++)
                {
                    for (var k = 0; k < 3; k++)
                        if (i != j && j != k) types.Add(i * 9 + j * 3 + k);
                }
            }

            var type_cnt = types.Count;
            var related = new int[type_cnt][];
            for(var i=0;i< type_cnt;i++)
            {
                related[i] = new int[type_cnt];
                var x1 = types[i] / 9;
                var x2 = types[i] / 3%3;
                var x3 = types[i] % 3;
                for(var j=0;j< type_cnt;j++)
                {
                    var y1 = types[j] / 9;
                    var y2 = types[j] / 3 % 3;
                    var y3 = types[j] % 3;
                    if (x1 != y1 && x2 != y2 && x3 != y3) related[i][j] = 1;
                }
            }

            var f = new int[n + 1][];
            for (var i = 0; i <= n; i++)
                f[i] = new int[type_cnt];
            for (var i = 0; i < type_cnt; i++) f[1][i] = 1;
            for (var i = 2; i <= n; i++)
                for (var j = 0; j < type_cnt; j++)
                    for (var k = 0; k < type_cnt; k++)
                        if (related[k][j] == 1) f[i][j] = (f[i][j] + f[i - 1][k]) % mod;

            var ans = 0;
            for(var i=0;i<type_cnt;i++)ans = (ans + f[n][i]) % mod;
            return ans;
        }
    }
}
