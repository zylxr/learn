using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunDecember24
    {
        public static void Run()
        {
            var totalNQueensClass = new TotalNQueensClass();
            var totalNQueenClassResult = totalNQueensClass.TotalNQueens(4);//2
            totalNQueenClassResult = totalNQueensClass.TotalNQueens2(4);//2

            var knightProbabilityClass = new KnightProbabilityClass();
            var knightProbabilityResult = knightProbabilityClass.KnightProbability(3,2,0,0);//0.0625

            var knightDialerClass = new KnightDialerClass();
            var knightDialerResult = knightDialerClass.KnightDialer(2);//20
            knightDialerResult = knightDialerClass.KnightDialer2(2);//20
        }
    }
}
