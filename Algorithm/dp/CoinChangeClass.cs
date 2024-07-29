using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class CoinChangeClass
    {
        //给你一个整数数组 coins ，表示不同面额的硬币；以及一个整数 amount ，表示总金额。
        //计算并返回可以凑成总金额所需的 最少的硬币个数 。如果没有任何一种硬币组合能组成总金额，返回 -1 。
        //你可以认为每种硬币的数量是无限的。
        //示例 1：

        //输入：coins = [1, 2, 5], amount = 11
        //输出：3 
        //解释：11 = 5 + 5 + 1
        //示例 2：

        //输入：coins = [2], amount = 3
        //输出：-1
        //示例 3：

        //输入：coins = [1], amount = 0
        //输出：0


        //提示：

        //1 <= coins.length <= 12
        //1 <= coins[i] <= 231 - 1
        //0 <= amount <= 104
        public int CoinChange(int[] coins, int amount)
        {
            var n = coins.Length;
            var dp = new int[amount+1];
            var max = amount + 1;
            for(var i=1;i<=amount;i++)
            {
                dp[i] = max;
                for(var j=0;j<n;j++)
                {
                    if (i - coins[j]>=0)
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]]+1);
                }
            }
            return dp[amount] >= max ? -1 : dp[amount];
        }
    }
}
