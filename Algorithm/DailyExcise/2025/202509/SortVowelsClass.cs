using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class SortVowelsClass
    {
        //2785. 将字符串中的元音字母排序
        //给你一个下标从 0 开始的字符串 s ，将 s 中的元素重新 排列 得到新的字符串 t ，它满足：

        //所有辅音字母都在原来的位置上。更正式的，如果满足 0 <= i<s.length 的下标 i 处的 s[i] 是个辅音字母，那么 t[i] = s[i] 。
        //元音字母都必须以他们的 ASCII 值按 非递减 顺序排列。更正式的，对于满足 0 <= i<j<s.length 的下标 i 和 j  ，如果 s[i] 和 s[j] 都是元音字母，那么 t[i] 的 ASCII 值不能大于 t[j] 的 ASCII 值。
        //请你返回结果字母串。

        //元音字母为 'a' ，'e' ，'i' ，'o' 和 'u' ，它们可能是小写字母也可能是大写字母，辅音字母是除了这 5 个字母以外的所有字母。




        //示例 1：

        //输入：s = "lEetcOde"
        //输出："lEOtcede"
        //解释：'E' ，'O' 和 'e' 是 s 中的元音字母，'l' ，'t' ，'c' 和 'd' 是所有的辅音。将元音字母按照 ASCII 值排序，辅音字母留在原地。
        //示例 2：

        //输入：s = "lYmpH"
        //输出："lYmpH"
        //解释：s 中没有元音字母（s 中都为辅音字母），所以我们返回 "lYmpH" 。


        //提示：

        //1 <= s.length <= 105
        //s 只包含英语字母表中的 大写 和 小写 字母。
        public string SortVowels(string s)
        {
            var yuanyin = new char[] { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };
            var sortedSet = new List<char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (yuanyin.Contains(s[i]))
                {
                    var j = sortedSet.Count - 1;
                    if (j==-1 || sortedSet[j] < s[i])
                    {
                        sortedSet.Add(s[i]);
                        continue;
                    }
                    while (j >= 0 && sortedSet[j] > s[i]) j--;
                    sortedSet.Insert(j+1, s[i]);
                }
            }
            var sb = new StringBuilder();
            for (int i = 0, j = 0; i < s.Length; i++)
            {
                if (yuanyin.Contains(s[i]))
                    sb.Append(sortedSet[j++]);
                else
                    sb.Append(s[i]);
            }
            return sb.ToString();
        }

        public string SortVowels2(string s)
        {
            var tmp = new List<char>();
            foreach(var ch in s)if(vowels.Contains(ch))tmp.Add(ch);
            tmp.Sort();
            var arr = s.ToCharArray();
            var idx = 0;
            for(var i=0;i<arr.Length; i++)
            {
                if (vowels.Contains(arr[i])) arr[i] = tmp[idx++];
            }
            return new string(arr);
        }
        private readonly char[] vowels =  new char[] { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };
        public string SortVowels3(string s)
        {
            var cnt = new int[58];
            Array.Fill(cnt, -1);
            foreach (var ch in vowels)
                cnt[ch - 'A']++;
            foreach(var ch in s)
            {
                if (cnt[ch-'A']!=-1)cnt[ch-'A']++;
            }
            var arr = s.ToCharArray();
            var idx = 0;
            for(var i=0;i<arr.Length;i++)
            {
                var pos = arr[i] - 'A';
                if (cnt[pos] != -1)
                {
                    while (cnt[idx] <= 0) idx++;
                    arr[i] = (char)(idx + 'A');
                    cnt[idx]--;
                }
            }
            return new string(arr);
        }
    }

}
