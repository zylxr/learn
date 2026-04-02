using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunApril26
    {
        public static void Run()
        {
            var survivedRobClass = new SurvivedRobotsHealthsClass();
            var survivedRobClassResult = survivedRobClass.SurvivedRobotsHealths(new int[] { 3, 5, 2, 6 }, new int[] { 10, 10, 15, 12 }, "RLRL");//14
            survivedRobClassResult = survivedRobClass.SurvivedRobotsHealths(new int[] { 3, 47 }, new int[] { 46, 26 }, "LR");//46,26
            survivedRobClassResult = survivedRobClass.SurvivedRobotsHealths(new int[] { 5, 46, 12 }, new int[] { 3, 27, 43 }, "RLL");//27,42

            survivedRobClassResult = survivedRobClass.SurvivedRobotsHealths2(new int[] { 5, 46, 12 }, new int[] { 3, 27, 43 }, "RLL");//27,42

            var maximumAmountClass = new MaximumAmountClass();
            var maximumAmountClassResult = maximumAmountClass.MaximumAmount(new int[][] { 
                new int[]{ 0, 1, -1 },
                new int[]{ 1, -2, 3 },
                new int[]{ 2, -3, 4 }
            });
        }
    }
}
