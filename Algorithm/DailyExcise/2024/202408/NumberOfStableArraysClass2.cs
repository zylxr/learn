using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class NumberOfStableArraysClass2
    {
        //找出所有稳定的二进制数组 II
        //给你 3 个正整数 zero ，one 和 limit 。

        //一个
        //二进制数组
        //arr 如果满足以下条件，那么我们称它是 稳定的 ：

        //0 在 arr 中出现次数 恰好 为 zero 。
        //1 在 arr 中出现次数 恰好 为 one 。
        //arr 中每个长度超过 limit 的
        //子数组
        //都 同时 包含 0 和 1 。
        //请你返回 稳定 二进制数组的 总 数目。

        //由于答案可能很大，将它对 109 + 7 取余 后返回。




        //示例 1：

        //输入：zero = 1, one = 1, limit = 2

        //输出：2

        //解释：

        //两个稳定的二进制数组为[1, 0] 和[0, 1] ，两个数组都有一个 0 和一个 1 ，且没有子数组长度大于 2 。

        //示例 2：

        //输入：zero = 1, one = 2, limit = 1

        //输出：1

        //解释：

        //唯一稳定的二进制数组是[1, 0, 1] 。

        //二进制数组[1, 1, 0] 和[0, 1, 1] 都有长度为 2 且元素全都相同的子数组，所以它们不稳定。

        //示例 3：

        //输入：zero = 3, one = 3, limit = 2

        //输出：14

        //解释：

        //所有稳定的二进制数组包括[0, 0, 1, 0, 1, 1] ，[0, 0, 1, 1, 0, 1] ，[0, 1, 0, 0, 1, 1] ，[0, 1, 0, 1, 0, 1] ，[0, 1, 0, 1, 1, 0] ，[0, 1, 1, 0, 0, 1] ，[0, 1, 1, 0, 1, 0] ，[1, 0, 0, 1, 0, 1] ，[1, 0, 0, 1, 1, 0] ，[1, 0, 1, 0, 0, 1] ，[1, 0, 1, 0, 1, 0] ，[1, 0, 1, 1, 0, 0] ，[1, 1, 0, 0, 1, 0] 和[1, 1, 0, 1, 0, 0] 。




        //提示：

        //1 <= zero, one, limit <= 1000

        const int MOD = 1000000007;
        int[][][] memo;
        int limit;
        public int NumberOfStableArrays(int zero, int one, int limit)
        {
            memo = new int[zero + 1][][];
            for(var i=0;i<=zero;i++)
            {
                memo[i] = new int[one + 1][];
                for(var j= 0;j<=one;j++)
                {
                    memo[i][j] = new int[2];
                    Array.Fill(memo[i][j], -1);
                }
            }
            this.limit = limit;
            return (DP(zero,one,0)+DP(zero,one,1)) % MOD;
        }
        public int DP(int zero, int one, int lastBit)
        {
            if (zero == 0) return lastBit == 0 || one > limit ? 0 : 1;
            if (one == 0) return lastBit == 1 || zero > limit ? 0 : 1;

            if (memo[zero][one][lastBit] == -1)
            {
                var res = 0;
                if(lastBit == 0)
                {
                    res = (DP(zero-1,one,0)+DP(zero-1,one,1) )% MOD;
                    if(zero>limit)
                        res = (res- DP(zero-limit-1,one,1)+MOD) % MOD;
                }else
                {
                    res = (DP(zero,one-1,0)+DP(zero,one-1,1))% MOD;
                    if(one>limit)
                        res = (res- DP(zero,one-1-limit,0)+MOD) % MOD;
                }
                memo[zero][one][lastBit] = res % MOD;
            }
            return memo[zero][one][lastBit];
        }

        public int NumberOfStableArraysDP(int zero, int one, int limit)
        {
            const int MOD = 1000000007;
            var dp = new int[zero + 1][][];
            for(var i=0;i<=zero;i++)
            {
                dp[i] = new int[one + 1][];
                for(var j=0;j<=one;j++)
                {
                    dp[i][j] = new int[2];
                    for (var lastBit = 0; lastBit <= 1; lastBit++)
                    {
                        if (i == 0)
                        {
                            if (lastBit == 0 || j > limit)
                                dp[i][j][lastBit] = 0;
                            else dp[i][j][lastBit] = 1;
                        }else if(j ==0)
                        {
                            if (lastBit == 1 || i > limit)
                                dp[i][j][lastBit] = 0;
                            else dp[i][j][lastBit] = 1;
                        }else if(lastBit == 0 )
                        {
                            dp[i][j][lastBit] = dp[i - 1][j][0] + dp[i - 1][j][1];
                            if (i > limit)
                                dp[i][j][lastBit] -= dp[i - limit - 1][j][1];
                        }else
                        {
                            dp[i][j][lastBit] = dp[i][j - 1][0] + dp[i][j - 1][1];
                            if (j > limit)
                                dp[i][j][lastBit] -= dp[i][j - 1 - limit][0];
                        }

                        dp[i][j][lastBit] %= MOD;
                        if (dp[i][j][lastBit] < 0)
                            dp[i][j][lastBit] += MOD;
                    }
                }
            }
            return (dp[zero][one][0] + dp[zero][one][1]) % MOD;
        }
    }
}
