using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinimumCostClass9
    {
        //3013. 将数组分成最小总代价的子数组 II
        //给你一个下标从 0 开始长度为 n 的整数数组 nums 和两个 正 整数 k 和 dist 。

        //一个数组的 代价 是数组中的 第一个 元素。比方说，[1, 2, 3] 的代价为 1 ，[3, 4, 1] 的代价为 3 。

        //你需要将 nums 分割成 k 个 连续且互不相交 的子数组，满足 第二 个子数组与第 k 个子数组中第一个元素的下标距离 不超过 dist 。换句话说，如果你将 nums 分割成子数组 nums[0..(i1 - 1)], nums[i1..(i2 - 1)], ..., nums[ik - 1..(n - 1)] ，那么它需要满足 ik-1 - i1 <= dist 。

        //请你返回这些子数组的 最小 总代价。



        //示例 1：

        //输入：nums = [1, 3, 2, 6, 4, 2], k = 3, dist = 3
        //输出：5
        //解释：将数组分割成 3 个子数组的最优方案是：[1, 3] ，[2, 6, 4] 和[2] 。这是一个合法分割，因为 ik-1 - i1 等于 5 - 2 = 3 ，等于 dist 。总代价为 nums[0] + nums[2] + nums[5] ，也就是 1 + 2 + 2 = 5 。
        //5 是分割成 3 个子数组的最小总代价。
        //示例 2：

        //输入：nums = [10, 1, 2, 2, 2, 1], k = 4, dist = 3
        //输出：15
        //解释：将数组分割成 4 个子数组的最优方案是：[10] ，[1] ，[2] 和[2, 2, 1] 。这是一个合法分割，因为 ik-1 - i1 等于 3 - 1 = 2 ，小于 dist 。总代价为 nums[0] + nums[1] + nums[2] + nums[3] ，也就是 10 + 1 + 2 + 2 = 15 。
        //分割[10] ，[1] ，[2, 2, 2] 和[1] 不是一个合法分割，因为 ik-1 和 i1 的差为 5 - 1 = 4 ，大于 dist 。
        //15 是分割成 4 个子数组的最小总代价。
        //示例 3：

        //输入：nums = [10, 8, 18, 9], k = 3, dist = 1
        //输出：36
        //解释：将数组分割成 4 个子数组的最优方案是：[10] ，[8] 和[18, 9] 。这是一个合法分割，因为 ik-1 - i1 等于 2 - 1 = 1 ，等于 dist 。总代价为 nums[0] + nums[1] + nums[2] ，也就是 10 + 8 + 18 = 36 。
        //分割[10] ，[8, 18] 和[9] 不是一个合法分割，因为 ik-1 和 i1 的差为 3 - 1 = 2 ，大于 dist 。
        //36 是分割成 3 个子数组的最小总代价。


        //提示：

        //3 <= n <= 105
        //1 <= nums[i] <= 109
        //3 <= k <= n
        //k - 2 <= dist <= n - 2
        public long MinimumCost(int[] nums, int k, int dist)
        {
            var n = nums.Length;
            var cnt = new Container(k - 2);
            for (var i = 1; i < k - 1; i++)
                cnt.Add(nums[i]);
            var ans = cnt.Sum() + nums[k - 1];
            for (var i = k; i<n;i++)
            {
                var j = i - dist - 1;
                if (j > 0) cnt.Erase(nums[j]);
                cnt.Add(nums[i - 1]);
                ans = Math.Min(ans, cnt.Sum() + nums[i]);
            }
            return ans + nums[0];
        }
        public class Container
        {
            private int k;
            private PriorityQueue<int, int> st1;
            private PriorityQueue<int, int> st2;
            private Dictionary<int, int> cnt1;
            private Dictionary<int, int> cnt2;
            private Dictionary<int, int> del1;
            private Dictionary<int, int> del2;
            private int st1Size;
            private int st2Size;
            private long sm;
            public Container(int k)
            {
                this.k = k;
                this.st1 = new PriorityQueue<int, int>();
                this.st2 = new PriorityQueue<int, int>();
                this.cnt1 = new Dictionary<int, int>();
                this.cnt2 = new Dictionary<int, int>();
                this.del1 = new Dictionary<int, int>();
                this.del2 = new Dictionary<int, int>();
                this.st1Size = 0;
                this.st2Size = 0;
                this.sm = 0;
            }
            private static void Inc(Dictionary<int,int> dict,int key)
            {
                if (dict.TryGetValue(key, out int v)) dict[key] = v + 1;
                else dict[key] = 1;
            }
            private static void Dec(Dictionary<int,int> dict,int key)
            {
                var v = dict[key] - 1;
                if (v == 0) dict.Remove(key);
                else dict[key] = v;
            }
            private void Prune1()
            {
                while(st1.Count>0)
                {
                    var x = st1.Peek();
                    if (del1.TryGetValue(x, out int d) && d > 0)
                    {
                        st1.Dequeue();
                        if (d == 1) del1.Remove(x);
                        else del1[x] = d - 1;
                    }
                    else break;
                }
            }
            private void Prune2()
            {
                while (st2.Count > 0)
                {
                    var x = st2.Peek();
                    if (del2.TryGetValue(x, out int d) && d > 0)
                    {
                        st2.Dequeue();
                        if (d == 1) del2.Remove(x);
                        else del2[x] = d - 1;
                    }
                    else break;
                }
            }

            private int ExtractMax1()
            {
                Prune1();
                var x = st1.Dequeue();
                Dec(cnt1, x);
                st1Size--;
                sm -= x;
                return x;
            }
            private int ExtractMin2()
            {
                Prune2();
                var x = st2.Dequeue();
                Dec(cnt2, x);
                st2Size--;
                return x;
            }

            private int Min2()
            {
                Prune2();
                return st2.Peek();
            }
            private void Insert1(int x)
            {
                st1.Enqueue(x, -x);
                Inc(cnt1, x);
                st1Size++;
                sm += x;
            }
            private void Insert2(int x)
            {
                st2.Enqueue(x,x);
                Inc(cnt2, x);
                st2Size++;
            }
            private void Adjust()
            {
                while(st1Size<k && st2Size > 0)
                {
                    var x = ExtractMin2();
                    Insert1(x);
                }
                while(st1Size>k)
                {
                    var x = ExtractMax1();
                    Insert2(x);
                }
            }
            public void Add(int x)
            {
                if (st2Size > 0)
                {
                    var mn = Min2();
                    if (x >= mn) Insert2(x);
                    else Insert1(x);
                }
                else Insert1(x);
                Adjust();
            }
            public void Erase(int x)
            {
                if(cnt1.TryGetValue(x,out int c1)&& c1>0)
                {
                    Dec(cnt1, x);
                    st1Size--;
                    sm -= x;
                    Inc(del1, x);
                }
                else
                {
                    Dec(cnt2, x);
                    st2Size--;
                    Inc(del2, x);
                }
                Adjust();
            }
            public long Sum()
            {
                return sm;
            }
        }
    }
}
