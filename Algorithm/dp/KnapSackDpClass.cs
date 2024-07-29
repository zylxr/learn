using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class KnapsackItem
    {
        public int Weight { get; set; }

        public decimal Val { get; set; }

        public decimal ValueDensity => Val / Weight;
    }
    public class KnapSackDpClass
    {
        public decimal[,] MostProfit(int[] weights, decimal[] vals ,int w)
        {
            var n = weights.Length;
            var dp = new decimal[n + 1, w + 1];
            for(var i=1;i<=n;i++)
            {
                for (var j = 1; j <= w; j++)
                {
                    if (weights[i-1] <= j)
                    {
                        if (vals[i-1] + dp[i-1, j - weights[i - 1]] > dp[i-1, j])
                        {
                            dp[i, j] = vals[i - 1] + dp[i-1, j - weights[i - 1]];
                        }
                        else
                            dp[i, j] = dp[i - 1, j];
                    }
                    else
                        dp[i, j] = dp[i - 1, j];
                }
            }
            return dp;
        }
        public decimal MostProfit2(int[] weights, decimal[] vals, int w)
        {
            var n = weights.Length;
            var dp = new decimal[w+1];
            for(var i=1;i<=w;i++)
            {
                for(var j=0;j<n;j++)
                {
                    if (weights[j] > i) continue;
                    if (dp[i - weights[j]] + vals[j] > dp[i])
                        dp[i] = dp[i - weights[j]] + vals[j];
                }
            }
            return dp[w];
        }
        public decimal MaxProfitByGreedy(int[] weights, decimal[] vals, int w)
        {
            var items = weights.Zip(vals, (w, v) => new KnapsackItem { Val = v,Weight = w }).OrderByDescending(_=>_.ValueDensity);
            var maxWeight = w;
            var totalValue = 0m;
            foreach(var item in items)
            {
                if (item.Weight > maxWeight) continue;
                maxWeight -= item.Weight;
                totalValue += item.Val;
            }
            return totalValue;
        }
        public void OutputKnapsackDP(decimal[,] dp, int w,int[] weights, decimal[] vals)
        {
            var n = weights.Length;
            var output = new int[n];
            var W = w;
            for (var i = n; i > 0; i--)
            {
                if (dp[i, W] == dp[i - 1, W])
                    output[i-1] = 0;
                else
                {
                    output[i - 1] = 1;
                    W = W - weights[i - 1];
                }
                if (dp[1, W] == 0)
                {
                    output[0] = 0;
                }
                else
                    output[0] = 1;
            }
            for(var i=0; i < n; i++)
                if (output[i] == 1)
                {
                    Console.WriteLine($"Weigh:{weights[i]},Value:{vals[i]}");
                }
        }
    }
}
