using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaximumLengthClass2
    {
        //3176.求出最长好子序列 I
        //给你一个整数数组 nums 和一个 非负 整数 k 。如果一个整数序列 seq 满足在下标范围[0, seq.length - 2] 中 最多只有 k 个下标 i 满足 seq[i] != seq[i + 1] ，那么我们称这个整数序列为 好 序列。

        //请你返回 nums 中 好
        //子序列
        //的最长长度。




        //示例 1：

        //输入：nums = [1, 2, 1, 1, 3], k = 2

        //输出：4

        //解释：

        //最长好子序列为[1, 2, 1, 1, 3] 。

        //示例 2：

        //输入：nums = [1, 2, 3, 4, 5, 1], k = 0

        //输出：2

        //解释：

        //最长好子序列为[1, 2, 3, 4, 5, 1] 。



        //提示：

        //1 <= nums.length <= 500
        //1 <= nums[i] <= 109
        //0 <= k <= min(nums.length, 25)
        public int MaximumLength(int[] nums, int k)
        {
            var ans = 0;
            var n = nums.Length;
            var dp = new int[n][];
            for(var i=0;i<n; i++)
            {
                dp[i] = new int[51];
                Array.Fill(dp[i], -1);
            }

            for(var i=0;i<n;i++)
            {
                dp[i][0] = 1;
                for(var l=0;l<=k;l++)
                {
                    for(var j=0;j<i;j++)
                    {
                        var add = nums[i] != nums[j] ? 1 : 0;
                        if (l - add >= 0 && dp[j][l - add] != -1)
                            dp[i][l] = Math.Max(dp[i][l], dp[j][l - add] + 1);
                    }
                    ans = Math.Max(ans,dp[i][l]);
                }
            }
            return ans;

        }
    
    
        public int MaximumLengthOptimize(int[] nums,int k)
        {
            var n = nums.Length;
            var dp = new Dictionary<int, int[]>();
            var zd = new int[k + 1];
            for(var i=0;i<n;i++)
            {
                var v = nums[i];
                dp.TryAdd(v, new int[k + 1]);
                var tmp = dp[v];
                for(var j=0;j<=k;j++)
                {
                    tmp[j] = tmp[j] + 1;
                    if (j > 0) tmp[j] = Math.Max(tmp[j], zd[j - 1] + 1);
                }

                for(var j=0;j<=k;j++)
                {
                    zd[j] = Math.Max(zd[j], tmp[j]);
                    if (j > 0) zd[j] = Math.Max(zd[j], zd[j - 1]);
                }
            }
            return zd[k];
        }
    }
}
