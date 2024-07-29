using Algorithm.DivideAndConquer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DevideAndConquer
{
    public class RunDivideAndConquer
    {
        public static void Run()
        {
            var segmentSum = new SegmentSum();
            var segments = new int[] { -2,11,-4,13,-5,-2};
            var segmentSumResult = segmentSum.Sum(segments,0,segments.Length-1);//20

            segmentSumResult = segmentSum.SumEx(segments,0,segments.Length-1);//13

            var roundRobinTournament = new RoundRobinTournament();
            var roundRobinTournamentResult = roundRobinTournament.GenerateSchedule(4);
            roundRobinTournament.PrintSchedule(roundRobinTournamentResult);
        }
    }
}
