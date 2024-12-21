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
        }
    }
}
