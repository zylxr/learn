using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunFeb26
    {
        public static void Run()
        {
            var minimumCostClass9 = new MinimumCostClass9();
            var minimuCostClass9Result = minimumCostClass9.MinimumCost(new int[] {
                1,3,2,6,4,2
            },3,3);//5

            var isTionicClass = new IsTrionicClass();
            var isTrionicClassResult = isTionicClass.IsTrionic(new int[] { 4, 1, 5, 2, 3 });//false
            isTrionicClassResult = isTionicClass.IsTrionic(new int[] { 1, 3, 5, 4, 2, 6 });//true
        }
    }
}
