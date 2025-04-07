using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class CanPartitionClass
    {
        //416. 分割等和子集
        //给你一个 只包含正整数 的 非空 数组 nums 。请你判断是否可以将这个数组分割成两个子集，使得两个子集的元素和相等。



        //示例 1：

        //输入：nums = [1, 5, 11, 5]
        //输出：true
        //解释：数组可以分割成[1, 5, 5] 和[11] 。
        //示例 2：

        //输入：nums = [1, 2, 3, 5]
        //输出：false
        //解释：数组不能分割成两个元素和相等的子集。


        //提示：

        //1 <= nums.length <= 200
        //1 <= nums[i] <= 100
        public bool CanPartition(int[] nums)
        {
            var n = nums.Length;
            if (n < 2) return false;
            int sum = 0, maxNum = 0;
            foreach(var num in nums)
            {
                maxNum = Math.Max(maxNum, num);
                sum += num;
            }
            if(sum %2!=0) return false;
            var target = sum / 2;
            if(maxNum > target) return false;
            var dp = new bool[n][];
            for (var i = 0; i < n; i++)
            {
                dp[i] = new bool[target + 1];
                dp[i][0] = true;
            }
            for(var i=1;i<n;i++)
            {
                var num = nums[i];
                for(var j =1;j<=target;j++)
                {
                    if (j >= num)
                        dp[i][j] = dp[i - 1][j] | dp[i - 1][j - num];
                    else
                        dp[i][j] = dp[i - 1][j];
                }
            }
            return dp[n - 1][target];
        }
    }
}
