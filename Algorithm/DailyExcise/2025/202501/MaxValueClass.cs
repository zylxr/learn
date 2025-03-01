using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxValueClass
    {
        //3287. 求出数组中最大序列值
        //给你一个整数数组 nums 和一个 正 整数 k 。

        //定义长度为 2 * x 的序列 seq 的 值 为：

        //(seq[0] OR seq[1] OR...OR seq[x - 1]) XOR(seq[x] OR seq[x + 1] OR ... OR seq[2 * x - 1]).
        //请你求出 nums 中所有长度为 2 * k 的
        //子序列
        //的 最大值 。

 

        //示例 1：

        //输入：nums = [2, 6, 7], k = 1

        //输出：5

        //解释：

        //子序列[2, 7] 的值最大，为 2 XOR 7 = 5 。

        //示例 2：

        //输入：nums = [4, 2, 5, 6, 7], k = 2

        //输出：2

        //解释：

        //子序列[4, 5, 6, 7] 的值最大，为(4 OR 5) XOR(6 OR 7) = 2 。

 

        //提示：

        //2 <= nums.length <= 400
        //1 <= nums[i] < 27
        //1 <= k <= nums.length / 2
        public int MaxValue(int[] nums, int k)
        {
            var A = FindOrs(nums, k);
            Array.Reverse(nums);
            var B = FindOrs(nums, k);
            var mx = 0;
            for(var i=k-1;i<nums.Length-k;i++)
            {
                foreach (var a in A[i])
                    foreach (var b in B[nums.Length - i - 2])
                        mx = Math.Max(mx, a ^ b); 
            }
            return mx;
        }

        public List<HashSet<int>> FindOrs(int[] nums, int k)
        {
            var dp = new List<HashSet<int>>();
            var prev = new List<HashSet<int>>();
            for(var i=0;i<=k;i++)
                prev.Add(new HashSet<int>());
            prev[0].Add(0);
            for(var i=0;i<nums.Length;i++)
            {
                for(var j= Math.Min(k-1,i+1);j>=0;j--)
                {
                    foreach(var x in prev[j])
                        prev[j+1].Add(x| nums[i]);
                }
                dp.Add(new HashSet<int>(prev[k]));
            }
            return dp;
        }
    }
}
