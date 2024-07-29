using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class RobClass
    {
        //你是一个专业的小偷，计划偷窃沿街的房屋。每间房内都藏有一定的现金，影响你偷窃的唯一制约因素就是相邻的房屋装有相互连通的防盗系统，如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。
        //给定一个代表每个房屋存放金额的非负整数数组，计算你 不触动警报装置的情况下 ，一夜之内能够偷窃到的最高金额。
        //示例 1：

        //输入：[1,2,3,1]
        //输出：4
        //解释：偷窃 1 号房屋(金额 = 1) ，然后偷窃 3 号房屋(金额 = 3)。
        //偷窃到的最高金额 = 1 + 3 = 4 。
        //示例 2：

        //输入：[2,7,9,3,1]
        //输出：12
        //解释：偷窃 1 号房屋(金额 = 2), 偷窃 3 号房屋(金额 = 9)，接着偷窃 5 号房屋(金额 = 1)。
        //偷窃到的最高金额 = 2 + 9 + 1 = 12 。
        public int RobOptimize(int[] nums)
        {
            var n = nums.Length;
            var dp = new int[n];
            for(var i=0;i<n;i++)
            {
                if (i == 0)
                {
                    dp[i] = nums[i];
                    continue;
                }
                if (i == 1)
                {
                    dp[i] = Math.Max(dp[i-1], nums[i]);
                    continue;
                }
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }
            return dp[n-1];
        }

        public int RobOptimize2(int[] nums)
        {
            var  n = nums.Length;
            var pre = 0;
            var cur = 0;
            for(var i=0;i<n;i++)
            {
                if(i==0)
                {
                    cur = nums[i];
                    continue;
                }
                if(i == 1)
                {
                    pre = cur;
                    cur = Math.Max(cur, nums[i]);
                    continue;
                }
                var tmp = cur;
                cur = Math.Max(pre + nums[i], cur);
                pre = tmp;
            }
            return cur;
        }
        public int Rob(int[] nums)
        {
            var n = nums.Length;
            var dp = new int[n, 2];
            for (var i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    dp[i, 0] = nums[i];
                    continue;
                }
                if (i == 1)
                {
                    dp[i, 0] = nums[i];
                    dp[i, 1] = dp[i - 1, 0];
                    continue;
                }
                dp[i, 0] = dp[i - 1, 1] + nums[i];
                dp[i, 1] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
            }
            return dp[n - 1, 0] > dp[n - 1, 1] ? dp[n - 1, 0] : dp[n - 1, 1];
        }
    }
}
