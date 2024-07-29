using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.BackTracking
{
    public class KnapsackBackTrackItem
    {
        public int Weight { get; set; }

        public decimal Val { get; set; }

        public decimal ValueDensity => Val / Weight;
    }
    public class KnapsackBackTrack
    {
        public decimal Bound(KnapsackBackTrackItem[] items, int W,int k, decimal gainedProfit, int usedWeight)
        {
            var n = items.Length;
            var upperProfit = gainedProfit;
            var tmpUsedWeight = usedWeight;
            for(var i = k; i < n; i++)
            {
                if(tmpUsedWeight + items[i].Weight <=W)
                {
                    upperProfit += items[i].Val;
                    tmpUsedWeight += items[i].Weight;
                }
                else
                {
                    
                    upperProfit += (W - tmpUsedWeight) * items[i].ValueDensity;
                    tmpUsedWeight = W;
                }
            }
            return upperProfit;
        }

        public int[] Knapsack(KnapsackBackTrackItem[] items, int W)
        {
            var index = 0;
            var n = items.Length;
            var current_weight = 0;
            var current_profit = 0m;
            var X = new int[n];
            var Y = new int[n];
            var profit = -1m;
            while(true)
            {
                while(index<n && current_weight + items[index].Weight<=W)
                {
                    current_profit += items[index].Val;
                    current_weight += items[index].Weight;
                    Y[index] = 1;
                    index++;
                }
                if (index >= n)
                {
                    profit = current_profit;
                    index = n;
                    for (var i = 0; i < n; i++) X[i] = Y[i];
                }
                else
                    Y[index] = 0;
                while(Bound(items,W,index,current_profit,current_weight)<=profit)
                {
                    while(index == n || index != 0  && Y[index] != 1)
                    {
                        index --;  
                    }
                    if (index == 0) return X;
                    Y[index] = 0;
                    current_profit -= items[index].Val;
                    current_weight -= items[index].Weight;
                }
                index++;
            }
        }

        // 回溯法解决0-1背包问题
        public decimal BacktrackingKnapsack(KnapsackBackTrackItem[] items, int capacity, int currentIndex, ref decimal maxVal, decimal currentVal, int currentWeight)
        {
            // 基准情况：如果当前索引超过物品数量，或者当前重量超过背包容量，则返回
            if (currentIndex >= items.Length || currentWeight > capacity)
                return currentVal;

            // 不选择当前物品，直接进入下一个物品的选择
            var valWithoutCurrent = BacktrackingKnapsack(items, capacity, currentIndex + 1, ref maxVal, currentVal, currentWeight);

            // 选择当前物品，并且更新当前价值和重量，尝试放入背包
            var valWithCurrent = 0m;
            if (currentWeight + items[currentIndex].Weight <= capacity)
            {
                valWithCurrent = BacktrackingKnapsack(items, capacity, currentIndex + 1, ref maxVal,
                                                     currentVal + items[currentIndex].Val,
                                                     currentWeight + items[currentIndex].Weight);
            }

            // 更新最大价值
            maxVal = Math.Max(maxVal, Math.Max(valWithCurrent, valWithoutCurrent));

            // 返回两种情况中价值较大的那个，作为上一层的参考
            return Math.Max(valWithCurrent, valWithoutCurrent);
        }

        public decimal BacktrackingKnapsackExcise(KnapsackBackTrackItem[] items, int capacity, int currentIndex, ref decimal maxVal, decimal currentVal, int currentWeight)
        {
            if (currentIndex >= items.Length || currentWeight > capacity) return currentVal;
            var valWithoutCurrent = BacktrackingKnapsackExcise(items, capacity, currentIndex + 1, ref maxVal, currentVal, currentWeight);
            var valWithCurrent = 0m;
            if(currentWeight + items[currentIndex].Weight <= capacity)
            {
                valWithCurrent = BacktrackingKnapsackExcise(items,capacity,currentIndex + 1, ref maxVal, currentVal + items[currentIndex].Val, currentWeight + items[currentIndex].Weight);
            }
            maxVal = Math.Max(maxVal,Math.Max(valWithoutCurrent, valWithCurrent));
            return Math.Max(valWithCurrent, valWithoutCurrent);
        }
    }
}
