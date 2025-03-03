using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class PalindromePartitionClass
    {
        //1278.分割回文串 III
        //给你一个由小写字母组成的字符串 s，和一个整数 k。

        //请你按下面的要求分割字符串：

        //首先，你可以将 s 中的部分字符修改为其他的小写英文字母。
        //接着，你需要把 s 分割成 k 个非空且不相交的子串，并且每个子串都是回文串。
        //请返回以这种方式分割字符串所需修改的最少字符数。



        //示例 1：

        //输入：s = "abc", k = 2
        //输出：1
        //解释：你可以把字符串分割成 "ab" 和 "c"，并修改 "ab" 中的 1 个字符，将它变成回文串。
        //示例 2：

        //输入：s = "aabbc", k = 3
        //输出：0
        //解释：你可以把字符串分割成 "aa"、"bb" 和 "c"，它们都是回文串。
        //示例 3：

        //输入：s = "leetcode", k = 8
        //输出：0



        //提示：

        //1 <= k <= s.length <= 100
        //s 中只含有小写英文字母。
        public int PalindromePartition(string s, int k)
        {

            var n = s.Length;
            var f = new int[n + 1, k+1];
            for (var i = 0; i <= n; i++)
                for (var j = 0; j <= k; j++)
                    f[i, j] = int.MaxValue;
            f[0, 0] = 0;
            for (var i = 1;i<=n;i++)
            {
                for(var j=1;j<=Math.Min(k,i);j++)
                {
                    if (j == 1)
                        f[i, j] = Cost(0, i - 1, s);
                    else
                    {
                        for(var i0=j-1;i0<=i;i0++)
                        {
                            f[i,j]= Math.Min(f[i, j], f[i0,j-1]+Cost(0, i - 1, s));
                        }
                    }
                }
            }
            return f[n, k];
        }
        public int Cost(int left,int right, string s)
        {
            var ans = 0;
            while(left<=right)
            {
                ans += s[left] == s[right] ? 0 : 1;
                left++;
                right--;
            }
            return ans;
        }

        public int PalindromePartition2(string s, int k)
        {
            var n = s.Length;
            var cost = new int[n, n];
            for(var span=2;span<=n;span++)
            {
                for(var i=0;i<=n-span;i++)
                {
                    var j = i + span - 1;
                    cost[i,j] = cost[i + 1, j - 1] + (s[i] == s[j]? 0 : 1);
                }
            }
            var f = new int[n + 1, k + 1];
            for (var i = 0; i <= n; i++)
                for (var j = 0; j <= k; j++) f[i, j] = int.MaxValue;
            f[0, 0] = 0;
            for(var i=1;i<=n;i++)
            {
                for(var j=1;j<=Math.Min(i,k);j++)
                {
                    if (j == 1) f[i, j] = cost[0, i - 1];
                    else
                    {
                        for (var i0 = j - 1; i0 < i; i0++)
                            f[i, j] = Math.Min(f[i, j], f[i0, j - 1] + cost[i0, i - 1]);
                    }
                }
            }
            return f[n, k];
        }
    }
}
