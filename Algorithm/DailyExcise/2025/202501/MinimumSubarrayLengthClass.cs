using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{

    public class MinimumSubarrayLengthClass
    {
        //3097. 或值至少为 K 的最短子数组 II
        //给你一个 非负 整数数组 nums 和一个整数 k 。

        //如果一个数组中所有元素的按位或运算 OR 的值 至少 为 k ，那么我们称这个数组是 特别的 。

        //请你返回 nums 中 最短特别非空
        //子数组
        //的长度，如果特别子数组不存在，那么返回 -1 。



        //示例 1：

        //输入：nums = [1, 2, 3], k = 2

        //输出：1

        //解释：

        //子数组[3] 的按位 OR 值为 3 ，所以我们返回 1 。

        //示例 2：

        //输入：nums = [2, 1, 8], k = 10

        //输出：3

        //解释：

        //子数组[2, 1, 8] 的按位 OR 值为 11 ，所以我们返回 3 。

        //示例 3：

        //输入：nums = [1, 2], k = 0

        //输出：1

        //解释：

        //子数组[1] 的按位 OR 值为 1 ，所以我们返回 1 。



        //提示：

        //1 <= nums.length <= 2 * 105
        //0 <= nums[i] <= 109
        //0 <= k <= 109

        public int MinimumSubarrayLength(int[] nums, int k)
        {
            var n = nums.Length;
            var bits = new int[30];
            var res = int.MaxValue;
            for(int l=0,r=0;r<n;r++)
            {
                for (var i = 0; i < 30; i++)
                    bits[i] += (nums[r] >> i) & 1;
                while(l<=r && Count(bits) >= k)
                {
                    res = Math.Min(res, r - l + 1);
                    for (var i = 0; i < 30; i++)
                        bits[i] -= (nums[l] >> i) & 1;
                    l++;
                }
            }
            return res == int.MaxValue ? -1 : res;
        }

        private int Count(int[] bits)
        {
            var ans = 0;
            for(var i=0;i<bits.Length;i++)
                ans |= (bits[i]<<i);
            return ans;
        }
    }
}
