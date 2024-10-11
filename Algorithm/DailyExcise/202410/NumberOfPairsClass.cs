using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class NumberOfPairsClass
    {
        //3164. 优质数对的总数 II
        //给你两个整数数组 nums1 和 nums2，长度分别为 n 和 m。同时给你一个正整数 k。

        //如果 nums1[i] 可以被 nums2[j] * k 整除，则称数对(i, j) 为 优质数对（0 <= i <= n - 1, 0 <= j <= m - 1）。

        //返回 优质数对 的总数。



        //示例 1：

        //输入：nums1 = [1, 3, 4], nums2 = [1, 3, 4], k = 1

        //输出：5

        //解释：

        //5个优质数对分别是(0, 0), (1, 0), (1, 1), (2, 0), 和(2, 2)。

        //示例 2：

        //输入：nums1 = [1, 2, 4, 12], nums2 = [2, 4], k = 3

        //输出：2

        //解释：

        //2个优质数对分别是(3, 0) 和(3, 1)。



        //提示：

        //1 <= n, m <= 105
        //1 <= nums1[i], nums2[j] <= 106
        //1 <= k <= 103
        public long NumberOfPairs(int[] nums1, int[] nums2, int k)
        {
            var count = new Dictionary<int, int>();
            var count2 = new Dictionary<int, int>();
            var max1 = 0;
            foreach(var num in nums1)
            {
                count.TryAdd(num, 0);
                count[num]++;
                max1 = Math.Max(max1, num);
            }
            foreach (var num in nums2)
            {
                count2.TryAdd(num, 0);
                count2[num]++;
            }
            long res = 0;
            foreach(var a in count2.Keys)
            {
                for(var b=a*k;b<=max1;b+=a*k)
                {
                    if (count.ContainsKey(b))
                        res += 1L * count[b] * count2[a];
                }
            }
            return res;
        }
    }
}
