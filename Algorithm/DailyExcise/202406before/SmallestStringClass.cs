using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class SmallestStringClass
    {
        //给你一个仅由小写英文字母组成的字符串 s 。在一步操作中，你可以完成以下行为：
        //选择 s 的任一非空子字符串，可能是整个字符串，接着将字符串中的每一个字符替换为英文字母表中的前一个字符。例如，'b' 用 'a' 替换，'a' 用 'z' 替换。
        //返回执行上述操作 恰好一次 后可以获得的 字典序最小 的字符串。
        //子字符串 是字符串中的一个连续字符序列。
        //现有长度相同的两个字符串 x 和 字符串 y ，在满足 x[i] != y[i] 的第一个位置 i 上，如果 x[i] 在字母表中先于 y[i] 出现，则认为字符串 x 比字符串 y 字典序更小 。
        //示例 1：
        //输入：s = "cbabc"
        //输出："baabc"
        //解释：我们选择从下标 0 开始、到下标 1 结束的子字符串执行操作。 
        //可以证明最终得到的字符串是字典序最小的。

        //示例 2：
        //输入：s = "acbbc"
        //输出："abaab"
        //解释：我们选择从下标 1 开始、到下标 4 结束的子字符串执行操作。
        //可以证明最终得到的字符串是字典序最小的。

        //示例 3：
        //输入：s = "leetcode"
        //输出："kddsbncd"
        //解释：我们选择整个字符串执行操作。
        //可以证明最终得到的字符串是字典序最小的。


        //提示：
        //1 <= s.length <= 3 * 105
        //s 仅由小写英文字母组成

        //替换的操作，对于大多数字符来说，会使字典序变小，除了字符 ‘a’ 用 ‘z’ 这一替换，会使字典序变大。
        //为了得到字典序最小的字符串，我们需要尽可能早地开始替换，即将被选择的非空子字符串的开始下标要尽可能小。
        //因此，我们要找到第一个非 ‘a’ 字符，将它作为非空子字符串的开始下标。在这之后，再找到第一个 ‘a’ 字符，
        //将它作为非空子字符串的结束下标（不包含），这之间所有的字符，都做一次替换，就得到了目标字符串。
        //还有一种可能是，字符串为全 ‘a’，这种情况下我们找不到第一个非 ‘a’ 字符，
        //题目有要求必须进行一次替换且子字符串非空，这种情况下我们对末尾字符进行一次替换即可。

        public string SmallestString(string s)
        {
            var indexOfFistNonA = FindFirstNonA(s);
            if (indexOfFistNonA == s.Length)
            {
                var sb = new StringBuilder(s);
                sb[s.Length - 1] = 'z';
                return sb.ToString();
            }
            var indexOfFirstA_AfterFirstNonA = FindFistA_AfterFirstNonA(s, indexOfFistNonA);
            var res = new StringBuilder();
            for (var i = 0; i < s.Length;i++)
            {
                if (i >= indexOfFistNonA && i < indexOfFirstA_AfterFirstNonA)
                {
                    res.Append((char)(s[i] - 1));
                }
                else res.Append(s[i]);
            }
            return res.ToString();
        }

        public int FindFirstNonA(string s)
        {
            for(var i=0;i<s.Length; i++)
            {
                if (s[i] != 'a')
                    return i;
            }
            return s.Length ;
        }

        public int FindFistA_AfterFirstNonA(string s, int firstNonA)
        {
            for (var i = firstNonA+1; i < s.Length; i++)
            {
                if (s[i] == 'a')
                    return i;
            }
            return s.Length;
        }
    }
}
