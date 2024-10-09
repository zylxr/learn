using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinimumDifferenceClass
    {
        //3171. 找到按位或最接近 K 的子数组
        //给你一个数组 nums 和一个整数 k 。你需要找到 nums 的一个
        //子数组
        //，满足子数组中所有元素按位或运算 OR 的值与 k 的 绝对差 尽可能 小 。换言之，你需要选择一个子数组 nums[l..r] 满足 |k - (nums[l] OR nums[l + 1] ... OR nums[r])| 最小。

        //请你返回 最小 的绝对差值。

        //子数组 是数组中连续的 非空 元素序列。




        //示例 1：

        //输入：nums = [1, 2, 4, 5], k = 3

        //输出：0

        //解释：

        //子数组 nums[0..1] 的按位 OR 运算值为 3 ，得到最小差值 |3 - 3| = 0 。

        //示例 2：

        //输入：nums = [1, 3, 1, 3], k = 2

        //输出：1

        //解释：

        //子数组 nums[1..1] 的按位 OR 运算值为 3 ，得到最小差值 |3 - 2| = 1 。

        //示例 3：

        //输入：nums = [1], k = 10

        //输出：9

        //解释：

        //只有一个子数组，按位 OR 运算值为 1 ，得到最小差值 |10 - 1| = 9 。



        //提示：

        //1 <= nums.length <= 105
        //1 <= nums[i] <= 109
        //1 <= k <= 109

        public int MinimumDifference(int[] nums, int k)
        {
            var n = nums.Length;
            var bitMaxPos = new int[31];
            var posToBit = new List<Tuple<int, int>>();
            Array.Fill(bitMaxPos, -1);
            var ans = int.MaxValue;
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < 31; j++)
                {
                    if ((nums[i] >> j & 1) != 0)
                    {
                        bitMaxPos[j] = i;
                    }
                }
                posToBit.Clear();
                for (var j = 0; j < 31; j++)
                {
                    if (bitMaxPos[j] != -1)
                        posToBit.Add(new Tuple<int, int>(bitMaxPos[j], j));
                }
                posToBit.Sort((a, b) => a.Item1 != b.Item1 ? b.Item1 - a.Item1 : b.Item2 - a.Item2);
                var val = 0;
                for (int j = 0, p = 0; j < posToBit.Count;)
                {

                    while (j < posToBit.Count && posToBit[j].Item1 == posToBit[p].Item1)
                    {
                        val |= 1 << posToBit[j].Item2;
                        j++;
                    }
                    p = j;
                    ans = Math.Min(ans, Math.Abs(val - k));
                }
            }
            return ans;
        }
        private int[] bitCount = new int[31];
        public int MinimumDifference2(int[] nums, int k)
        {
            var n = nums.Length;
            int left = 0, right = 0;
            var val = 0;
            var ans = int.MaxValue;
            for (; left < n; left++)
            {
                while(right < n && val <k)
                {
                    val |= nums[right];
                    UpdateBitCount(nums[right], 1);
                    right++;
                    ans = Math.Min(ans, Math.Abs(val - k));
                }
                if (val == k)
                {
                    ans = 0;
                    return ans;
                }
                UpdateBitCount(nums[left], -1);
                val = ComputeBitValue();
                if(val>0)ans = Math.Min(ans, Math.Abs(val - k));
            }
            return ans;
        }
        public void UpdateBitCount(int num, int delta)
        {
            var pos = 0;
            while(num>0)
            {
                if((num &1)!=0)
                {
                    bitCount[pos] += delta;
                }
                pos++;
                num >>= 1;
            }
        }

        public int ComputeBitValue()
        {
            var res = 0;
            for(var i=0;i<bitCount.Length;i++) 
            {
                    if (bitCount[i]>0)res |= 1<<i;
            }
            return res;
        }
    }
}
