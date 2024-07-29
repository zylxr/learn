using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class MaxPathSumClass
    {
        //二叉树中的 路径 被定义为一条节点序列，序列中每对相邻节点之间都存在一条边。同一个节点在一条路径序列中 至多出现一次 。该路径 至少包含一个 节点，且不一定经过根节点。
        //路径和 是路径中各节点值的总和。

        //给你一个二叉树的根节点 root ，返回其 最大路径和 。
        //示例 1：
        //输入：root = [1,2,3]
        //输出：6
        //解释：最优路径是 2 -> 1 -> 3 ，路径和为 2 + 1 + 3 = 6
        //示例 2：
        //输入：root = [-10,9,20,null,null,15,7]
        //输出：42
        //解释：最优路径是 15 -> 20 -> 7 ，路径和为 15 + 20 + 7 = 42
        //提示：

        //树中节点数目范围是[1, 3 * 104]
        //-1000 <= Node.val <= 1000
        private int maxSum;
        public int MaxPathSum(TreeNode root)
        {
             maxSum = int.MinValue;
            var result = SubSum(root);
            return maxSum;
        }

        public int[] SubSum(TreeNode node)
        {
            var result = new int[2];
            if (node == null) return result;
            var left = SubSum(node.left);
            var right = SubSum(node.right);
            var maxSub = Math.Max(left[0], right[0]);
            result[0] =  Math.Max(maxSub+node.val,node.val);
            result[1] = node.val + Math.Max(left[0], 0) + Math.Max(right[0],0);
            maxSum = Math.Max(maxSum, result[1]);
            return result;
        }
    }
}
