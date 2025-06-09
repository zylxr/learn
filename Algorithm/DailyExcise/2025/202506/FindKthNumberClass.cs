using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class FindKthNumberClass
    {
        //440. 字典序的第K小数字
        //给定整数 n 和 k，返回[1, n] 中字典序第 k 小的数字。




        //示例 1:

        //输入: n = 13, k = 2
        //输出: 10
        //解释: 字典序的排列是[1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9]，所以第二小的数字是 10。
        //示例 2:

        //输入: n = 1, k = 1
        //输出: 1


        //提示:

        //1 <= k <= n <= 109

        public int FindKthNumber(int n, int k)
        {
            var curr = 1;
            k--;
            while(k>0)
            {
                var steps = GetSteps(curr, n);
                if(steps<=k)
                {
                    k -= steps;
                    curr++;
                }
                else
                {
                    curr = curr * 10;
                    k--;
                }
            }
            return curr;
        }

        public int GetSteps(int curr,int n)
        {
            var steps = 0L;
            long first = curr;
            long last = curr;
            while(first<=n)
            {
                steps += Math.Min(last, n) - first + 1;
                first = first * 10;
                last = last * 10 + 9;
            }
            return (int)steps;
        }
    }
}
