﻿using Algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinimumValueSumClass
    {
        //划分数组得到最小的值之和
        //给你两个数组 nums 和 andValues，长度分别为 n 和 m。

        //数组的 值 等于该数组的 最后一个 元素。

        //你需要将 nums 划分为 m 个 不相交的连续
        //子数组
        //，对于第 ith 个子数组[li, ri]，子数组元素的按位 AND 运算结果等于 andValues[i]，换句话说，对所有的 1 <= i <= m，nums[li] & nums[li + 1] & ... & nums[ri] == andValues[i] ，其中 & 表示按位 AND 运算符。

        //返回将 nums 划分为 m 个子数组所能得到的可能的 最小 子数组 值 之和。如果无法完成这样的划分，则返回 -1 。



        //示例 1：

        //输入： nums = [1, 4, 3, 3, 2], andValues = [0, 3, 3, 2]

        //输出： 12

        //解释：

        //唯一可能的划分方法为：

        //[1, 4] 因为 1 & 4 == 0
        //[3] 因为单元素子数组的按位 AND 结果就是该元素本身
        //[3] 因为单元素子数组的按位 AND 结果就是该元素本身
        //[2] 因为单元素子数组的按位 AND 结果就是该元素本身
        //这些子数组的值之和为 4 + 3 + 3 + 2 = 12

        //示例 2：

        //输入： nums = [2, 3, 5, 7, 7, 7, 5], andValues = [0, 7, 5]

        //输出： 17

        //解释：

        //划分 nums 的三种方式为：

        //[[2, 3, 5],[7, 7, 7],[5]] 其中子数组的值之和为 5 + 7 + 5 = 17
        //[[2, 3, 5, 7],[7, 7],[5]] 其中子数组的值之和为 7 + 7 + 5 = 19
        //[[2, 3, 5, 7, 7],[7],[5]] 其中子数组的值之和为 7 + 7 + 5 = 19
        //子数组值之和的最小可能值为 17

        //示例 3：

        //输入： nums = [1, 2, 3, 4], andValues = [2]

        //输出： -1

        //解释：

        //整个数组 nums 的按位 AND 结果为 0。由于无法将 nums 划分为单个子数组使得元素的按位 AND 结果为 2，因此返回 -1。



        //提示：

        //1 <= n == nums.length <= 104
        //1 <= m == andValues.length <= min(n, 10)
        //1 <= nums[i] < 105
        //0 <= andValues[j] < 105

        private static int INF = (1 << 20) - 1;
        private Dictionary<int, int>[] memo;
        public int MinimumValueSum(int[] nums, int[] andValues)
        {
            var n = nums.Length;
            var m = andValues.Length;
            memo = new Dictionary<int, int>[m * n];
            for(var i=0;i<m*n;i++)
            {
                memo[i] = new Dictionary<int, int>();
            }
            var res = DFS(0, 0, INF, nums, andValues);
            return res < INF ? res : -1;
        }
        private int DFS(int i, int j , int cur, int[] nums, int[] andValues)
        {
            var n = nums.Length;
            var m = andValues.Length;
            var key = i * m + j;
            if (i == n && j == m) return 0;
            if (i == n || j == m) return INF;
            if (memo[key].ContainsKey(cur))
                return memo[key][cur];
            cur &= nums[i];
            if ((cur & andValues[j]) < andValues[j])
                return INF;
            var res = DFS(i + 1, j, cur, nums, andValues);
            if (cur == andValues[j])
                res = Math.Min(res, DFS(i + 1, j + 1, INF, nums, andValues) + nums[i]);
            memo[key].TryAdd(cur, res);
            return res;
        }
    }
}
