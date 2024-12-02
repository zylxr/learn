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
        }
    }
}
