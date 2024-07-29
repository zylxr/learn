using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class LongestPalindromeSubseqClass
    {
        //给你一个字符串 s ，找出其中最长的回文子序列，并返回该序列的长度。
        //子序列定义为：不改变剩余字符顺序的情况下，删除某些字符或者不删除任何字符形成的一个序列。
        //示例 1：
        //输入：s = "bbbab"
        //输出：4
        //解释：一个可能的最长回文子序列为 "bbbb" 。
        //示例 2：

        //输入：s = "cbbd"
        //输出：2
        //解释：一个可能的最长回文子序列为 "bb" 。
 

        //提示：

        //1 <= s.length <= 1000
        //s 仅由小写英文字母组成
        public int LongestPalindromeSubseq(string s)
        {
            var n = s.Length;
            var dp = new int[n, n];
            var maxLen = 1;
            for (var i = 0; i < n; i++)
                dp[i, i] = 1;
            for(var l=2;l<=n;l++)
            {
                for(var i=0;i<n;i++)
                {
                    var j = i + l - 1;
                    if (j >= n) continue;
                    if (s[i] == s[j])
                    {
                        if (j - 1 >= i + 1) dp[i, j] = dp[i + 1, j - 1] + 2;
                        else dp[i, j] = 2;
                    }
                    else
                    {
                        if (j - 1 >= i + 1)
                            dp[i, j] = Math.Max(dp[i, j - 1], dp[i + 1, j]);
                        else dp[i, j] = 1;
                    }   
                    maxLen = Math.Max(maxLen, dp[i, j]);
                }
            }
            return maxLen;
        }

        public int LongestPalindromSubseq2(string s)
        {
            var maxLen = 1;
            var n = s.Length;
            var dp = new int[n, n];
            for(var i = n-1;i>=0;i--)
            {
                dp[i, i] = 1;
                for(var j=i+1;j<n;j++)
                {
                    if (s[j] == s[i])
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    else
                        dp[i, j] = Math.Max(dp[i, j - 1], dp[i + 1, j]);
                }
            }
            return dp[0,n-1];
        }


    }
}
