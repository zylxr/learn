using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class CombinationSum4Class
    {
        //给你一个由 不同 整数组成的数组 nums ，和一个目标整数 target 。请你从 nums 中找出并返回总和为 target 的元素组合的个数。
        //题目数据保证答案符合 32 位整数范围。
        //示例 1：
        //输入：nums = [1,2,3], target = 4
        //输出：7
        //解释：
        //所有可能的组合为：
        //(1, 1, 1, 1)
        //(1, 1, 2)
        //(1, 2, 1)
        //(1, 3)
        //(2, 1, 1)
        //(2, 2)
        //(3, 1)
        //请注意，顺序不同的序列被视作不同的组合。
        //示例 2：

        //输入：nums = [9], target = 3
        //输出：0
 

        //提示：

        //1 <= nums.length <= 200
        //1 <= nums[i] <= 1000
        //nums 中的所有元素 互不相同
        //1 <= target <= 1000
        public int CombinationSum4(int[] nums, int target)
        {
            var dp = new int[target];
            for(var i=1;i<=target;i++)
            {
                foreach(var num in nums)
                {
                    var diff = i - num;
                    if (diff < 0) continue;
                    if (diff == 0) dp[i - 1] += 1;
                    else
                    {
                        dp[i - 1] += dp[diff - 1];
                    }
                }
            }
            return dp[target - 1];
        }
    }
}
