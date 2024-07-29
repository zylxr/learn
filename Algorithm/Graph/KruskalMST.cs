using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public class KruskalEdge
    {
        public int Src { get; set; }
        public int Dest { get; set; }
        public decimal Weight { get; set; }
    }
    public class KruskalMST
    {
        private int n;
        private List<KruskalEdge>[] adj;

        public KruskalMST(int n)
        {
            this.n = n;
            adj = new List<KruskalEdge>[n];
            for(var i=0;i<n;i++) adj[i] = new List<KruskalEdge>();
        }
        public void AddEdge(int x,int y,decimal weight)
        {
            adj[x].Add(new KruskalEdge { Src = x, Dest = y, Weight = weight });
        }

        public decimal MST()
        {
            var minCost = 0.0m;
            // Sort edges by weight in non-decreasing order
            var edges = new List<KruskalEdge>();
            for(var i=0;i<n; i++)
            {
                foreach(var item in adj[i])
                {
                    edges.Add(item);
                }
            }
            edges.Sort((x,y)=>x.Weight.CompareTo(y.Weight));
            // Create Union-Find data structure to check for cycles
            var parent = new int[n];
            for (var i = 0; i < n; i++)
                parent[i] = -1;
            // Include edges in MST one by one
            foreach (var edge in edges)
            {
                var x = Find(parent,edge.Src);
                var y = Find(parent,edge.Dest);
                // If including this edge doesn't cause a cycle
                if (x!= y)
                {
                    minCost += edge.Weight;
                    Union(parent,x, y);
                }
            }
            return minCost;
        }

        private int Find(int[] parent,int i)
        {
            if (parent[i] == -1) return i;
            return Find(parent, parent[i]);
        }

        private void Union(int[] parent,int x,int y)
        {
            var xset =Find(parent, x);
            var yset = Find(parent, y);
            // Attach the smaller tree under the root of the larger tree
            if (xset != yset)
            {
                parent[xset] = yset;
            }
        }
    }
}
