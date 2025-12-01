using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunDec25
    {
        public static void Run()
        {
            var maxRunTimeClass = new MaxRunTimeClass();
            var maxRunTimeClassResult = maxRunTimeClass.MaxRunTime(2,new int[] { 3,3,3});//4
            var countTrapezoidsClass = new CountTrapezoidsClass();
            var countTrapezoidsClassResult = countTrapezoidsClass.CountTrapezoids(
               new int[][] { 
                   new int[] { 1,0 },
                   new int[] { 2,0},
                   new int[]{ 3,0},
                   new int[]{2,2 },
                   new int[]{3,2}
               });//3
        }
    }
}
