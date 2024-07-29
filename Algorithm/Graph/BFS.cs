using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    //Adjacent List
    public class BFSGraphWithAdjList
    {
        private int n;
        private List<int>[] adj;

        public BFSGraphWithAdjList(int n)
        {
            this.n = n;
            this.adj = new List<int>[n];
            for(var i=0;i < n; i++)
            {
                adj[i] = new List<int>();
            }
        }
        public void AddEdge(int x,int y)
        {
            adj[x].Add(y);
        }

        public void BFS( int v)
        {
            var visited = new bool[n];
            var queue = new Queue<int>();
            visited[v] = true;
            Console.WriteLine($"Breadth First traversal with Adjacent list,vertext:{v}");
            queue.Enqueue(v);
            while(queue.Count > 0)
            {
                v = queue.Dequeue();
                foreach(var item in adj[v])
                {
                    if (!visited[item])
                    {
                        visited[item] = true;
                        queue.Enqueue(item);
                        Console.WriteLine($"Breadth First traversal with Adjacent list,vertext:{item}");
                    }
                }
            }
        }
    }

    public class BFSGraphWithAdjMatrix
    {
        private int n;
        private int[,] adj;

        public BFSGraphWithAdjMatrix(int n)
        {
            this.n = n;
            adj = new int[n, n];
        }

        public void AddEdge(int x,int y)
        {
            adj[x, y] = 1;
        }

        public void BFS(int v)
        {
            var visited = new bool[n];
            var queue = new Queue<int>();
            visited[v] = true;
            Console.WriteLine($"Breadth First traversal with Adjacent matrix,vertext:{v}");
            queue.Enqueue(v);
            while (queue.Count>0)
            {
                var s = queue.Dequeue();
                for(var i=0;i<n;i++)
                {
                    if (!visited[i] && adj[s,i] == 1)
                    {
                        visited[i] = true;
                        Console.WriteLine($"Breadth First traversal with Adjacent matrix,vertext:{i}");
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
