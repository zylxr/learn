using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaximumLengthClass4
    {
        //3202. 找出有效子序列的最大长度 II
        //给你一个整数数组 nums 和一个 正 整数 k 。
        //nums 的一个 子序列 sub 的长度为 x ，如果其满足以下条件，则称其为 有效子序列 ：

        //(sub[0] + sub[1]) % k == (sub[1] + sub[2]) % k == ... == (sub[x - 2] + sub[x - 1]) % k
        //返回 nums 的 最长有效子序列 的长度。



        //示例 1：

        //输入：nums = [1, 2, 3, 4, 5], k = 2

        //输出：5

        //解释：

        //最长有效子序列是[1, 2, 3, 4, 5] 。

        //示例 2：

        //输入：nums = [1, 4, 2, 3, 1, 4], k = 3

        //输出：4

        //解释：

        //最长有效子序列是[1, 4, 1, 4] 。



        //提示：

        //2 <= nums.length <= 103
        //1 <= nums[i] <= 107
        //1 <= k <= 103
        public int MaximumLength(int[] nums, int k)
        {
            var dp = new int[k, k];
            var res = 0;
            foreach(var num in nums)
            {
                var mod = num % k;
                for(var prev =0;prev<k;prev++)
                {
                    dp[prev, mod] = dp[prev, mod] + 1;
                    res = Math.Max(res, dp[prev, mod]);
                }
            }
            return res;
        }
    }
}
