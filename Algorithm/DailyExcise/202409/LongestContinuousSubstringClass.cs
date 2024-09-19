using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class LongestContinuousSubstringClass
    {
        //2414. 最长的字母序连续子字符串的长度
        //字母序连续字符串 是由字母表中连续字母组成的字符串。换句话说，字符串 "abcdefghijklmnopqrstuvwxyz" 的任意子字符串都是 字母序连续字符串 。

        //例如，"abc" 是一个字母序连续字符串，而 "acb" 和 "za" 不是。
        //给你一个仅由小写英文字母组成的字符串 s ，返回其 最长 的 字母序连续子字符串 的长度。



        //示例 1：

        //输入：s = "abacaba"
        //输出：2
        //解释：共有 4 个不同的字母序连续子字符串 "a"、"b"、"c" 和 "ab" 。
        //"ab" 是最长的字母序连续子字符串。
        //示例 2：

        //输入：s = "abcde"
        //输出：5
        //解释："abcde" 是最长的字母序连续子字符串。


        //提示：

        //1 <= s.length <= 105
        //s 由小写英文字母组成

        public int LongestContinuousSubstring(string s)
        {
            var n = s.Length;
            var maxLen = 1;
            var tmpLen = 1;
            if (n <= 1) return maxLen;
            for (var i = 1; i < n; i++)
            {
                if (s[i] == (s[i - 1] + 1)) tmpLen++;
                else
                {
                    tmpLen = 1;
                }
                maxLen = Math.Max(maxLen, tmpLen);
            }
            return maxLen;
        }
    }
}
