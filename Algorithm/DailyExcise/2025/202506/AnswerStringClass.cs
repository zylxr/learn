using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class AnswerStringClass
    {
        //3403. 从盒子中找出字典序最大的字符串 I
        //给你一个字符串 word 和一个整数 numFriends。

        //Alice 正在为她的 numFriends 位朋友组织一个游戏。游戏分为多个回合，在每一回合中：

        //word 被分割成 numFriends 个 非空 字符串，且该分割方式与之前的任意回合所采用的都 不完全相同 。
        //所有分割出的字符串都会被放入一个盒子中。
        //在所有回合结束后，找出盒子中 字典序最大的 字符串。



        //示例 1：

        //输入: word = "dbca", numFriends = 2

        //输出: "dbc"

        //解释: 

        //所有可能的分割方式为：

        //"d" 和 "bca"。
        //"db" 和 "ca"。
        //"dbc" 和 "a"。
        //示例 2：

        //输入: word = "gggg", numFriends = 4

        //输出: "g"

        //解释: 

        //唯一可能的分割方式为："g", "g", "g", 和 "g"。



        //提示:

        //1 <= word.length <= 5 * 103
        //word 仅由小写英文字母组成。
        //1 <= numFriends <= word.length

        public string AnswerString(string word, int numFriends)
        {
            var n = word.Length;
            if (numFriends > n) return string.Empty;
            if (numFriends == 1) return word;
            var maxStr = string.Empty;
            var maxPos = 0;
            var maxVal = word[maxPos];
            for (var i = 1; i < n; i++)
                if (word[i] > maxVal)
                {
                    maxPos = i;
                    maxVal = word[i];
                }
                else if (word[i] == maxVal)
                {
                    if (i < n - 1 && word[i + 1] > word[maxPos + 1])
                        maxPos = i;
                }
            var matches = new List<string>();
            for (var i = 0; i < n; i++)
            {
                if (word[i] == maxVal)
                {
                    var len = Math.Min(n - numFriends + 1, n - i);
                    maxStr = word.Substring(i, len);
                    matches.Add(maxStr);
                }
            }
            maxStr = String.Empty;
            foreach (var s in matches)
            {
                if (Great(s, maxStr)) maxStr = s;
            }

            return maxStr;
        }
        private bool Great(string s1, string s2)
        {
            var l1 = s1.Length;
            var l2 = s2.Length;
            var l = Math.Min(l1, l2);
            var i = 0;
            while (i < l)
            {
                if (s1[i] == s2[i]) i++;
                else if (s1[i] > s2[i]) return true;
                else return false;
            }
            return l1 < l2 ? false : true;
        }

        public string AnswerString2(string word, int numFriends)
        {
            if (numFriends == 1) return word;
            var n = word.Length;
            var res = "";
            for(var i=0;i<n;i++)
            {
                var s = word.Substring(i, Math.Min(n - numFriends + 1, n - i));
                if (string.Compare(res, s) <= 0) res = s;
            }
            return res;
        }

        public string LastSubstring(string s)
        {
            int i = 0, j = 1, n = s.Length;
            while(j<n)
            {
                var k = 0;
                while (j + k < n && s[i + k] == s[j + k]) k++;
                if (j + k < n && s[i + k] < s[j + k])
                {
                    var t = i;
                    i = j;
                    j = Math.Max(j + 1, t + k + 1);
                }
                else
                    j = j + k + 1;
            }
            return s.Substring(i);
        }

        public string AnswerString3(string word,int numFriends)
        {
            if (numFriends == 1) return word;
            var last = LastSubstring(word);
            var n = word.Length;
            var m = last.Length;
            return last.Substring(0, Math.Min(m, n - numFriends + 1));
        }
    }
}
