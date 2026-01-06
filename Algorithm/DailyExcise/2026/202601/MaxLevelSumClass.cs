using Algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxLevelSumClass
    {
        //1161. 最大层内元素和
        //给你一个二叉树的根节点 root。设根节点位于二叉树的第 1 层，而根节点的子节点位于第 2 层，依此类推。

        //返回总和 最大 的那一层的层号 x。如果有多层的总和一样大，返回其中 最小 的层号 x。




        //示例 1：



        //输入：root = [1, 7, 0, 7, -8, null, null]
        //输出：2
        //解释：
        //第 1 层各元素之和为 1，
        //第 2 层各元素之和为 7 + 0 = 7，
        //第 3 层各元素之和为 7 + -8 = -1，
        //所以我们返回第 2 层的层号，它的层内元素之和最大。
        //示例 2：

        //输入：root = [989, null, 10250, 98693, -89388, null, null, null, -32127]
        //输出：2



        //提示：

        //树中的节点数在[1, 104] 范围内
        //-105 <= Node.val <= 105
        public int MaxLevelSum(TreeNode root)
        {
            var max = root.val;
            var nodes = new List<TreeNode>();
            nodes.Add(root);
            var level = 0;
            var maxlevel = 1;
            while (nodes.Count > 0)
            {
                var newNodes = new List<TreeNode>();
                var sum = 0;
                level++;
                for (var i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i].left != null) newNodes.Add(nodes[i].left);
                    if (nodes[i].right != null) newNodes.Add(nodes[i].right);
                    sum += nodes[i].val;
                }
                nodes.Clear();
                nodes = newNodes;
                if (sum > max)
                {
                    max = sum;
                    maxlevel = level;
                }
            }
            return maxlevel;
        }

        private IList<int> sum = new List<int>();
        public int MaxLevelSum2(TreeNode root)
        {
            DFS(root, 0);
            var ans = 0;
            for (var i = 0; i < sum.Count; i++)
                if (sum[i] > sum[ans])
                    ans = i;
            return ans + 1;
        }
        private void DFS(TreeNode node, int level)
        {
            if (level == sum.Count) sum.Add(node.val);
            else sum[level] += node.val;
            if (node.left != null) DFS(node.left, level + 1);
            if(node.right != null) DFS(node.right, level + 1);
        }
    }

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

}
