using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class SmallestRangeIIClass
    {
        //910. 最小差值 II
        //给你一个整数数组 nums，和一个整数 k 。

        //对于每个下标 i（0 <= i<nums.length），将 nums[i] 变成 nums[i] + k 或 nums[i] - k 。

        //nums 的 分数 是 nums 中最大元素和最小元素的差值。

        //在更改每个下标对应的值之后，返回 nums 的最小 分数 。




        //示例 1：

        //输入：nums = [1], k = 0
        //输出：0
        //解释：分数 = max(nums) - min(nums) = 1 - 1 = 0 。
        //示例 2：

        //输入：nums = [0, 10], k = 2
        //输出：6
        //解释：将数组变为[2, 8] 。分数 = max(nums) - min(nums) = 8 - 2 = 6 。
        //示例 3：

        //输入：nums = [1, 3, 6], k = 3
        //输出：3
        //解释：将数组变为[4, 6, 3] 。分数 = max(nums) - min(nums) = 6 - 3 = 3 。


        //提示：

        //1 <= nums.length <= 104
        //0 <= nums[i] <= 104
        //0 <= k <= 104
        public int SmallestRangeII(int[] nums, int k)
        {
            //这个循环遍历数组的所有相邻元素对(a, b)。对于每一对(a, b)，考虑将所有小于等于 a 的元素增加 k，将所有大于 a 的元素减少 k（这里假设 b 大于 a，因为数组已排序）。然后计算在这种情况下新的最大值和最小值之差，并更新结果 res。
            //Math.Max(ma - k, a + k) 计算的是在这种调整后可能的新最大值。
            //Math.Min(mi + k, b - k) 计算的是在这种调整后可能的新最小值。
            var n = nums.Length;
            Array.Sort(nums);
            var min = nums[0];
            var max = nums[n - 1];
            var res = max - min;
            for(var i=1;i<n;i++)
            {
                res = Math.Min(res, Math.Max(max-k, nums[i-1]+k) - Math.Min(min+k, nums[i]-k));
            }
            return res;
        }
    }
}
