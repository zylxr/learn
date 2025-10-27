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

            var swimInWaterClass = new SwimInWaterClass();
            var swimInWaterClassResult = swimInWaterClass.SwimInWater(new int[][] { 
                new int[]{ 0, 1, 2, 3, 4 },
                new int[]{ 24,23,22,21,5 },
                new int[]{ 12,13,14,15,16 },
                new int[]{11,17,18,19,20 },
                new int[]{ 10, 9, 8, 7, 6 }
            });//16

            swimInWaterClassResult = swimInWaterClass.SwimInWater(new int[][] {
                new int[]{ 3,2 },
                new int[]{ 0,1 }
            });//3

            var avoidFloodClass = new AvoidFloodClass();
            var avoidFloodClassResult = avoidFloodClass.AvoidFlood(new int[] { 69, 0, 0, 0, 69 }); //[-1,69,1,1,-1]

            var successfulPairClass = new SuccessfulPairsClass();
            var successfulPairResult = successfulPairClass.SuccessfulPairs(new int[] { 5,1,3},new int[] { 1,2,3,4,5},7);//[4,0,3]
        
            var minTimeClass = new MinTimeClass();
            var minTimeClassResult = minTimeClass.MinTime(new int[] { 1,5,2,4}, new int[] {5,1,4,2 });//110
        
            var maximumTotalDamageClass = new MaximumTotalDamageClass();
            var maximumTotalDamageClassResult = maximumTotalDamageClass.MaximumTotalDamage(new int[] {1,1,3,4 });//6
            maximumTotalDamageClassResult = maximumTotalDamageClass.MaximumTotalDamage(new int[] { 7,1,6,3 });//10
        
            var findSmallestIntegerClass = new FindSmallestIntegerClass();
            var findSmallestIntegerClassResult = findSmallestIntegerClass.FindSmallestInteger(new int[] {
                3,0,3,2,4,2,1,1,0,4
            },
                5);//10

            var maxPartitionClass = new MaxPartitionsAfterOperationsClass();
            var maxPartitionClassResult = maxPartitionClass.MaxPartitionsAfterOperations("accca",2);//3
        
            var maxFrequencyClass = new MaxFrequencyClass();
            var maxFrequenceResult = maxFrequencyClass.MaxFrequency(new int[] { 1, 2, 4, 5 },2,4);//4

            var maxFrequncyClass2 = new MaxFrequencyClass2();
            var maxFrequncyClass2Result = maxFrequncyClass2.MaxFrequency(new int[] {93,45 },1,2);//1

            var numberOfBeamClass = new NumberOfBeamsClass();
            var numberOfBeamClassResult = numberOfBeamClass.NumberOfBeams(new string[] {
            "011001","000000","010100","001000"
            });//8
        }
    }
}
