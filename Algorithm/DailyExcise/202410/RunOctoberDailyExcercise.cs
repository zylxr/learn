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
            var minCostTicketsResult = minCosTicketsClass.MincostTickets(new int[] { 1, 4, 6, 7, 8, 20 }, new int[] { 2, 7, 15 });//11

            minCostTicketsResult = minCosTicketsClass.MincostTickets(new int[] { 1, 4, 6, 7, 8, 365 }, new int[] { 2, 7, 15 });//11

            minCostTicketsResult = minCosTicketsClass.MincostTickets2(new int[] { 1, 4, 6, 7, 8, 20 }, new int[] { 2, 7, 15 });//11

            var minSpeedOnTimeClass = new MinSpeedOnTimeClass();
            var minSpeedOnTimeResult = minSpeedOnTimeClass.MinSpeedOnTime(new int[] { 1, 3, 2 }, 6);//1

            minSpeedOnTimeResult = minSpeedOnTimeClass.MinSpeedOnTime(new int[] { 1, 3, 2 }, 2.7);//3

            minSpeedOnTimeResult = minSpeedOnTimeClass.MinSpeedOnTime(new int[] { 1, 1, 100000 }, 2.01);//10000000

            minSpeedOnTimeResult = minSpeedOnTimeClass.MinSpeedOnTime(new int[] { 37, 64, 81 }, 3.11);//73

            var minCostClass = new MinCostClass();
            var minCostResult = minCostClass.MinCost(30, new int[][] {
                new int[]{ 0,1,10},
                new int[]{ 1,2,10},
                new int[]{2,5,10},
                new int[]{0,3,1 },
                new int[]{3,4,10},
                new int[]{4,5,15}
            }, new int[] { 5, 1, 2, 20, 20, 3 });//11


            minCostResult = minCostClass.MinCost(100, new int[][] {
                new int[]{ 0,1,100}
            }, new int[] { 2, 5 });//7


            minCostResult = minCostClass.MinCost2(30, new int[][] {
                new int[]{ 0,1,10},
                new int[]{ 1,2,10},
                new int[]{2,5,10},
                new int[]{0,3,1 },
                new int[]{3,4,10},
                new int[]{4,5,15}
            }, new int[] { 5, 1, 2, 20, 20, 3 });//11

            var nthPersonGetNthSeatClass = new NthPersonGetsNthSeatClass();
            var nthPersonGetNthSeatResult = nthPersonGetNthSeatClass.NthPersonGetsNthSeat(4);//0.5

            var minimumTimeClass = new MinimumTimeClass2();
            var minimumTimeResult = minimumTimeClass.MinimumTime(new int[] { 1, 2, 3 }, 5);//3
            minimumTimeResult = minimumTimeClass.MinimumTime(new int[] { 2 }, 1);//2

            var minRefuelStopsClass = new MinRefuelStopsClass();
            var minRefuleStopsResult = minRefuelStopsClass.MinRefuelStops(100, 10, new int[][] {
                new int[]{ 10,60},
                new int[]{20,30 },
                new int[]{ 30,30},
                new int[]{ 60,40}
            });//2

            minRefuleStopsResult = minRefuelStopsClass.MinRefuelStops(1, 1, new int[][] { });//0

            minRefuleStopsResult = minRefuelStopsClass.MinRefuelStops(100, 1, new int[][] { new int[] { 10, 100 } });//-1

            minRefuleStopsResult = minRefuelStopsClass.MinRefuelStops(100, 25, new int[][] {
                new int[] { 25, 25 },
                new int[]{ 50,25},
                new int[]{ 75,25},
                });//3

            minRefuleStopsResult = minRefuelStopsClass.MinRefuelStops2(100, 25, new int[][] {
                new int[] { 25, 25 },
                new int[]{ 50,25},
                new int[]{ 75,25},
                });//3

            minRefuleStopsResult = minRefuelStopsClass.MinRefuelStops3(100, 25, new int[][] {
                new int[] { 25, 25 },
                new int[]{ 50,25},
                new int[]{ 75,25},
                });//3

            var minimumDifferenceClass = new MinimumDifferenceClass();
            var minimumDifferenceResult = minimumDifferenceClass.MinimumDifference(new int[] { 1, 2, 4, 5 }, 3); //0

            minimumDifferenceResult = minimumDifferenceClass.MinimumDifference2(new int[] { 1 }, 10);//9

            var numberOfPairsClass = new NumberOfPairsClass();
            var numberOfPairsResult = numberOfPairsClass.NumberOfPairs(new int[] { 1, 3, 4 }, new int[] { 1, 3, 4 }, 1); //5

            var duplicateNumberClass = new DuplicateNumbersXORClass();
            var duplicateNumberResult = duplicateNumberClass.DuplicateNumbersXOR(new int[] { 1, 2, 2, 1 });//3

            duplicateNumberResult = duplicateNumberClass.DuplicateNumbersXOR2(new int[] { 1, 2, 2, 1 });//3

            var superEggDropClass = new SuperEggDropClass();
            var superEggDropResult = superEggDropClass.SuperEggDrop(1,2); //2
            superEggDropResult = superEggDropClass.SuperEggDrop(2, 6); //3

            superEggDropResult = superEggDropClass.SuperEggDrop2(2, 6); //3

            superEggDropResult = superEggDropClass.SuperEggDrop3(2, 6); //3

            var maxHeightOfTriangle = new MaxHeightOfTriangleClass();
            var maxHeightOfTriangleResult = maxHeightOfTriangle.MaxHeightOfTriangle(10,1);//2

            var numberOfPermutationClass = new NumberOfPermutationsClass();
            var numberOfPermutationResult = numberOfPermutationClass.NumberOfPermutations(3,new int[][] { new int[] { 2,2},new int[] { 0,0} }); //2

            numberOfPermutationResult = numberOfPermutationClass.NumberOfPermutations2(3, new int[][] { new int[] { 2, 2 }, new int[] { 0, 0 } }); //2
        }
    }
}
