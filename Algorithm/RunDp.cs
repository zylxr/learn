using Algorithm.dp;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class RunDp
    {
        public static void RunDP()
        {
            var questions = new int[][] {
                new int[]{3,2 },
                new int[]{4,3},
                new int[]{4,4 },
                new int[]{2,5}
            };
            var mostPointsClass = new MostPointsClass();
            var mostPointsResult = mostPointsClass.MostPointsLessEffiency(questions);//5
            mostPointsResult = mostPointsClass.MostPoints(questions);//5

            questions = new int[][]
            {
                new int[]{1,1 },
                new int[]{2,2},
                new int[]{3,3},
                new int[]{4,4},
                new int[]{5,5}
            };
            mostPointsResult = mostPointsClass.MostPoints(questions);//7

            questions = new int[][]
            {
                new int[]{12,46},
                new int[]{78,19},
                new int[]{63,15},
                new int[]{79,62},
                new int[]{13,10}
            };
            mostPointsResult = mostPointsClass.MostPoints(questions);//79

            //mostPointsResult = mostPointsClass.MostPoints(testdata.QuestionData.GetQuestions());


            var climbStairClass = new ClimbStairsClass();
            var climbStairsResult = climbStairClass.ClimbStairs(2);//2

            var fibClass = new FibClass();
            var fibClassResult = fibClass.Fib(3);//2

            var tribonacciClass = new TribonacciClass();
            var tribonacciResult = tribonacciClass.Tribonacci(4);//4

            var cost = new int[] { 10, 15, 20 };
            var minCostClimbingStairsClass = new MinCostClimbingStairsClass();
            var minCostClimbingStairsResult = minCostClimbingStairsClass.MinCostClimbingStairs(cost);//15

            cost = new int[] { 1, 0, 0, 1 };
            minCostClimbingStairsResult = minCostClimbingStairsClass.MinCostClimbingStairs(cost);//0

            var nums = new int[] { 1, 2, 3, 1 };
            var robClass = new RobClass();
            var robClassResult = robClass.Rob(nums);//4
            robClassResult = robClass.RobOptimize(nums);//4
            robClassResult = robClass.RobOptimize2(nums);//4
            nums = new int[] { 2, 7, 9, 3, 1 };
            robClassResult = robClass.Rob(nums);//12
            robClassResult = robClass.RobOptimize(nums);// 12
            robClassResult = robClass.RobOptimize2(nums);

            var points = new int[] { 3, 4, 2 };
            var deleteAndEarnClass = new DeleteAndEarnClass();
            var deleteAndEarnResult = deleteAndEarnClass.DeleteAndEarn(points);//6

            points = new int[] { 2, 4, 6 };
            deleteAndEarnResult = deleteAndEarnClass.DeleteAndEarn(points);//12

            var uniquePathsClass = new UniquePathsClass();
            var uniquePathsResult = uniquePathsClass.UniquePaths(3, 7);//28
            uniquePathsResult = uniquePathsClass.UniquePathsOptimize1(3, 7);//28

            var grid = new int[][] {
                new int[]{1,3,1 },
                new int[]{1,5,1},
                new int[] {4,2,1 }
            };
            var minPathSumClass = new MinPathSumClass();
            var minPathSumResult = minPathSumClass.MinPathSum(grid);//7

            var objstacleGrid = new int[][] {
                new int[] {0,0,0 },
                new int[] {0,1,0},
                new int[] {0,0,0}
            };
            var uniquePathsWithObstacleClass = new UniquePathsWithObstaclesClass();
            var uniquePathsWithObstacleResult = uniquePathsWithObstacleClass.UniquePathsWithObstacles(objstacleGrid);//2
            uniquePathsWithObstacleResult = uniquePathsWithObstacleClass.UniquePathsWithObstaclesOptimize(objstacleGrid);//2

            var triangle = new List<List<int>> {
                new List<int> {2},
                new List<int> {3,4},
                new List<int> {6,5,7},
                new List<int> {4,1,8,3},
            };
            var minimumTotalClass = new MinimumTotalClass();
            var minimumTotalResult = minimumTotalClass.MinimumTotal1(triangle); //11

            minimumTotalResult = minimumTotalClass.MinimumTotal(triangle); //11

            triangle = new List<List<int>> {
                new List<int>{-1 },
                new List<int> {-2,-3},
            };
            minimumTotalResult = minimumTotalClass.MinimumTotal1(triangle);//-4

            var matrix = new int[][] {
                new int[]{ 2,1,3},
                new int[]{6,5,4},
                new int[]{7,8,9}
            };
            var minFallingPathSumClass = new MinFallingPathSumClass();
            var minFallingPathSumResult = minFallingPathSumClass.MinFallingPathSum(matrix); //13

            var charMatrix = new char[][] {
                new char[] { '1','0','1','0','0'},
                new char[] { '1','0','1','1','1'},
                new char[] {'1','1','1','1','1'},
                new char[] { '1', '0', '0', '1', '0' }
            };
            var maximalSquareClass = new MaximalSquareClass();
            var maximalSquareResult = maximalSquareClass.MaximalSquare(charMatrix);//4

            var s = "babad";
            var longestPalindromeClass = new LongestPalindromeClass();
            var longestPalindromeResult = longestPalindromeClass.LongestPalindrome(s);//3
            longestPalindromeResult = longestPalindromeClass.LongestPalinromeCenter(s);//3


            s = "cbbd";
            longestPalindromeResult = longestPalindromeClass.LongestPalindrome(s);//2 bb
            longestPalindromeResult = longestPalindromeClass.LongestPalinromeCenter(s);//2 bb
            var longestPalindromeResultAddtionaltest = longestPalindromeClass.LongestPalindrome2(s);//2

            s = "babad";
            longestPalindromeResult = longestPalindromeClass.LongestPalinromeCenter(s);//3 bab
            longestPalindromeResult = longestPalindromeClass.PalindromeLengthManacher(s);//3 bab

            s = "aaaa";
            longestPalindromeResult = longestPalindromeClass.LongestPalinromeCenter(s);

            s = "leetcode";
            var wordDict = new List<string> { "leet", "code" };
            var wordBreakClass = new WordBreakClass();
            var wordBreakResult = wordBreakClass.WordBreak(s, wordDict); // true

            s = "bbbab";
            var longestPalindromeSubseqClass = new LongestPalindromeSubseqClass();
            var longestPalindromSubseqResult = longestPalindromeSubseqClass.LongestPalindromeSubseq(s);//bbbb 4
            s = "aabaa";
            longestPalindromSubseqResult = longestPalindromeSubseqClass.LongestPalindromeSubseq(s);//5,aabaa
            s = "abcabcabcabc";
            longestPalindromSubseqResult = longestPalindromeSubseqClass.LongestPalindromeSubseq(s);//7
            longestPalindromSubseqResult = longestPalindromeSubseqClass.LongestPalindromSubseq2(s);//7

            var word1 = "a";
            var word2 = "ab";
            var minDistanceClass = new MinDistanceClass();
            var minDistanceResult = minDistanceClass.MinDistance(word1, word2);//1

            var minimumDeleteSumClass = new MinimumDeleteSumClass();
            var minimumDeleteSumResult = minimumDeleteSumClass.MinimumDeleteSum("sea", "eat");//231

            var numDisinctClass = new NumDistinctClass();
            var numDistinctResult = numDisinctClass.NumDistinct("rabbbit", "rabbit");//3
            numDistinctResult = numDisinctClass.NumDistinct2("rabbbit", "rabbit");//3

            nums = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
            var lengthOfLISClass = new LengthOfLISClass();
            var lengthOfLISResult = lengthOfLISClass.LengthOfLIS(nums);//4; 2, 3, 7, 101
            lengthOfLISResult = lengthOfLISClass.LengthOfLISByBinary(nums);//4

            nums = new int[] { 4, 10, 4, 3, 8, 9 };
            lengthOfLISResult = lengthOfLISClass.LengthOfLIS(nums);//3, 数值相同不视为递增

            nums = new int[] { 0, 1, 0, 3, 2, 3 };
            lengthOfLISResult = lengthOfLISClass.LengthOfLISByBinary(nums);//4

            nums = new int[] { 1, 3, 5, 4, 7 };
            var findNumberOfLISClass = new FindNumberOfLISClass();
            var findNumberOfLISResult = findNumberOfLISClass.FindNumberOfLIS(nums);//2
            nums = new int[] { 2, 2, 2, 2, 2 };
            findNumberOfLISResult = findNumberOfLISClass.FindNumberOfLIS(nums);//5

            var pairs = new int[][]
            {
                new int[] { 1,2},
                new int[]{ 2,3},
                new int[] { 3,4},
            };
            var findLongestChainClass = new FindLongestChainClass();
            var findLongestChainResult = findLongestChainClass.FindLongestChain(pairs);//2
            pairs = new int[][] {
                new int[]{ 1,2},
                new int[]{ 7,8},
                new int[]{ 4,5},
            };
            findLongestChainResult = findLongestChainClass.FindLongestChain(pairs);//3

            pairs = new int[][] {
                new int[]{-6,9 },
                new int[]{1,6},
                new int[]{ 8,10},
                new int[]{ -1,4},
                new int[]{ -6,-2},
                new int[]{ -9,8},
                new int[]{ -5,3},
                new int[]{ 0,3}
            };
            findLongestChainResult = findLongestChainClass.FindLongestChain(pairs);//3
            findLongestChainResult = findLongestChainClass.FindLongestChainByGreedy(pairs);//3

            pairs = new int[][]
            {
                new int[]{ -1,1},
                new int[]{ -2,7},
                new int[]{ -5,8},
                new int[]{ -3,8},
                new int[]{ 1,3},
                new int[]{ -2,9},
                new int[]{ -5,2}
            };
            findLongestChainResult = findLongestChainClass.FindLongestChain(pairs);//1

            findLongestChainResult = findLongestChainClass.FindLongestChainByGreedy(pairs);//1

            pairs = new int[][]
            {
                new int[]{ 7,9 },
                new int[]{ 4,5},
                new int[]{ 7,9},
                new int[]{ -7,-1},
                new int[]{ 0,10},
                new int[]{ 3,10},
                new int[]{ 3,6},
                new int[]{ 2,3}
            };
            findLongestChainResult = findLongestChainClass.FindLongestChain(pairs);//4

            findLongestChainResult = findLongestChainClass.FindLongestChainByBinarySearch(pairs);//4

            var arr = new int[] { 1, 5, 7, 8, 5, 3, 4, 2, 1 };
            var difference = -2;
            var longestSubsequenceClass = new LongestSubsequenceClass();
            var longestSubsequenceResult = longestSubsequenceClass.LongestSubsequence(arr, difference);//4
            longestSubsequenceResult = longestSubsequenceClass.LongestSubsequenceOptimize(arr, difference);//4

            nums = new int[] { 20, 1, 15, 3, 10, 5, 8 };
            var longestArithSeqLengthClass = new LongestArithSeqLengthClass();
            var longestArithSequenceLengthResult = longestArithSeqLengthClass.LongestArithSeqLength(nums);//4

            var envelopes = new int[][]
            {
                new int[]{ 5,4 },
                new int[]{ 6,4},
                new int[]{ 6,7},
                new int[]{ 2,3}
            };
            var maxEnvelopClass = new MaxEnvelopesClass();
            var maxEnvelopResult = maxEnvelopClass.MaxEnvelopes(envelopes);//3

            envelopes = new int[][]
            {
                new int[]{ 7,8 },
                new int[]{ 12,16 },
                new int[]{ 12,5},
                new int[]{ 1,8},
                new int[]{ 4,19},
                new int[]{ 3,15},
                new int[]{ 4,10},
                new int[]{ 9,16}
            };
            maxEnvelopResult = maxEnvelopClass.MaxEnvelopes(envelopes);//3
            maxEnvelopResult = maxEnvelopClass.MaxEnvelopesOtimize(envelopes);//3

            envelopes = new int[][]
            {
                new int[]{ 4,5},
                new int[]{ 4,6},
                new int[]{ 6,7},
                new int[]{ 2,3},
                new int[]{ 1,1}
            };
            maxEnvelopResult = maxEnvelopClass.MaxEnvelopesOtimize(envelopes);//4

            var obstacles = new int[] {
                1, 2, 3, 2
            };
            var longestObstacleCourseAtEachPositionClass = new LongestObstacleCourseAtEachPositionClass();
            var longestObstacleCourseAtEachPositionResult = longestObstacleCourseAtEachPositionClass.LongestObstacleCourseAtEachPosition(obstacles);//1,2,3,3
            longestObstacleCourseAtEachPositionResult = longestObstacleCourseAtEachPositionClass.LongestObstacleCourseAtEachPositionOptimize(obstacles);//1,2,3,3
            var testSearchData = new List<int> {
                1,2,3,3,3,4
            };
            var searchResult = longestObstacleCourseAtEachPositionClass.BinarySearch(testSearchData, 4);

            var arra = new int[] { 1, 2, 4, 5 };
            var arrIndex = Array.BinarySearch(arra, 0, 4, 3);

            var text1 = "abcde";
            var text2 = "ace";
            var longestCommonSubsequenceClass = new LongestCommonSubsequenceClass();
            var longestCommonSubsequenceResult = longestCommonSubsequenceClass.LongestCommonSubsequence(text1, text2);//ace, 3

            var t = (2 + 3) >> 1;

            var nums1 = new int[] {
                2,5,1,2,5
            };
            var nums2 = new int[] { 10, 5, 2, 1, 5, 2 };
            var maxUnCrossedLinestClass = new MaxUncrossedLinesClass();
            var maxUnCrossedLinestResult = maxUnCrossedLinestClass.MaxUncrossedLines(nums1, nums2);//3

            var mins = "mbadm";
            var minInsertionsClass = new MinInsertionsClass();
            var minInsertionsResult = minInsertionsClass.MinInsertions(mins);//2
            minInsertionsResult = minInsertionsClass.MinInsertions2(mins);//2

            var prices = new int[] {
                1,2,3,0,2
            };
            var maxProfitClass = new MaxProfitClass();
            var maxProfitResult = maxProfitClass.MaxProfit(prices);//3 买入, 卖出, 冷冻期, 买入, 卖出

            prices = new int[] {
                1,2,4
            };
            maxProfitResult = maxProfitClass.MaxProfit(prices); //3

            var fee = 3;
            prices = new int[] { 1, 3, 7, 5, 10, 3 };
            var maxProfitClassWithFee = new MaxProfitClassWithFees();
            var maxProfitWithFeeResult = maxProfitClassWithFee.MaxProfit(prices, fee);//6
            maxProfitWithFeeResult = maxProfitClassWithFee.MaxProfitGreedy(prices, fee);//6

            var heights = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var trapClass = new TrapClass();
            var trapResult = trapClass.Trap(heights);//6
            trapResult = trapClass.TrapByStack(heights);//6
            trapResult = trapClass.TrapByDoubleLink(heights);//6

            prices = new int[] { 3,2,6,5,0,3};
            var maxProfitClassWithK = new MaxProfitClassWithK();
            var maxProfitResultWithK = maxProfitClassWithK.MaxProfit(2,prices);//7

            maxProfitResultWithK = maxProfitClassWithK.MaxProfitByQuickSort(2, prices);//7

            prices = new int[] { 2,4,1};
            maxProfitResultWithK = maxProfitClassWithK.MaxProfit(2,prices);//2
            prices = new int[] { 4, 7, 1, 2 };
            maxProfitResultWithK = maxProfitClassWithK.MaxProfit(2, prices);//4
            maxProfitResultWithK = maxProfitClassWithK.MaxProfitOtimize(2, prices);//4

            //最多完成两笔交易
            prices = new int[] { 7, 6, 4, 3, 1 };
            var maxProfitWith2Detal = new MaxProfitClassWith2Deal();
            var maxProfitWith2DealResult = maxProfitWith2Detal.MaxProfit(prices);//0

            var n = 3;
            var numTreesClass = new NumTreesClass();
            var numTreesResult = numTreesClass.NumTrees(n);//5
            numTreesResult = numTreesClass.NumTreesDp(n);//5

            var generateTreesClass = new GenerateTreesClass();
            var generateTreeResult = generateTreesClass.GenerateTrees(3);//[[1,null,2,null,3],[1,null,3,2],[2,1,3],[3,1,null,null,2],[3,2,null,1]]

            var tree = new TreeNode { 
                left = new TreeNode {
                    left = null,
                    right = new TreeNode {
                        val =3,
                    },
                    val = 2
                },
                right = new TreeNode {
                    right = new TreeNode { 
                        val =1
                    },
                    val = 3
                },
                val = 3
            };
            var robClassIII = new RobClassIII();
            var robResultIII = robClassIII.Rob(tree);//7

            tree = new TreeNode { 
                val = -10,
                left = new TreeNode { 
                    val = 9
                },
                right = new TreeNode { 
                    val = 20,
                    left = new TreeNode { 
                        val = 15
                    },
                    right = new TreeNode { 
                        val = 7
                    }
                }
            };
            var maxPathSumClass = new MaxPathSumClass();
            var maxPathSumResult = maxPathSumClass.MaxPathSum(tree);//42 = 15+20+7
            tree = new TreeNode { val = -3};
            maxPathSumResult = maxPathSumClass.MaxPathSum(tree);//-3
            tree = new TreeNode
            {
                val = 5,
                left = new TreeNode { 
                        val = 4,
                        left = new TreeNode { val = 11}
                   },
                right = new TreeNode {
                    val = 8,
                    left = new TreeNode
                    { 
                        val = 13,
                        left = new TreeNode
                        {
                            val =7
                        },
                        right = new TreeNode
                        {
                            val = 2,
                            left = new TreeNode { val = 1 }
                        }
                    },
                    right = new TreeNode
                    {
                        val = 4
                    }
                   }
            };

            maxPathSumResult = maxPathSumClass.MaxPathSum(tree);//48

            var numSquareClass = new NumSquaresClass();
            var numSquareResult = numSquareClass.NumSquares(12);//3

            var amount = 5;
            var coins = new int[] { 1,2,5};
            var changeClass = new ChangeClass();
            var changeClassResult = changeClass.Change(amount, coins);//4

            var target = 4;
            var nums11 = new int[] { 1,2,3};
            var combinationSum4Class = new CombinationSum4Class();
            var combinationSum4ClassResult = combinationSum4Class.CombinationSum4(nums11, target);//7

            var strs = new string[] {
                "10", "0001", "111001", "1", "0"
            };
            var m11 = 5;
            var n11 = 3;
            var findMaxFormClass = new FindMaxFormClass();
            var findMaxFormClassResult = findMaxFormClass.FindMaxForm(strs,m11,n11);//4

            strs = new string[] { "10", "0", "1" };
            findMaxFormClassResult = findMaxFormClass.FindMaxForm(strs, 1, 1);//2

            var knapsackDpClass = new KnapSackDpClass();
            var weights = new int[] { 3,4,7,8,9};
            var vals = new decimal[] { 4,5,10,11,13};

            var knapsackDpResult = knapsackDpClass.MostProfit(weights,vals,17);//最大值 24,最优解：0,0,0,1,1
            knapsackDpClass.OutputKnapsackDP(knapsackDpResult, 17, weights, vals);
            var knapsackDpResult1 = knapsackDpClass.MostProfit2(weights,vals,17);//24
            var knapsackDpResult2 = knapsackDpClass.MaxProfitByGreedy(weights,vals,17);//23, 和动态规划的结果不一致，不是最优解

            //Longest common sub sequence
            var lcsdpClass = new LCSDPClass();
            var str1 = "ABCBDAB";
            var str2 = "BDCABA";
            var lcsdpResult = lcsdpClass.LongestCommonSubsequence(str1,str2);
            lcsdpClass.OutputLCS(str1,str1.Length,str2.Length,lcsdpResult);

            //MatrixChain Multiply
            var matrixChainMulti = new MatrixChainMultiplication();
            var p = new int[] { 30,35,15,5,10,20,25};
            var matrixChainMultiResult = matrixChainMulti.MatrixChainOrder(p);//1,1,3,3,3;0,2,3,3,3;0,0,3,3,3;0,0,0,4,5;0,0,0,0,5
            matrixChainMulti.PrintMatrixChain(matrixChainMultiResult,1,matrixChainMultiResult.GetLength(0)-1);//((A1(A2A3))((A4A5)A6))

            //MostPointsClass2
            var questions2 = new int[][] {
                new int[]{3,2 },
                new int[]{4,3},
                new int[]{4,4},
                new int[]{2,5}
            };
            var mostPointsClass2 = new MostPointsClass2();
            var mostPointsClass2Result = mostPointsClass2.MostPoints(questions2);//5

            //CoinChange
            var coinsData = new int[] { 1, 2, 5 };
            var amountData = 11;
            var coinChangeClass = new CoinChangeClass();
            var coinChangeClassResult = coinChangeClass.CoinChange(coinsData, amountData);//3,11 = 5 + 5 + 1

            coinsData = new int[] { 2 };
            amountData = 3;
            coinChangeClassResult = coinChangeClass.CoinChange(coinsData,amountData);//-1

            //Good String
            var low = 3;
            var high = 3;
            var zero = 1;
            var one = 1;
            var goodStringClass = new CountGoodStringsClass();
            var goodStringClassResult = goodStringClass.CountGoodStrings(low,high,zero,one);//8

            var numDecodingsClass = new NumDecodingsClass();
            var numDecodingsClassResult = numDecodingsClass.NumDecodings("226");//3
            numDecodingsClassResult = numDecodingsClass.NumDecodings("06");//0

            var days = new int[] { 1, 4, 6, 7, 8, 20 };
            var costs = new int[] { 2, 7, 15 };
            var minCostTicketsClass = new MincostTicketsClass();
            var minCostTicketsResult = minCostTicketsClass.MincostTickets(days,costs);//11

            //多米诺和托米诺平铺
            var numTilingClass = new NumTilingsClass();
            var numTilingResult = numTilingClass.NumTilings(3);//5

            //接雨水 -- 立方
            var heightMap = new int[][] {
                new int[]{ 1, 4, 3, 1, 3, 2 },
                new int[]{ 3,2,1,3,2,4 },
                new int[]{ 2, 3, 3, 2, 3, 1 }
            };
            var trapRainWater = new TrapRainWaterCube();
            var trapRainWaterCubeResult = trapRainWater.TrapRainWaterByMinHeap(heightMap);//4

            trapRainWaterCubeResult = trapRainWater.TrapRainWaterByBFS(heightMap);//4
            Console.WriteLine();
        }
    }
}
