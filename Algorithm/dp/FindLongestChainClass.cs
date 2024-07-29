using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class FindLongestChainClass
    {
        //给你一个由 n 个数对组成的数对数组 pairs ，其中 pairs[i] = [lefti, righti] 且 lefti<righti 。
        //现在，我们定义一种 跟随 关系，当且仅当 b < c 时，数对 p2 = [c, d] 才可以跟在 p1 = [a, b] 后面。我们用这种形式来构造 数对链 。
        //找出并返回能够形成的 最长数对链的长度 。
        //你不需要用到所有的数对，你可以以任何顺序选择其中的一些数对来构造。
        //示例 1：
        //输入：pairs = [[1, 2], [2, 3], [3, 4]]
        //输出：2
        //解释：最长的数对链是[1, 2] -> [3,4] 。
        //示例 2：
        //输入：pairs = [[1, 2], [7, 8], [4, 5]]
        //输出：3
        //解释：最长的数对链是[1, 2] -> [4,5] -> [7,8] 。
        //提示：
        //n == pairs.length
        //1 <= n <= 1000
        //-1000 <= lefti<righti <= 1000
        public int FindLongestChain(int[][] pairs)
        {
            var n = pairs.Length;
            Array.Sort(pairs, (a, b) => {
                return a[0]-b[0];
                //var ret = a[1].CompareTo(b[1]);
                //if(ret == 0)return a[0].CompareTo(b[0]);
                //return ret;
            });
            var dp = new int[n];
            dp[0] = 1;
            for(var i= 1;i<n;i++)
            {
                dp[i] = 1;
                for(var j=0;j<i;j++)
                {
                    if (pairs[i][0] > pairs[j][1])
                    {
                        dp[i] = Math.Max(dp[j] + 1, dp[i]);
                    }
                }
            }
            return dp[n - 1];
        }

        //要挑选最长数对链的第一个数对时，最优的选择是挑选第二个数字最小的，这样能给挑选后续的数对留下更多的空间。
        //挑完第一个数对后，要挑第二个数对时，也是按照相同的思路，
        //是在剩下的数对中，第一个数字满足题意的条件下，挑选第二个数字最小的。按照这样的思路，
        //可以先将输入按照第二个数字排序，然后不停地判断第一个数字是否能满足大于前一个数对的第二个数字即可。
        public int FindLongestChainByGreedy(int[][] pairs)
        {
            Array.Sort(pairs, (a, b) => a[1] - b[1]);
            var cur = int.MinValue;
            var res = 0;
            foreach(var pair in pairs) {
                if (cur < pair[0])
                {
                    cur = pair[1];
                    res++;
                }
            }
            return res;
        }

        //贪心 + 二分查找的形式。用一个数组 arr 记录当前最优情况，arr[i] 就表示长度为 i+1 的数对链的末尾可以取得的最小值，遇到一个新数对时，
        //先用二分查找得到这个数对可以放置的位置，再更新 arr\textit{arr}arr

        public int FindLongestChainByBinarySearch(int[][] pairs)
        {
            Array.Sort(pairs, (a, b) => a[0] - b[0]);
            var arr = new List<int>();
            foreach(var pair in pairs)
            {
                if(arr.Count == 0 || pair[0] > arr[arr.Count - 1])
                    arr.Add(pair[1]);
                else
                {
                    var index = BinarySearch(arr, arr[0]);
                    arr[index] = Math.Min(pair[1], arr[index]);
                }
            }
            return arr.Count;
        }

        public int BinarySearch(List<int> arr, int x)
        {
            var left = 0;
            var right =arr.Count - 1;
            while(left < right)
            {
                var mid= (left + right) / 2;
                if (arr[mid] > x)
                {
                    right = mid;
                }
                else
                    left = mid + 1;
            }
            return left;
        }
    }
}
