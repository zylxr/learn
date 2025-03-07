using Algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class BeautifulSubsetsClass
    {
        //2597. 美丽子集的数目
        //给你一个由正整数组成的数组 nums 和一个 正 整数 k 。

        //如果 nums 的子集中，任意两个整数的绝对差均不等于 k ，则认为该子数组是一个 美丽 子集。

        //返回数组 nums 中 非空 且 美丽 的子集数目。

        //nums 的子集定义为：可以经由 nums 删除某些元素（也可能不删除）得到的一个数组。只有在删除元素时选择的索引不同的情况下，两个子集才会被视作是不同的子集。



        //示例 1：

        //输入：nums = [2, 4, 6], k = 2
        //输出：4
        //解释：数组 nums 中的美丽子集有：[2], [4], [6], [2, 6] 。
        //可以证明数组[2, 4, 6] 中只存在 4 个美丽子集。
        //示例 2：

        //输入：nums = [1], k = 1
        //输出：1
        //解释：数组 nums 中的美丽数组有：[1] 。
        //可以证明数组[1] 中只存在 1 个美丽子集。 


        //提示：

        //1 <= nums.length <= 18
        //1 <= nums[i], k <= 1000

        private int ans = 0;
        private Dictionary<int,int> cnt = new Dictionary<int,int>();
        public int BeautifulSubsets(int[] nums, int k)
        {
            DFS(nums, k, 0);
            return ans - 1;
        }

        public int BeautifulSubsets2(int[] nums, int k)
        {
            var groups = new Dictionary<int, SortedDictionary<int, int>>();
            foreach(var a in nums)
            {
                var mod = a % k;
                groups.TryAdd(mod,new SortedDictionary<int, int>());
                groups[mod][a] = groups[mod].GetValueOrDefault(a, 0)+1;

            }
            var ans = 1;
            foreach(var g in groups.Values)
            {
                var m = g.Count;
                var f = new int[m, 2];
                f[0, 0] = 1;
                f[0, 1] = (1 << g.First().Value) - 1;
                var i = 1;
                var prev = g.First();
                foreach(var curr in g.Skip(1))
                {
                    f[i, 0] = f[i - 1, 0] + f[i - 1, 1];
                    if (curr.Key - prev.Key == k)
                        f[i, 1] = f[i - 1, 0] * ((1 << curr.Value) - 1);
                    else
                        f[i, 1] = (f[i - 1, 0] + f[i - 1, 1]) * ((1 << curr.Value) - 1);
                    prev = curr;
                    i++;
                }
                ans *= f[m - 1, 0] + f[m - 1, 1];
            }
            return ans - 1;
        }
        public void DFS(int[] nums,int k, int i)
        {
            if (i == nums.Length)
            {
                ans++;
                return;
            }
            DFS(nums, k, i + 1);
            if (cnt.GetValueOrDefault(nums[i]-k,0)==0 && cnt.GetValueOrDefault(nums[i]+k,0)==0)
            {
                cnt[nums[i]] = cnt.GetValueOrDefault(nums[i], 0) + 1;
                DFS(nums, k, i + 1);
                cnt[nums[i]] = cnt.GetValueOrDefault(nums[i], 0) - 1;
            }
        }
    }
}
