using Algorithm.dp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunDailyExcise
    {
        public static void Run()
        {
            var s = "aaaa";
            var maximuLengthClass = new MaximumLengthClass();
            var maximumLengthResult = maximuLengthClass.MaximumLength(s);//2
            s = "abcdef";
            maximumLengthResult = maximuLengthClass.MaximumLength(s);//-1

            s = "aaaa";
            maximumLengthResult = maximuLengthClass.MaximumLengthByBinanry(s);//2
            s = "bbc";
            maximumLengthResult = maximuLengthClass.MaximumLengthByBinanry(s);//-1
            s = "abcccccdddd";
            maximumLengthResult = maximuLengthClass.MaximumLengthByBinanry(s);//3

            maximumLengthResult = maximuLengthClass.MaximumLengthByOptimization(s);//3

            var grid = new int[][] {
                new int[]{ 9, 1, 7},
                new int[]{ 8, 9, 2 },
                new int[]{ 3, 4, 6 }
            };
            var findMissingAndRepeatedValues = new FindMissingAndRepeatedValuesClass();
            var findMissingAndRepeatedValuesResult = findMissingAndRepeatedValues.FindMissingAndRepeatedValues(grid);// [9,5]

            var nums = new int[] { 1, 1, 1, 2, 2, 3 };
            var removeDupClass = new RemoveDuplicatesClass();
            var removeDupResult = removeDupClass.RemoveDuplicates(nums);//5:[1,1,2,2,3]

            var distributeCandiesClass = new DistributeCandiesClass();
            var distributeCandiesResult = distributeCandiesClass.DistributeCandiesByEnum(3, 3);//10
            distributeCandiesResult = distributeCandiesClass.DistributeCandiesByEnum(5, 2);//3

            distributeCandiesResult = distributeCandiesClass.DistributeCandiesByOptimization(5, 2);//3

            distributeCandiesResult = distributeCandiesClass.DistributeCandiesByRongChi(5, 2);//3

            var canditypes = new int[] { 1, 1, 2, 2, 3, 3 };
            var distributeCandies2Class = new DistributeCandies2();
            var distributedCandies2Result = distributeCandies2Class.DistributeCandies(canditypes);//3

            var distributeCandies3Class = new DistributeCandies3();
            var distributeCandies3Result = distributeCandies3Class.DistributeCandies(7, 4);//[1,2,3,1]

            var edges = new int[][] {
                new int[]{ 0, 1, 1 },
                new int[]{ 1,2,5 },
                new int[]{ 2,3,13 },
                new int[]{ 3,4,9 },
                new int[]{ 4, 5, 2 }
            };
            var signalSpeed = 1;
            var countPairsOfConnectableServers = new CountPairsOfConnectableServersClass();
            var countPairsOfConnectableServersResult = countPairsOfConnectableServers.CountPairsOfConnectableServers(edges, signalSpeed);//[0,4,6,6,4,0];

            var quikPowerTest = countPairsOfConnectableServers.QuickPower(10, 3, 6);

            var nums1 = new int[] { 2, 1, 3, 3 };
            var resultArrayClass = new ResultArrayClass();
            var resultArrayResult = resultArrayClass.ResultArray(nums1);//2,3,1,3
            nums1 = new int[] { 5, 14, 3, 1, 2 };
            resultArrayResult = resultArrayClass.ResultArray(nums1);//[5,3,1,2,14]
            nums1 = new int[] { 23, 55, 90 };
            resultArrayResult = resultArrayClass.ResultArray(nums1);//[23,90,55]

            var sm = "101";
            var minimumStepsClass = new MinimumStepsClass();
            var minimumStepsResult = minimumStepsClass.MinimumSteps(sm);//1

            var maxNums = new int[] { 3, 2, 1, 4, 5 };
            var maxOperationClass = new MaxOperationsClass();
            var maxOperationClassResult = maxOperationClass.MaxOperations(maxNums);//2

            var people = new int[] { 3, 5, 3, 4 };
            var limitNum = 5;
            var numRescueBoatsClass = new NumRescueBoatsClass();
            var numRescueBoatsResult = numRescueBoatsClass.NumRescueBoats(people, limitNum);//4

            var board = new char[][] {
                new char[] { 'X', '.', '.', 'X' },
                new char[] { '.', '.', '.', 'X' },
                new char[] { '.', '.', '.', 'X' }
            };
            var countBattleShipsClass = new CountBattleshipsClass();
            var countBattleShipsResult = countBattleShipsClass.CountBattleships1(board);//2

            board = new char[][] {
                new char[] { 'X', '.', '.', 'X' },
                new char[] { '.', '.', '.', 'X' },
                new char[] { '.', '.', '.', 'X' }
            };
            countBattleShipsResult = countBattleShipsClass.CountBattleships2(board);//2

            var itemsfind = new int[][] {
                new int[]{ 3, 2 },
                new int[]{ 5,1 },
                new int[]{ 10,1 },
            };
            var k = 2;
            var findMaximumEleganceClass = new FindMaximumEleganceClass();
            var findMaximumEleganceResult = findMaximumEleganceClass.FindMaximumElegance(itemsfind, k);//17

            var numsMaxScore = new int[] { 2, 3, 6, 1, 9, 2 };
            var maxScoreClass = new MaxScoreClass();
            var maxScoreResult = maxScoreClass.MaxScore(numsMaxScore, 5); //13

            var maximuBeautyClass = new MaximumBeautyClass();
            var numsBeauty = new int[] { 4, 6, 1, 2 };
            var maximuBeautyResult = maximuBeautyClass.MaximumBeauty1(numsBeauty, 2);//3 ;

            maximuBeautyResult = maximuBeautyClass.MaximuBeauty2(numsBeauty, 2);//3

            var strs = new string[] {
                "aba","cdc","eae"
            };
            var findLUSLengthClass = new FindLUSlengthClass();
            var findLUSLengthResult = findLUSLengthClass.FindLUSlength(strs);//3

            strs = new string[] { "aaa", "aaa", "aa" };
            findLUSLengthResult = findLUSLengthClass.FindLUSlength(strs);//-1

            var sentence = "there are $1 $2 and 5$ candies in the shop";
            var discountPrices = new DiscountPricesClass();
            var discountPriceResult = discountPrices.DiscountPrices(sentence, 50);//there are $0.50 $1.00 and 5$ candies in the shop

            var mat = new int[][] {
                new int[]{ 3,1},
                new int[]{ 3, 4 }
            };
            var maxIncreasingCellsClass = new MaxIncreasingCellsClass();
            var maxIncreasingCellsResult = maxIncreasingCellsClass.MaxIncreasingCells(mat);//2

            mat = new int[][] {
                new int[]{ 3,1,6},
                new int[]{ -9, 5, 7 }
            };
            maxIncreasingCellsResult = maxIncreasingCellsClass.MaxIncreasingCells(mat);//4

            var beauNums = new int[] { 2, 5, 1, 4 };
            var countBeautifulPairs = new CountBeautifulPairsClass();
            var countBeautifulPairsResult = countBeautifulPairs.CountBeautifulPairs(beauNums);//5

            countBeautifulPairsResult = countBeautifulPairs.CountBeautifulPairs2(beauNums);//5
            countBeautifulPairsResult = countBeautifulPairs.CountBeautifulPairs3(beauNums);//5

            var smallestBeatifulString = new SmallestBeautifulStringClass();
            var smallestBeatifulResult = smallestBeatifulString.SmallestBeautifulString("abcz", 26);//abda

            var nextNums = new int[] { 1, 2, 1 };
            var nextGreaterElements = new NextGreaterElementsClass();
            var nextGreaterElementsResult = nextGreaterElements.NextGreaterElements(nextNums); //2, -1, 2

            var goodGrid = new int[][] {
                new int[]{ 0, 1, 1, 0 },
                new int[]{ 0,0,0,1 },
                new int[]{ 1, 1, 1, 1 }
            };
            //goodGrid = new int[][]{
            //    new int[]{ 1,1,1 },
            //    new int[]{ 1, 1, 1 }
            //}; //0
            var goodSubSetOfBinaryMatrix = new GoodSubsetofBinaryMatrixClass();
            var goodSubSetOfBinaryMatrixResult = goodSubSetOfBinaryMatrix.GoodSubsetofBinaryMatrix(goodGrid);//[0,1]

            var specialNums = new int[] { 2, 3, 6 };
            var specialPermClass = new SpecialPermClass();
            var specialPermResult = specialPermClass.SpecialPerm(specialNums);//2

            specialPermResult = specialPermClass.SpecialPermDP(specialNums);//2

            var smallestStringClass = new SmallestStringClass();
            var smallestStringResult = smallestStringClass.SmallestString("cbabc");//"baabc"

            var cost = new int[] { 1, 2, 3, 2 };
            var time = new int[] { 1,2,3,2};
            var paintWallsClass = new PaintWallsClass();
            var paintWallsResult = paintWallsClass.PaintWalls1(cost,time);//3
            paintWallsResult = paintWallsClass.PaintWalls2(cost,time);//3

            var values = new int[] { 1, 2, 3, 4 };
            var edgesQuality = new int[][] {
                new int[]{ 0,1,10},
                new int[]{ 1,2,11},
                new int[]{ 2, 3, 12 },
                new int[]{ 1, 3, 13 }
            };
            var maxTime = 50;
            var maximalPathQualityClass = new MaximalPathQualityClass();
            var maximalPathQualityResult = maximalPathQualityClass.MaximalPathQuality(values,edgesQuality,maxTime);//7

            values = new[] { 5, 10, 15, 20 };
            edgesQuality = new int[][] {
                new int[]{ 0,1,10},
                new int[]{ 1,2,10},
                new int[]{ 0,3,10}
            };
            maxTime = 30;
            maximalPathQualityResult = maximalPathQualityClass.MaximalPathQuality(values, edgesQuality, maxTime);//25

            var maxPrimeNums = new int[] { 4, 2, 9, 5, 3 };
            var maximumPrimeClass = new MaximumPrimeDifferenceClass();
            var maximumPrimeResult = maximumPrimeClass.MaximumPrimeDifference(maxPrimeNums);//3

            var sumOfTheDigitOfHarshadNumber = new SumOfTheDigitsOfHarshadNumberClass();
            var sumOfTheDigitOfHarshadNumberResult = sumOfTheDigitOfHarshadNumber.SumOfTheDigitsOfHarshadNumber(18);//9
            sumOfTheDigitOfHarshadNumberResult = sumOfTheDigitOfHarshadNumber.SumOfTheDigitsOfHarshadNumber1(18);//9 

            var miniMovesNum = new int[] { 1, 1, 0, 0, 0, 1, 1, 0, 0, 1 };
            var minimumMoves = new MinimumMovesClass();
            var minimuMovesResult = minimumMoves.MinimumMoves1(miniMovesNum,3,1);//3
            minimuMovesResult = minimumMoves.MinimumMoves2(miniMovesNum,3,1);//3

            miniMovesNum = new int[] { 0, 1, 0, 1, 1 };
            minimuMovesResult = minimumMoves.MinimumMoves1(miniMovesNum, 3, 0);//3

            var maxtrix = new int[][] {
                new int[]{ 1, 2, -1 },
                new int[]{ 4,-1,6 },
                new int[]{ 7, 8, 9 }
            };
            var modifiedMatrixClass = new ModifiedMatrixClass();
            var modifiedMatrixResult = modifiedMatrixClass.ModifiedMatrix(maxtrix);

            var countNums = new int[] { 0, 1, 1, 1 };
            var countAlternatingSubArrays = new CountAlternatingSubarraysClass();
            var countAlternatingResult = countAlternatingSubArrays.CountAlternatingSubarrays(countNums);//5

            var pivotIndexNum = new int[] { 1, 7, 3, 6, 5, 6 };
            var pivotIndexClass = new PivotIndexClass();
            var pivotIndexResult = pivotIndexClass.PivotIndex(pivotIndexNum);//3

            var points = new int[][] { 
                new int[]{ 3, 10 },
                new int[]{ 5,15 },
                new int[]{ 10,2 },
                new int[]{ 4, 4 }
            };
            var minimumDistanceClass = new MinimumDistanceClass();
            var minimumDistanceResult = minimumDistanceClass.MinimumDistance(points);//12

            var incNums = new int[] { 1, 2, 3, 4 };
            var incremovableSubArr = new IncremovableSubarrayCountClass();
            var incremovableSubResult = incremovableSubArr.IncremovableSubarrayCount(incNums);//10
            incremovableSubResult = incremovableSubArr.IncremovableSubarrayCount1(incNums);//10

            var incNums1 = new int[] { 1, 2, 3, 4 };
            var incremovableSubArr1 = new IncremovableSubarrayCountClass1();
            var incremovableSubResult1 = incremovableSubArr1.IncremovableSubarrayCount(incNums1);//10

            var gameNums = new int[] { 5, 4, 2, 3 };
            var numberGameClass = new NumberGameClass();
            var numberGameResult = numberGameClass.NumberGame(gameNums); //3,2,5,4

            var canSortNums = new int[] { 8, 4, 2, 30, 15 };
            var canSortArray = new CanSortArrayClass();
            var canSortArrayResult = canSortArray.CanSortArray(canSortNums); //true

            var accounts = new List<IList<string>> {
                new List<string>{ "John", "johnsmith@mail.com", "john_newyork@mail.com" },
                new List<string>{ "John", "johnsmith@mail.com", "john00@mail.com" },
                new List<string>{ "Mary", "mary@mail.com" }, 
                new List<string>{"John", "johnnybravo@mail.com"}
            };
            var accountMergeClass = new AccountsMergeClass();
            var accountMergeResult = accountMergeClass.AccountsMerge(accounts);//[["John", 'john00@mail.com', 'john_newyork@mail.com', 'johnsmith@mail.com'],  ["John", "johnnybravo@mail.com"], ["Mary", "mary@mail.com"]]

            var findnums1 = new int[] { 4, 3, 2, 3, 1 };
            var findnums2 = new int[] { 2, 2, 5, 2, 3, 6 };
            var findIntersectionsValueClass = new FindIntersectionValuesClass();
            var findIntersectionResult = findIntersectionsValueClass.FindIntersectionValues(findnums1,findnums2);//3,4

            var roads = new int[][] {
                new int[]{ 0, 1, 2 },
                new int[]{ 1,2,10 },
                new int[]{ 0,2,10 },
            };
            var numberOfSetClass = new NumberOfSetsClass();
            var numberOfSetResult = numberOfSetClass.NumberOfSets(3,5,roads);//5

            var minimuEdges = new int[][] {
                new int[]{0,1,2 },
                new int[]{ 1,2,1},
                new int[]{ 0,2,4}
            };
            var disappear = new int[] { 1,1,5};
            var minimumTimeClass = new MinimumTimeClass();
            var minimumTimeResult = minimumTimeClass.MinimumTime(3,minimuEdges,disappear); //0,-1,4

            var minLevelPossible = new int[] { 1, 0, 1, 0 };
            var minimuLevelClass = new MinimumLevelsClass();
            var minimumLevelResult = minimuLevelClass.MinimumLevels(minLevelPossible);//1

            var minimumGrid = new int[][] {
                new int[]{1,1,0 },
                new int[]{1,1,1},
                new int[]{1,2,1},
            };
            var minimumMoveClass2 = new MinimumMovesClass2();
            var minimumMoveResult2 = minimumMoveClass2.MinimumMoves(minimumGrid);//3

            var bombs = new int[][] { 
                new int[]{2,1,3 },
                new int[]{6,1,4}
            };
            var maximuDetonationClass = new MaximumDetonationClass();
            var maximumDetonationResult = maximuDetonationClass.MaximumDetonation(bombs);//2

            bombs = new int[][] {
                new int[]{ 1,1,100000 },
                new int[]{ 100000, 100000, 1 }
            };
            maximumDetonationResult = maximuDetonationClass.MaximumDetonation(bombs);//1

            var sumNums = new int[] { 1, 2, 3, 4 };
            var sumOfPowerClass = new SumOfPowersClass();
            var sumOfPowerResult = sumOfPowerClass.SumOfPowersDP(sumNums,3);//4

            var relNums = new int[] { 1, 6, 7, 8 };
            var moveFrom = new int[] { 1, 7, 2 };
            var moveTo = new int[] { 2, 9, 5 };
            var relocateMarbleClass = new RelocateMarblesClass();
            var relocateMarbleResult = relocateMarbleClass.RelocateMarbles(relNums,moveFrom,moveTo);//[5,6,8,9]

            var minimumOperationClass = new MinimumOperationsClass();
            var minimumOperationResult = minimumOperationClass.MinimumOperations("2245047");//2

            var findNums = new int[] { 1, 3, 2, 4 };
            var findValueOfPartitionClass = new FindValueOfPartitionClass();
            var findValueOfPartitionResult = findValueOfPartitionClass.FindValueOfPartition(findNums);//1

            var getSmallestStringClass = new GetSmallestStringClass();
            var getSmallestStringResult = getSmallestStringClass.GetSmallestString("zbbz",3); //aaaz

            var operations = new string[] { "5", "2", "C", "D", "+" };
            var calPointsClass = new CalPointsClass();
            var calPointResult = calPointsClass.CalPoints(operations);//30

            var variables = new int[][] { 
                new int[]{ 2, 3, 3, 10 },
                new int[]{ 3,3,3,1},
                new int[]{ 6, 1, 1, 4 }
            };
            var getGoodIndicesClass = new GetGoodIndicesClass();
            var getGoodIndicesResult = getGoodIndicesClass.GetGoodIndices(variables, 2);//0,2

            var minPoints = new int[][] { 
                new int[]{ 2,1},
                new int[]{ 1,0},
                new int[]{ 1,4},
                new int[]{ 1,8},
                new int[]{ 3,5},
                new int[]{ 4, 6 }
            };
            var minRectangleClass = new MinRectanglesToCoverPointsClass();
            var minRectangleResult = minRectangleClass.MinRectanglesToCoverPoints(minPoints,1);//2

            var cards = new int[] { 1, 2, 8, 9 };
            var maxmiumScoreClass = new MaxmiumScoreClass();
            var maxmiumScoreResult = maxmiumScoreClass.MaxmiumScore(cards, 3);//18

            var numGrid = new int[][] { 
                new int[]{ 0, 1, 0 },
                new int[]{ 0,1,1 },
                new int[]{ 0, 1, 0 }
            };
            var numberOfRightTriangleClass = new NumberOfRightTrianglesClass();
            var numberOfRightTriangleResult = numberOfRightTriangleClass.NumberOfRightTriangles(numGrid);//2

            var maxPoints = new int[][] { 
                new int[]{ 2, 2 },
                new int[]{ -1,-2 },
                new int[]{-4,4 },
                new int[]{-3,1 },
                new int[]{ 3, -3 }
            };
            var maxPointsInsideSquareClass = new MaxPointsInsideSquareClass();
            var maxPointsInsideSquareResult = maxPointsInsideSquareClass.MaxPointsInsideSquare(maxPoints, "abdca");//2

            var models = new int[][] {
                new int[]{ 1,1,0 },
                new int[]{ 2,0,1 },
                new int[]{ 4, 2, 2 }
            };
            var getMaximumNumberClass = new GetMaximumNumberClass();
            var getMaximumNumberResult = getMaximumNumberClass.GetMaximumNumber(models); //2

            var root = new TreeNode {
                val = 3,
                left = new TreeNode {
                    val = 4,
                    left = new TreeNode {val=1 },
                    right = new TreeNode {val=2}
                },
                right = new TreeNode { val =5 },
            };
            var subTree = new TreeNode
            {
                val = 4,
                left = new TreeNode { val = 1 },
                right = new TreeNode { val = 2 }
            };

            var subTreeClass = new IsSubtreeClass();
            var subTreeResult = subTreeClass.IsSubtree(root,subTree);//true

            var findIntegerClass = new FindIntegersClass();
            var findintegerResult = findIntegerClass.FindIntegers(5);//5

            var removeDuplicates = findIntegerClass.RemoveDuplicates(new int[] { 1,1,2}); //[1,2]

            var numberOfStableArrayClass = new NumberOfStableArraysClass();
            var numberOfStableArrayResult = numberOfStableArrayClass.NumberOfStableArrays(1,1,2);//2

            var numberOfStableArrayClass2 = new NumberOfStableArraysClass2();
            var numberOfStableArrayResult2 = numberOfStableArrayClass2.NumberOfStableArrays(1, 1, 2);//2
            numberOfStableArrayResult2 = numberOfStableArrayClass2.NumberOfStableArraysDP(1, 1, 2);//2
            Array.Sort(beauNums);
        }
    }
}
