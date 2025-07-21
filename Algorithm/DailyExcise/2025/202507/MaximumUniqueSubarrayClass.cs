using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaximumUniqueSubarrayClass
    {
        //1695. 删除子数组的最大得分
        //给你一个正整数数组 nums ，请你从中删除一个含有 若干不同元素 的子数组。删除子数组的 得分 就是子数组各元素之 和 。

        //返回 只删除一个 子数组可获得的 最大得分 。

        //如果数组 b 是数组 a 的一个连续子序列，即如果它等于 a[l], a[l + 1],..., a[r] ，那么它就是 a 的一个子数组。



        //示例 1：

        //输入：nums = [4, 2, 4, 5, 6]
        //输出：17
        //解释：最优子数组是[2, 4, 5, 6]
        //示例 2：

        //输入：nums = [5, 2, 1, 2, 5, 2, 1, 2, 5]
        //输出：8
        //解释：最优子数组是[5, 2, 1] 或[1, 2, 5]



        //提示：

        //1 <= nums.length <= 105
        //1 <= nums[i] <= 104

        public int MaximumUniqueSubarray(int[] nums)
        {
            var hs = new HashSet<int>();
            var sum = 0;
            int l = 0, r = 0;
            var n = nums.Length;
            var ans = 0;
            while (l < n)
            {
                while (r < n && !hs.Contains(nums[r]))
                {
                    sum += nums[r];
                    hs.Add(nums[r]);
                    r++;
                }
                ans = Math.Max(ans, sum);
                sum -= nums[l];
                hs.Remove(nums[l]);
                l++;
            }
            return ans;
        }

        public int MaximumUniqueSubarray2(int[] nums)
        {
            var n = nums.Length;
            var psum = new int[n + 1];
            var cnt = new Dictionary<int, int>();
            var ans = 0;
            var pre = 0;
            for (var i = 0; i < n; i++) {
                psum[i + 1] = psum[i] + nums[i];
                pre = Math.Max(pre, cnt.GetValueOrDefault(nums[i], 0));
                ans = Math.Max(ans, psum[i + 1] - psum[pre]);
                cnt[nums[i]] = i+1;
            }
            return ans;
        }
    }
}
