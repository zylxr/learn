using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunSep25
    {
        public static void Run()
        {
            var maxAverageRatioClass = new MaxAverageRatioClass();
            var maxAverageRatioClassResult = maxAverageRatioClass.MaxAverageRatio(new int[][]
            {
                new int[] {1,2 },
                new int[] {3,5},
                new int[] {2,2}
            }, 2);//0.78333

            maxAverageRatioClassResult = maxAverageRatioClass.MaxAverageRatio2(new int[][]
            {
                new int[] {1,2 },
                new int[] {3,5},
                new int[] {2,2}
            }, 2);//0.78333

            maxAverageRatioClassResult = maxAverageRatioClass.MaxAverageRatio2(new int[][]
            {
                new int[] {2,4 },
                new int[] {3,9},
                new int[] { 4, 5 },
                new int[] { 2, 10 }
            }, 4);//0.53485

            //maxAverageRatioClassResult = maxAverageRatioClass.MaxAverageRatio(new int[][]
            //{
            //    new int[] {2,4 },
            //    new int[] {3,9},
            //    new int[] { 4, 5 },
            //    new int[] { 2, 10 }
            //}, 4);//0.53485
        }
    
    }
}
