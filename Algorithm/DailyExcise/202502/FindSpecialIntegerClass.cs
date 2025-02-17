using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class FindSpecialIntegerClass
    {
        //1287. 有序数组中出现次数超过25%的元素
        //给你一个非递减的 有序 整数数组，已知这个数组中恰好有一个整数，它的出现次数超过数组元素总数的 25%。

        //请你找到并返回这个整数



        //示例：

        //输入：arr = [1, 2, 2, 6, 6, 6, 6, 7, 10]
        //输出：6



        //提示：

        //1 <= arr.length <= 10^4
        //0 <= arr[i] <= 10^5
        public int FindSpecialInteger(int[] arr)
        {
            var dict = new Dictionary<int, int>();
            var ans = arr[0];
            var total = arr.Length;
            for (var i = 0; i < arr.Length; i++)
            {
                dict.TryAdd(arr[i], 0);
                dict[arr[i]]++;
            }
            var maxRate = 0f;
            foreach (var item in dict.Keys)
            {
                var rate = (float)dict[item] / total;

                if (rate >= 0.25 && rate>maxRate)
                {
                    ans = item;
                    maxRate = rate;
                }
            }
            return ans;
        }
        
    }
}
