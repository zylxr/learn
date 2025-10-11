using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaximumTotalDamageClass
    {
        //3186. 施咒的最大总伤害
        //一个魔法师有许多不同的咒语。

        //给你一个数组 power ，其中每个元素表示一个咒语的伤害值，可能会有多个咒语有相同的伤害值。

        //已知魔法师使用伤害值为 power[i] 的咒语时，他们就 不能 使用伤害为 power[i] - 2 ，power[i] - 1 ，power[i] + 1 或者 power[i] + 2 的咒语。

        //每个咒语最多只能被使用 一次 。

        //请你返回这个魔法师可以达到的伤害值之和的 最大值 。




        //示例 1：

        //输入：power = [1, 1, 3, 4]

        //输出：6

        //解释：

        //可以使用咒语 0，1，3，伤害值分别为 1，1，4，总伤害值为 6 。

        //示例 2：

        //输入：power = [7, 1, 6, 6]

        //输出：13

        //解释：

        //可以使用咒语 1，2，3，伤害值分别为 1，6，6，总伤害值为 13 。



        //提示：

        //1 <= power.length <= 105
        //1 <= power[i] <= 109
        public long MaximumTotalDamage(int[] power)
        {
            Array.Sort(power);
            var n = power.Length;
            var dp = new long[n];
            dp[0] = power[0];
            var ans = dp[0];
            var j = 0;
            var max = 0L;
            for (var i = 1; i < n; i++)
            {
                dp[i] = power[i];
                for (; power[j] < power[i] - 2; j++)
                {
                    max = Math.Max(max, dp[j]);
                }
                if (power[i] == power[i - 1]) dp[i] += dp[i - 1];
                else dp[i] += max;

                ans = Math.Max(ans, dp[i]);
            }
            return ans;
        }
    }
}
