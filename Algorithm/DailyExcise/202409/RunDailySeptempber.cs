using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunDailySeptempber
    {
        public static void Run()
        {
            var maxConsecutiveAnswerClass = new MaxConsecutiveAnswersClass();
            var maxConsecutiveAnswerResult = maxConsecutiveAnswerClass.MaxConsecutiveAnswers("TTFF",2);//4

            var maxStrengthClass = new MaxStrengthClass();
            var maxStrengthResult = maxStrengthClass.MaxStrength(new int[] { 3, -1, -5, 2, 5, -9 });//1350
            maxStrengthResult = maxStrengthClass.MaxStrength1(new int[] { 3, -1, -5, 2, 5, -9 });//1350

            var countWayClass = new CountWaysClass();
            var countWayResult = countWayClass.CountWays(new List<int> { 1,1});//2

            var clearDigitsClass = new ClearDigitsClass();
            var clearDigitsResult = clearDigitsClass.ClearDigits("ag3");//"a"

            clearDigitsResult = clearDigitsClass.ClearDigits("cb34");//""

            var maximumLengthClass2 = new MaximumLengthClass2();
            var maximumLengthResult = maximumLengthClass2.MaximumLength(new int[] { 1, 2, 1, 1, 3 },2);//4

            maximumLengthResult = maximumLengthClass2.MaximumLengthOptimize(new int[] { 1, 2, 1, 1, 3 }, 2);//4

            var mergeNodeClass = new MergeNodesClass();
            var mergeNodeResult = mergeNodeClass.MergeNodes(
                new ListNode { 
                    Val =0,
                    Next = new ListNode { 
                        Val = 3,
                        Next = new ListNode
                        {
                            Val = 1,
                            Next = new ListNode
                            {
                                Val = 0,
                                Next = new ListNode
                                {
                                    Val = 4,
                                    Next = new ListNode
                                    {
                                        Val = 5,
                                        Next = new ListNode
                                        {
                                            Val = 2,
                                            Next = new ListNode
                                            {
                                                Val = 0
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                );//[4,11]

            var countQuadruplets = new CountQuadrupletsClass();
            var countQuadRupletResult = countQuadruplets.CountQuadruplets(new int[] { 1,3,2,4,5});//2

            var maximizeWinClass = new MaximizeWinClass();
            var maximizeWinResult = maximizeWinClass.MaximizeWin(new int[] { 1, 1, 2, 2, 3, 3, 5 },2); //7

            maximizeWinResult = maximizeWinClass.MaximizeWin(new int[] { 1, 2, 3, 4 }, 0);//2

            maximizeWinResult = maximizeWinClass.MaximizeWin2(new int[] { 1, 2, 3, 4 }, 0);//2

            var maxNumOfMarketIndicesClass = new MaxNumOfMarkedIndicesClass();
            var maxNumOfMarketIndicesResult = maxNumOfMarketIndicesClass.MaxNumOfMarkedIndices(new int[] { 9, 2, 5, 4 });//4
            maxNumOfMarketIndicesResult = maxNumOfMarketIndicesClass.MaxNumOfMarketIndices2(new int[] { 9,2,5,4});//4

            var maximumRobotClass = new MaximumRobotsClass();
            var maximumRobotResult = maximumRobotClass.MaximumRobots(new int[] { 3, 6, 1, 3, 4 },new int[] { 2, 1, 3, 4, 5 },25);//3
        
            var removeStarsClass = new RemoveStarsClass();
            var removeStarsResult = removeStarsClass.RemoveStars("leet**cod*e");//lecoe
        }
    }
}
