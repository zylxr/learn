using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class CheckPartitioningClass
    {
        //1745. 分割回文串 IV
        //给你一个字符串 s ，如果可以将它分割成三个 非空 回文子字符串，那么返回 true ，否则返回 false 。

        //当一个字符串正着读和反着读是一模一样的，就称其为 回文字符串 。




        //示例 1：

        //输入：s = "abcbdd"
        //输出：true
        //解释："abcbdd" = "a" + "bcb" + "dd"，三个子字符串都是回文的。
        //示例 2：

        //输入：s = "bcbddxy"
        //输出：false
        //解释：s 没办法被分割成 3 个回文子字符串。


        //提示：

        //3 <= s.length <= 2000
        //s​​​​​​ 只包含小写英文字母。
        public bool CheckPartitioning(string s)
        {
            var n = s.Length;
            var isPalindrome = new bool[n, n];
            for(var i=n-1;i>=0;i--)
            {
                isPalindrome[i, i] = true;
                for (var j = i + 1; j < n; j++)
                {
                    if(j-1<i+1)isPalindrome[i, j] = s[i]==s[j];
                    else isPalindrome[i, j] = isPalindrome[i + 1, j - 1] && s[i] == s[j];
                }
            }

            for(var start = 1; start <n-1;start++)
            {
                if (!isPalindrome[0, start - 1]) continue;
                for (var end = start; end < n - 1; end++)
                    if (isPalindrome[start, end] && isPalindrome[end+1,n-1]) return true;
            }
            return false;
        }
    }
}
