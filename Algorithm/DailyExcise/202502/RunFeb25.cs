using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunFeb25
    {
        public static void Run()
        {
            var validPalindromeClass = new ValidPalindromeClass();
            var validPalindrome = validPalindromeClass.ValidPalindrome("abca");//true

            var subsetsWithDupClass = new SubsetsWithDupClass();
            var subsetsWithDup = subsetsWithDupClass.SubsetsWithDup(new int[] { 1, 2, 2 });//[[],[1],[1,2],[1,2,2],[2],[2,2]]
            subsetsWithDup = subsetsWithDupClass.SubsetsWithDup(new int[] { 1,1 });//[[],[1],[1,1]]

            subsetsWithDup = subsetsWithDupClass.SubsetsWithDup2(new int[] { 1, 1 });//[[],[1],[1,1]]

            var permuteUniqueClass = new PermuteUniqueClass();
            var permuteUnique = permuteUniqueClass.PermuteUnique(new int[] { 1, 1, 2 });//[[1,1,2],[1,2,1],[2,1,1]]

            var generateMatrixClass = new GenerateMatrixClass();
            var generateMatrix = generateMatrixClass.GenerateMatrix(3);//[[1,2,3],[8,9,4],[7,6,5]]

            generateMatrix = generateMatrixClass.GenerateMatrix2(3);//[[1,2,3],[8,9,4],[7,6,5]]

            var uniquePathsWithObstaclesClass = new UniquePathsWithObstaclesClass();
            var uniquePathsWithObstacles = uniquePathsWithObstaclesClass.UniquePathsWithObstacles(new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 0 }, new int[] { 0, 0, 0 } });//2
            uniquePathsWithObstacles = uniquePathsWithObstaclesClass.UniquePathsWithObstacles(new int[][] { new int[] { 0, 0 } });//1
            
            uniquePathsWithObstacles = uniquePathsWithObstaclesClass.UniquePathsWithObstacles2(new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 0 }, new int[] { 0, 0, 0 } });//2
        
            var catMouseGameClass = new CatMouseGameClass();
            var catMouseGame = catMouseGameClass.CatMouseGame(new int[][] { new int[] { 2, 5 }, new int[] { 3 }, new int[] { 0, 4, 5 }, new int[] { 1, 4, 5 }, new int[] { 2, 3 }, new int[] { 0, 2, 3 } });//0

            catMouseGame = catMouseGameClass.CatMouseGame2(new int[][] { new int[] { 2, 5 }, new int[] { 3 }, new int[] { 0, 4, 5 }, new int[] { 1, 4, 5 }, new int[] { 2, 3 }, new int[] { 0, 2, 3 } });//0
        
            var canMouseWinClass = new CanMouseWinClass();
            var canMouseWinClassResult = canMouseWinClass.CanMouseWin(new string[] { "####F", "#C...", "M...." },1,2);//true
        
            var minimumSizeClass = new MinimumSizeClass();
            var minimumSizeResult = minimumSizeClass.MinimumSize(new int[] {9 },2);//3
            minimumSizeResult = minimumSizeClass.MinimumSize(new int[] {7,17 }, 2);//7
            minimumSizeResult = minimumSizeClass.MinimumSize(new int[] {9 }, 200);//1

            var maxDistanceClass = new MaxDistanceClass();
            var maxDistanceResult = maxDistanceClass.MaxDistance(new int[] {1,2,3,4,7 }, 3);//3

            var findBallClass = new FindBallClass();
            var findBallResult = findBallClass.FindBall(new int[][] { new int[] { -1 } });//[-1]

            findBallResult = findBallClass.FindBall(new int[][] {
                new int[] {1,1,1,1,1,1            },
                new int[] { -1,-1,-1,-1,-1,-1 },
                new int[] { 1,1,1,1,1,1 },
                new int[] { -1, -1, -1, -1, -1, -1 }
            });//[0,1,2,3,4,-1]

            findBallResult = findBallClass.FindBall2(new int[][] {
                new int[] {1,1,1,1,1,1            },
                new int[] { -1,-1,-1,-1,-1,-1 },
                new int[] { 1,1,1,1,1,1 },
                new int[] { -1, -1, -1, -1, -1, -1 }
            });//[0,1,2,3,4,-1]

            var findSpecialIntegerClass = new FindSpecialIntegerClass();
            var findSpecialIntegerResult = findSpecialIntegerClass.FindSpecialInteger(new int[] { 1, 2, 2, 6, 6, 6, 6, 7, 10 });//6
            findSpecialIntegerResult = findSpecialIntegerClass.FindSpecialInteger(new int[] { 1,2,3,3});//3

            var rangeFreqQueryClass = new RangeFreqQueryClass(new int[] { 12, 33, 4, 56, 22, 2, 34, 33, 22, 12, 34, 56 });
            var rangeFreqQueryResult = rangeFreqQueryClass.Query(1,2,4); // 1
            rangeFreqQueryResult = rangeFreqQueryClass.Query(0,11,33);//2

            var maxDistanceClass2 =  new MaxDistanceClass2();
            var maxDistanceClassResult = maxDistanceClass2.MaxDistance(new List<IList<int>> { 
                new List<int>{ 1, 2, 3 },
                new List<int>{ 4,5 },
                new List<int>{ 1, 2, 3 }
            });//4

            var evenOddBitClass = new EvenOddBitClass();
            var evenOddBitResult = evenOddBitClass.EvenOddBit(50);//[1,2]

            var minimumWhiteTileClass = new MinimumWhiteTilesClass();
            var minimumWhiteTileResult = minimumWhiteTileClass.MinimumWhiteTiles("10110101",2,2);//2
            minimumWhiteTileResult = minimumWhiteTileClass.MinimumWhiteTiles2("10110101", 2, 2);//2

            var similarPairClass = new SimilarPairsClass();
            var similarPairResult = similarPairClass.SimilarPairs(
                new string[] { "aba", "aabb", "abcd", "bac", "aabc" }
                );//2
            similarPairResult = similarPairClass.SimilarPairs2(
                new string[] { "aba", "aabb", "abcd", "bac", "aabc" }
                );//2
        }
    }
}
