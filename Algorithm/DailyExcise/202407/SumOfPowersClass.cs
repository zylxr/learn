using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class SumOfPowersClass
    {
        //给你一个长度为 n 的整数数组 nums 和一个 正 整数 k 。
        //一个子序列的 能量 定义为子序列中 任意 两个元素的差值绝对值的 最小值 。
        //请你返回 nums 中长度 等于 k 的 所有 子序列的 能量和 。
        //由于答案可能会很大，将答案对 109 + 7 取余 后返回。
        //示例 1：
        //输入：nums = [1, 2, 3, 4], k = 3
        //输出：4
        //解释：
        //nums 中总共有 4 个长度为 3 的子序列：[1, 2, 3] ，[1, 3, 4] ，[1, 2, 4] 和[2, 3, 4] 。
        //能量和为 |2 - 3| + |3 - 4| + |2 - 1| + |3 - 4| = 4 。

        //示例 2：
        //输入：nums = [2, 2], k = 2
        //输出：0

        //解释：
        //nums 中唯一一个长度为 2 的子序列是[2, 2] 。能量和为 |2 - 2| = 0 。

        //示例 3：
        //输入：nums = [4, 3, -1], k = 2

        //输出：10

        //解释：

        //nums 总共有 3 个长度为 2 的子序列：[4, 3] ，[4, -1] 和[3, -1] 。
        //能量和为 |4 - 3| + |4 - (-1)| + |3 - (-1)| = 10 。

        //提示：
        //2 <= n == nums.length <= 50
        //-108 <= nums[i] <= 108 
        //2 <= k <= n


        //思路与算法

        //由于子序列的能量为任意两个元素的差值绝对值的最小值，因此对子序列排序后，其能量为两两相邻元素的差值绝对值的最小值。
        //在对原数组 nums 排序后，我们在计算子序列能量时只需考虑相邻元素之间的差值即可。
        //采用求解数组最长上升子序列的思想，我们从小到大枚举 i 作为子序列中的最后一个元素，再从 0 到 i−1 去枚举 j 作为 i 的前置元素，
        //这样一来产生差值 diff =∣nums[i]−nums[j]∣。接着我们再枚举子序列的长度 p，然后考虑从「以 j 结尾且长度为 p−1 的子序列」等一系列状态进行转移求解。
        //设 d[i][p][v] 表示以 i 为结尾时，有多少个长度为 p 且能量为 v 的子序列。这样一来，就有如下转移方程：

        //d[i][p][v]= 
        //⎩
        //⎨
        //⎧
        //​
  
        //∑ 
        //j
        //​
        //d[j][p−1][v]
        //∑ 
        //j
        //​
        //d[j][p−1][diff]+d[j][p−1][diff + 1]+⋯
        //0
        //​
  
        //forv<diff
        //forv=diff
        //forv> diff
        //​


        //在实现时，我们只需枚举所有 d[j][p−1][v]，然后更新到 d[i][p][min(diff, v)] 即可。

        //最后，我们枚举所有长度为 k 的状态，并将 v×d[i][k][v] 累加到答案中，即可得到 nums 中长度等于 k 的所有子序列的能量和。

        //细节

        //长度为 n 的整数数组，两两元素之间的差值种类数不会超过  
        //2
        //n×(n−1)
        //​
        //，因此状态表示中 v 的数量级大致在 n 
        //2
        //量级。具体到每个状态 d[i][p][v]，实际可取的 v 更少。因此，在代码实现时可以将 d[i][p] 定义为字典（哈希表），来减少状态枚举数量，并减少代码量。
        //将 d[i][1][inf] 初始化为 1，方便后续状态转移，其中 inf 表示无穷大。
        const int INF = 0x3f3f3f3f, MOD = 1000000007;
        public int SumOfPowersDP(int[] nums, int k)
        {
            var n = nums.Length;
            var res = 0;
            var d = new Dictionary<int, int>[n][];
            for(var i=0;i<n;i++)
            {
                d[i] = new Dictionary<int, int>[k + 1];
                for (var j = 0; j <= k; j++)
                    d[i][j] = new Dictionary<int, int>();
            }
            Array.Sort(nums);
            for(var i=0;i<n;i++)
            {
                d[i][1].Add(INF, 1);
                for(var j=0;j<i;j++)
                {
                    var diff = Math.Abs(nums[i]- nums[j]);
                    for(var p =2;p<=k;p++)
                    {
                        foreach(var kv in d[j][p-1])
                        {
                            var v = kv.Key;
                            var cnt = kv.Value;
                            var currKey = Math.Min(diff, v);
                            d[i][p].TryAdd(currKey, 0);
                            d[i][p][currKey] = (d[i][p][currKey] + cnt) % MOD;
                        }
                    }
                }
                foreach(var kv in d[i][k])
                {
                    var v = kv.Key;
                    var cnt = kv.Value;
                    res = (int)((res + 1L * v * cnt % MOD) % MOD);
                }
            }
            return res;
        }

        public int SumOfPowers2(int[] nums, int k)
        {
            int n = nums.Length;
            Array.Sort(nums);
            ISet<int> set = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    set.Add(nums[i] - nums[j]);
                }
            }
            set.Add(INF);
            IList<int> vals = new List<int>(set);
            ((List<int>)vals).Sort();

            int[][][] d = new int[n][][];
            for (int i = 0; i < n; i++)
            {
                d[i] = new int[k + 1][];
                for (int j = 0; j <= k; j++)
                {
                    d[i][j] = new int[vals.Count];
                }
            }
            int[][] border = new int[n][];
            for (int i = 0; i < n; i++)
            {
                border[i] = new int[k + 1];
            }
            int[][] sum = new int[k + 1][];
            for (int i = 0; i <= k; i++)
            {
                sum[i] = new int[vals.Count];
            }
            int[][] suf = new int[n][];
            for (int i = 0; i < n; i++)
            {
                suf[i] = new int[k + 1];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int pos = BinarySearch(vals, nums[i] - nums[j]);
                    for (int p = 1; p <= k; p++)
                    {
                        while (border[j][p] < pos)
                        {
                            sum[p][border[j][p]] = (sum[p][border[j][p]] - suf[j][p] + MOD) % MOD;
                            sum[p][border[j][p]] = (sum[p][border[j][p]] + d[j][p][border[j][p]]) % MOD;
                            suf[j][p] = (suf[j][p] - d[j][p][border[j][p]] + MOD) % MOD;
                            border[j][p]++;
                            sum[p][border[j][p]] = (sum[p][border[j][p]] + suf[j][p]);
                        }
                    }
                }

                d[i][1][vals.Count - 1] = 1;
                for (int p = 2; p <= k; p++)
                {
                    for (int v = 0; v < vals.Count; v++)
                    {
                        d[i][p][v] = sum[p - 1][v];
                    }
                }
                for (int p = 1; p <= k; p++)
                {
                    for (int v = 0; v < vals.Count; v++)
                    {
                        suf[i][p] = (suf[i][p] + d[i][p][v]) % MOD;
                    }
                    sum[p][0] = (sum[p][0] + suf[i][p]) % MOD;
                }
            }

            int res = 0;
            for (int i = 0; i < n; i++)
            {
                for (int v = 0; v < vals.Count; v++)
                {
                    res = (int)((res + 1L * vals[v] * d[i][k][v] % MOD) % MOD);
                }
            }
            return res;
        }

        public int BinarySearch(IList<int> vals, int target)
        {
            int low = 0, high = vals.Count;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (vals[mid] >= target)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return low;
        }
    }
}
