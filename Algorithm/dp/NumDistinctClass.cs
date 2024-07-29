using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class NumDistinctClass
    {
        //给你两个字符串 s 和 t ，统计并返回在 s 的 子序列 中 t 出现的个数，结果需要对 109 + 7 取模。
        //示例 1：

        //输入：s = "rabbbit", t = "rabbit"
        //输出：3
        //解释：
        //如下所示, 有 3 种可以从 s 中得到 "rabbit" 的方案。
        //rabbbit
        //rabbbit
        //rabbbit
        //示例 2：

        //输入：s = "babgbag", t = "bag"
        //输出：5
        //解释：
        //如下所示, 有 5 种可以从 s 中得到 "bag" 的方案。 
        //babgbag
        //babgbag
        //babgbag
        //babgbag
        //babgbag


        //提示：

        //1 <= s.length, t.length <= 1000
        //s 和 t 由英文字母组成
        public int NumDistinct(string s, string t)
        {
            var m = s.Length;
            var n = t.Length;
            var dp = new int[m+1, n+1];
            for (var i = 0; i <= m; i++)
                dp[i, 0] = 1;
            for(var i=1;i<=m;i++)
            {
                for(var j=1;j<=n;j++)
                {
                    if (s[i - 1] == t[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + dp[i-1,j];
                    else
                        dp[i, j] = dp[i-1, j];
                }
            }
            return dp[m, n];
        }

        public int NumDistinct2(string s,string t)
        {
            var m = s.Length;
            var n = t.Length;
            if (m < n) return 0;
            var dp = new int[m + 1, n + 1];
            for (var i = 0; i <= m; i++)
                dp[i, n] = 1;
            for(var i=m-1;i>=0;i--)
            {
                for(var j=n-1;j>=0;j--)
                {
                    if (s[i] == t[j])
                        dp[i, j] = dp[i + 1, j + 1] + dp[i + 1, j];
                    else
                        dp[i, j] = dp[i + 1, j];
                }
            }
            return dp[0, 0];
        }
    }
}
