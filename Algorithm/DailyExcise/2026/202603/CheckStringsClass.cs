using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class CheckStringsClass
    {
        //2840. 判断通过操作能否让字符串相等 II
        //给你两个字符串 s1 和 s2 ，两个字符串长度都为 n ，且只包含 小写 英文字母。

        //你可以对两个字符串中的 任意一个 执行以下操作 任意 次：

        //选择两个下标 i 和 j ，满足 i<j 且 j - i 是 偶数，然后 交换 这个字符串中两个下标对应的字符。



        //如果你可以让字符串 s1 和 s2 相等，那么返回 true ，否则返回 false 。






        //示例 1：

        //输入：s1 = "abcdba", s2 = "cabdab"
        //输出：true
        //解释：我们可以对 s1 执行以下操作：
        //- 选择下标 i = 0 ，j = 2 ，得到字符串 s1 = "cbadba" 。
        //- 选择下标 i = 2 ，j = 4 ，得到字符串 s1 = "cbbdaa" 。
        //- 选择下标 i = 1 ，j = 5 ，得到字符串 s1 = "cabdab" = s2 。
        //示例 2：

        //输入：s1 = "abe", s2 = "bea"
        //输出：false
        //解释：无法让两个字符串相等。



        //提示：

        //n == s1.length == s2.length
        //1 <= n <= 105
        //s1 和 s2 只包含小写英文字母。
        public bool CheckStrings(string s1, string s2)
        {
            var n = s1.Length;
            var res = true;
            if (n == 1) return s1[0] == s2[0];
            for (var i = 0; i < 2; i++)
            {
                var dict1 = new Dictionary<int, int>();
                var dict2 = new Dictionary<int, int>();
                for (var j = i; j < n; j += 2)
                {
                    var k1 = s1[j] - 'a';
                    var k2 = s2[j] - 'a';
                    dict1.TryAdd(k1, 0);
                    dict2.TryAdd(k2, 0);
                    dict1[k1]++;
                    dict2[k2]++;
                }
                if (dict1.Count != dict2.Count) return false;
                foreach (var key in dict1.Keys)
                {
                    if (!dict2.ContainsKey(key) || dict1[key] != dict2[key]) return false;
                }
            }
            return res;
        }
    }
}
