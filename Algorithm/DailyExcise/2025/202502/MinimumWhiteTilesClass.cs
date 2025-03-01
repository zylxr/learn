using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinimumWhiteTilesClass
    {
        //2209. 用地毯覆盖后的最少白色砖块
        //给你一个下标从 0 开始的 二进制 字符串 floor ，它表示地板上砖块的颜色。

        //floor[i] = '0' 表示地板上第 i 块砖块的颜色是 黑色 。
        //floor[i] = '1' 表示地板上第 i 块砖块的颜色是 白色 。
        //同时给你 numCarpets 和 carpetLen 。你有 numCarpets 条 黑色 的地毯，每一条 黑色 的地毯长度都为 carpetLen 块砖块。请你使用这些地毯去覆盖砖块，使得未被覆盖的剩余 白色 砖块的数目 最小 。地毯相互之间可以覆盖。

        //请你返回没被覆盖的白色砖块的 最少 数目。



        //示例 1：



        //输入：floor = "10110101", numCarpets = 2, carpetLen = 2
        //输出：2
        //解释：
        //上图展示了剩余 2 块白色砖块的方案。
        //没有其他方案可以使未被覆盖的白色砖块少于 2 块。
        //示例 2：



        //输入：floor = "11111", numCarpets = 2, carpetLen = 3
        //输出：0
        //解释：
        //上图展示了所有白色砖块都被覆盖的一种方案。
        //注意，地毯相互之间可以覆盖。


        //提示：

        //1 <= carpetLen <= floor.length <= 1000
        //floor[i] 要么是 '0' ，要么是 '1' 。
        //1 <= numCarpets <= 1000

        const int INF = 0x3f3f3f3f;
        public int MinimumWhiteTiles(string floor, int numCarpets, int carpetLen)
        {
            var n = floor.Length;
            int[,] d = new int[n + 1, numCarpets + 1];
            for(var i=0;i<=n;i++)
            {
                for (var j = 0; j <= numCarpets; j++)
                    d[i, j] = INF;
            }
            for (var j = 0; j <= numCarpets; j++)
                d[0, j] = 0;
            for (var i = 1; i <= n; i++)
                d[i, 0] = d[i - 1, 0] + (floor[i - 1] == '1' ? 1 : 0);
            for(var i=1;i<=n;i++)
            {
                for(var j= 1;j<=numCarpets;j++)
                {
                    d[i, j] = d[i - 1, j] + (floor[i - 1] == '1' ? 1 : 0);
                    d[i, j] = Math.Min(d[i, j], d[Math.Max(0, i - carpetLen), j - 1]);
                }
            }
            return d[n, numCarpets];
        }

        public int MinimumWhiteTiles2(string floor, int numCarpets, int carpetLen)
        {
            var n = floor.Length;
            var d = new int[n + 1];
            var f = new int[n + 1];
            Array.Fill(d, INF);
            Array.Fill(f, INF);
            d[0] = 0;
            for (var i = 1; i <= n; i++)
                d[i] = d[i - 1] + (floor[i - 1] == '1' ? 1 : 0);
            for(var j=1;j<=numCarpets;j++)
            {
                f[0] = 0;
                for(var i=1;i<=n;i++)
                {
                    f[i] = f[i - 1] + (floor[i - 1] == '1' ? 1 : 0);
                    f[i] = Math.Min(f[i], d[Math.Max(0, i - carpetLen)]);
                }
                var tmp = d;
                d = f;
                f = tmp;
            }
            return d[n];
        }
    }
}
