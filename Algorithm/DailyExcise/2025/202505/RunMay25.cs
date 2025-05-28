using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunMay25
    {
        public static void Run()
        {
            var maxTargetNodesClass = new MaxTargetNodesClass();
            var maxTargetNodeClassResult = maxTargetNodesClass.MaxTargetNodes(
                new int[][] { new int[]{0,1 },new int[]{0,2 },new int[]{0,3 },new int[]{0,4 } },
                new int[][] { new int[] { 0,1},new int[] { 1,2},new int[] { 2,3} },
                1
                );//[6,3,3,3,3]
        }
    }
}
