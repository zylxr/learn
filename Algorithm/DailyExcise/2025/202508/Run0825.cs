using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class Run0825
    {
        public static void Run()
        {
            var minCostClass3 = new MinCostClass3();
            var minCostClass3Result = minCostClass3.MinCost(new int[] { 4, 2, 2, 2 },new int[] { 1, 4, 1, 2 });//1

            var totalFruitClass = new TotalFruitClass();
            var totalFruitClassResult = totalFruitClass.TotalFruit(new int[] { 1,0,1,4,1,4,1,2,3});//5

            var numOfUnplaceFruitClass = new NumOfUnplacedFruitsClass();
            var numOfUnplaceFruitClassResult = numOfUnplaceFruitClass.NumOfUnplacedFruits(new int[] { 4,2,5},new int[] { 3,5,4} );//1
            numOfUnplaceFruitClassResult = numOfUnplaceFruitClass.NumOfUnplacedFruits2(new int[] { 4, 2, 5 }, new int[] { 3, 5, 4 });//1

            var maxCollectionFruitsClass = new MaxCollectedFruitsClass();
            var maxCollectionFruitsClassResult = maxCollectionFruitsClass.MaxCollectedFruits(new int[][] { 
                new int[] { 1,2,3,4 },
                new int[] { 5,6,8,7 },
                new int[] { 9,10,11,12 },
                new int[] { 13,14,15,16 }
            });//100

            var soupServingClass = new SoupServingsClass();
            var soupServingClassResult = soupServingClass.SoupServings(50);//0.6250

            soupServingClassResult = soupServingClass.SoupServings2(50);//0.6250

            var  productQueriesClass = new ProductQueriesClass();
            var productQueriesClassResult = productQueriesClass.ProductQueries(15,new int[][] {
                new int[]{ 0,1 },
                new int[]{ 2,2 },
                new int[]{ 0,3}
            });//[2,4,64]

            var numberOfWaysClass = new NumberOfWaysClass();
            var numberOfWaysClassResult = numberOfWaysClass.NumberOfWays(10,2);//1
            numberOfWaysClassResult = numberOfWaysClass.NumberOfWays2(10, 2);//1

            var isPowerOfFourClass = new IsPowerOfFourClass();
            var isPowerOfFourClassResult = isPowerOfFourClass.IsPowerOfFour(16);//true

            isPowerOfFourClassResult = isPowerOfFourClass.IsPowerOfFour2(16);//true

            var judgePoint24Class = new JudgePoint24Class();
            var judgePoint24ClassResult = judgePoint24Class.JudgePoint24(new int[] { 4,1,8,7});//true

            var zeroFilledSubArrayClass = new ZeroFilledSubarrayClass();
            var zeroFilledSubArrayClassResult = zeroFilledSubArrayClass.ZeroFilledSubarray(new int[] { 1, 3, 0, 0, 2, 0, 0, 4 });//6

            var countSquareClass = new CountSquaresClass();
            var countSquareClassResult = countSquareClass.CountSquares(new int[][] {
                new int[]{ 0, 1, 1, 1},
                new int[]{1,1,1,1},
                new int[]{ 0,1,1,1}
            });//15

            var numSubMatClass = new NumSubmatClass();
            var numSubMatClassResult = numSubMatClass.NumSubmat(new int[][] {
                new int[]{ 1, 0, 1 },
                new int[]{ 1,1,0 },
                new int[]{ 1,1,0 }
            });//13

            numSubMatClassResult = numSubMatClass.NumSubmat(new int[][] {
                new int[]{ 0,1,1,0 },
                new int[]{0,1,1,1},
                new int[]{ 1,1,1,0}
            });//24

            numSubMatClassResult = numSubMatClass.NumSubmat2(new int[][] {
                new int[]{ 0,1,1,0 },
                new int[]{0,1,1,1},
                new int[]{ 1,1,1,0}
            });//24

            var minimuAreaClass = new MinimumAreaClass();
            var minimumAreaClassResult = minimuAreaClass.MinimumArea(new int[][] {
                new int[] { 0,1,0 },
                new int[] { 1,0,1 }
            });//6

            minimumAreaClassResult = minimuAreaClass.MinimumArea(new int[][] {
                new int[] { 0 },
                new int[] { 1 }
            });//1

            minimumAreaClassResult = minimuAreaClass.MinimumArea(new int[][] {
                new int[] { 0,0,0 },
                new int[] { 0, 0, 0 },
                new int[] { 0, 0,0 },
                new int[] { 0, 0,1 }
            });//1

            var minimumSumClass = new MinimumSumClass();
            var minimumSumClassResult = minimumSumClass.MinimumSum(
                new int[][] { 
                    new int[] { 1, 0, 1 },
                    new int[] { 1, 1,1 }
                });//5

            var findDiagonalOrderClass = new FindDiagonalOrderClass();
            var findDiagonalOrderClassResult = findDiagonalOrderClass.FindDiagonalOrder(new int[][] {
                new int[]{ 1, 2, 3 },
                new int[]{ 4, 5, 6 },
                new int[]{ 7, 8, 9 }
            });//[1,2,4,7,5,3,6,8,9]

            findDiagonalOrderClassResult = findDiagonalOrderClass.FindDiagonalOrder2(new int[][] {
                new int[]{ 1, 2, 3 },
                new int[]{ 4, 5, 6 },
                new int[]{ 7, 8, 9 }
            });//[1,2,4,7,5,3,6,8,9]

            var lenOfVDiagonalClass = new LenOfVDiagonalClass();
            var lenOfVDiagonalClassResult = lenOfVDiagonalClass.LenOfVDiagonal(
                new int[][] {
                    new int[]{ 2,2,1,2,2},
                    new int[]{2,0,2,2,0 },
                    new int[]{ 2,0,1,1,0},
                    new int[]{ 1,0,2,2,2},
                    new int[]{ 2,0,0,2,2}

                }
                );//5

            var sortMatrixClass = new SortMatrixClass();
            var sortMatrixClassResult = sortMatrixClass.SortMatrix(new int[][] { 
                new int[]{ 1,7,3},
                new int[]{ 9,8,2},
                new int[]{ 4, 5, 6 }
            });//[[8,2,3],[9,6,7],[4,5,1]]

            sortMatrixClassResult = sortMatrixClass.SortMatrix2(new int[][] {
                new int[]{ 1,7,3},
                new int[]{ 9,8,2},
                new int[]{ 4, 5, 6 }
            });//[[8,2,3],[9,6,7],[4,5,1]]

            var flowerGameClass = new FlowerGameClass();
            var flowerGameClassResult = flowerGameClass.FlowerGame(3,2);//3

            var isValidSudokuClass = new IsValidSudokuClass();
            var isValidSudokuClassResult = isValidSudokuClass.IsValidSudoku(new char[][] {
                new char[]{'5','3','.','.','7','.','.','.','.' },
                new char[]{ '6','.','.','1','9','5','.','.','.'},
                new char[]{'.','9','8','.','.','.','.','6','.' },
                new char[]{ '8','.','.','.','6','.','.','.','3'},
                new char[]{ '4','.','.','8','.','3','.','.','1'},
                new char[]{'7','.','.','.','2','.','.','.','6' },
                new char[]{'.','6','.','.','.','.','2','8','.' },
                new char[]{ '.','.','.','4','1','9','.','.','5'},
                new char[]{ '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            });//true

            isValidSudokuClassResult = isValidSudokuClass.IsValidSudoku(new char[][] {
                new char[]{'.','.','4','.','.','.','6','3','.' },
                new char[]{ '.','.','.','.','.','.','.','.','.'},
                new char[]{'5','.','.','.','.','.','.','9','.' },
                new char[]{ '.','.','.','5','6','.','.','.','.'},
                new char[]{'4','.','3','.','.','.','.','.','1'},
                new char[]{'.','.','.','7','.','.','.','.','.' },
                new char[]{'.','.','.','5','.','.','.','.','.' },
                new char[]{'.','.','.','.','.','.','.','.','.'},
                new char[]{ '.', '.', '.', '.', '.', '.', '.', '.', '.' }
            });//false

            isValidSudokuClassResult = isValidSudokuClass.IsValidSudoku2(new char[][] {
                new char[]{'.','.','4','.','.','.','6','3','.' },
                new char[]{ '.','.','.','.','.','.','.','.','.'},
                new char[]{'5','.','.','.','.','.','.','9','.' },
                new char[]{ '.','.','.','5','6','.','.','.','.'},
                new char[]{'4','.','3','.','.','.','.','.','1'},
                new char[]{'.','.','.','7','.','.','.','.','.' },
                new char[]{'.','.','.','5','.','.','.','.','.' },
                new char[]{'.','.','.','.','.','.','.','.','.'},
                new char[]{ '.', '.', '.', '.', '.', '.', '.', '.', '.' }
            });//false
        }
    }
}
