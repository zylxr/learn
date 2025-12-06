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
            var countTrapezoidsClass2 = new CountTrapezoidsClass2();
            var countTrapezoidsClass2Result = countTrapezoidsClass2.CountTrapezoids(new
                int[][] {
                    new int[]{ -3, 2 },
                    new int[]{ 3, 0},
                    new int[]{ 2, 3},
                    new int[]{ 3, 2},
                    new int[]{ 2, -3}
                });//2

            var countCollisionsClass = new CountCollisionsClass();
            var countCollisionsClassResult = countCollisionsClass.CountCollisions("RLRSLL");//5
            countCollisionsClassResult = countCollisionsClass.CountCollisions2("RLRSLL");//5

            var countPartitionClass = new CountPartitionsClass();
            var countPartitionClassResult = countPartitionClass.CountPartitions(new int[] { 9, 4, 1, 3, 7 },4);//6
            countPartitionClassResult = countPartitionClass.CountPartitions2(new int[] { 9, 4, 1, 3, 7 }, 4);//6
        }
    }
}
