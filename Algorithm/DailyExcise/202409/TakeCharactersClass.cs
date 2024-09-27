using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class TakeCharactersClass
    {
        //2516. 每种字符至少取 K 个
        //给你一个由字符 'a'、'b'、'c' 组成的字符串 s 和一个非负整数 k 。每分钟，你可以选择取走 s 最左侧 还是 最右侧 的那个字符。

        //你必须取走每种字符 至少 k 个，返回需要的 最少 分钟数；如果无法取到，则返回 -1 。



        //示例 1：

        //输入：s = "aabaaaacaabc", k = 2
        //输出：8
        //解释：
        //从 s 的左侧取三个字符，现在共取到两个字符 'a' 、一个字符 'b' 。
        //从 s 的右侧取五个字符，现在共取到四个字符 'a' 、两个字符 'b' 和两个字符 'c' 。
        //共需要 3 + 5 = 8 分钟。
        //可以证明需要的最少分钟数是 8 。
        //示例 2：

        //输入：s = "a", k = 1
        //输出：-1
        //解释：无法取到一个字符 'b' 或者 'c'，所以返回 -1 。


        //提示：

        //1 <= s.length <= 105
        //s 仅由字母 'a'、'b'、'c' 组成
        //0 <= k <= s.length

        public int TakeCharacters(string s, int k)
        {
            var n = s.Length;
            var dict = new Dictionary<char, int>();
            dict.Add('a', 0);
            dict.Add('b', 0);
            dict.Add('c', 0);
            for (var i = 0; i < n; i++)
            {
                dict[s[i]]++;
            }
            if (dict['a'] < k || dict['b'] < k || dict['c'] < k) return -1;
            var maxLen = 0;
            for (int low = 0, high = 0; high < n; high++)
            {
                dict[s[high]]--;
                while (low <= high && (dict['a'] < k || dict['b'] < k || dict['c'] < k))
                {
                    dict[s[low++]]++;
                }
                maxLen = Math.Max(maxLen, high - low+1);

            }
            return n - maxLen;
        }

        public int TakeCharacters2(string s, int k)
        {
            var n = s.Length;
            var cnt = new int[3];
            foreach(var c in s)
                cnt[c - 'a']++;
            if (cnt[0] < k || cnt[1] < k || cnt[2] < k) return -1;
            var ans = n;
            for(int low=0,high = 0;high<n; high++)
            {
                cnt[s[high] - 'a']--;
                while(low<high && (cnt[0] < k || cnt[1]<k || cnt[2]<k))
                {
                    cnt[s[low++] - 'a']++;
                }
                if (cnt[0] >= k && cnt[1] >= k && cnt[2] >= k)
                    ans = Math.Min(ans, n - (high - low + 1));
            }
            return ans;
        }
    }
}
