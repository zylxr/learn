using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{

    public class LongestPalindromeClass
    {
        //给你一个字符串 s，找到 s 中最长的回文
        //子串
        //。
        //如果字符串的反序与原始字符串相同，则该字符串称为回文字符串。 
        //示例 1：
        //输入：s = "babad"
        //输出："bab"
        //解释："aba" 同样是符合题意的答案。
        //示例 2：
        //输入：s = "cbbd"
        //输出："bb"
        //提示：
        //1 <= s.length <= 1000
        //s 仅由数字和英文字母组成
        public string LongestPalindrome(string s)
        {
            var n = s.Length;
            var dp = new bool[n, n];
            for (var i = 0; i < n; i++)
                dp[i, i] = true;
            var maxLength = 1;
            var begin = 0;
            for(var l=2;l<=n;l++)
            {
                for(var i=0;i<n;i++)
                {
                    var j = i + l-1;
                    if (j > n - 1||i>j) break;
                    if (i + 1 >= n||j-1<=0||i+1>=j-1)
                        dp[i, j] = (s[i] == s[j]);
                    else
                        dp[i, j] = (s[i] == s[j]) && dp[i + 1, j - 1];
                    if (dp[i,j] && maxLength<l)
                    {
                        maxLength = l;
                        begin = i;
                    }
                }
            }
            return s.Substring(begin,maxLength);
        }

        public int LongestPalindrome2(string s)
        {
            var n = s.Length;
            var dp = new int[n, n];
            for (var i = 0; i < n; i++)
                dp[i, i] = 1;
            var maxLength = 1;
            var begin = 0;
            for (var l =n-1; l >=0 ; l--)
            {
                for (var i = l+1; i < n; i++)
                {
                    if (s[l] == s[i])
                        dp[l, i] = dp[l + 1, i - 1] + 2;
                    else
                        dp[l, i] = 0;
                    if (maxLength < dp[l,i])maxLength = dp[l,i];
                }
            }
            return maxLength;
        }


        //中心扩展算法
        public string LongestPalinromeCenter(string s)
        {
            var n = s.Length;
            var start = 0;
            var maxLen = 1;
            for(var i=0;i<n-1;i++)
            {
                var len1 = PalindromeLength(s, i, i);
                var len2 = PalindromeLength(s, i, i + 1);
                var len = Math.Max(len1, len2);
                if (len > maxLen)
                {
                    maxLen = len;
                    start = i - (len-1) / 2 ;
                }
            } 
            return s.Substring(start,maxLen);
        }

        public int PalindromeLength(string s,int left,int right)
        {
            var len = 1;
            while (left>=0 && right<s.Length && s[left] == s[right])
            {
                len = right - left + 1;
                left = left - 1;
                right = right + 1;
            }
            return len;
        }

        //下面的讨论只涉及长度为奇数的回文字符串。长度为偶数的回文字符串我们将会在最后与长度为奇数的情况统一起来。
        //思路与算法

        //在中心扩展算法的过程中，我们能够得出每个位置的臂长。那么当我们要得出以下一个位置 i 的臂长时，能不能利用之前得到的信息呢？

        //答案是肯定的。具体来说，如果位置 j 的臂长为 length，并且有 j + length > i，如下图所示：
        //当在位置 i 开始进行中心拓展时，我们可以先找到 i 关于 j 的对称点 2 * j - i。那么如果点 2 * j - i 的臂长等于 n，我们就可以知道，点 i 的臂长至少为 min(j + length - i, n)。那么我们就可以直接跳过 i 到 i + min(j + length - i, n) 这部分，从 i + min(j + length - i, n) + 1 开始拓展。
        //我们只需要在中心扩展法的过程中记录右臂在最右边的回文字符串，将其中心作为 j，在计算过程中就能最大限度地避免重复计算。
        //那么现在还有一个问题：如何处理长度为偶数的回文字符串呢？
        //我们可以通过一个特别的操作将奇偶数的情况统一起来：我们向字符串的头尾以及每两个字符中间添加一个特殊字符 #，比如字符串 aaba 处理后会变成 #a#a#b#a#。那么原先长度为偶数的回文字符串 aa 会变成长度为奇数的回文字符串 #a#a#，而长度为奇数的回文字符串 aba 会变成长度仍然为奇数的回文字符串 #a#b#a#，我们就不需要再考虑长度为偶数的回文字符串了。

        //注意这里的特殊字符不需要是没有出现过的字母，我们可以使用任何一个字符来作为这个特殊字符。这是因为，当我们只考虑长度为奇数的回文字符串时，每次我们比较的两个字符奇偶性一定是相同的，所以原来字符串中的字符不会与插入的特殊字符互相比较，不会因此产生问题。

        public string PalindromeLengthManacher(string s)
        {
            var start = 0;
            var maxLen = 1;
            var sb = new StringBuilder();
            sb.Append("#");
            for(var i=0;i<s.Length ; i++)
            {
                sb.Append(s[i]);
                sb.Append("#");
            }
            s = sb.ToString();
            var right = -1;
            var j = -1;
            var armList = new List<int>();
            for(var i=0;i<s.Length ;i++)
            {
                int cur;
                if (right > i)
                {
                    var i_sym = j * 2 - i;
                    var min_symLen = Math.Min(armList[i_sym], right - i);
                    cur = ArmLength(s,i-min_symLen,i+min_symLen);
                }else
                {
                    cur = ArmLength(s, i, i);
                }
                armList.Add(cur);
                if (i + cur > right)
                {
                    j = i;
                    right = i + cur;
                }
                if(cur*2+1>maxLen)
                {
                    start = i - cur;
                    maxLen = 2 * cur+1;
                }
            }

            var ans = new StringBuilder();
            for(var i=start;i<start+maxLen;i++) {
                if (s[i] != '#')
                {
                    ans.Append(s[i]);
                }
            }
            return ans.ToString();

        }

        public int ArmLength(string s, int left,int right)
        {
            var armLength = 0;
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left = left- 1;
                right = right + 1;
            }
            armLength = (right-left-2)/2;
            return armLength;
        }
    }
}
