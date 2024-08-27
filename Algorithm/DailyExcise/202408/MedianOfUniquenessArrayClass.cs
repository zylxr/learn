using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MedianOfUniquenessArrayClass
    {
        //3134. 找出唯一性数组的中位数
        //给你一个整数数组 nums 。数组 nums 的 唯一性数组 是一个按元素从小到大排序的数组，包含了 nums 的所有
        //非空子数组中
        //不同元素的个数。

        //换句话说，这是由所有 0 <= i <= j<nums.length 的 distinct(nums[i..j]) 组成的递增数组。

        //其中，distinct(nums[i..j]) 表示从下标 i 到下标 j 的子数组中不同元素的数量。

        //返回 nums 唯一性数组 的 中位数 。

        //注意，数组的 中位数 定义为有序数组的中间元素。如果有两个中间元素，则取值较小的那个。



        //示例 1：

        //输入：nums = [1, 2, 3]

        //输出：1

        //解释：

        //nums 的唯一性数组为[distinct(nums[0..0]), distinct(nums[1..1]), distinct(nums[2..2]), distinct(nums[0..1]), distinct(nums[1..2]), distinct(nums[0..2])]，即[1, 1, 1, 2, 2, 3] 。唯一性数组的中位数为 1 ，因此答案是 1 。

        //示例 2：

        //输入：nums = [3, 4, 3, 4, 5]

        //输出：2

        //解释：

        //nums 的唯一性数组为[1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3] 。唯一性数组的中位数为 2 ，因此答案是 2 。

        //示例 3：

        //输入：nums = [4, 3, 5, 4]

        //输出：2

        //解释：

        //nums 的唯一性数组为[1, 1, 1, 1, 2, 2, 2, 3, 3, 3] 。唯一性数组的中位数为 2 ，因此答案是 2 。



        //提示：

        //1 <= nums.length <= 105
        //1 <= nums[i] <= 105
        public int MedianOfUniquenessArray(int[] nums)
        {
            var n = nums.Length;
            var median = ((long)n*(n+1)>>1+1)>> 1;
            var res = 0;
            int l = 1, h = n;
            while(l<=h)
            {
                var mid = (l + h) >> 1;
                if (Check(nums, mid, median))
                {
                    res = mid;
                    h = mid - 1;
                }
                else l = mid + 1;
            }
            return res;
        }
        //检测数组中不同元素数目小于等于 t 的连续子数组数目是否大于 等于 median
        public bool Check(int[] nums, int t, long median)
        {
            var dict = new Dictionary<int, int>();
            var tot = 0L;
            for (int i = 0, j = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                    dict[nums[i]]++;
                else
                    dict[nums[i]] = 1;
                while(dict.Count>t)
                {
                    dict[nums[j]]--;
                    if (dict[nums[j]] == 0)
                        dict.Remove(nums[j]);
                    j++;
                }
                tot += i - j + 1;
            }
            return tot >= median;
        }
    }
}
