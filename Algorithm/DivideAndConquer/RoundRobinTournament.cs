using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DivideAndConquer
{
    public class RoundRobinTournament
    {
        //生成满足条件的循环赛日程表。这里我们假设参赛人数 𝑛=2^𝑘，这样可以保证能够完美地分割参赛者进行比赛安排

        public int[,] GenerateSchedule(int n)
        {
            var ret = new int[n + 1, n + 1];
            ret[1, 1] = 1;
            ret[1, 2] = 2;
            ret[2, 1] = 2;
            ret[2, 2] = 1;
            for(var k=1;2*k<=n;k++)
            {
                var pre = 2 * k;
                var curr = 2 * pre;
                if (curr > n) break;
                //扩展左下角
                for (var i = pre + 1; i <= curr; i++)
                    for (var j = 1; j <= pre; j++)
                        ret[i, j] = ret[i - pre, j] + pre;
                //扩展右上角
                for(var i=1;i <= pre; i++)
                    for(var j=pre+1;j <= curr; j++)
                        ret[i, j] = ret[i,j-pre]+pre;
                //扩展右下角
                for(var i=pre+1;i<=curr;i++)
                    for(var j= pre+1;j<=curr;j++)
                        ret[i,j] = ret[i-pre,j-pre]+pre;
            }
            return ret;
        }

        public void PrintSchedule(int[,] ret)
        {
            var n = ret.GetLength(0);
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    Console.WriteLine($"Schedule[{i},{j}]={ret[i,j]}");
        }
    }
}
