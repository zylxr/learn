using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Algorithm.DailyExcise
{
    public class CountGoodClass
    {
        //2537. 统计好子数组的数目
        //给你一个整数数组 nums 和一个整数 k ，请你返回 nums 中 好 子数组的数目。

        //一个子数组 arr 如果有 至少 k 对下标(i, j) 满足 i<j 且 arr[i] == arr[j] ，那么称它是一个 好 子数组。

        //子数组 是原数组中一段连续 非空 的元素序列。




        //示例 1：

        //输入：nums = [1, 1, 1, 1, 1], k = 10
        //输出：1
        //解释：唯一的好子数组是这个数组本身。
        //示例 2：

        //输入：nums = [3, 1, 4, 3, 2, 2, 4], k = 2
        //输出：4
        //解释：总共有 4 个不同的好子数组：
        //- [3, 1, 4, 3, 2, 2] 有 2 对。
        //- [3, 1, 4, 3, 2, 2, 4] 有 3 对。
        //- [1, 4, 3, 2, 2, 4] 有 2 对。
        //- [4, 3, 2, 2, 4] 有 2 对。



        //提示：

        //1 <= nums.length <= 105
        //1 <= nums[i], k <= 109
        public long CountGood(int[] nums, int k)
        {
            var n = nums.Length;
            var same = 0;
            var right = -1;
            var cnt = new Dictionary<int, int>();
            var ans = 0L;
            for(var left=0;left<n;left++)
            {
                while(same<k && right+1<n)
                {
                    right++;
                    cnt.TryGetValue(nums[right], out var current);
                    same += current;
                    cnt[nums[right]] = current + 1;
                }
                if (same >= k)
                    ans += n - right;
                cnt[nums[left]] = cnt[nums[left]] - 1;
                same -= cnt[nums[left]];
            }
            return ans;
        }
    }
}
