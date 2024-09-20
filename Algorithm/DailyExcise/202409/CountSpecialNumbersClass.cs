using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class CountSpecialNumbersClass
    {
        //2376. 统计特殊整数
        //如果一个正整数每一个数位都是 互不相同 的，我们称它是 特殊整数 。

        //给你一个 正 整数 n ，请你返回区间[1, n] 之间特殊整数的数目。




        //示例 1：

        //输入：n = 20
        //输出：19
        //解释：1 到 20 之间所有整数除了 11 以外都是特殊整数。所以总共有 19 个特殊整数。
        //示例 2：

        //输入：n = 5
        //输出：5
        //解释：1 到 5 所有整数都是特殊整数。
        //示例 3：

        //输入：n = 135
        //输出：110
        //解释：从 1 到 135 总共有 110 个整数是特殊整数。
        //不特殊的部分数字为：22 ，114 和 131 。


        //提示：

        //1 <= n <= 2 * 109
        public int CountSpecialNumbers(int n)
        {
            var ans = 0;
            for (var i = 1; i <= n; i++)
            {
                var t = i;
                var dict = new Dictionary<int, int>();
                var isSpecial = true;
                while (t > 0)
                {
                    var r = t % 10;
                    if (dict.ContainsKey(r))
                    {
                        isSpecial = false;
                        break;
                    }
                    dict.Add(r, 1);
                    t /= 10;
                }
                if(isSpecial)ans++;
            }
            return ans;
        }

        public int CountSpecialNumbers2(int n)
        {
            var nStr = n.ToString();
            var res = 0;
            var prod = 9;
            for(var i=0;i<nStr.Length-1; i++)
            {
                res += prod;
                prod *= 9 - i;
            }
            res += Dp(0, false, nStr);
            return res;
        }
        public int CountOnes(int number)
        {
            var count = 0;
            while (number > 0)
            {
                count++;
                number &= number - 1;
            }
            return count;
        }
        Dictionary<int, int> memo = new Dictionary<int, int>();
        private int Dp(int mask, bool prefixSmaller,string nStr)
        {
            if (CountOnes(mask) == nStr.Length) return 1;
            var key = mask * 2 + (prefixSmaller ? 1 : 0);
            if(!memo.ContainsKey(key))
            {
                var res = 0;
                var lowerBound = mask == 0 ? 1 : 0;
                var upperBound = prefixSmaller ? 9 : nStr[CountOnes(mask)] - '0';
                for(var i = lowerBound;i<= upperBound; i++)
                {
                    if (((mask >> i) & 1) == 0)
                        res += Dp(mask | (1 << i), prefixSmaller || i < upperBound, nStr);
                }
                memo[key] = res;
            }
            return memo[key];
        }
    }
}
