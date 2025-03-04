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
        }
    }
}
