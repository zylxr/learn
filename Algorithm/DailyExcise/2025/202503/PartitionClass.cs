using Algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class PartitionClass
    {
        //131. 分割回文串
        //给你一个字符串 s，请你将 s 分割成一些子串，使每个子串都是 回文串 。返回 s 所有可能的分割方案。
        //示例 1：

        //输入：s = "aab"
        //输出：[["a", "a", "b"],["aa", "b"]]
        //示例 2：

        //输入：s = "a"
        //输出：[["a"]]


        //提示：

        //1 <= s.length <= 16
        //s 仅由小写英文字母组成
        bool[][] f;
        List<List<string>> ret = new List<List<string>>();
        List<string> ans = new List<string>();
        int n;
        public IList<List<string>> Partition(string s)
        {
            n = s.Length;
            f = new bool[n][];
            for (var i = 0; i < n; i++)
            {
                f[i] = new bool[n];
                Array.Fill(f[i], true);
            }
            for(var i=n-1;i>=0;i--)
            {
                for (var j = i + 1; j < n; j++)
                    f[i][j] = (s[i] == s[j]) && f[i + 1][j - 1];
            }
            DFS(s, 0);
            return ret;
        }

        public void DFS(string s, int i)
        {
            if(i == n)
            {
                ret.Add(new List<string>(ans));
                return;
            }
            for(var j=i;j<n;j++)
            {
                if (f[i][j])
                {
                    ans.Add(s.Substring(i,j-i+1));
                    DFS(s, j + 1);
                    ans.RemoveAt(ans.Count - 1);
                }
            }
        }
    }
}
