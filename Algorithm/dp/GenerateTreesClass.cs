using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class GenerateTreesClass
    {
        //给你一个整数 n ，请你生成并返回所有由 n 个节点组成且节点值从 1 到 n 互不相同的不同 二叉搜索树 。可以按 任意顺序 返回答案。
        //示例 1：
        //输入：n = 3
        //输出：[[1,null,2,null,3],[1,null,3,2],[2,1,3],[3,1,null,null,2],[3,2,null,1]]
        //示例 2：

        //输入：n = 1
        //输出：[[1]]


        //提示：

        //1 <= n <= 8
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
        public IList<TreeNode> GenerateTrees(int n)
        {
            if(n== 0) return new List<TreeNode>();
            return GenerateTrees(1, n);
        }

        public IList<TreeNode> GenerateTrees(int start,int end)
        {
            var alltrees = new List<TreeNode>();
            if(start> end)
            {
                alltrees.Add(null);
                return alltrees;
            }
            for(var i= start;i<=end;i++)
            {
                var leftTree = GenerateTrees(start, i - 1);
                var rightTree = GenerateTrees(i + 1, end);
                foreach(var left in leftTree)
                {
                    foreach(var right in rightTree)
                    {
                        var node = new TreeNode(i, left, right);
                        alltrees.Add(node);
                    }
                }
            }
            return alltrees;
        }
    }
}
