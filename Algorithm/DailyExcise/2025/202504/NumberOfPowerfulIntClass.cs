using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class NumberOfPowerfulIntClass
    {
        //2999. 统计强大整数的数目
        //给你三个整数 start ，finish 和 limit 。同时给你一个下标从 0 开始的字符串 s ，表示一个 正 整数。

        //如果一个 正 整数 x 末尾部分是 s （换句话说，s 是 x 的 后缀），且 x 中的每个数位至多是 limit ，那么我们称 x 是 强大的 。

        //请你返回区间[start..finish] 内强大整数的 总数目 。

        //如果一个字符串 x 是 y 中某个下标开始（包括 0 ），到下标为 y.length - 1 结束的子字符串，那么我们称 x 是 y 的一个后缀。比方说，25 是 5125 的一个后缀，但不是 512 的后缀。




        //示例 1：

        //输入：start = 1, finish = 6000, limit = 4, s = "124"
        //输出：5
        //解释：区间[1..6000] 内的强大数字为 124 ，1124 ，2124 ，3124 和 4124 。这些整数的各个数位都 <= 4 且 "124" 是它们的后缀。注意 5124 不是强大整数，因为第一个数位 5 大于 4 。
        //这个区间内总共只有这 5 个强大整数。
        //示例 2：

        //输入：start = 15, finish = 215, limit = 6, s = "10"
        //输出：2
        //解释：区间[15..215] 内的强大整数为 110 和 210 。这些整数的各个数位都 <= 6 且 "10" 是它们的后缀。
        //这个区间总共只有这 2 个强大整数。
        //示例 3：

        //输入：start = 1000, finish = 2000, limit = 4, s = "3000"
        //输出：0
        //解释：区间[1000..2000] 内的整数都小于 3000 ，所以 "3000" 不可能是这个区间内任何整数的后缀。



        //提示：

        //1 <= start <= finish <= 1015
        //1 <= limit <= 9
        //1 <= s.length <= floor(log10(finish)) + 1
        //s 数位中每个数字都小于等于 limit 。
        //s 不包含任何前导 0 。

        public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
        {
            string low = start.ToString();
            string high = finish.ToString();
            int n = high.Length;
            low = low.PadLeft(n, '0'); // 对齐位数
            int pre_len = n - s.Length; // 前缀长度
            long[] memo = new long[n];
            Array.Fill(memo, -1);

            return Dfs(0, true, true, low, high, limit, s, pre_len, memo);
        }
        private long Dfs(int i, bool limitLow, bool limitHigh,
                    string low, string high, int limit, string s,
                    int preLen, long[] memo)
        {
            // 递归边界
            if (i == low.Length)
            {
                return 1;
            }
            if (!limitLow && !limitHigh && memo[i] != -1)
            {
                return memo[i];
            }
            int lo = limitLow ? low[i] - '0' : 0;
            int hi = limitHigh ? high[i] - '0' : 9;
            long res = 0;
            if (i < preLen)
            {
                for (int digit = lo; digit <= Math.Min(hi, limit); digit++)
                {
                    res += Dfs(i + 1, limitLow && digit == lo,
                              limitHigh && digit == hi,
                              low, high, limit, s, preLen, memo);
                }
            }
            else
            {
                int x = s[i - preLen] - '0';
                if (lo <= x && x <= Math.Min(hi, limit))
                {
                    res = Dfs(i + 1, limitLow && x == lo,
                             limitHigh && x == hi,
                             low, high, limit, s, preLen, memo);
                }
            }

            if (!limitLow && !limitHigh)
            {
                memo[i] = res;
            }
            return res;
        }
    }
}
