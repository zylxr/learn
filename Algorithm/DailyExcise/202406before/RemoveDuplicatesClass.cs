using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RemoveDuplicatesClass
    {
        public int RemoveDuplicates(int[] nums)
        {
            //给你一个有序数组 nums ，请你 原地 删除重复出现的元素，使得出现次数超过两次的元素只出现两次 ，返回删除后数组的新长度。
            //不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。
            //    示例 1：

            //输入：nums = [1, 1, 1, 2, 2, 3]
            //输出：5, nums = [1, 1, 2, 2, 3]
            //解释：函数应返回新长度 length = 5, 并且原数组的前五个元素被修改为 1, 1, 2, 2, 3。 不需要考虑数组中超出新长度后面的元素。
            //示例 2：

            //输入：nums = [0, 0, 1, 1, 1, 1, 2, 3, 3]
            //输出：7, nums = [0, 0, 1, 1, 2, 3, 3]
            //解释：函数应返回新长度 length = 7, 并且原数组的前七个元素被修改为 0, 0, 1, 1, 2, 3, 3。不需要考虑数组中超出新长度后面的元素。
            var n = nums.Length;
            int high = 2, low = 2;
            while (high < n)
            {
                if (nums[low - 2] != nums[high])
                {
                    nums[low] = nums[high];
                    low++;
                }
                high++;
            }
            return low;
        }
    }
}
