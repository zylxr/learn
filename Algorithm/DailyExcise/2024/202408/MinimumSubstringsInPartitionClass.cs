using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
        //3144. 分割字符频率相等的最少子字符串
        //给你一个字符串 s ，你需要将它分割成一个或者更多的 平衡 子字符串。比方说，s == "ababcc" 那么("abab", "c", "c") ，("ab", "abc", "c") 和("ababcc") 都是合法分割，但是("a", "bab", "cc") ，("aba", "bc", "c") 和("ab", "abcc") 不是，不平衡的子字符串用粗体表示。

        //请你返回 s 最少 能分割成多少个平衡子字符串。

        //注意：一个 平衡 字符串指的是字符串中所有字符出现的次数都相同。

 

        //示例 1：

        //输入：s = "fabccddg"

        //输出：3

        //解释：

        //我们可以将 s 分割成 3 个子字符串：("fab, "ccdd", "g") 或者 ("fabc", "cd", "dg") 。

        //示例 2：

        //输入：s = "abababaccddb"

        //输出：2

        //解释：

        //我们可以将 s 分割成 2 个子字符串：("abab", "abaccddb") 。

 

        //提示：

        //1 <= s.length <= 1000
        //s 只包含小写英文字母。
    public class MinimumSubstringsInPartitionClass
    {
        public int MinimumSubstringsInPartition(string s)
        {
            const int INF = 0x3f3f3f3f;
            var n = s.Length;
            var d = new int[n + 1];
            Array.Fill(d, INF);
            d[0] = 0;
            for(var i=1;i<=n;i++)
            {
                var dict = new Dictionary<char, int>();
                var maxCnt = 0;
                for(var j=i;j>=1;j--)
                {
                    dict.TryAdd(s[j - 1], 0);
                    dict[s[j - 1]]++;
                    maxCnt = Math.Max(maxCnt, dict[s[j-1]]);
                    if (maxCnt * dict.Count == (i - j + 1) && d[j - 1] != INF)
                        d[i] = Math.Min(d[i], d[j - 1] + 1);
                }
            }
            return d[n];
        }
    }
}
