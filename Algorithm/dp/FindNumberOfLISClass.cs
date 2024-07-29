using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class FindNumberOfLISClass
    {
        //给定一个未排序的整数数组 nums ， 返回最长递增子序列的个数 。

        //注意 这个数列必须是 严格 递增的。
        //示例 1:

        //输入: [1,3,5,4,7]
        //输出: 2
        //解释: 有两个最长递增子序列，分别是[1, 3, 4, 7] 和[1, 3, 5, 7]。
        //示例 2:

        //输入: [2,2,2,2,2]
        //输出: 5
        //解释: 最长递增子序列的长度是1，并且存在5个子序列的长度为1，因此输出5。
 

        //提示: 

        //1 <= nums.length <= 2000
        //-106 <= nums[i] <= 106
        public int FindNumberOfLIS(int[] nums)
        {
            var n = nums.Length;
            var dp = new int[n];
            var maxLen = 0;
            var counts = new int[n];
            var countNum = 0;
            for (var i = 0; i < n; i++)
            {
                dp[i] = 1;
                counts[i] = 1;
                if (i == 0)
                {
                    dp[i] = 1;
                    maxLen = 1;
                    counts[i] = 1;
                    continue;
                }
                for (var j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (dp[j] + 1 > dp[i])
                        {
                            dp[i] = dp[j] + 1;
                            counts[i] = counts[j];
                        }
                        else if (dp[j] + 1 == dp[i])
                        {
                            counts[i] += counts[j];
                        }
                    }
                }
                maxLen = Math.Max(maxLen, dp[i]);
            }
            
            for(var i=0;i<n;i++)
            {
                if (dp[i] == maxLen)
                    countNum += counts[i];
            }
            return countNum;
        }

    }
}
