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

            var minCostClass = new MinCostClass2();
            var minCostClassResult = minCostClass.MinCost(7,new int[] { 1, 3, 4, 5 });//16

            var countKConstraintSubString = new CountKConstraintSubstringsClass();
            var countKConstraintSubStringResult = countKConstraintSubString.CountKConstraintSubstrings("10101",1);//12

            var countKConstraintSubString2 = new CountKConstraintSubstringsClass2();
            var countKConstraintSubString2Result = countKConstraintSubString2.CountKConstraintSubstrings("0001111",2,new int[][] { new int[] {0,6 } });//[26]
        
            var countGoodNodesClass = new CountGoodNodesClass();
            var countGoodNodesResult = countGoodNodesClass.CountGoodNodes(new int[][] {
                new int[]{0,1 },
                new int[]{0,2 },
                new int[]{1,3 },
                new int[]{1,4 },
                new int[]{2,5 },
                new int[]{2,6 }
            });//7
        }
    }
}
