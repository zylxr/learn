using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public class GraphEdge
    {
        public int Vertex { get; set; }
        public decimal Distance { get; set; }
    }

    public class DijkstraWithAdjMatrix
    {
        private int _v;
        private decimal[,] adj; // Adjacency matrix representation
        public DijkstraWithAdjMatrix(int n)
        {
            _v = n;
            adj = new decimal[n, n];
        }
        public void AddEdge(int v,int w, decimal weight)
        {
            adj[v,w] = weight;// Mark weight for edge between v and w
        }

        // Function to implement Dijkstra's algorithm with adjacency matrix
        public decimal[] Dijkstra(int src)
        {
            var dist = new decimal[_v];
            for(var i=0;i< _v;i++)
            {
                dist[i] = decimal.MaxValue;
            }
            dist[src] = 0;
            // Create a set to track processed vertices
            var visited = new bool[_v];
            for(var i=0;i< _v; i++)
            {
                // Pick the minimum distance vertex from the set of vertices not yet processed
                var u = MinDistance(dist, visited);

                // Mark the picked vertex as processed
                visited[u] = true;
                // Update distance of adjacent vertices of the picked vertex
                for(var v=0;v<_v;v++)
                {
                    // Update dist[v] only if it is not visited, there is an edge from u to v, 
                    // and total weight of path from src to v through u is smaller than current value of dist[v]
                    if (!visited[v] && adj[u, v] !=0 && adj[u, v] + dist[u] < dist[v])
                        dist[v] = adj[u, v] + dist[u];
                }
            }
            return dist;
        }

        // Utility function to find the vertex with minimum distance among
        // the non-processed vertices
        private int MinDistance(decimal[] dist, bool[] visited)
        {
            var min = decimal.MaxValue;
            var minIndex = -1;
            for(var i=0;i< _v;i++)
            {
                if (!visited[i] && dist[i]<min)
                {
                    min = dist[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
    }

    public class DijkstraWithAdjLink
    {
        private int _v;
        private List<GraphEdge>[] _adj;

        public DijkstraWithAdjLink(int n)
        {
            this._v = n;
            _adj = new List<GraphEdge>[n];
            for(var i=0;i < n; i++)
                _adj[i] = new List<GraphEdge>();
        }

        // Function to implement Dijkstra's algorithm for shortest paths
        public decimal[] Dijkstra(int src)
        {
            var dist = new decimal[_v];
            for (var i = 0; i < _v; i++)
                dist[i] = decimal.MaxValue;
            dist[src] = 0;
            // Create a Min-Heap for vertices not yet included in Shortest Path Tree
            var queue = new PriorityQueue<GraphEdge, decimal>();
            queue.Enqueue(new GraphEdge { Distance = 0,Vertex = src },0);

            while(queue.Count > 0)
            {
                var u = queue.Dequeue();
                foreach(var item in _adj[u.Vertex])
                {
                    var d = item.Vertex;
                    var w = item.Distance;
                    if (dist[d] > w + dist[u.Vertex])
                    {
                        dist[d] = w + dist[u.Vertex];
                        queue.Enqueue(new GraphEdge { Vertex = d, Distance = w }, d);
                    }
                }
            }
            return dist;
        }

        public void AddEdge(int x,int y,decimal distance)
        {
            _adj[x].Add(new GraphEdge { Vertex = y,Distance = distance });
        }
    }
}
