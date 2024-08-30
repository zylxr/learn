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

            var findProductsOfElementsClass = new FindProductsOfElementsClass();
            var findProductsOfElementsResult = findProductsOfElementsClass.FindProductsOfElements(
                new long[][] { new long[] { 1,3,7} }
                );//[4]

            var getImportanceClass = new GetImportanceClass();
            var getImportanceResult = getImportanceClass.GetImportance(new List<Employee> { new Employee { Id =1, 
                Importance=5,
                SubOrdinates = new List<int>{ 2,3}
            } ,
                new Employee{ Id= 2, Importance = 3,SubOrdinates = new List<int>() },
                new Employee{ Id= 3, Importance=3 ,SubOrdinates = new List<int>()}
            },1);//11

            getImportanceResult = getImportanceClass.GetImportanceByBFS(new List<Employee> { new Employee { Id =1,
                Importance=5,
                SubOrdinates = new List<int>{ 2,3}
            } ,
                new Employee{ Id= 2, Importance = 3,SubOrdinates = new List<int>() },
                new Employee{ Id= 3, Importance=3 ,SubOrdinates = new List<int>()}
            }, 1);//11

            var medianOfUniqueneseArray = new MedianOfUniquenessArrayClass();
            var medianOfUniqueneseResult = medianOfUniqueneseArray.MedianOfUniquenessArray(new int[] { 1,2,3});//1

            var minimumSubStringInPartition = new MinimumSubstringsInPartitionClass();
            var minimumSubStringInPartitionResult = minimumSubStringInPartition.MinimumSubstringsInPartition("fabccddg");//3:"fab, "ccdd", "g") 或者 ("fabc", "cd", "dg") 

            var sumDigitDiffClass = new SumDigitDifferencesClass();
            var sumDigitDiffResult = sumDigitDiffClass.SumDigitDifferences(new int[] {12,23,12});//4
            GetPrime();
        }

        public static void GetPrime()
        {
            var visited = new bool[1005];
            visited[0] = visited[1]= true;
            var tot = 0;
            var p = new int[1005];
            for(var i=2;i<1005;i++)
            {
                if(!visited[i])
                {
                    p[++tot] = i;
                }
                for (var j = 1; j <= tot && i * p[j] < 1005; j++)
                {
                    visited[i * p[j]] = true;
                    if (i % p[j] == 0) break;
                }
            }

        }
    }
}
