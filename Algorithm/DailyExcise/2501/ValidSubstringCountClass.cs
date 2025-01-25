using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class ValidSubstringCountClass
    {
        //3297. 统计重新排列后包含另一个字符串的子字符串数目 I
        //给你两个字符串 word1 和 word2 。

        //如果一个字符串 x 重新排列后，word2 是重排字符串的
        //前缀
        //，那么我们称字符串 x 是 合法的 。

        //请你返回 word1 中 合法
        //子字符串
        //的数目。




        //示例 1：

        //输入：word1 = "bcca", word2 = "abc"

        //输出：1

        //解释：

        //唯一合法的子字符串是 "bcca" ，可以重新排列得到 "abcc" ，"abc" 是它的前缀。

        //示例 2：

        //输入：word1 = "abcabc", word2 = "abc"

        //输出：10

        //解释：

        //除了长度为 1 和 2 的所有子字符串都是合法的。

        //示例 3：

        //输入：word1 = "abcabc", word2 = "aaabc"

        //输出：0



        //解释：

        //1 <= word1.length <= 105
        //1 <= word2.length <= 104
        //word1 和 word2 都只包含小写英文字母。
        public long ValidSubstringCount(string word1, string word2)
        {
            var diff = new int[26];
            foreach (var c in word2)
                diff[c - 'a']--;
            var res = 0L;
            var cnt = diff.Count(_ => _ < 0);
            var l = 0;
            var r = 0;
            while(l<word1.Length)
            {
                while (r < word1.Length && cnt > 0)
                {
                    Update(diff, word1[r] - 'a', 1, ref cnt);
                    r++;
                }
                if (cnt == 0) res += word1.Length - r + 1;
                Update(diff, word1[l] - 'a', -1, ref cnt);
                l++;
            }
            return res;
        }

        private void Update(int[] diff, int c, int add ,ref int cnt)
        {
            diff[c] += add;
            if (add == 1 && diff[c] == 0) cnt--;
            else if (add == -1 && diff[c] == -1)cnt++;
        }

        public long ValidSubstringCount2(string word1, string word2)
        {
            var count = new int[26];
            foreach (var c in word2)
                count[c - 'a']++;
            var n = word1.Length;
            var preCount = new int[n + 1, 26];
            for(var i=1;i<=n;i++)
            {
                for (var j = 0; j < 26; j++)
                    preCount[i, j] = preCount[i - 1, j];
                preCount[i, word1[i - 1] - 'a']++;
            }
            var res = 0L;
            for(var l=1;l<=n;l++)
            {
                var r = Get(l, n + 1, preCount, count);
                res += n - r + 1;
            }
            return res;
        }
        private int Get(int l, int r, int[,] preCount, int[] count)
        {
            var border = l;
            while(l<r)
            {
                var m = (l + r) >> 1;
                var f = true;
                for(var i=0;i<26;i++)
                {
                    if (preCount[m, i] - preCount[border - 1, i] < count[i])
                    {
                        f = false;
                        break;
                    }
                }
                if (f) r = m;
                else l = m + 1;
            }
            return l;
        }
    }
}
