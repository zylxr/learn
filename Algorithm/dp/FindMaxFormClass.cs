using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class FindMaxFormClass
    {
        //给你一个二进制字符串数组 strs 和两个整数 m 和 n 。
        //请你找出并返回 strs 的最大子集的长度，该子集中 最多 有 m 个 0 和 n 个 1 。
        //如果 x 的所有元素也是 y 的元素，集合 x 是集合 y 的 子集 。
        //示例 1：
        //输入：strs = ["10", "0001", "111001", "1", "0"], m = 5, n = 3
        //输出：4
        //解释：最多有 5 个 0 和 3 个 1 的最大子集是 {"10","0001","1","0"} ，因此答案是 4 。
        //其他满足题意但较小的子集包括 {"0001","1"} 和 {"10","1","0"} 。{"111001"} 不满足题意，因为它含 4 个 1 ，大于 n 的值 3 。
        //示例 2：
        //输入：strs = ["10", "0", "1"], m = 1, n = 1
        //输出：2
        //解释：最大的子集是 {"0", "1"} ，所以答案是 2 。
        //提示：
        //1 <= strs.length <= 600
        //1 <= strs[i].length <= 100
        //strs[i] 仅由 '0' 和 '1' 组成
        //1 <= m, n <= 100给你一个二进制字符串数组 strs 和两个整数 m 和 n 。

        //请你找出并返回 strs 的最大子集的长度，该子集中 最多 有 m 个 0 和 n 个 1 。

        //如果 x 的所有元素也是 y 的元素，集合 x 是集合 y 的 子集 。
        //示例 1：
        //输入：strs = ["10", "0001", "111001", "1", "0"], m = 5, n = 3
        //输出：4
        //解释：最多有 5 个 0 和 3 个 1 的最大子集是 {"10","0001","1","0"} ，因此答案是 4 。
        //其他满足题意但较小的子集包括 {"0001","1"} 和 {"10","1","0"} 。{"111001"} 不满足题意，因为它含 4 个 1 ，大于 n 的值 3 。
        //示例 2：

        //输入：strs = ["10", "0", "1"], m = 1, n = 1
        //输出：2
        //解释：最大的子集是 {"0", "1"} ，所以答案是 2 。
        //提示：

        //1 <= strs.length <= 600
        //1 <= strs[i].length <= 100
        //strs[i] 仅由 '0' 和 '1' 组成
        //1 <= m, n <= 100
        public int FindMaxForm(string[] strs, int m, int n)
        {
            //var dp = new int[m+1, n+1];
            //foreach(var str in strs)
            //{
            //    var scount = GetZeroOnes(str);
            //    for(var i=m;i>=0;i--)
            //    {
            //        for(var j=n;j>=0;j--)
            //        {
            //            if (i < scount[0] || j < scount[1])continue;
            //            dp[i, j] = Math.Max(dp[i, j], dp[i - scount[0], j - scount[1]]+1);
            //        }
            //    }
            //}
            //return dp[m,n];
            var len = strs.Length;
            var dp = new int[len+1, m + 1, n + 1];
            for(var l=1;l<=len;l++)
            {
                var str = strs[l-1];
                var scount = GetZeroAndOnes(str);
                for(var i = 0;i<=m;i++)
                {
                    for(var j= 0;j<=n;j++)
                    {
                        dp[l, i, j] = dp[l - 1, i, j];
                        if (i >= scount[0] && j >= scount[1])
                            dp[l, i, j] = Math.Max(dp[l, i, j], dp[l - 1, i - scount[0], j - scount[1]] + 1);

                    }
                }
            }
            return dp[len,m, n];
        }

        public int[] GetZeroAndOnes(string str)
        {
            var ret = new int[2];
            foreach(var c in str)
            {
                ret[c - '0']++;
            }
            return ret;
        }
        public int[] GetZeroOnes(string str)
        {
            var result = new int[2];
            foreach(var c in str)
            {
                if (c == '1') result[1] += 1;
                else result[0] += 1;
            }
            return result;
        }
    }
}
