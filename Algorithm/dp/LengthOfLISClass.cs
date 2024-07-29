using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class LengthOfLISClass
    {
        //给你一个整数数组 nums ，找到其中最长严格递增子序列的长度。
        //子序列 是由数组派生而来的序列，删除（或不删除）数组中的元素而不改变其余元素的顺序。例如，[3,6,2,7]
        //是数组[0, 3, 1, 6, 2, 2, 7] 的
        //子序列
        //。
 
        //示例 1：
        //输入：nums = [10,9,2,5,3,7,101,18]
        //输出：4
        //解释：最长递增子序列是[2, 3, 7, 101]，因此长度为 4 。
        //示例 2：
        //输入：nums = [0,1,0,3,2,3]
        //输出：4
        //示例 3：
        //输入：nums = [7,7,7,7,7,7,7]
        //输出：1
        //提示：
        //1 <= nums.length <= 2500
        //-104 <= nums[i] <= 104
        public int LengthOfLIS(int[] nums)
        {
            var n = nums.Length;
            var dp = new int[n];
            var maxLength = 0;
            for(var i=0;i<n;i++)
            {
                dp[i] = 1;
                for(var j=0;j<i;j++)
                {
                    if (nums[i] > nums[j])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
                maxLength = Math.Max(maxLength, dp[i]);
            }
            return maxLength;
        }

        public int LengthOfLISByBinary(int[] nums) {
        
            var n = nums.Length;
            var dp = new int[n];
            var len = 0;
            for(var i=0;i<n;i++)
            {
                if (i == 0) 
                {
                    len = 1;
                    dp[0] = nums[i];
                    continue;
                }

                if (nums[i] >= dp[len-1])
                {
                    dp[len] = nums[i];
                    len++;
                }else
                {
                    var index = findIndex(nums[i], dp,len);
                    dp[index ] = nums[i];
                }
            }
            return len;
        }

        public int findIndex(int num, int[] dp,int len)
        {
            var left = 0;
            var right = len;
            var mid = (left + right) >>1;
            while(left<right)
            {
                if (num<=dp[mid])
                {
                    right = mid ;
                }
                else
                    left = mid+1;
                mid = (left + right)>>1;
            }
            return mid;
        }
    }
}
