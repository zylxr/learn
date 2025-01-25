using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Algorithm.DailyExcise
{
    public class KnightDialerClass
    {
        //935. 骑士拨号器
        //象棋骑士有一个独特的移动方式，它可以垂直移动两个方格，水平移动一个方格，或者水平移动两个方格，垂直移动一个方格(两者都形成一个 L 的形状)。

        //象棋骑士可能的移动方式如下图所示:



        //我们有一个象棋骑士和一个电话垫，如下所示，骑士只能站在一个数字单元格上(即蓝色单元格)。



        //给定一个整数 n，返回我们可以拨多少个长度为 n 的不同电话号码。

        //你可以将骑士放置在任何数字单元格上，然后你应该执行 n - 1 次移动来获得长度为 n 的号码。所有的跳跃应该是有效的骑士跳跃。

        //因为答案可能很大，所以输出答案模 109 + 7.



        //示例 1：

        //输入：n = 1
        //输出：10
        //解释：我们需要拨一个长度为1的数字，所以把骑士放在10个单元格中的任何一个数字单元格上都能满足条件。
        //示例 2：

        //输入：n = 2
        //输出：20
        //解释：我们可以拨打的所有有效号码为[04, 06, 16, 18, 27, 29, 34, 38, 40, 43, 49, 60, 61, 67, 72, 76, 81, 83, 92, 94]
        //示例 3：

        //输入：n = 3131
        //输出：136006598
        //解释：注意取模


        //提示：

        //1 <= n <= 5000

        public int KnightDialer(int n)
        {
            var MOD = (int)(1e+9)+7;
            var moves = new int[][] {
                new int[]{ 4,6},
                new int[]{6,8 },
                new int[]{7,9 },
                new int[]{4,8 },
                new int[]{ 3,9,0 },
                new int[]{ },
                new int[]{ 1,7,0},
                new int[]{ 2,6},
                new int[]{ 1,3  },
                new int[]{ 2,4}
            };
            var d = new int[2][];
            for (var i = 0; i < 2; i++)
                d[i] = new int[10];
            Array.Fill(d[1], 1);
            for(var i=2;i<=n;i++)
            {
                var x = i & 1;
                for(var j=0;j<10;j++)
                {
                    d[x][j] = 0;
                    foreach (var k in moves[j])
                        d[x][j] = (d[x][j] + d[x ^ 1][k]) % MOD;
                }
            }
            var res = 0;
            foreach(var x in d[n%2])
                res = (res+x) % MOD;
            return res;
        }

        const int MOD = (int)(1e+9) + 7;
        public int KnightDialer2(int n)
        {
            
            var original = new int[][] {
                new int[]{0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
                new int[]{0, 0, 0, 0, 0, 0, 1, 0, 1, 0},
                new int[]{0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
                new int[]{0, 0, 0, 0, 1, 0, 0, 0, 1, 0},
                new int[]{1, 0, 0, 1, 0, 0, 0, 0, 0, 1},
                new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                new int[]{1, 1, 0, 0, 0, 0, 0, 1, 0, 0},
                new int[]{0, 0, 1, 0, 0, 0, 1, 0, 0, 0},
                new int[]{0, 1, 0, 1, 0, 0, 0, 0, 0, 0},
                new int[]{0, 0, 1, 0, 1, 0, 0, 0, 0, 0}
            };
            var res = new int[][] {
                new int[]{1,1,1,1,1,1,1,1,1,1 }
            };
            var original2 = new int[10][];
            for(var i=0;i<10;i++)
            {
                original2[i] = new int[10];
                original2[i][i] = 1;
            }

            n--;
            while(n>0)
            {
                if ((n & 1) != 0)
                    original2 = Mul(original2, original);
                original = Mul(original, original);
                n >>= 1;
            }

            res = Mul(res, original2);
            var ret = 0;
            foreach (var x in res[0])
                ret = (ret + x) % MOD;
            return ret;
        }

        public int[][] Mul(int[][] lth, int[][] rth)
        {
            var res = new int[lth.Length][];
            for (var i = 0; i < lth.Length; i++)
                res[i] = new int[rth[0].Length];
            for(var k = 0; k < lth[0].Length;k++)
                for(var i=0;i<lth.Length;i++)
                    for(var j = 0; j < rth[0].Length;j++)
                        res[i][j] = (int)((res[i][j] + 1L * lth[i][k] * rth[k][j]% MOD)%MOD);
            return res;
        }
    }
}
