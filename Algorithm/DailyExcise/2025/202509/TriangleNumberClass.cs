using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class TriangleNumberClass
    {
        //611. 有效三角形的个数
        //给定一个包含非负整数的数组 nums ，返回其中可以组成三角形三条边的三元组个数。



        //示例 1:

        //输入: nums = [2, 2, 3, 4]
        //输出: 3
        //解释:有效的组合是: 
        //2,3,4 (使用第一个 2)
        //2,3,4 (使用第二个 2)
        //2,2,3
        //示例 2:

        //输入: nums = [4, 2, 3, 4]
        //输出: 4



        //提示:

        //1 <= nums.length <= 1000
        //0 <= nums[i] <= 1000
        public int TriangleNumber(int[] nums)
        {
            var n = nums.Length;
            Array.Sort(nums);
            var ans = 0;
            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    var left = j + 1;
                    var right = n;
                    while (left < right)
                    {
                        var mid = (left + right) >> 1;
                        if (nums[mid] >= nums[i] + nums[j]) right = mid;
                        else left = mid + 1;
                    }
                    ans += left - j-1;
                }
            }
            return ans;
        }

        public int TriangleNumber2(int[] nums)
        {
            var ans = 0;
            var n = nums.Length;
            Array.Sort(nums);
            for (var i = 0; i < n - 2; i++)
            {
                for (var j = i + 1; j < n - 1; j++)
                {
                    for (var k = j + 1; k < n; k++)
                    {
                        if (nums[i] + nums[j] <= nums[k]) break;
                        ans++;
                    }
                }
            }
            return ans;
        }


    }
}
