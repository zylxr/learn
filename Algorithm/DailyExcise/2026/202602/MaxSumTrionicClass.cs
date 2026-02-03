using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxSumTrionicClass
    {
        //3640. 三段式数组 II
        //给你一个长度为 n 的整数数组 nums。

        //三段式子数组 是一个连续子数组 nums[l...r]（满足 0 <= l<r<n），并且存在下标 l<p < q<r，使得：

        //nums[l...p] 严格 递增，
        //nums[p...q] 严格 递减，
        //nums[q...r] 严格 递增。
        //请你从数组 nums 的所有三段式子数组中找出和最大的那个，并返回其 最大 和。




        //示例 1：

        //输入：nums = [0, -2, -1, -3, 0, 2, -1]

        //输出：-4

        //解释：

        //选择 l = 1, p = 2, q = 3, r = 5：

        //nums[l...p] = nums[1...2] = [-2, -1] 严格递增 (-2 < -1)。
        //nums[p...q] = nums[2...3] = [-1, -3] 严格递减(-1 > -3)。
        //nums[q...r] = nums[3...5] = [-3, 0, 2] 严格递增(-3 < 0 < 2)。
        //和 = (-2) + (-1) + (-3) + 0 + 2 = -4。
        //示例 2:

        //输入: nums = [1, 4, 2, 7]

        //输出: 14

        //解释:

        //选择 l = 0, p = 1, q = 2, r = 3：

        //nums[l...p] = nums[0...1] = [1, 4] 严格递增(1 < 4)。
        //nums[p...q] = nums[1...2] = [4, 2] 严格递减(4 > 2)。
        //nums[q...r] = nums[2...3] = [2, 7] 严格递增(2 < 7)。
        //和 = 1 + 4 + 2 + 7 = 14。


        //提示:

        //4 <= n = nums.length <= 105
        //-109 <= nums[i] <= 109
        //保证至少存在一个三段式子数组。
        public long MaxSumTrionic(int[] nums)
        {
            var n = nums.Length;
            int p, q;
            var ans = long.MinValue;
            long sum, max_sum, res;

            for (var i = 0; i < n; i++)
            {
                var j = i + 1;
                res = 0;
                for (; j < n && nums[j] > nums[j - 1]; j++) ;
                p = j - 1;
                if (p == i) continue;
                res += nums[p] + nums[p - 1];
                for (; j < n && nums[j] < nums[j - 1]; j++)
                {
                    res += nums[j];
                }
                q = j - 1;
                if (p == q || q == n - 1 || nums[j] <= nums[q])
                {
                    i = q;
                    continue;
                }
                res += nums[q + 1];
                sum = 0;
                max_sum = 0;
                for (var k = q + 2; k < n && nums[k] > nums[k - 1]; k++)
                {
                    sum += nums[k];
                    max_sum = Math.Max(max_sum, sum);
                }
                res += max_sum;
                sum = 0;
                max_sum = 0;
                for (var k = p - 2; k >= i; k--)
                {
                    sum += nums[k];
                    max_sum = Math.Max(sum, max_sum);
                }
                res += max_sum;
                ans = Math.Max(res, ans);
                i = q - 1;
            }
            return ans;
        }
    }
}
