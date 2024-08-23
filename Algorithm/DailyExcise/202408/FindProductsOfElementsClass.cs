using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class FindProductsOfElementsClass
    {
        //大数组元素的乘积
        //一个非负整数 x 的 强数组 指的是满足元素为 2 的幂且元素总和为 x 的最短有序数组。下表说明了如何确定 强数组 的示例。可以证明，x 对应的强数组是独一无二的。

        //数字 二进制表示   强数组
        //1	00001	[1]
        //8	01000	[8]
        //10	01010	[2, 8]
        //13	01101	[1, 4, 8]
        //23	10111	[1, 2, 4, 16]


        //我们将每一个升序的正整数 i （即1，2，3等等）的 强数组 连接得到数组 big_nums ，big_nums 开始部分为[1, 2, 1, 2, 4, 1, 4, 2, 4, 1, 2, 4, 8, ...] 。

        //给你一个二维整数数组 queries ，其中 queries[i] = [fromi, toi, modi] ，你需要计算(big_nums[fromi]* big_nums[fromi + 1] * ... * big_nums[toi]) % modi 。

        //请你返回一个整数数组 answer ，其中 answer[i] 是第 i 个查询的答案。



        //示例 1：

        //输入：queries = [[1, 3, 7]]

        //输出：[4]

        //解释：

        //只有一个查询。

        //big_nums[1..3] = [2, 1, 2] 。它们的乘积为 4。结果为 4 % 7 = 4。

        //示例 2：

        //输入：queries = [[2, 5, 3],[7, 7, 4]]

        //输出：[2, 2]

        //解释：

        //有两个查询。

        //第一个查询：big_nums[2..5] = [1, 2, 4, 1] 。它们的乘积为 8 。结果为  8 % 3 = 2。

        //第二个查询：big_nums[7] = 2 。结果为 2 % 4 = 2。



        //提示：

        //1 <= queries.length <= 500
        //queries[i].length == 3
        //0 <= queries[i][0] <= queries[i][1] <= 1015
        //1 <= queries[i][2] <= 105
        public int[] FindProductsOfElements(long[][] queries)
        {
            var ans = new int[queries.Length];
            for(var i=0;i<queries.Length; i++)
            {
                //偏移让数组下标从 1 开始
                queries[i][0]++;
                queries[i][1]++;
                var l = MidCheck(queries[i][0]);
                var r = MidCheck(queries[i][1]);
                var mod = (int)queries[i][2];

                long res = 1;
                long pre = CountOne(l - 1);
                for(var j =0;j<60;j++)
                {
                    if((1L<<j & l) != 0)
                    {
                        pre++;
                        if (pre >= queries[i][0] && pre <= queries[i][1])
                            res = res * (1L << j) % mod;
                    }
                }

                if(r>l)
                {
                    long bac = CountOne(r - 1);
                    for(var j=0;j<60; j++)
                    {
                        if((1L<<j & r) != 0) 
                        {
                            bac++;
                            if (bac >= queries[i][0] && bac <= queries[i][1])
                                res = res * (1L << j) % mod;
                        }
                    }
                }

                if(r-l>1)
                {
                    long xs = CountPow(r - 1) - CountPow(l);
                    res = res * PowMod(2L, xs, mod) % mod;
                }
                ans[i] = (int)res;
            }
            return ans;
        }

        public long MidCheck(long x)
        {
            long l =1 , r = (long)1e15;
            while(l<r)
            {
                long mid = (l + r) >> 1;
                if (CountOne(mid) >= x)
                {
                    r = mid;
                }
                else
                    l = mid + 1;
            }
            return r;
        }

        //计算 <= x 的所有数的数位 1 的和 
        public long CountOne(long x)
        {
            long res = 0;
            int sum = 0;
            for(var i=60;i>=0;i--)
            {
                if((1L<<i &x)!= 0)
                {
                    res += 1L * sum * (1L << i);
                    sum += 1;
                    if (i > 0)
                        res += 1L * i * (1L << (i - 1));
                }
            }
            res += sum;
            return res;
        }

        //计算 <=x 所有数的数位对幂的贡献之和
        public long CountPow(long x)
        {
            long res = 0;
            int sum = 0;
            for(var i=60;i>=0;i--)
            {
                if((1L<<i & x)!=0)
                {
                    res += 1L * sum * (1L << i);
                    sum += i;
                    if (i > 0)
                        res += 1L * i * (i - 1) / 2 * (1L << (i - 1));
                }
            }
            res += sum;
            return res;
        }
        public int PowMod(long x, long y, int mod)
        {
            long res = 1;
            while(y!=0)
            {
                if((y & 1)!=0)
                    res = res * x%mod;
                x = x * x % mod;
                y >>= 1;
            }
            return (int)res;
        }
    }
}
