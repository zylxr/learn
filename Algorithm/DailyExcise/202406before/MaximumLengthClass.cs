using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaximumLengthClass
    {
        //给你一个仅由小写英文字母组成的字符串 s 。
        //如果一个字符串仅由单一字符组成，那么它被称为 特殊 字符串。例如，字符串 "abc" 不是特殊字符串，而字符串 "ddd"、"zz" 和 "f" 是特殊字符串。
        //返回在 s 中出现 至少三次 的 最长特殊子字符串 的长度，如果不存在出现至少三次的特殊子字符串，则返回 -1 。
        //子字符串 是字符串中的一个连续 非空 字符序列。

        //示例 1：
        //输入：s = "aaaa"
        //输出：2
        //解释：出现三次的最长特殊子字符串是 "aa" ：子字符串 "aaaa"、"aaaa" 和 "aaaa"。
        //可以证明最大长度是 2 。

        //示例 2：
        //输入：s = "abcdef"
        //输出：-1
        //解释：不存在出现至少三次的特殊子字符串。因此返回 -1 。

        //示例 3：
        //输入：s = "abcaba"
        //输出：1
        //解释：出现三次的最长特殊子字符串是 "a" ：子字符串 "abcaba"、"abcaba" 和 "abcaba"。
        //可以证明最大长度是 1 。
        public int MaximumLength(string s)
        {
            int ans = -1;
            int len = s.Length;

            IList<int>[] chs = new IList<int>[26];
            for (int i = 0; i < 26; i++)
            {
                chs[i] = new List<int>();
            }
            int cnt = 0;
            for (int i = 0; i < len; i++)
            {
                cnt++;
                if (i + 1 == len || s[i] != s[i + 1])
                {
                    int ch = s[i] - 'a';
                    chs[ch].Add(cnt);
                    cnt = 0;

                    for (int j = chs[ch].Count - 1; j > 0; j--)
                    {
                        if (chs[ch][j] > chs[ch][j - 1])
                        {
                            int temp = chs[ch][j];
                            chs[ch][j] = chs[ch][j - 1];
                            chs[ch][j - 1] = temp;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (chs[ch].Count > 3)
                    {
                        chs[ch].RemoveAt(chs[ch].Count - 1);
                    }
                }
            }

            for (int i = 0; i < 26; i++)
            {
                if (chs[i].Count > 0 && chs[i][0] > 2)
                {
                    ans = Math.Max(ans, chs[i][0] - 2);
                }
                if (chs[i].Count > 1 && chs[i][0] > 1)
                {
                    ans = Math.Max(ans, Math.Min(chs[i][0] - 1, chs[i][1]));
                }
                if (chs[i].Count > 2)
                {
                    ans = Math.Max(ans, chs[i][2]);
                }
            }

            return ans;
        }

        public int MaximumLengthByBinanry(string s)
        {
            var n = s.Length;
            var dict = new Dictionary<char, List<int>>();
            for (int i = 0, j = 0; i < n; i = j)
            {
                while (j < n && s[i] == s[j])
                {
                    j++;
                }
                dict.TryAdd(s[i], new List<int>());
                dict[s[i]].Add(j - i);
            }
            var ans = -1;
            foreach (var item in dict)
            {
                int low = 1, high = n - 2;

                while (low <= high)
                {
                    var count = 0;
                    var mid = (low + high) >> 1;
                    foreach (var k in item.Value)
                    {
                        if (k >= mid)
                            count += k - mid + 1;
                    }
                    if (count >= 3)
                    {
                        ans = Math.Max(ans, mid);
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }
            return ans;
        }

        //当然我们可以进一步进行优化，由于题目只要求出现次数大于等于 3 次即可，实际我们只需要找到每种字符的最长的 3 个长度即可，
        //从这 3 个长度一定可以找到出现次数大于等于 333 的最长子字符串。
        public int MaximumLengthByOptimization(string s)
        {
            var n = s.Length;
            var dp = new int[26, 3];
            for (int i = 0, j = 0; i < n; i = j)
            {
                while (j < n && s[i] == s[j])
                {
                    j++;
                }
                var index = s[i] - 'a';
                var len = j - i;
                if (len > dp[index, 0])
                {
                    dp[index, 2] = dp[index, 1];
                    dp[index, 1] = dp[index, 0];
                    dp[index, 0] = len;
                }
                else if (len > dp[index, 1])
                {
                    dp[index, 2] = dp[index, 1];
                    dp[index, 1] = len;
                }
                else
                    dp[index, 2] = len;
            }
            var ans = 0;
            for (var k = 0; k < 26; k++)
            {
                ans = Math.Max(ans, dp[k, 0] - 2);
                ans = Math.Max(ans, Math.Min(dp[k, 0] - 1, dp[k, 1]));
                ans = Math.Max(ans, dp[k, 2]);
            }
            return ans > 0 ? ans : -1;
        }
    }
}
