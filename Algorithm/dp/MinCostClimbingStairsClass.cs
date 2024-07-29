﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class MinCostClimbingStairsClass
    {
        //给你一个整数数组 cost ，其中 cost[i] 是从楼梯第 i 个台阶向上爬需要支付的费用。一旦你支付此费用，即可选择向上爬一个或者两个台阶。

        //你可以选择从下标为 0 或下标为 1 的台阶开始爬楼梯。

        //请你计算并返回达到楼梯顶部的最低花费。
        //示例 1：
        //输入：cost = [10,15,20]
        //输出：15
        //解释：你将从下标为 1 的台阶开始。
        //- 支付 15 ，向上爬两个台阶，到达楼梯顶部。
        //总花费为 15 。
        //示例 2：

        //输入：cost = [1,100,1,1,1,100,1,1,100,1]
        //输出：6
        //解释：你将从下标为 0 的台阶开始。
        //- 支付 1 ，向上爬两个台阶，到达下标为 2 的台阶。
        //- 支付 1 ，向上爬两个台阶，到达下标为 4 的台阶。
        //- 支付 1 ，向上爬两个台阶，到达下标为 6 的台阶。
        //- 支付 1 ，向上爬一个台阶，到达下标为 7 的台阶。
        //- 支付 1 ，向上爬两个台阶，到达下标为 9 的台阶。
        //- 支付 1 ，向上爬一个台阶，到达楼梯顶部。
        //总花费为 6 。
        public int MinCostClimbingStairs(int[] cost)
        {
            var n = cost.Length;
            var dp = new int[n+1];
            if (n <= 1) return dp[0];
            for (var i = 2; i <=n; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + cost[i-1], dp[i - 2] + cost[i - 2]);
            }
            return dp[n ];
        }
    }
}
