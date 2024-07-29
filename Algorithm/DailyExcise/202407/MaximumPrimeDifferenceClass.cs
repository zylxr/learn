using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaximumPrimeDifferenceClass
    {
        //给你一个整数数组 nums。
        //返回两个（不一定不同的）质数在 nums 中 下标 的 最大距离。
        //示例 1：
        //输入： nums = [4, 2, 9, 5, 3]
        //输出： 3
        //解释： nums[1]、nums[3] 和 nums[4] 是质数。因此答案是 |4 - 1| = 3。
        //示例 2：
        //输入： nums = [4, 8, 2, 8]
        //输出： 0
        //解释： nums[2] 是质数。因为只有一个质数，所以答案是 |2 - 2| = 0。

        //提示：
        //1 <= nums.length <= 3 * 105
        //1 <= nums[i] <= 100
        //输入保证 nums 中至少有一个质数。
        public int MaximumPrimeDifference(int[] nums)
        {
            var n = nums.Length;
            var first = -1;
            var ans = 0;
            for (var i = 0; i < n; i++)
            {
                var isPrime = IsPrime(nums[i]);
                if (!isPrime) continue;
                if(first == -1)
                {
                    first = i;
                }
                ans = Math.Max(ans, i - first);
            }
            return ans;
        }

        public bool IsPrime(int number)
        {
            if(number<=1)return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            var boundary = (int)Math.Floor(Math.Sqrt(number));
            for(var i=3;i<=boundary;i +=2)
            {
                if (number % i == 0) return false;

            }
            return true;
        }
    }
}
