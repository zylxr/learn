using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class MaxProfitClassWithK
    {
        //给你一个整数数组 prices 和一个整数 k ，其中 prices[i] 是某支给定的股票在第 i 天的价格。
        //设计一个算法来计算你所能获取的最大利润。你最多可以完成 k 笔交易。也就是说，你最多可以买 k 次，卖 k 次。
        //注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。
        //示例 1：
        //输入：k = 2, prices = [2,4,1]
        //输出：2
        //解释：在第 1 天(股票价格 = 2) 的时候买入，在第 2 天(股票价格 = 4) 的时候卖出，这笔交易所能获得利润 = 4-2 = 2 。
        //示例 2：
        //输入：k = 2, prices = [3,2,6,5,0,3]
        //输出：7
        //解释：在第 2 天(股票价格 = 2) 的时候买入，在第 3 天(股票价格 = 6) 的时候卖出, 这笔交易所能获得利润 = 6-2 = 4 。
        //随后，在第 5 天(股票价格 = 0) 的时候买入，在第 6 天(股票价格 = 3) 的时候卖出, 这笔交易所能获得利润 = 3-0 = 3 。
        //提示：
        //1 <= k <= 100
        //1 <= prices.length <= 1000
        //0 <= prices[i] <= 1000
        public int MaxProfit(int k, int[] prices)
        {
            var n = prices.Length;
            k = Math.Min(k, n >> 1);
            var buy = new int[k+1, n];
            var sell = new int[k+1, n];
            buy[0, 0] = -prices[0];
            for (var i=1;i<=k;i++)
            {
                buy[i, 0] = buy[i - 1, 0];
                for(var j=1;j<n;j++)
                {
                    buy[i, j] = Math.Max(buy[i, j-1], sell[i-1, j-1] - prices[j]);
                    sell[i, j] = Math.Max(buy[i, j - 1] + prices[j], sell[i, j - 1]);
                }
            }
            var ans = sell[k, n-1];
            return ans;
        }

        public int MaxProfitOtimize(int k, int[] prices)
        {
            var n = prices.Length;
            k = Math.Min(k, n >> 1);
            var sell = new int[k + 1,n];
            for(var i= 1;i<=k;i++)
            {
                var tmp = -prices[0];
                for(var j= 1;j<n;j++)
                {
                    sell[i, j] = Math.Max(sell[i, j - 1], tmp + prices[j]);
                    tmp = Math.Max(tmp, sell[i - 1, j - 1] - prices[j]);
                }
            }
            var ans = sell[k,n-1];
            return ans;
        }

        public int MaxProfitByQuickSort(int k, int[] prices)
        {
            var n = prices.Length;
            if (k > n >> 1)
            {
                return QuikSolve(prices);
            }
            var dp = new int[k + 1, n];//卖出
            for(var i=1;i<=k;i++)
            {
                var tmp = -prices[0];//买入
                for(var j=1;j<n;j++)
                {
                    dp[i, j] = Math.Max(dp[i, j - 1], prices[j] + tmp);
                    tmp = Math.Max(tmp, dp[i - 1, j - 1] - prices[j]);
                }
            }
            return dp[k, n - 1];

        }
        public int QuikSolve(int[] prices)
        {
            var sum = 0;
            var n = prices.Length;
            for(var i=1;i<n;i++)
            {
                if (prices[i] > prices[i - 1])
                    sum += prices[i] - prices[i - 1];
            }
            return sum;
        }
    }
}
