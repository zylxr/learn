using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunNov25
    {
        public static void Run()
        {
            var minCostClass4 = new MinCostClass4();
            var minCostClass4Result = minCostClass4.MinCost("abaac",new int[] { 1, 2, 3, 4, 5 });//3

            var findXSumClass = new findXSumClass();
            var findXSumClassResult = findXSumClass.FindXSum(new int[] { 1, 1, 2, 2, 3, 4, 2, 3 },6,2);//[6,10,12]
        }
    }
}
