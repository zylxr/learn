using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaximumGainClass
    {
        //1717. 删除子字符串的最大得分
        //给你一个字符串 s 和两个整数 x 和 y 。你可以执行下面两种操作任意次。

        //删除子字符串 "ab" 并得到 x 分。
        //比方说，从 "cabxbae" 删除 ab ，得到 "cxbae" 。
        //删除子字符串"ba" 并得到 y 分。
        //比方说，从 "cabxbae" 删除 ba ，得到 "cabxe" 。
        //请返回对 s 字符串执行上面操作若干次能得到的最大得分。



        //示例 1：

        //输入：s = "cdbcbbaaabab", x = 4, y = 5
        //输出：19
        //解释：
        //- 删除 "cdbcbbaaabab" 中加粗的 "ba" ，得到 s = "cdbcbbaaab" ，加 5 分。
        //- 删除 "cdbcbbaaab" 中加粗的 "ab" ，得到 s = "cdbcbbaa" ，加 4 分。
        //- 删除 "cdbcbbaa" 中加粗的 "ba" ，得到 s = "cdbcba" ，加 5 分。
        //- 删除 "cdbcba" 中加粗的 "ba" ，得到 s = "cdbc" ，加 5 分。
        //总得分为 5 + 4 + 5 + 5 = 19 。
        //示例 2：

        //输入：s = "aabbaaxybbaabb", x = 5, y = 4
        //输出：20


        //提示：

        //1 <= s.length <= 105
        //1 <= x, y <= 104
        //s 只包含小写英文字母。
        public int MaximumGain(string s, int x, int y)
        {
            var sum = 0;
            var first = x > y ? 'a' : 'b';
            var second = x > y ? 'b' : 'a';
            var min = Math.Min(x, y);
            var max = Math.Max(x, y);
            var ret1 = RemovePattern(s, first, second, max);
            sum += ret1.Item1;
            var ret2 = RemovePattern(ret1.Item2, second, first, min);
            sum += ret2.Item1;
            return sum;
        }

        private (int,string) RemovePattern(string s,char first,char second,int score)
        {
            var stack = new Stack<char>();
            var totalScore = 0;
            foreach(var ch in s)
            {
                if(ch==second && stack.Count>0 && stack.Peek()==first)
                {
                    totalScore += score;
                    stack.Pop();
                }else stack.Push(ch);
            }
            return (totalScore, string.Concat(stack.Reverse())); 
        }
    }
}
