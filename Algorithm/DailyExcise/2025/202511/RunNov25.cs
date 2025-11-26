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

            var processQueriesClass = new ProcessQueriesClass();
            var processQueriesClassResult = processQueriesClass.ProcessQueries(5,
                new int[][] {
                    new int[]{ 1,2},
                    new int[]{2,3},
                    new int[]{3,4 },
                    new int[]{4,5}
                },
                new int[][] {
                    new int[]{ 1,3},
                    new int[]{2,1},
                    new int[]{1,1},
                    new int[] { 2,2},
                    new int[]{1,2}
                });//[3,2,3]
            var maxPowerClass = new MaxPowerClass();
            var maxPowerClassResult = maxPowerClass.MaxPower(new int[] { 1, 2, 4, 5, 0 },1,2);//5

            var minimuOneBitClass = new MinimumOneBitOperationsClass();
            var minimuOneBitClassResult = minimuOneBitClass.MinimumOneBitOperations(9);//14

            minimuOneBitClassResult = minimuOneBitClass.MinimumOneBitOperations2(9);//14

            var minOperationClass = new MinOperationsClass4();
            var minOperationClassResult = minOperationClass.MinOperations(new int[] { 3, 1, 2, 1 });//3
            var minOperationClass2= new MinOperationsClass5();
            var minOperationClassResult2 = minOperationClass2.MinOperations(new int[] { 2, 6, 3, 4 });//4 
        
            var rangeAddQueriesClass = new RangeAddQueriesClass();
            var rangeAddQueriesClassResult = rangeAddQueriesClass.RangeAddQueries(
                3,
                new int[][] { 
                    new int[]{ 1, 1, 2, 2 },
                    new int[]{ 0, 0, 1, 1 }
                });//[[1,1,0],[1,2,1],[0,1,1]]

            var numberOfSubStringClass = new NumberOfSubstringsClass();
            var numberOfSubStringClassResult = numberOfSubStringClass.NumberOfSubstrings("00011");//5

            var intersectionClass = new IntersectionSizeTwoClass();
            var intersectionClassResult = intersectionClass.IntersectionSizeTwo(new int[][] {
            new int[]{ 1,2 },
            new int[]{2,3 },
            new int[]{ 2,4},
            new int[]{ 4,5} }
            );//5

            var countPalindromicSubClass = new CountPalindromicSubsequenceClass();
            var countPalindromicSubClassResult = countPalindromicSubClass.CountPalindromicSubsequence("aabca");//3

            var smallestRep = new SmallestRepunitDivByKClass();
            var smallestRepResult = smallestRep.SmallestRepunitDivByK(3);//3

            var numberOfPathsClass = new NumberOfPathsClass();
            var numberOfPathClassResult = numberOfPathsClass.NumberOfPaths(new int[][] {
                new int[]{ 5,2,4},
                new int[]{ 3,0,5},
                new int[]{ 0,7,2}
            },3);//2

            numberOfPathClassResult = numberOfPathsClass.NumberOfPaths2(new int[][] {
                new int[]{ 5,2,4},
                new int[]{ 3,0,5},
                new int[]{ 0,7,2}
            }, 3);//2

            var maxSubArraySumClass = new MaxSubarraySumClass();
            var maxSubArraySumClassResult = maxSubArraySumClass.MaxSubarraySum(new int[] { 1,2},1);//3
        }

    }
}
