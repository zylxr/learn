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

            var maxSpendingClass = new MaxSpendingClass();
            var maxSpendingResult = maxSpendingClass.MaxSpending(
                new int[][] {
                    new int[]{ 8, 5, 2 },
                    new int[]{ 6,4,1 },
                    new int[]{ 9,7,3 },
                }
                );//285

            var closestRoomClass = new ClosestRoomClass();
            var closestRoomResult = closestRoomClass.ClosestRoom(new int[][] {
                new int[]{ 2,2},
                new int[]{ 1,2},
                new int[]{ 3,2},
            },
            new int[][] {
                new int[]{3,1 },
                new int[]{3,3},
                new int[]{5,2 }
            });//[3,-1,3]

            var minValidStringClass = new MinValidStringsClass();
            var minValidStringResult = minValidStringClass.MinValidStrings(new string[] { "abc","aaaaa","bcdef" }, "aabcdabc");//3

            var minValidStringClass2 = new MinValidStringsClass2();
            var minValidStringResult2 = minValidStringClass2.MinValidStrings(new string[] { "abc", "aaaaa", "bcdef" }, "aabcdabc");//3
        
            var minAnagramLength = new MinAnagramLengthClass();
            var minAnagramLengthResult = minAnagramLength.MinAnagramLength("abba");//2

            var sortTheStudentClass = new SortTheStudentsClass();
            var sortTheStudentResult = sortTheStudentClass.SortTheStudents(new int[][] { 
                new int[]{ 10, 6, 9, 1 },
                new int[]{ 7,5,11,2 },
                new int[]{ 4,8,3,15 }
            },2); // [[7,5,11,2],[10,6,9,1],[4,8,3,15]]

            var examRoomClass = new ExamRoomClass(10);
            examRoomClass.Seat();//0
            examRoomClass.Seat();//9
            examRoomClass.Seat();//4
            examRoomClass.Seat();//2
            examRoomClass.Leave(4);
            examRoomClass.Seat();//5

            var eatenAppleClass = new EatenApplesClass();
            var eatenAppleResult = eatenAppleClass.EatenApples(new int[] { 1, 2, 3, 5, 2 },new int[]{ 3, 2, 1, 4, 2 });//7

            var minimumCostClass = new MinimumCostClass();
            var minimumCostResult = minimumCostClass.MinimumCost(
                3,2,new int[] { 1,3},new int[] { 5 }
                );//13

            var occurrencesOfElementClass = new OccurrencesOfElementClass();
            var occurrencesOfElementResult = occurrencesOfElementClass.OccurrencesOfElement(
                new int[] { 1,3,1,7},
                new int[] {1,3,2,4 },1);//[0,-1,2,-1]

            var isSubPathClass = new IsSubPathClass();
            var isSubPathResult = isSubPathClass.IsSubPath(
                new IsSubPathClass.ListNode(4,
                    new IsSubPathClass.ListNode(2,
                        new IsSubPathClass.ListNode(8)
                    )
                ),
                new IsSubPathClass.TreeNode
                {
                    val = 1,
                    left = new IsSubPathClass.TreeNode
                    {
                        val = 4,
                        right = new IsSubPathClass.TreeNode
                        {
                            val = 2,
                            left = new IsSubPathClass.TreeNode
                            {
                                val = 1
                            }
                        }
                    },
                    right = new IsSubPathClass.TreeNode
                    {
                        val = 4,
                        left = new IsSubPathClass.TreeNode
                        {
                            val = 2,
                            left = new IsSubPathClass.TreeNode
                            {
                                val = 6
                            },
                            right = new IsSubPathClass.TreeNode
                            {
                                val = 8,
                                left = new IsSubPathClass.TreeNode
                                {
                                    val = 1
                                },
                                right = new IsSubPathClass.TreeNode
                                {
                                    val = 3
                                }
                            }
                        }
                    }
                }
                 );// true
        }
    }
}
