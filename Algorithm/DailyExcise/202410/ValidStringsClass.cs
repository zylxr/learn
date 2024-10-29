using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class ValidStringsClass
    {
        //3211. 生成不含相邻零的二进制字符串
        //给你一个正整数 n。

        //如果一个二进制字符串 x 的所有长度为 2 的
        //子字符串
        //中包含 至少 一个 "1"，则称 x 是一个 有效 字符串。

        //返回所有长度为 n 的 有效 字符串，可以以任意顺序排列。



        //示例 1：

        //输入： n = 3

        //输出： ["010", "011", "101", "110", "111"]

        //解释：

        //长度为 3 的有效字符串有："010"、"011"、"101"、"110" 和 "111"。

        //示例 2：

        //输入： n = 1

        //输出： ["0", "1"]

        //解释：

        //长度为 1 的有效字符串有："0" 和 "1"。



        //提示：

        //1 <= n <= 18
        public IList<string> ValidStrings(int n)
        {
            this.n = n;
            DFS(new StringBuilder());
            return res;
        }


        int n;
        IList<string> res = new List<string>();
        public void DFS(StringBuilder sb)
        {
            if(sb.Length == n)res.Add(sb.ToString());
            else
            {
                if(sb.Length == 0 || sb[sb.Length-1] == '1')
                {
                    sb.Append('0');
                    DFS(sb);
                    sb.Length--;
                }
                sb.Append('1');
                DFS(sb);
                sb.Length--;
            }
        }

        public List<string> ValidStrings2(int n)
        {
            var  res = new List<string>();
            var mask = (1 << n) - 1;
            for(var i=0;i<1<<n;i++)
            {
                var t = mask ^ i;
                if(((t >>1) & t) == 0)
                {
                    var str = Convert.ToString(i, 2);
                    var sb = new StringBuilder();
                    for (var j = n - str.Length; j > 0; j--)
                        sb.Append('0');
                    sb.Append(str);
                    res.Add(sb.ToString());
                }
            }
            return res;
        }
    }
}
