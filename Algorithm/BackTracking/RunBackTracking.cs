using Algorithm.dp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.BackTracking
{
    public class RunBackTracking
    {
        public static void Run()
        {
            var knapsackBacktracking = new KnapsackBackTrack();
            var vals= new decimal[] { 11,21,31,33,43,53,55,65};
            var weights = new int[] { 1,11,21,23,33,43,45,55 };
            var items = weights.Zip(vals,(w,v)=>new KnapsackBackTrackItem { Val = v,Weight = w }).OrderByDescending(_=>_.ValueDensity).ToArray();
            var knapsackBacktrackingResult = knapsackBacktracking.Knapsack(items,110);
            decimal knapsackBacktrackingResult1 = 0;
            knapsackBacktracking.BacktrackingKnapsack(items, 110,0,ref knapsackBacktrackingResult1,0,0);
            knapsackBacktracking.BacktrackingKnapsackExcise(items, 110, 0, ref knapsackBacktrackingResult1, 0, 0);

            var nQueenClass = new NQueen();
            var nQueenResult = nQueenClass.FindNQueen(8);
            var nQueenResult1 = nQueenClass.FindNQueenSolutions(8);
        }
    }
}
