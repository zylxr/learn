using Algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class SpecialPermClass
    {
        //给你一个下标从 0 开始的整数数组 nums ，它包含 n 个 互不相同 的正整数。如果 nums 的一个排列满足以下条件，我们称它是一个特别的排列：
        //对于 0 <= i<n - 1 的下标 i ，要么 nums[i] % nums[i + 1] == 0 ，要么 nums[i + 1] % nums[i] == 0 。
        //请你返回特别排列的总数目，由于答案可能很大，请将它对 109 + 7 取余 后返回。
        //示例 1：
        //输入：nums = [2, 3, 6]
        //输出：2
        //解释：[3, 6, 2] 和[2, 6, 3] 是 nums 两个特别的排列。
        //示例 2：
        //输入：nums = [1, 4, 3]
        //输出：2
        //解释：[3, 1, 4] 和[4, 1, 3] 是 nums 两个特别的排列。


        //提示：

        //2 <= nums.length <= 14
        //1 <= nums[i] <= 109

        int[] nums;
        int n;
        int[][] f;
        int MOD = 1000000007;
        public int SpecialPerm(int[] nums)
        {
            this.nums = nums;
            this.n = nums.Length;
            this.f = new int[1 << n][];
            for (var i = 0; i < 1 << n; i++)
            {
                f[i] = new int[n];
                Array.Fill(f[i], -1);
            }
            var res = 0;
            for(var i=0;i<n;i++)
            {
                res = (res+DFS((1<<n)-1,i)) % MOD;
            }
            return res;
        }

        public int DFS(int state, int i)
        {
            if (f[state][i] != -1)
                return f[state][i];
            if (state == (1 << i)) return 1;
            f[state][i] = 0;
            for(var j=0;j<n;j++)
            {
                if(i==j ||(( state>>j & 1) == 0))
                {
                    continue;
                }
                if (nums[i] % nums[j] != 0 && nums[j] % nums[i] != 0)
                    continue;
                f[state][i] = (f[state][i]+DFS(state^(1<<i),j)) % MOD;
            }
            return f[state][i];
        }

        public int SpecialPermDP(int[] nums)
        {
            var n = nums.Length;
            var dp = new int[1 << n][];
            for(var i=0;i<1<<n;i++)
                dp[i] = new int[n];
            for (var i = 0; i < n; i++)
                dp[1<<i][i] = 1;
            for(var state=1;state<(1<<n);state++)
            {
                for(var i=0;i<n;i++)
                {
                    if ((state >> i & 1) == 0) continue;
                    for(var j=0;j<n;j++)
                    {
                        if (i == j || ((state >> j & 1) == 0)) continue;
                        if (nums[i] % nums[j] != 0 && nums[j] % nums[i] != 0) continue;
                        dp[state][i] = (dp[state][i] + dp[state ^ (1 << i)][j]) % MOD;
                    }
                }
            }

            var res = 0;
            for(var i=0;i<n;i++)
            {
                res = (res + dp[(1 << n) - 1][i]) % MOD;
            }
            return res;
        }
    }
}
