using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Algorithm.DailyExcise
{
    public class FindLUSlengthClass
    {
        //给定字符串列表 strs ，返回其中 最长的特殊序列 的长度。如果最长特殊序列不存在，返回 -1 。
        //特殊序列 定义如下：该序列为某字符串 独有的子序列（即不能是其他字符串的子序列）。
        //s 的 子序列可以通过删去字符串 s 中的某些字符实现。
        //例如，"abc" 是 "aebdc" 的子序列，因为您可以删除"aebdc"中的下划线字符来得到 "abc" 。"aebdc"的子序列还包括"aebdc"、 "aeb" 和 "" (空字符串)。

        //示例 1：
        //输入: strs = ["aba", "cdc", "eae"]
        //输出: 3

        //示例 2:
        //输入: strs = ["aaa", "aaa", "aa"]
        //输出: -1

        //提示:

        //2 <= strs.length <= 50
        //1 <= strs[i].length <= 10
        //strs[i] 只包含小写英文字母


        //对于给定的某个字符串 str[i]，如果它的一个子序列 sub 是「特殊序列」，
        //那么 str[i] 本身也是一个「特殊序列」。
        //这是因为如果 sub 没有在除了 str[i] 之外的字符串中以子序列的形式出现过，那么给 sub 不断地添加字符，它也不会出现。
        //而 str[i] 就是 sub 添加若干个（可以为零个）字符得到的结果。
        //因此我们只需要使用一个双重循环，外层枚举每一个字符串 str[i] 作为特殊序列，内层枚举每一个字符串 str[j] (i≠j)，判断 str[i] 是否不为 str[j] 的子序列即可。
        //要想判断 str[i] 是否为 str[j] 的子序列，我们可以使用贪心 + 双指针的方法：即初始时指针 pti 和 ptj 分别指向两个字符串的首字符。
        //如果两个字符相同，那么两个指针都往右移动一个位置，表示匹配成功；否则只往右移动指针 ptj，表示匹配失败。如果 pti
        //遍历完了整个字符串，就说明 str[i] 是 str[j]  的子序列。
        //在所有满足要求的 str[i]  中，我们选出最长的那个，返回其长度作为答案。如果不存在满足要求的字符串，那么返回 −1。
        public int FindLUSlength(string[] strs)
        {
            var res = -1;
            var n = strs.Length;
            for(var i=0;i < n;i++)
            {
                var check = true;
                for(var j=0;j<n;j++)
                {
                    if(i!=j && IsSub(strs[i],strs[j]))
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                    res = Math.Max(res, strs[i].Length);
            }
            return res;
        }

        private bool IsSub(string s, string t)
        {
            var sIndex = 0; var tIndex = 0;
            while (sIndex < s.Length && tIndex < t.Length)
            {
                if (s[sIndex] == t[tIndex])
                {
                    sIndex++;
                }
                tIndex++;
            }
            return sIndex == s.Length;
        }
    }
}
