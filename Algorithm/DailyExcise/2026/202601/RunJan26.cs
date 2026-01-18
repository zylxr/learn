using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunJan26
    {
        public static void Run()
        {
            var numOfWaysClass = new NumOfWaysClass();
            var numOfWaysClassResult = numOfWaysClass.NumOfWays(2);//54

            var sumFourDivisionClass = new SumFourDivisorsClass();
            var sumFourDivisionClassResult = sumFourDivisionClass.SumFourDivisors(new int[] { 21,4,7});//32
        
            var maxMatrixSumClass = new MaxMatrixSumClass();
            var maxMatrixSumClassResult = maxMatrixSumClass.MaxMatrixSum(new int[][] { 
                new int[] { -1,0,-1 },
                new int[] { -2,1,3 },
                new int[] { 3,2,2 }
            });//15

            var maxLevelSumClass = new MaxLevelSumClass();
            var r = new TreeNode { val =1,left = new TreeNode { val = 7,
                left = new TreeNode { val=7},right = new TreeNode { val=-8}
            },
                right = new TreeNode { val = 0} };
            var maxlevelSumClassResult = maxLevelSumClass.MaxLevelSum(r);//2
            maxlevelSumClassResult = maxLevelSumClass.MaxLevelSum2(r);//2

            var maxDotProductClass = new MaxDotProductClass();
            var maxDotProductClassResult = maxDotProductClass.MaxDotProduct(
                new int[] {2,1,-2,5 },
                new int[] { 3,0,-6});//18

            var minimumDeleteSumClass = new MinimumDeleteSumClass();
            var minimumDeleteSumClassResult = minimumDeleteSumClass.MinimumDeleteSum("sea","eat");//231

            var separateSquaresClass = new SeparateSquaresClass();
            var separateSquaresClassResult = separateSquaresClass.SeparateSquares(new int[][] { new int[] { 0, 0, 1 },new int[] { 2, 2, 1 } });//1

            var largestSquareAreaClass = new LargestSquareAreaClass();
            var largestSquareAreaClassResult = largestSquareAreaClass.LargestSquareArea(
                new int[][] { new int[] { 1, 1 },new int[] { 2, 2 },new int[] { 3, 1 } },
                new int[][] { new int[] { 3, 3 },new int[] { 4, 4 },new int[] { 6, 6 } }
                );//1

            var maxSideLengthClass = new MaxSideLengthClass();
            var maxSideLengthClassResult = maxSideLengthClass.MaxSideLength(new int[][] { 
                new int[]{ 1, 1, 3, 2, 4, 3, 2 },
                new int[]{1,1,3,2,4,3,2 },
                new int[]{ 1, 1, 3, 2, 4, 3, 2 }
            },4);//2

            maxSideLengthClassResult = maxSideLengthClass.MaxSideLength2(new int[][] {
                new int[]{ 1, 1, 3, 2, 4, 3, 2 },
                new int[]{1,1,3,2,4,3,2 },
                new int[]{ 1, 1, 3, 2, 4, 3, 2 }
            }, 4);//2
        }
    }
}
