using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunOct25
    {
        public static void Run()
        {
            var traprainwaterClass = new TrapRainWaterClass();
            var traprainwaterClassResult = traprainwaterClass.TrapRainWater(new int[][] {
                new int[]{ 1, 4, 3, 1, 3, 2 },
                new int[]{ 3, 2, 1, 3, 2, 4 },
                new int[]{ 2, 3, 3, 2, 3, 1 }
            });//4

            traprainwaterClassResult = traprainwaterClass.TrapRainWater(new int[][] {
                new int[]{ 3,3,3,3,3 },
                new int[]{ 3,2,2,2,3 },
                new int[]{ 3, 2, 1, 2, 3 },
                new int[]{ 3, 2, 2, 2, 3 },
                new int[]{ 3, 3, 3, 3, 3 }
            });//10

            var maxAreaClass = new MaxAreaClass();
            var maxAreaClassResult = maxAreaClass.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });//49
        }
    }
}
