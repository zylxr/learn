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

            var maxTargetNode2Class = new MaxTargetNodes2Class();
            var maxTargetNode2ClassResult = maxTargetNode2Class.MaxTargetNodes(
                new int[][] { new int[] { 0, 1}, new int[] { 0,2}, new int[] { 2,3}, new int[] { 2,4} },
                new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 2, 7 }, new int[] { 1, 4 }, new int[] { 4, 5 }, new int[] { 4, 6 } }
                );//[8,7,7,8,8]

            maxTargetNode2ClassResult = maxTargetNode2Class.MaxTargetNodes2(
                new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 2, 3 }, new int[] { 2, 4 } },
                new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 2, 7 }, new int[] { 1, 4 }, new int[] { 4, 5 }, new int[] { 4, 6 } }
                );//[8,7,7,8,8]

            var closestMeetingNodeClass = new ClosestMeetingNodeClass();
            var closestMeetingNodeResult = closestMeetingNodeClass.ClosestMeetingNode(
                    new int[] { 1, 2, -1 },
                    0,2
                );//2

            closestMeetingNodeResult = closestMeetingNodeClass.ClosestMeetingNode(
                    new int[] { 4, 4, 4, 5, 1, 2, 2 },
                    1, 1
                );//1

            closestMeetingNodeResult = closestMeetingNodeClass.ClosestMeetingNode(
                    new int[] { 9, 8, 7, 0, 5, 6, 1, 3, 2, 2 },
                    1, 6
                );//1

            closestMeetingNodeResult = closestMeetingNodeClass.ClosestMeetingNode(
                    new int[] { 2,0,0 },
                    2, 0
                );//0
        }
    }
}
