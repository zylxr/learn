using Algorithm.dp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunApril25
    {
        public static void Run()
        {
            var mostPointsClass = new MostPointsClass();
            var mostPointsClassResult = mostPointsClass.MostPoints(new int[][] {
               new int[]{3,2 },
               new int[]{4,3},
               new int[]{4,4},
               new int[]{2,5},
            });//5

            mostPointsClassResult = mostPointsClass.MostPoints(new int[][] {
               new int[]{1,1 },
               new int[]{2,2},
               new int[]{3,3},
               new int[]{4,4},
               new int[]{5,5},
            });//7

            mostPointsClassResult = mostPointsClass.MostPoints2(new int[][] {
               new int[]{1,1 },
               new int[]{2,2},
               new int[]{3,3},
               new int[]{4,4},
               new int[]{5,5},
            });//7
        }
    }
}
