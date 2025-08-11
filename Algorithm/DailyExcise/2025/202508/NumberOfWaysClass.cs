using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class NumberOfWaysClass
    {
        //2787. 将一个数字表示成幂的和的方案数
        //给你两个 正 整数 n 和 x 。

        //请你返回将 n 表示成一些 互不相同 正整数的 x 次幂之和的方案数。换句话说，你需要返回互不相同整数[n1, n2, ..., nk] 的集合数目，满足 n = n1x + n2x + ... + nkx 。

        //由于答案可能非常大，请你将它对 109 + 7 取余后返回。

        //比方说，n = 160 且 x = 3 ，一个表示 n 的方法是 n = 23 + 33 + 53 。




        //示例 1：

        //输入：n = 10, x = 2
        //输出：1
        //解释：我们可以将 n 表示为：n = 32 + 12 = 10 。
        //这是唯一将 10 表达成不同整数 2 次方之和的方案。
        //示例 2：

        //输入：n = 4, x = 1
        //输出：2
        //解释：我们可以将 n 按以下方案表示：
        //- n = 41 = 4 。
        //- n = 31 + 11 = 4 。


        //提示：

        //1 <= n <= 300
        //1 <= x <= 5

        private const int MOD = 1_000_000_007;
        public int NumberOfWays(int n, int x)
        {
            var dp = new long[n + 1, n + 1];
            dp[0, 0] = 1;
            for(var i =1;i<=n;i++)
            {
                var val = (long)Math.Pow(i, x);
                for(var j=0;j<=n;j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    if (j>=val)
                        dp[i,j] = (dp[i, j] + dp[i-1,j-val]) %MOD;
                }
            }
            return (int)dp[n, n];
        }

        public int NumberOfWays2(int n, int x)
        {
            var dp = new int[n + 1];
            dp[0] = 1;
            for(var i=1;i<=n;i++)
            {
                var val = (long)Math.Pow(i, x);
                if (val > n) continue;
                for(var j=n;j>=val;j--)
                    dp[j] = (dp[j] + dp[j-val]) %MOD;
            }
            return (int)dp[n];
        }
    }
}
