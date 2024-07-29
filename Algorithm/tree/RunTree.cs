using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.tree
{
    public class RunTree
    {
        public static void Run() {

            var treeOrder = new TreeOrder();
            var tree = new TreeNode {
                Data = 1,
                Left = new TreeNode {
                    Data= 2,
                    Left = new TreeNode
                    {
                        Data = 4
                    },
                    Right= new TreeNode { 
                        Data = 5
                    }
                },
                Right = new TreeNode { Data = 3 }
            };
            treeOrder.PostOrderTraverser(tree);//4,5,2,3,1
            treeOrder.LevelTraverser(tree);//1,2,3,4,5

            var huffManTree = new HuffmanTreeClass();
            var data = new string[] { "1", "2", "3", "4", "5", "6" };
            var weights = new int[] { 1, 2, 3, 4, 5, 6 };
            var buildedHuffManTree = huffManTree.BuildTreeWithPririotyQueue(data,weights);
            buildedHuffManTree = huffManTree.BuildTreeWithoutPriorityQueue(data,weights);
        }
    }
}
