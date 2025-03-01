using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class CountKConstraintSubstringsClass2
    {
        //3261. 统计满足 K 约束的子字符串数量 II
        //给你一个 二进制 字符串 s 和一个整数 k。

        //另给你一个二维整数数组 queries ，其中 queries[i] = [li, ri] 。

        //如果一个 二进制字符串 满足以下任一条件，则认为该字符串满足 k 约束：

        //字符串中 0 的数量最多为 k。
        //字符串中 1 的数量最多为 k。
        //返回一个整数数组 answer ，其中 answer[i] 表示 s[li..ri] 中满足 k 约束 的
        //子字符串
        //的数量。




        //示例 1：

        //输入：s = "0001111", k = 2, queries = [[0, 6]]

        //输出：[26]

        //解释：

        //对于查询[0, 6]， s[0..6] = "0001111" 的所有子字符串中，除 s[0..5] = "000111" 和 s[0..6] = "0001111" 外，其余子字符串都满足 k 约束。

        //示例 2：

        //输入：s = "010101", k = 1, queries = [[0, 5],[1, 4],[2, 3]]

        //输出：[15, 9, 3]

        //解释：

        //s 的所有子字符串中，长度大于 3 的子字符串都不满足 k 约束。



        //提示：

        //1 <= s.length <= 105
        //s[i] 是 '0' 或 '1'
        //1 <= k <= s.length
        //1 <= queries.length <= 105
        //queries[i] == [li, ri]
        //0 <= li <= ri<s.length
        //所有查询互不相同
        public long[] CountKConstraintSubstrings(string s, int k, int[][] queries)
        {
            var n = s.Length;
            var count = new int[2];
            var right = new int[n];
            Array.Fill(right, n);
            var prefix = new long[n + 1];
            for(int i=0,j=0;j<n;j++)
            {
                count[s[j] - '0']++;
                while (count[0]>k && count[1]>k)
                {
                    count[s[i] - '0']--;
                    right[i] = j;
                    i++;
                }
                prefix[j + 1] = prefix[j] + j - i + 1;
            }
            var res = new long[queries.Length];
            for(var q =0;q<queries.Length;q++)
            {
                var l = queries[q][0];
                var r = queries[q][1];
                var i = Math.Min(right[l], r + 1);
                var part1 = (long)(i - l + 1) * (i - l) / 2;
                var part2 = prefix[r + 1] - prefix[i];
                res[q] = part1 + part2;
            }
            return res;
        }
    }
}
