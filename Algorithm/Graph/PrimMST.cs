using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public class PrimEdge
    {
        public int To { get; set; }
        public decimal Weight { get; set; }
    }
    public class PrimMST
    {
        private int n;
        private decimal[,] adj;

        public PrimMST(int n)
        {
            this.n = n;
            adj = new decimal[n, n];
        }
        public void AddEdge(int x,int y, decimal weight)
        {
            adj[x, y] = weight;
        }

        public void MST()
        {
            var visited = new bool[n];
            var parent = new int[n];
            var keys = new decimal[n];
            
            keys[0] = 0;
            visited[0]= true;
            parent[0] = -1;
            var queue = new CustomPriorityQueue<int, decimal>();
            queue.EnQueue(0, keys[0]);
            for(var i =1;i<n; i++)
            {
                keys[i] = decimal.MaxValue;
                queue.EnQueue(i, keys[i]);
            }
            while(!queue.IsEmpty())
            {
                var u = queue.Dequeue();
                visited[u.Item1] = true;
                for(var i=0;i<n;i++)
                {
                    if (adj[u.Item1,i]>0 && !visited[i] &&adj[u.Item1,i]<keys[i])
                    {
                        parent[i] = u.Item1;
                        keys[i] = adj[u.Item1,i];
                        queue.UpdatePriority(i, keys[i]);
                    }
                }
            }
        }
    }
}
