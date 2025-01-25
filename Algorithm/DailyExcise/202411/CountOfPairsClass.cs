using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class CountOfPairsClass
    {
        //3250. 单调数组对的数目 I
        //给你一个长度为 n 的 正 整数数组 nums 。

        //如果两个 非负 整数数组(arr1, arr2) 满足以下条件，我们称它们是 单调 数组对：

        //两个数组的长度都是 n 。
        //arr1 是单调 非递减 的，换句话说 arr1[0] <= arr1[1] <= ... <= arr1[n - 1] 。
        //arr2 是单调 非递增 的，换句话说 arr2[0] >= arr2[1] >= ... >= arr2[n - 1] 。
        //对于所有的 0 <= i <= n - 1 都有 arr1[i] + arr2[i] == nums[i] 。
        //请你返回所有 单调 数组对的数目。

        //由于答案可能很大，请你将它对 109 + 7 取余 后返回。




        //示例 1：

        //输入：nums = [2, 3, 2]

        //输出：4

        //解释：

        //单调数组对包括：

        //([0, 1, 1], [2, 2, 1])
        //([0, 1, 2], [2, 2, 0])
        //([0, 2, 2], [2, 1, 0])
        //([1, 2, 2], [1, 1, 0])
        //示例 2：

        //输入：nums = [5, 5, 5, 5]

        //输出：126




        //提示：

        //1 <= n == nums.length <= 2000
        //1 <= nums[i] <= 50
        public int CountOfPairs(int[] nums)
        {
            var n = nums.Length;
            var dp = new int[n, 51];
            var mod = 1000000007;
            for (var v = 0; v <= nums[0]; v++)
                dp[0, v] = 1;
            for(var i=1;i<n;i++)
            {
                for(var v2=0;v2<=nums[i];v2++)
                {
                    for(var v1=0;v1<=v2;v1++)
                    {
                        if (nums[i - 1] - v1 >= nums[i] - v2 && nums[i] - v2 >= 0)
                            dp[i, v2] = (dp[i, v2] + dp[i - 1, v1]) % mod;
                    }
                }
            }
            var res = 0;
            for (var v = 0; v < 51; v++)
                res = (res + dp[n - 1, v]) % mod;
            return res;
        }

        public int CountOfPairs2(int[] nums)
        {
            var n = nums.Length;
            var m = nums.Max();
            var mod = (int)(1e9 + 7);
            var dp = new int[n][];
            for (var i = 0; i < n; i++)
                dp[i] = new int[m + 1];
            for (var j = 0; j <= nums[0]; j++)
                dp[0][j] = 1;
            for(var i=1;i<n;i++)
            {
                var d = Math.Max(0, nums[i] - nums[i - 1]);
                for(var j = d; j <= nums[i];j++)
                {
                    if (j == 0)
                        dp[i][j] = dp[i - 1][j - d];
                    else
                        dp[i][j] = (dp[i][j - 1] + dp[i - 1][j - d]) % mod;
                }
            }
            var res = 0;
            foreach(var num in dp[n - 1])
                res = (res + num) % mod;
            return res;
        }
    }
}
