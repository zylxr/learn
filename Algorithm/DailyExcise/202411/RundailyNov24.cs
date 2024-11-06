using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RundailyNov24
    {
        public static void Run()
        {
            var maxEnergyBoost = new MaxEnergyBoostClass();
            var maxEnergyBoostResult = maxEnergyBoost.MaxEnergyBoost(new int[] { 1, 3, 1 }, new int[] { 3, 1, 1 });//5

            var minChangesClass = new MinChangesClass();
            var minChangesResult = minChangesClass.MinChanges(11, 56);//-1

            var judgeSquareSumClass = new JudgeSquareSumClass();
            var judgeSquareSumResult = judgeSquareSumClass.JudgeSquareSum(5); //true
            judgeSquareSumResult = judgeSquareSumClass.JudgeSquareSum2(5);//true

            var resultArrayClass = new ResultsArrayClass2();
            var resultArrayResult = resultArrayClass.ResultsArray(new int[] { 1, 2, 3, 4, 3, 2, 5 },3);//[3,4,-1,-1,-1]
        }
    }
}
