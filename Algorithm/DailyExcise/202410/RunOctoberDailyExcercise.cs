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

        }
    }
}
