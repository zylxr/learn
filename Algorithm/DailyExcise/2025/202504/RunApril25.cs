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

            var subSetXORSumClass = new SubsetXORSumClass();
            var subSetXORSumResult = subSetXORSumClass.SubsetXORSum(new int[] { 5, 1, 6 });//28

            subSetXORSumResult = subSetXORSumClass.SubsetXORSum2(new int[] { 5, 1, 6 });//28

            subSetXORSumResult = subSetXORSumClass.SubsetXORSum2(new int[] { 1,3 });//6

            subSetXORSumResult = subSetXORSumClass.SubsetXORSum3(new int[] { 1, 3 });//6

            var canPartitionClass = new CanPartitionClass();
            var canPartitionClassResult = canPartitionClass.CanPartition(new int[] {1,5,11,5 });//true

            var numberOfPowerfulIntClass = new NumberOfPowerfulIntClass();
            var numberOfPowerfulIntResult = numberOfPowerfulIntClass.NumberOfPowerfulInt(1,6000,4,"124");//5

            numberOfPowerfulIntResult = numberOfPowerfulIntClass.NumberOfPowerfulInt(20, 1159, 5, "20");//8

            var countGoodIntegersClass = new CountGoodIntegersClass();
            var countGoodIntegersResult = countGoodIntegersClass.CountGoodIntegers(3, 5);//27
        }
    }
}
