using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class MinInsertionsClass
    {
        //给你一个字符串 s ，每一次操作你都可以在字符串的任意位置插入任意字符。
        //请你返回让 s 成为回文串的 最少操作次数 。

        //「回文串」是正读和反读都相同的字符串。
        //示例 1：

        //输入：s = "zzazz"
        //输出：0
        //解释：字符串 "zzazz" 已经是回文串了，所以不需要做任何插入操作。
        //示例 2：

        //输入：s = "mbadm"
        //输出：2
        //解释：字符串可变为 "mbdadbm" 或者 "mdbabdm" 。
        //示例 3：

        //输入：s = "leetcode"
        //输出：5
        //解释：插入 5 个字符后字符串变为 "leetcodocteel" 。
 

        //提示：

        //1 <= s.length <= 500
        //s 中所有字符都是小写字母。
        public int MinInsertions(string s)
        {
            var n = s.Length;
            var dp = new int[n,n];
            for(var i=n-2;i>=0;i--)
            {
                for(var j=i+1; j<n;j++)
                {
                    if (s[i] == s[j])
                        dp[i, j] = dp[i + 1, j -1];
                    else
                        dp[i,j] = Math.Min(dp[i + 1, j], dp[i,j-1])+1;
                }
            }
            return dp[0, n-1];
        }

        //如果我们将 inv(p) 和 q 的最长公共子序列设为 r，那么在这两个步骤之后，我们在 inv(p) 中得到了 inv(r)，q 中得到了 r，并且得到了回文中心 c 或 cc。我们将这三个部分拼在一起，实际上得到了一个回文串 inv(r) + c/cc + r，并且它是原字符串 s 的一个子序列！这个回文串越长，就意味着我们需要添加的字符越少。也就是说，我们需要在原字符串 s 中找到一个最长回文子序列，若其长度为 l，那么我们只需要添加 |s| - l 个字符，就可以将 s 变为回文串。

        //如何从直观上来理解它呢？当我们在原字符串 s 中找到最长回文子序列后，对于在 s 中但不在子序列中的那些字符，如果其在回文中心的左侧，我们就在右侧对应的位置添加一个相同的字符；如果其在回文中心的右侧，我们就在左侧对应的位置添加一个相同的字符。例如：

        //当 s = "dabca" 时，它的最长回文子序列为 "aba"，我们将 s 写成如下的形式：

        //a b   a(回文中心为 b)
        //s = d a   b c a
        //s = d a b c a d(字符 d 在回文中心左侧，那么在右侧对应位置添加一个相同的字符)
        //s = d a c b c a d(字符 c 在回文中心右侧，那么在左侧对应位置添加一个相同的字符)
        //我们添加了 2 个字符将 s 变为回文串。另一方面，|s| - l = 5 - 3 = 2，这两个值相等。

        //那么如何求出 s 的最长回文子序列 sPA 呢？实际上，sPA 就等同于 s 和 inv(s) 的最长公共子序列，即 sPA 既是 s 的子序列，也是 inv(s) 的子序列（这样就保证了 sPA 是一个回文的子序列）。这样以来，我们只要在 O(N2)O(N^2)O(N
        //2
        //) 的时间求出 s 和 inv(s) 的最长公共子序列，根据它的长度 l，通过 |s| - l 就可以得到答案。

        public int MinInsertions2(string s)
        {
            var n = s.Length;
            var dp = new int[n+1,n+1];
            var t = "";
            for(var i=n-1;i>=0;i--)
                t += s[i];
            for(var i=1;i<=n;i++)
            {
                dp[i, i] = 1;
                for(var j=1;j<=n;j++)
                {
                    if (s[i - 1] == t[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
            return n - dp[n, n];
        }
    }
}
