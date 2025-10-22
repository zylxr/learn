using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxFrequencyClass2
    {
        //3347. 执行操作后元素的最高频率 II
        //给你一个整数数组 nums 和两个整数 k 和 numOperations 。

        //你必须对 nums 执行 操作  numOperations 次。每次操作中，你可以：

        //选择一个下标 i ，它在之前的操作中 没有 被选择过。
        //将 nums[i] 增加范围[-k, k] 中的一个整数。
        //在执行完所有操作以后，请你返回 nums 中出现 频率最高 元素的出现次数。

        //一个元素 x 的 频率 指的是它在数组中出现的次数。



        //示例 1：

        //输入：nums = [1, 4, 5], k = 1, numOperations = 2

        //输出：2

        //解释：

        //通过以下操作得到最高频率 2 ：

        //将 nums[1] 增加 0 ，nums 变为[1, 4, 5] 。
        //将 nums[2] 增加 -1 ，nums 变为[1, 4, 4] 。
        //示例 2：

        //输入：nums = [5, 11, 20, 20], k = 5, numOperations = 1

        //输出：2

        //解释：

        //通过以下操作得到最高频率 2 ：

        //将 nums[1] 增加 0 。


        //提示：

        //1 <= nums.length <= 105
        //1 <= nums[i] <= 109
        //0 <= k <= 109
        //0 <= numOperations <= nums.length
        public int MaxFrequency(int[] nums, int k, int numOperations)
        {
            var n = nums.Length;
            var cnt = new Dictionary<int, int>();
            var sets = new SortedSet<int>();
            Array.Sort(nums);
            for (var i = 0; i < n; i++)
            {
                cnt.TryAdd(nums[i], 0);
                cnt[nums[i]]++;
                sets.Add(nums[i]);
                if (nums[i] - k >= nums[0]) sets.Add(nums[i] - k);
                if (nums[i] + k <= nums[nums.Length - 1]) sets.Add(nums[i] + k);
            }
            var ans = 0;
            foreach (var i in sets)
            {
                var l = LeftBound(nums, i - k);
                var r = RightBound(nums, i + k);
                if (cnt.ContainsKey(i))
                {
                    ans = Math.Max(ans, Math.Min(r - l + 1, cnt[i] + numOperations));
                }
                else ans = Math.Max(ans, Math.Min(r - l + 1, numOperations));
            }
            return ans;
        }
        private int LeftBound(int[] nums, int value)
        {
            var l = 0;
            var r = nums.Length - 1;
            while (l < r)
            {
                var mid = (l + r) >> 1;
                if (nums[mid] < value) l = mid + 1;
                else r = mid;
            }
            return l;
        }
        private int RightBound(int[] nums, int value)
        {
            var l = 0;
            var r = nums.Length - 1;
            while (l < r)
            {
                var mid = (l + r + 1) >> 1;
                if (nums[mid] > value) r = mid - 1;
                else l = mid;
            }
            return l;
        }
    }
}
