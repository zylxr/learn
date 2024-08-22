using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunDailyPartialAugust
    {
        public static void Run()
        {
            var magicDict = new MagicDictionaryClass();
            magicDict.BuildDict(new string[] { "hello", "leetcode" });
            var magicDictResult = magicDict.Search("hello");//false
            magicDictResult = magicDict.Search("hhllo");//true
            magicDictResult = magicDict.Search("hell");//false
            magicDictResult = magicDict.Search("leetcoded");//false

            //使用字典树方法
            magicDict.BuildDict2(new string[] { "hello", "leetcode" });
            magicDictResult = magicDict.Search2("hello");//false
            magicDictResult = magicDict.Search2("hhllo");//true
            magicDictResult = magicDict.Search2("hell");//false
            magicDictResult = magicDict.Search2("leetcoded");//false

            var isArraySpecialClass = new IsArraySpecialClass();
            var isArraySpecialResult = isArraySpecialClass.IsArraySpecial(new int[] { 3, 4, 1, 2, 6 }, new int[][] { new int[] { 0, 4 } });//[false]

            isArraySpecialResult = isArraySpecialClass.IsArraySpecial(new int[] { 4, 3, 1, 6 }, new int[][] { new int[] { 0, 2 },new int[] { 2, 3 } });//[false,true]

            var maxScoreClass = new MaxScoreClass2();
            var grid = new int[][] { 
                new int[]{ 9, 5, 7, 3 },
                new int[]{ 8, 9, 6, 1 },
                new int[]{ 6,7,14,3 },
                new int[]{ 2, 5, 3, 1 }
            };
            var maxScoreResult = maxScoreClass.MaxScore1(grid);//9
            maxScoreResult = maxScoreClass.MaxScore2(grid);//9
            maxScoreResult = maxScoreClass.MaxScore3(grid);//9
            maxScoreResult = maxScoreClass.MaxScore4(grid);//9

            var minimumValuesSumClass = new MinimumValueSumClass();
            var minimuValuesSumResult = minimumValuesSumClass.MinimumValueSum(new int[] { 1, 4, 3, 3, 2 },new int[] { 0, 3, 3, 2 });//12

            var minimumoperationsToMakePeriodicClass = new MinimumOperationsToMakeKPeriodicClass();
            var minimumoperationToMakePeriodicResult = minimumoperationsToMakePeriodicClass.MinimumOperationsToMakeKPeriodic("leetcodeleet",4);//1
       
            var checkRecordClass = new CheckRecordClass();
            var checkRecordResult = checkRecordClass.CheckRecord(2);//8
            checkRecordResult = checkRecordClass.CheckRecord1(2);//8
            checkRecordResult = checkRecordClass.CheckRecord2(2);//8

            var waysToReachStair = new WaysToReachStairClass();
            var waysToreachStairResult = waysToReachStair.WaysToReachStair(0);//2

            var hs = new HashSet<int>();
            hs.Add(5);
            hs.Add(1);
            var findMaximuNumberClass = new FindMaximumNumberClass();
            var findMaximuNumberResult = findMaximuNumberClass.FindMaximumNumber(9, 1);//6

            var minEndClass = new MinEndClass();
            var minEndResult = minEndClass.MinEnd(3,4);//6
        }
    }
}
