﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class WaysToReachStairClass
    {
        //到达第 K 级台阶的方案数
        //给你有一个 非负 整数 k 。有一个无限长度的台阶，最低 一层编号为 0 。

        //Alice 有一个整数 jump ，一开始值为 0 。Alice 从台阶 1 开始，可以使用 任意 次操作，目标是到达第 k 级台阶。假设 Alice 位于台阶 i ，一次 操作 中，Alice 可以：

        //向下走一级到 i - 1 ，但该操作 不能 连续使用，如果在台阶第 0 级也不能使用。
        //向上走到台阶 i + 2jump 处，然后 jump 变为 jump + 1 。
        //请你返回 Alice 到达台阶 k 处的总方案数。

        //注意，Alice 可能到达台阶 k 处后，通过一些操作重新回到台阶 k 处，这视为不同的方案。



        //示例 1：

        //输入：k = 0

        //输出：2

        //解释：

        //2 种到达台阶 0 的方案为：

        //Alice 从台阶 1 开始。
        //执行第一种操作，从台阶 1 向下走到台阶 0 。
        //Alice 从台阶 1 开始。
        //执行第一种操作，从台阶 1 向下走到台阶 0 。
        //执行第二种操作，向上走 20 级台阶到台阶 1 。
        //执行第一种操作，从台阶 1 向下走到台阶 0 。
        //示例 2：

        //输入：k = 1

        //输出：4

        //解释：

        //4 种到达台阶 1 的方案为：

        //Alice 从台阶 1 开始，已经到达台阶 1 。
        //Alice 从台阶 1 开始。
        //执行第一种操作，从台阶 1 向下走到台阶 0 。
        //执行第二种操作，向上走 20 级台阶到台阶 1 。
        //Alice 从台阶 1 开始。
        //执行第二种操作，向上走 20 级台阶到台阶 2 。
        //执行第一种操作，向下走 1 级台阶到台阶 1 。
        //Alice 从台阶 1 开始。
        //执行第一种操作，从台阶 1 向下走到台阶 0 。
        //执行第二种操作，向上走 20 级台阶到台阶 1 。
        //执行第一种操作，向下走 1 级台阶到台阶 0 。
        //执行第二种操作，向上走 21 级台阶到台阶 2 。
        //执行第一种操作，向下走 1 级台阶到台阶 1 。


        //提示：

        //0 <= k <= 109
        public int WaysToReachStair(int k)
        {
            var n = 0;
            var npow = 1;
            var ans = 0;
            while(true)
            {
                if (npow - n - 1 <= k && k <= npow)
                {
                    ans += Comb(n + 1, npow - k);
                }
                else if (npow - n - 1 > k) break;
                ++n;
                npow *= 2;
            }
            return ans;
        }

        public int Comb(int n, int k)
        {
            long ans = 1;
            for(var i=n;i>=n-k+1;i--)
            {
                ans *= i;
                ans /= n - i + 1;
            }
            return (int)ans;
        }
    }
}
