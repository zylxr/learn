using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.tree
{
    public class HuffManTree
    {
        public string Data { get; set; }

        public HuffManTree Left { get; set; }

        public HuffManTree Right { get; set; }

        public int Weight { get; set; }

        public HuffManTree Parent { get; set; }
    }
    public class HuffmanTreeClass
    {
        public HuffManTree BuildTreeWithPririotyQueue(string[] s, int[] weights)
        {
            var priorityQueue = new PriorityQueue<HuffManTree, int>();
            for(var i =0;i<weights.Length;i++)
            {
                var ht = new HuffManTree {
                    
                    Weight = weights[i],
                    Data = s[i]
                };
                priorityQueue.Enqueue(ht, ht.Weight);
            }
            while(priorityQueue.Count > 1)
            {
                var left = priorityQueue.Dequeue();
                var right = priorityQueue.Dequeue();
                var newNode = new HuffManTree
                {
                    Left = left,
                    Right = right,
                    Weight = left.Weight+right.Weight
                };
                left.Parent= newNode;
                right.Parent = newNode;
                priorityQueue.Enqueue(newNode, newNode.Weight);
            }

            //测试i,与算法无关
            var i1 = 0;
            for (; i1 < 5; i1++)
                Console.Write($",{i1}");
            return priorityQueue.Dequeue();
        }

        public HuffManTree BuildTreeWithoutPriorityQueue(string[] s, int[] weights)
        {
            var nodes = new List<HuffManTree>();
            for(var i=0;i<weights.Length; i++)
            {
                var node = new HuffManTree { Data = s[i], Weight = weights[i] };
                nodes.Add(node);
            }
            while(nodes.Count > 1)
            {
                var minIndex1 = 0;
                var minIndex2 = 1;
                for(var i=2;i<nodes.Count;i++)
                {
                    if (nodes[i].Weight < nodes[minIndex1].Weight)
                    {
                        minIndex2 = minIndex1;
                        minIndex1 = i;
                    }else if (nodes[i].Weight < nodes[minIndex2].Weight)
                    {
                        minIndex2 = i;
                    }
                }
                var newNode = new HuffManTree { Left = nodes[minIndex1],Right = nodes[minIndex2],Weight = nodes[minIndex1].Weight + nodes[minIndex2].Weight };
                nodes[minIndex1].Parent = newNode;
                nodes[minIndex2].Parent = newNode;
                nodes.RemoveAt(Math.Max(minIndex1,minIndex2));
                nodes.RemoveAt(Math.Min(minIndex1,minIndex2));
                nodes.Add(newNode);
            }
            return nodes[0];
        }
    }
}
