using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithm.dp.GenerateTreesClass;

namespace Algorithm.dp
{
    public class TreeNode
    {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class RobClassIII
    {
        //小偷又发现了一个新的可行窃的地区。这个地区只有一个入口，我们称之为 root 。

        //除了 root 之外，每栋房子有且只有一个“父“房子与之相连。一番侦察之后，聪明的小偷意识到“这个地方的所有房屋的排列类似于一棵二叉树”。 如果 两个直接相连的房子在同一天晚上被打劫 ，房屋将自动报警。

        //给定二叉树的 root 。返回 在不触动警报的情况下 ，小偷能够盗取的最高金额 。
        //示例 1:
        //输入: root = [3,2,3,null,3,null,1]
        //输出: 7 
        //解释: 小偷一晚能够盗取的最高金额 3 + 3 + 1 = 7
        //示例 2:
        //输入: root = [3,4,5,1,3,null,1]
        //输出: 9
        //解释: 小偷一晚能够盗取的最高金额 4 + 5 = 9
        //提示：
        //树的节点数在[1, 104] 范围内
        //0 <= Node.val <= 104
        public int Rob(TreeNode root)
        {
            var result = GetMax(root);
            return Math.Max(result[0], result[1]);
        }
        public int[] GetMax(TreeNode node)
        {
            var result = new int[2];
            if (node == null) return result;
            var leftMax = GetMax(node.left);
            var rightMax = GetMax(node.right);
            
            result[0] = node.val + leftMax[1]+ rightMax[1];
            result[1] = Math.Max(leftMax[0], leftMax[1])+ Math.Max(rightMax[0], rightMax[1]);
            return result;
        }
    }
}
