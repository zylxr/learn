using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class LongestSubsequenceClass
    {
        //给你一个整数数组 arr 和一个整数 difference，请你找出并返回 arr 中最长等差子序列的长度，该子序列中相邻元素之间的差等于 difference 。
        //子序列 是指在不改变其余元素顺序的情况下，通过删除一些元素或不删除任何元素而从 arr 派生出来的序列。
        //示例 1：

        //输入：arr = [1,2,3,4], difference = 1
        //输出：4
        //解释：最长的等差子序列是[1, 2, 3, 4]。
        //示例 2：

        //输入：arr = [1,3,5,7], difference = 1
        //输出：1
        //解释：最长的等差子序列是任意单个元素。
        //示例 3：

        //输入：arr = [1,5,7,8,5,3,4,2,1], difference = -2
        //输出：4
        //解释：最长的等差子序列是[7, 5, 3, 1]。
 

        //提示：

        //1 <= arr.length <= 105
        //-104 <= arr[i], difference <= 104
        public int LongestSubsequence(int[] arr, int difference)
        {
            var n = arr.Length;
            var dp = new int[n];
            dp[0] = 1;
            var maxLen = 1;
            for(var i=1;i<n;i++)
            {
                dp[i] = 1;
                for(var j=0;j<i;j++)
                {
                    if (arr[j] + difference == arr[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
                maxLen = Math.Max(maxLen, dp[i]);
            }
            return maxLen;
        }

        public int LongestSubsequenceOptimize(int[] arr, int difference)
        {
            var dict = new Dictionary<int, int>();
            var maxLen = 1;
            foreach(var a in arr)
            {
                if(dict.TryGetValue(a-difference,out var pre))
                {
                    dict[a] = pre + 1;
                    
                }
                else
                {
                    dict[a]= 1;
                }
                maxLen = Math.Max(maxLen, dict[a]);
            }
            return maxLen;
        }
    }
}
