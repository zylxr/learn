using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunOctoberDailyExcercise
    {
        public static void Run()
        {
            var minCosTicketsClass = new MincostTicketsClass();
            var minCostTicketsResult = minCosTicketsClass.MincostTickets(new int[] { 1, 4, 6, 7, 8, 20 },new int[] { 2, 7, 15 });//11

            minCostTicketsResult = minCosTicketsClass.MincostTickets(new int[] { 1, 4, 6, 7, 8, 365 }, new int[] { 2,7,15});//11

            minCostTicketsResult = minCosTicketsClass.MincostTickets2(new int[] { 1, 4, 6, 7, 8, 20 }, new int[] { 2, 7, 15 });//11

            var minSpeedOnTimeClass = new MinSpeedOnTimeClass();
            var minSpeedOnTimeResult = minSpeedOnTimeClass.MinSpeedOnTime(new int[] { 1, 3, 2 },6);//1

            minSpeedOnTimeResult = minSpeedOnTimeClass.MinSpeedOnTime(new int[] { 1, 3, 2 }, 2.7);//3

            minSpeedOnTimeResult = minSpeedOnTimeClass.MinSpeedOnTime(new int[] { 1, 1, 100000 }, 2.01);//10000000

            minSpeedOnTimeResult = minSpeedOnTimeClass.MinSpeedOnTime(new int[] { 37, 64, 81 }, 3.11);//73

        }
    }
}
