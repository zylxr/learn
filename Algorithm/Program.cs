using Algorithm.BackTracking;
using Algorithm.DailyExcise;
using Algorithm.DevideAndConquer;
using Algorithm.dp;
using Algorithm.Graph;
using Algorithm.Greedy;
using Algorithm.tree;
using System.Globalization;

namespace Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region dynamic programming
            RunDp.RunDP();
            #endregion

            var kmp = new KMPAlgorithm();
            var kmpResult = kmp.Search("long text", "pattern");//-1
            kmpResult = kmp.Search("ababababbababac","ababac");//9
            kmp.BuildPartialMatchTable("aaabaaa");
            kmp.BuildPartialMatchTable("aaabaaac");
            kmp.BuildPartialMatchTable("12d3a12d3de");
            kmp.BuildNext("aaabaaac");
            kmp.BuildNext("abababb");
            kmpResult = kmp.SearchEx("ababababbababac", "ababac");//9

            RunTree.Run();
            Algorithm.Graph.RunGraphUtil.RunGraph();

            Sort.RunSort.Run();

            RunDivideAndConquer.Run();
            RunGreedy.Run();
            RunBackTracking.Run();
            RunDailyExcise.Run();
            RunDailyPartialAugust.Run();
            RunDailySeptempber.Run();
            RunOctoberDailyExcercise.Run();
            Console.WriteLine("Hello, World!");
        }
    }
}
