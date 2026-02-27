using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunFeb26
    {
        public static void Run()
        {
            var minimumCostClass9 = new MinimumCostClass9();
            var minimuCostClass9Result = minimumCostClass9.MinimumCost(new int[] {
                1,3,2,6,4,2
            },3,3);//5

            var isTionicClass = new IsTrionicClass();
            var isTrionicClassResult = isTionicClass.IsTrionic(new int[] { 4, 1, 5, 2, 3 });//false
            isTrionicClassResult = isTionicClass.IsTrionic(new int[] { 1, 3, 5, 4, 2, 6 });//true

            var maxsumTrionicClass  = new MaxSumTrionicClass();
            var maxsumTrionicClassResult = maxsumTrionicClass.MaxSumTrionic(new int[] { 0, -2, -1, -3, 0, 2, -1 });//-4

            var minRemovalClass = new MinRemovalClass();
            var minRemovalClassResult = minRemovalClass.MinRemoval(new int[] { 1, 6, 2, 9 },3);//2

            var minimudeletionClass2 = new MinimumDeletionsClass2();
            var minimudeletionClass2Result = minimudeletionClass2.MinimumDeletions("aababbab");//2

            var balanceBSTClass = new BalanceBSTClass();
            var root = new BalanceBSTClass.TreeNode(
                1,null,
                new BalanceBSTClass.TreeNode(
                    2,null,
                    new BalanceBSTClass.TreeNode(
                        3,null,
                        new BalanceBSTClass.TreeNode(4)
                    )
                )
            );
            var balanceBSTClassResult = balanceBSTClass.BalanceBST(root);//[2,1,3,null,null,null,4]

            var longestBalancedClass = new LongestBalancedClass();
            var longestBalancedClassResult = longestBalancedClass.LongestBalanced(new int[] { 2, 5, 4, 3 });//4

            var longestBalanceClass2 = new LongestBalancedClass2();
            var longestBalanceClass2Result = longestBalanceClass2.LongestBalanced(new int[] { 2, 5, 4, 3 });//4

            var longestBalancedClass3 = new LongestBalancedClass3();
            var longestBalancedClass3Result = longestBalancedClass3.LongestBalanced("zzabccy");//4

            var champagnTowerClass = new ChampagneTowerClass();
            var champagnTowerClassResult = champagnTowerClass.ChampagneTower(2,1,1);//0.5

            var readBinanryWatchClass = new ReadBinaryWatchClass();
            var readBinaryWatchClassResult = readBinanryWatchClass.ReadBinaryWatch(1);//["0:01","0:02","0:04","0:08","0:16","0:32","1:00","2:00","4:00","8:00"]

            var sumRootToLeafClass = new SumRootToLeafClass();
            var root1 = new TreeNode
            {
                val = 1,
                left = new TreeNode(0)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(1)
                },
                right = new TreeNode(1) { 
                    left = new TreeNode(0),
                    right = new TreeNode(1)
                }
            };
            var sumRootToLeafClassResult = sumRootToLeafClass.SumRootToLeaf(root1);//22

            var numStepsClass = new NumStepsClass();
            var numStepClassResult = numStepsClass.NumSteps("1101");//6

            var minOperationsClass = new MinOperationsClass6();
            var minOperationClassResult = minOperationsClass.MinOperations("0101",3);//2
        }
    }
}
