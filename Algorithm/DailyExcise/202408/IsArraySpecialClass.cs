﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class IsArraySpecialClass
    {
        //特殊数组 II
        //如果数组的每一对相邻元素都是两个奇偶性不同的数字，则该数组被认为是一个 特殊数组 。

        //你有一个整数数组 nums 和一个二维整数矩阵 queries，对于 queries[i] = [fromi, toi]，请你帮助你检查
        //子数组
        //nums[fromi..toi] 是不是一个 特殊数组 。

        //返回布尔数组 answer，如果 nums[fromi..toi] 是特殊数组，则 answer[i] 为 true ，否则，answer[i] 为 false 。




        //示例 1：

        //输入：nums = [3, 4, 1, 2, 6], queries = [[0, 4]]

        //输出：[false]

        //解释：

        //子数组是[3, 4, 1, 2, 6]。2 和 6 都是偶数。

        //示例 2：

        //输入：nums = [4, 3, 1, 6], queries = [[0, 2],[2, 3]]

        //输出：[false, true]

        //解释：

        //子数组是[4, 3, 1]。3 和 1 都是奇数。因此这个查询的答案是 false。
        //子数组是[1, 6]。只有一对：(1,6)，且包含了奇偶性不同的数字。因此这个查询的答案是 true。


        //提示：

        //1 <= nums.length <= 105
        //1 <= nums[i] <= 105
        //1 <= queries.length <= 105
        //queries[i].length == 2
        //0 <= queries[i][0] <= queries[i][1] <= nums.length - 1
        public bool[] IsArraySpecial(int[] nums, int[][] queries)
        {
            var n = nums.Length;
            var qlen = queries.Length;
            var ans = new bool[qlen];
            var dp = new int[n];
            for(var i=1;i<n;i++)
            {
                if (((nums[i] ^ nums[i-1]) & 1) == 1)
                    dp[i] = dp[i - 1] + 1;
            }
            for(var i=0;i<qlen;i++)
            {
                var q = queries[i];
                var x = q[0];
                var y = q[1];
                ans[i] = (dp[y] - dp[x]) >= y - x;
            }
            return ans;
        }
    }
}