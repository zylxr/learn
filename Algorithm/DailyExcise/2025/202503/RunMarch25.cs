using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunMarch25
    {
        public static void Run()
        {
            var partitionClass = new PartitionClass();
            var partitionResult = partitionClass.Partition("aab");//[["a","a","b"],["aa","b"]]

            var palindromePartitionClass = new PalindromePartitionClass();
            var palindromePartitionResult = palindromePartitionClass.PalindromePartition("abc",2);//1
            palindromePartitionResult = palindromePartitionClass.PalindromePartition2("abc", 2);//1

            var checkPartitionClass = new CheckPartitioningClass();
            var checkPartitionResult = checkPartitionClass.CheckPartitioning("abcbdd");//true
            checkPartitionResult = checkPartitionClass.CheckPartitioning("bcbddxy");//false
            checkPartitionResult = checkPartitionClass.CheckPartitioning("xxdtzghekllxsiqydgnsktyjpshdbhbkiutwdxjgikdpowshccjfcgdeldgaloovpwpvzopqvpvgvpfpogzwzgrtuuezvqcqoymmcoabiaydtiyvfbgqpzkucdqnwkgfwg");//false

            var beautifulSubArraysClass = new BeautifulSubarraysClass();
            var beautifulSubArrayResult = beautifulSubArraysClass.BeautifulSubarrays(new int[] { 4, 3, 1, 2, 4 });//2

            var beautifulSubsetsClass = new BeautifulSubsetsClass();
            var beautifulSubsetsResult = beautifulSubsetsClass.BeautifulSubsets(new int[] { 2,4,6},2);//4
            beautifulSubsetsResult = beautifulSubsetsClass.BeautifulSubsets2(new int[] { 2, 4, 6 }, 2);//4

            var maximumBeautyClass = new MaximumBeautyClass2();
            var maximumBeautyResult = maximumBeautyClass.MaximumBeauty(new int[] { 1,3,1,1},7,6,12,1);//14

            var countOfSubstringsClass = new CountOfSubstringsClass();
            var countOfSubstringsClassResult = countOfSubstringsClass.CountOfSubstrings("aeiou",0);//1

            var minSwapClass = new MinSwapsClass();
            var minSwapResult = minSwapClass.MinSwaps("][][");//1

            var minimumCostClass = new MinimumCostClass3();
            var minimumCostResult = minimumCostClass.MinimumCost("0011");//2
            minimumCostResult = minimumCostClass.MinimumCost2("0011");//2

            var minimizeStringLengthClass = new MinimizedStringLengthClass();
            var minimizedStringLengthResult = minimizeStringLengthClass.MinimizedStringLength("aaabc");//3

            var longestCycleClass = new LongestCycleClass();
            var longestCycleResult = longestCycleClass.LongestCycle(new int[] { 3,3,4,2,3});//3
        }
    }
}
