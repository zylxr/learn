using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunJan26
    {
        public static void Run()
        {
            var numOfWaysClass = new NumOfWaysClass();
            var numOfWaysClassResult = numOfWaysClass.NumOfWays(2);//54

            var sumFourDivisionClass = new SumFourDivisorsClass();
            var sumFourDivisionClassResult = sumFourDivisionClass.SumFourDivisors(new int[] { 21,4,7});//32
        
            var maxMatrixSumClass = new MaxMatrixSumClass();
            var maxMatrixSumClassResult = maxMatrixSumClass.MaxMatrixSum(new int[][] { 
                new int[] { -1,0,-1 },
                new int[] { -2,1,3 },
                new int[] { 3,2,2 }
            });//15
        }
    }
}
