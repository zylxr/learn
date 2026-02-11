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

        }
    }
}
