using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.tree
{
    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
    public class TreeOrder
    {
        /// <summary>
        /// 后续遍历树--非递归
        /// </summary>
        /// <param name="root"></param>
        public void PostOrderTraverser(TreeNode root)
        { 
            var stack = new Stack<TreeNode>();
            TreeNode pre = null;
            while(root!=null || stack.Count>0)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }else
                {
                    root = stack.Pop();
                    if(root.Right !=null && pre != root.Right)
                    {
                        stack.Push(root);
                        root = root.Right;
                    }else
                    {
                        Console.WriteLine(root.Data);
                        pre = root;
                        root = null;
                    }
                }
            }
        }    

        public void LevelTraverser(TreeNode root)
        {
            var queue =new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count>0)
            {
                var item = queue.Dequeue();
                Console.WriteLine(item.Data);
                if(item.Left != null)queue.Enqueue(item.Left);
                if(item.Right != null)queue.Enqueue(item.Right);
            }
        }
    }
}
