using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class CandyClass
    {
        //135. 分发糖果
        //n 个孩子站成一排。给你一个整数数组 ratings 表示每个孩子的评分。

        //你需要按照以下要求，给这些孩子分发糖果：

        //每个孩子至少分配到 1 个糖果。
        //相邻两个孩子评分更高的孩子会获得更多的糖果。
        //请你给每个孩子分发糖果，计算并返回需要准备的 最少糖果数目 。




        //示例 1：

        //输入：ratings = [1, 0, 2]
        //输出：5
        //解释：你可以分别给第一个、第二个、第三个孩子分发 2、1、2 颗糖果。
        //示例 2：

        //输入：ratings = [1, 2, 2]
        //输出：4
        //解释：你可以分别给第一个、第二个、第三个孩子分发 1、2、1 颗糖果。
        //第三个孩子只得到 1 颗糖果，这满足题面中的两个条件。


        //提示：

        //n == ratings.length
        //1 <= n <= 2 * 104
        //0 <= ratings[i] <= 2 * 104
        public int Candy(int[] ratings)
        {
            var n = ratings.Length;
            var ans = 0;
            var d = new int[n];
            d[0] = 1;
            for (var i = 1; i < n; i++)
            {
                if (ratings[i] == ratings[i - 1])
                {
                    d[i] = 1;
                }
                else if (ratings[i] > ratings[i - 1])
                {
                    d[i] = d[i - 1] + 1;
                }
                else
                {
                    d[i] = 1;
                    var j = i-1 ;
                    while (j >= 0 && ratings[j] > ratings[j+1]&& d[j] - d[j+1]==0)
                    {
                        d[j]++;
                        j--;
                    }
                }
            }
            for (var i = 0; i < n; i++) ans += d[i];
            return ans;
        }

        public int Candy2(int[] ratings)
        {
            var n = ratings.Length;
            var left = new int[n];
            for (var i = 0; i < n; i++)
            {
                if (i > 0 && ratings[i] > ratings[i - 1])
                    left[i] = left[i - 1] + 1;
                else
                    left[i] = 1;
            }
            var ret = 0;
            var right = 0;
            for (var i = n - 1; i >= 0; i--)
            {
                if (i < n - 1 && ratings[i] > ratings[i + 1])
                    right++;
                else
                    right = 1;
                ret += Math.Max(right, left[i]);
            }
            return ret;
        }

        public int Candy3(int[] ratings)
        {
            var n = ratings.Length;
            var ret = 1;
            var inc = 1;
            var dec = 0;
            var pre = 1;
            for (var i = 1; i < n; i++)
            {
                if (ratings[i] >= ratings[i - 1])
                {
                    dec = 0;
                    pre = ratings[i] == ratings[i - 1] ? 1 : pre + 1;
                    ret += pre;
                    inc = pre;
                }
                else
                {
                    dec++;
                    if (dec == inc) dec++;
                    ret += dec;
                    pre = 1;
                }
            }
            return ret;
        }
    }
    
}
