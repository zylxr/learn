using Algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class NumberOfPermutationsClass
    {
        //3193. 统计逆序对的数目
        //给你一个整数 n 和一个二维数组 requirements ，其中 requirements[i] = [endi, cnti] 表示这个要求中的末尾下标和 逆序对 的数目。

        //整数数组 nums 中一个下标对(i, j) 如果满足以下条件，那么它们被称为一个 逆序对 ：

        //i<j 且 nums[i]> nums[j]
        //请你返回[0, 1, 2, ..., n - 1] 的
        //排列
        //perm 的数目，满足对 所有 的 requirements[i] 都有 perm[0..endi] 恰好有 cnti 个逆序对。

        //由于答案可能会很大，将它对 109 + 7 取余 后返回。




        //示例 1：

        //输入：n = 3, requirements = [[2, 2],[0, 0]]

        //输出：2

        //解释：

        //两个排列为：

        //[2, 0, 1]
        //前缀[2, 0, 1] 的逆序对为(0, 1) 和(0, 2) 。
        //前缀[2] 的逆序对数目为 0 个。
        //[1, 2, 0]
        //前缀[1, 2, 0] 的逆序对为(0, 2) 和(1, 2) 。
        //前缀[1] 的逆序对数目为 0 个。
        //示例 2：

        //输入：n = 3, requirements = [[2, 2],[1, 1],[0, 0]]

        //输出：1

        //解释：

        //唯一满足要求的排列是[2, 0, 1] ：

        //前缀[2, 0, 1] 的逆序对为(0, 1) 和(0, 2) 。
        //前缀[2, 0] 的逆序对为(0, 1) 。
        //前缀[2] 的逆序对数目为 0 。
        //示例 3：

        //输入：n = 2, requirements = [[0, 0],[1, 0]]

        //输出：1

        //解释：

        //唯一满足要求的排列为[0, 1] ：

        //前缀[0] 的逆序对数目为 0 。
        //前缀[0, 1] 的逆序对为(0, 1) 。



        //提示：

        //2 <= n <= 300
        //1 <= requirements.length <= n
        //requirements[i] = [endi, cnti]
        //0 <= endi <= n - 1
        //0 <= cnti <= 400
        //输入保证至少有一个 i 满足 endi == n - 1 。
        //输入保证所有的 endi 互不相同。
        const int MOD = 1000000007;
        IDictionary<int,int> dict = new Dictionary<int,int>();
        int[][] dp;
        public int NumberOfPermutations(int n, int[][] requirements)
        {
            dict.Clear();
            var maxCnt = 0;
            dict.Add(0, 0);
            foreach(var req in requirements)
            {
                if (!dict.ContainsKey(req[0]))
                    dict.Add(req[0], req[1]);
                else
                    dict[req[0]] = req[1];
                maxCnt = Math.Max(maxCnt, req[1]);
            }
            if (dict[0] != 0) return 0;
            dp = new int[n][];
            for (var i = 0; i < n;i++)
            {
                dp[i] = new int[maxCnt + 1];
                Array.Fill(dp[i], -1);
            }
            return DFS(n - 1, dict[n - 1]);
        }

        public int NumberOfPermutations2(int n, int[][] requirements)
        {
            dict.Clear();

            var maxCnt = 0;
            dict.Add(0, 0);
            foreach (var req in requirements)
            {
                if (!dict.ContainsKey(req[0]))
                    dict.Add(req[0], req[1]);
                else
                    dict[req[0]] = req[1];
                maxCnt = Math.Max(maxCnt, req[1]);
            }
            if (dict[0] != 0) return 0;
            dp = new int[n][];
            for (var i = 0; i < n; i++)
            {
                dp[i] = new int[maxCnt + 1];
                Array.Fill(dp[i], -1);
            }
            return DFS2(n - 1, dict[n - 1]);
        }

        public int DFS2(int end, int cnt)
        {
            if (cnt < 0) return 0;
            if (end == 0) return 1;
            if (dp[end][cnt] != -1)return dp[end][cnt];
            if(dict.ContainsKey(end-1))
            {
                var r = dict[end-1];
                if (r <= cnt && cnt <= end + r)
                    return dp[end][cnt] = DFS2(end - 1, r);
                else return dp[end][cnt]= 0;
            }else
            {
                if (cnt >= end)
                    return dp[end][cnt] = (DFS2(end, cnt - 1) - DFS2(end - 1, cnt - 1 - end) + DFS2(end - 1, cnt) + MOD) % MOD;
                else
                    return dp[end][cnt] = (DFS2(end, cnt - 1) + DFS2(end - 1, cnt)) % MOD;
            }
        }

        public int DFS(int end,int cnt)
        {
            if (end == 0) return 1;
            if (dp[end][cnt] != -1)return dp[end][cnt];

            if(dict.ContainsKey(end-1))
            {
                var r = dict[end-1];
                if (r <= cnt && cnt <= end + r)
                {
                    return dp[end][cnt] = DFS(end - 1, r);
                }
                else return dp[end][cnt] = 0;
            }else
            {
                var sm = 0;
                for(var i=0;i<=Math.Min(end,cnt);i++)
                {
                    sm = (sm + DFS(end - 1, cnt - i)) % MOD;
                }
                return dp[end][cnt] = sm;
            }
        }
    }
}
