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
        }
    }
}
