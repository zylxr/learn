using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Algorithm.DailyExcise
{
    public class MinimumMoneyClass
    {
        //2412. 完成所有交易的初始最少钱数
        //给你一个下标从 0 开始的二维整数数组 transactions，其中transactions[i] = [costi, cashbacki] 。

        //数组描述了若干笔交易。其中每笔交易必须以 某种顺序 恰好完成一次。在任意一个时刻，你有一定数目的钱 money ，为了完成交易 i ，money >= costi 这个条件必须为真。执行交易后，你的钱数 money 变成 money - costi + cashbacki 。

        //请你返回 任意一种 交易顺序下，你都能完成所有交易的最少钱数 money 是多少。



        //示例 1：

        //输入：transactions = [[2, 1],[5, 0],[4, 2]]
        //输出：10
        //解释：
        //刚开始 money = 10 ，交易可以以任意顺序进行。
        //可以证明如果 money< 10 ，那么某些交易无法进行。
        //示例 2：

        //输入：transactions = [[3, 0], [0, 3]]
        //输出：3
        //解释：
        //- 如果交易执行的顺序是[[3, 0], [0, 3]] ，完成所有交易需要的最少钱数是 3 。
        //- 如果交易执行的顺序是[[0, 3], [3, 0]] ，完成所有交易需要的最少钱数是 0 。
        //所以，刚开始钱数为 3 ，任意顺序下交易都可以全部完成。



        //提示：

        //1 <= transactions.length <= 105
        //transactions[i].length == 2
        //0 <= costi, cashbacki <= 109
        public long MinimumMoney(int[][] transactions)
        {
            //var init = 0;
            //var remain = 0;
            //foreach (var t in transactions)
            //{
            //    if (remain < t[0])
            //    {
            //        var diff = t[0] - remain;
            //        init += diff;
            //        remain += diff;
            //    }
            //    remain += t[1] - t[0];
            //}
            //return init;

            // 需要强调的是任意一种 交易顺序，而不是数组的交易顺序
            var totalLoss = 0L;
            var res = 0;
            foreach (var t in transactions)
            {
                var cost = t[0];
                var cashBask = t[1];
                totalLoss += Math.Max(0, cost - cashBask);
                res = Math.Max(res, Math.Min(cost, cashBask));
            }
            return totalLoss + res;
        }
    }
}
