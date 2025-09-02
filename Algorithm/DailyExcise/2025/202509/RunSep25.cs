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

            var numberOfPairsClass2 = new NumberOfPairsClass2();
            var numberOfPairsClass2Result = numberOfPairsClass2.NumberOfPairs(
                new int[][] {
                    new int[]{ 0,1},
                    new int[]{1,3 },
                    new int[]{6,1}
                }
                );//2

            numberOfPairsClass2Result = numberOfPairsClass2.NumberOfPairs(
                new int[][] {
                    new int[]{ 0,2},
                    new int[]{5,1 },
                    new int[]{5,6}
                }
                );//2

            numberOfPairsClass2Result = numberOfPairsClass2.NumberOfPairs(
                new int[][] {
                    new int[]{ 6,2},
                    new int[]{4,4 },
                    new int[]{2,6}
                }
                );//2
            var numberOfPairsClass3 = new NumberOfPairsClass3();
            var numberOfPairsClass3Result = numberOfPairsClass3.NumberOfPairs(new int[][] { 
                new int[]{1,1 },
                new int[]{2,2},
                new int[]{3,3},
            });//0

            numberOfPairsClass3Result = numberOfPairsClass3.NumberOfPairs2(new int[][] {
                new int[]{1,1 },
                new int[]{2,2},
                new int[]{3,3},
            });//0
        }
    }
}
