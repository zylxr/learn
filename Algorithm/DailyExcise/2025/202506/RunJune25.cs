using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunJune25
    {
        public static void Run()
        {
            var candyClass = new CandyClass();
            var candyClassResult = candyClass.Candy(new int[] { 1, 0, 2 });//5
            candyClassResult = candyClass.Candy(new int[] { 1, 3, 2, 2, 1 });//7
            candyClassResult = candyClass.Candy(new int[] { 1, 2, 3, 1, 0 });//9

            candyClassResult = candyClass.Candy2(new int[] { 1, 2, 3, 1, 0 });//9
            candyClassResult = candyClass.Candy3(new int[] { 1, 2, 3, 1, 0 });//9

            var maxCandiesClass2 = new MaxCandiesClass2();
            var maxCandiesClass2Result = maxCandiesClass2.MaxCandies(
                new int[] { 1, 0, 1, 0 },
                new int[] { 7, 5, 4, 100 },
                new int[][] { new int[] { },new int[] { },new int[] { 1 },new int[] { } },
                new int[][] { new int[] {1,2 },new int[] {3 },new int[] { },new int[] { } },
                new int[] { 0 }
                );//16

            var answerStringClass = new AnswerStringClass();
            var answerStringClassResult = answerStringClass.AnswerString("aann",2);//nn
            answerStringClassResult = answerStringClass.AnswerString2("aann", 2);//nn
            answerStringClassResult = answerStringClass.AnswerString3("aann", 2);//nn

            var smallestQuivalenStringClass = new SmallestEquivalentStringClass();
            var smallestQuivalenStrngClassResult = smallestQuivalenStringClass.SmallestEquivalentString("parker", "morris", "parser");//makkek
        
            var robotWithStringClass = new RobotWithStringClass();
            var robotWithStringClassResult = robotWithStringClass.RobotWithString("zza");//azz

            var clearStarsClass = new ClearStarsClass();
            var clearStarsClassResult = clearStarsClass.ClearStars("aaba*");//aab

            var findKthNumberClass = new FindKthNumberClass();
            var findKthNumberClassResult = findKthNumberClass.FindKthNumber(13,2);//10

            var maxDifferenceClass = new MaxDifferenceClass();
            var maxDifferenceClassResult = maxDifferenceClass.MaxDifference("12233",4);//-1

            var minimizeMaxClass = new MinimizeMaxClass();
            var minimizeMaxClassResult = minimizeMaxClass.MinimizeMax(new int[] { 10, 1, 2, 7, 1, 3 },2);//1

            minimizeMaxClassResult = minimizeMaxClass.MinimizeMax(new int[] { 3, 4, 2, 3, 2, 1, 2 }, 3);//1

            var lrutest = new LRU();
            lrutest.Test();

            var countGoodArrayClass = new CountGoodArraysClass();
            var countGoodArrayClassResult = countGoodArrayClass.CountGoodArrays(3,2,1);//4

            var divideArrayClass = new DivideArrayClass();
            var divideArrayClassResult = divideArrayClass.DivideArray(new int[] { 1, 3, 4, 8, 7, 9, 3, 5, 1 }, 2);//[[1,1,3],[3,4,5],[7,8,9]]
            divideArrayClassResult = divideArrayClass.DivideArray2(new int[] { 1, 3, 4, 8, 7, 9, 3, 5, 1 }, 2);//[[1,1,3],[3,4,5],[7,8,9]]

            var partitionArrayClass = new PartitionArrayClass();
            var partitionArrayClassResult = partitionArrayClass.PartitionArray(new int[] { 3, 6, 1, 2, 5 },2);//2

            var maxDistanceClass = new MaxDistanceClass3();
            var maxDistanceClassResult = maxDistanceClass.MaxDistance("NWSE",1);//3
            maxDistanceClassResult = maxDistanceClass.MaxDistance2("NWSE", 1);//3

            var minimumDeletionClass = new MinimumDeletionsClass();
            var minimumDeletionClassResult = minimumDeletionClass.MinimumDeletions("aabcaba", 0);//3

            var kmirrorClass = new KMirrorClass();
            var kmirrorClassResult = kmirrorClass.KMirror(2,5);//25

            var kthSmallestProductClass = new KthSmallestProductClass();
            var kthSmallestProductClassResult = kthSmallestProductClass.KthSmallestProduct(new int[] {2,5 }, new int[] {3,4 },2 );//8
            kthSmallestProductClassResult = kthSmallestProductClass.KthSmallestProduct2(new int[] { 2, 5 }, new int[] { 3, 4 }, 2);//8

            var longestSubClass = new LongestSubsequenceClass();
            var longestSubClassResult = longestSubClass.LongestSubsequence("1001010",5);//5
        }
    }
}
