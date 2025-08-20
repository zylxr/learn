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
        }
    }
}
