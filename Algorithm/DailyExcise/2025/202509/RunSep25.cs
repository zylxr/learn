using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunSep25
    {
        public static void Run()
        {
            var maxAverageRatioClass = new MaxAverageRatioClass();
            var maxAverageRatioClassResult = maxAverageRatioClass.MaxAverageRatio(new int[][]
            {
                new int[] {1,2 },
                new int[] {3,5},
                new int[] {2,2}
            }, 2);//0.78333

            maxAverageRatioClassResult = maxAverageRatioClass.MaxAverageRatio2(new int[][]
            {
                new int[] {1,2 },
                new int[] {3,5},
                new int[] {2,2}
            }, 2);//0.78333

            maxAverageRatioClassResult = maxAverageRatioClass.MaxAverageRatio2(new int[][]
            {
                new int[] {2,4 },
                new int[] {3,9},
                new int[] { 4, 5 },
                new int[] { 2, 10 }
            }, 4);//0.53485

            //maxAverageRatioClassResult = maxAverageRatioClass.MaxAverageRatio(new int[][]
            //{
            //    new int[] {2,4 },
            //    new int[] {3,9},
            //    new int[] { 4, 5 },
            //    new int[] { 2, 10 }
            //}, 4);//0.53485

            var numberOfPairsClass2 = new NumberOfPairsClass2();
            var numberOfPairsClass2Result = numberOfPairsClass2.NumberOfPairs(
                new int[][] {
                    new int[]{ 0,1},
                    new int[]{1,3 },
                    new int[]{6,1}
                }
                );//2

            numberOfPairsClass2Result = numberOfPairsClass2.NumberOfPairs(
                new int[][] {
                    new int[]{ 0,2},
                    new int[]{5,1 },
                    new int[]{5,6}
                }
                );//2

            numberOfPairsClass2Result = numberOfPairsClass2.NumberOfPairs(
                new int[][] {
                    new int[]{ 6,2},
                    new int[]{4,4 },
                    new int[]{2,6}
                }
                );//2
            var numberOfPairsClass3 = new NumberOfPairsClass3();
            var numberOfPairsClass3Result = numberOfPairsClass3.NumberOfPairs(new int[][] { 
                new int[]{1,1 },
                new int[]{2,2},
                new int[]{3,3},
            });//0

            numberOfPairsClass3Result = numberOfPairsClass3.NumberOfPairs2(new int[][] {
                new int[]{1,1 },
                new int[]{2,2},
                new int[]{3,3},
            });//0

            var makeTheIntegerZeroClass = new MakeTheIntegerZeroClass();
            var makeTheIntegerZeroClassResult = makeTheIntegerZeroClass.MakeTheIntegerZero(3,-2);//3

            var minOperationsClass = new MinOperationsClass3();
            var minOperationsClassResult = minOperationsClass.MinOperations(new int[][] { 
                new int[]{3,10 }
            });//8

            minOperationsClassResult = minOperationsClass.MinOperations(new int[][] {
                new int[]{6,8 }
            });//3

            minOperationsClassResult = minOperationsClass.MinOperations(new int[][] {
                new int[]{19,23 }
            });//8

            minOperationsClassResult = minOperationsClass.MinOperations2(new int[][] {
                new int[]{19,23 }
            });//8

            var peopleAwareClass = new PeopleAwareOfSecretClass();
            var peopleAwareClassResult = peopleAwareClass.PeopleAwareOfSecret(6,2,4);//5
            peopleAwareClassResult = peopleAwareClass.PeopleAwareOfSecret2(6, 2, 4);//5

            var minimumTeachingClass = new MinimumTeachingsClass();
            var minimumTeachingClassResult = minimumTeachingClass.MinimumTeachings(
                3,new int[][] { new int[] { 2},new int[] { 1,3},new int[] { 1,2},new int[] { 3} },
                new int[][] { new int[] { 1, 4 }, new int[] { 1,2},new int[] { 3,4},new int[] { 2,3} }
                );//2

            var sortVowelsClass = new SortVowelsClass();
            var sortVowelsClassResult = sortVowelsClass.SortVowels("lEetcOde");//lEOtcede
            sortVowelsClassResult = sortVowelsClass.SortVowels2("lEetcOde");//lEOtcede
            sortVowelsClassResult = sortVowelsClass.SortVowels3("lEetcOde");//lEOtcede

            var doesAliceWinClass = new DoesAliceWinClass();
            var doesAliceWinClassResult = doesAliceWinClass.DoesAliceWin("leetcoder");//true

            var replaceNonCoprimeClass = new ReplaceNonCoprimesClass();
            var replaceNonComprimeClassResult = replaceNonCoprimeClass.ReplaceNonCoprimes(new int[] { 6, 4, 3, 2, 7, 6, 2 });//[12,7,6]

            var numberContainersClass = new NumberContainersClass();
            var numberContainersClassResult = numberContainersClass.Find(10);//-1;
            numberContainersClass.Change(2, 10);
            numberContainersClass.Change(1, 10);
            numberContainersClass.Change(3, 10);
            numberContainersClass.Change(5, 10);
            numberContainersClassResult = numberContainersClass.Find(10);//1
            numberContainersClass.Change(1, 20);
            numberContainersClassResult = numberContainersClass.Find(10);//2

            numberContainersClass = new NumberContainersClass();
            numberContainersClass.Change(1, 10);
            numberContainersClass.Change(1, 20);
            numberContainersClassResult = numberContainersClass.Find(10);//-1


            var numberContainersClass1 = new NumberContainersClass();
            var numberContainersClassResult1 = numberContainersClass1.Find2(10);//-1;
            numberContainersClass1.Change2(2, 10);
            numberContainersClass1.Change2(1, 10);
            numberContainersClass1.Change2(3, 10);
            numberContainersClass1.Change2(5, 10);
            numberContainersClassResult1 = numberContainersClass1.Find2(10);//1
            numberContainersClass1.Change2(1, 20);
            numberContainersClassResult1 = numberContainersClass1.Find2(10);//2

            numberContainersClass1 = new NumberContainersClass();
            numberContainersClass1.Change2(1, 10);
            numberContainersClass1.Change2(1, 20);
            numberContainersClassResult1 = numberContainersClass1.Find2(10);//-1

            var taskManagerClass = new TaskManagerClass(new List<IList<int>> {
                new List<int>{ 1,101,8},
                new List<int>{ 2, 102, 20 },
                new List<int>{ 3, 103, 5 }
            });
            taskManagerClass.Add(4, 104, 5);
            taskManagerClass.Edit(102, 9);
            var taskManagerClassResult = taskManagerClass.ExecTop();//2
            taskManagerClass.Rmv(101);
            taskManagerClass.Add(50, 101, 8);
            taskManagerClassResult = taskManagerClass.ExecTop();//50

            var routerClass = new RouterClass(2);
            var routerClassAddResult = routerClass.AddPacket(2, 5, 1);//true
            var forwardResult = routerClass.ForwardPacket();//2,5,1
            var routerClassGetResult = routerClass.GetCount(5, 1, 1);//0
        }
    }
}
