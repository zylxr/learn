using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class ClearStarsClass
    {
        //3170. 删除星号以后字典序最小的字符串
        //给你一个字符串 s 。它可能包含任意数量的 '*' 字符。你的任务是删除所有的 '*' 字符。

        //当字符串还存在至少一个 '*' 字符时，你可以执行以下操作：

        //删除最左边的 '*' 字符，同时删除该星号字符左边一个字典序 最小 的字符。如果有多个字典序最小的字符，你可以删除它们中的任意一个。
        //请你返回删除所有 '*' 字符以后，剩余字符连接而成的 字典序最小 的字符串。



        //示例 1：

        //输入：s = "aaba*"

        //输出："aab"

        //解释：

        //删除 '*' 号和它左边的其中一个 'a' 字符。如果我们选择删除 s[3] ，s 字典序最小。

        //示例 2：

        //输入：s = "abc"

        //输出："abc"

        //解释：

        //字符串中没有 '*' 字符。



        //提示：

        //1 <= s.length <= 105
        //s 只含有小写英文字母和 '*' 字符。
        //输入保证操作可以删除所有的 '*' 字符。

        public string ClearStars(string s)
        {
            var cnt = new Stack<int>[26];
            for (var i = 0; i < 26; i++) cnt[i] = new Stack<int>();
            var arr = s.ToCharArray();
            for(var i=0;i<arr.Length;i++)
            {
                if (arr[i] != '*') cnt[arr[i] - 'a'].Push(i);
                else
                {
                    for(var j=0;j<26;j++)
                    {
                        if (cnt[j].Count>0)
                        {
                            arr[cnt[j].Pop()] = '*';
                            break;
                        }
                    }
                }
            }
            return new string(Array.FindAll(arr,c=>c!='*'));
        }
    }
}
