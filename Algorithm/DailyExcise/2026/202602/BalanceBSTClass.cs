using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class BalanceBSTClass
    {
        //1382. 将二叉搜索树变平衡
        //给你一棵二叉搜索树，请你返回一棵 平衡后 的二叉搜索树，新生成的树应该与原来的树有着相同的节点值。如果有多种构造方法，请你返回任意一种。

        //如果一棵二叉搜索树中，每个节点的两棵子树高度差不超过 1 ，我们就称这棵二叉搜索树是 平衡的 。




        //示例 1：



        //输入：root = [1, null, 2, null, 3, null, 4, null, null]
        //输出：[2, 1, 3, null, null, null, 4]
        //解释：这不是唯一的正确答案，[3, 1, 4, null, 2, null, null] 也是一个可行的构造方案。
        //示例 2：



        //输入: root = [2, 1, 3]
        //输出: [2, 1, 3]


        //提示：

        //树节点的数目在[1, 104] 范围内。
        //1 <= Node.val <= 105
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
        private List<int> inorderSeq = new List<int>();
        public TreeNode BalanceBST(TreeNode root)
        {
            GetInOrder(root);
            return Build(0, inorderSeq.Count - 1);
        }
        private void GetInOrder(TreeNode o)
        {
            if (o.left != null) GetInOrder(o.left);
            inorderSeq.Add(o.val);
            if (o.right != null) GetInOrder(o.right);
        }
        private TreeNode Build(int l, int r)
        {
            var mid = (l + r) >> 1;
            var o = new TreeNode(inorderSeq[mid]);
            if (l <= mid - 1) o.left = Build(l, mid - 1);
            if (mid + 1 <= r) o.right = Build(mid + 1, r);
            return o;
        }
    }
}
