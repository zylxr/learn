﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class PaintWallsClass
    {
        //给你两个长度为 n 下标从 0 开始的整数数组 cost 和 time ，分别表示给 n 堵不同的墙刷油漆需要的开销和时间。你有两名油漆匠：

        //一位需要 付费 的油漆匠，刷第 i 堵墙需要花费 time[i] 单位的时间，开销为 cost[i] 单位的钱。
        //一位 免费 的油漆匠，刷 任意 一堵墙的时间为 1 单位，开销为 0 。但是必须在付费油漆匠 工作 时，免费油漆匠才会工作。
        //请你返回刷完 n 堵墙最少开销为多少。



        //示例 1：

        //输入：cost = [1, 2, 3, 2], time = [1, 2, 3, 2]
        //输出：3
        //解释：下标为 0 和 1 的墙由付费油漆匠来刷，需要 3 单位时间。同时，免费油漆匠刷下标为 2 和 3 的墙，需要 2 单位时间，开销为 0 。总开销为 1 + 2 = 3 。
        //示例 2：

        //输入：cost = [2, 3, 4, 2], time = [1, 1, 1, 1]
        //输出：4
        //解释：下标为 0 和 3 的墙由付费油漆匠来刷，需要 2 单位时间。同时，免费油漆匠刷下标为 1 和 2 的墙，需要 2 单位时间，开销为 0 。总开销为 2 + 2 = 4 。


        //提示：

        //1 <= cost.length <= 500
        //cost.length == time.length
        //1 <= cost[i] <= 106
        //1 <= time[i] <= 500
        public int PaintWalls1(int[] cost, int[] time)
        {
            var n = cost.Length;
            var f = new int[2 * n + 1];
            Array.Fill(f, int.MaxValue >> 1);
            f[n] = 0;

            for (var i = 0; i < n; i++) 
            {
                var g = new int[2 * n + 1];
                Array.Fill(g, int.MaxValue >> 1);
                for(var j=0;j<2*n+1;j++)
                {
                    var ind = Math.Min(2 * n, j + time[i]);
                    //付费
                    g[ind] = Math.Min(g[ind], f[j] + cost[i]);
                    //免费
                    if (j > 0)
                        g[j -1] = Math.Min(g[j - 1], f[j]);
                }
                f = g;
            }
            var res = f[n];
            for (var i = n + 1; i <= 2 * n; i++)
                res = Math.Min(res, f[i]);
            return res;
        }

        public int PaintWalls2(int[] cost, int[] time)
        {
            var n = cost.Length;
            var f = new int[n + 2];
            Array.Fill(f, int.MaxValue >> 1);
            f[0] = 0;
            for (var i = 0; i < n; i++)
            {
                for (var j = n + 1; j >= 0; j--)
                {
                    f[Math.Min(j + time[i], n) + 1] = Math.Min(f[Math.Min(j + time[i], n) + 1], f[j] + cost[i]);
                }
            }
            return Math.Min(f[n], f[n+1]);
        }
    }
}
