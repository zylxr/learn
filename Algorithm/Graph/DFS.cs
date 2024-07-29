using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public class DFS
    {
        //邻接链表 adjacent list
        public class GraphWithAdjList
        {
            private int n;
            private List<int>[] adjList;
            public GraphWithAdjList(int n)
            {
                this.n = n;
                adjList = new List<int>[n];
                for(var i=0;i<n;i++)
                {
                    adjList[i] = new List<int>(); 
                }
            }

            public void AddEdge(int x,int y)
            {
                adjList[x].Add(y);
            }

            public void DFS(int v)
            {
                var visited = new bool[n];
                DFSUtil(v, visited);
            }

            void DFSUtil(int v, bool[] visited)
            {
                visited[v] = true;
                Console.WriteLine($"DFS With List visit:{v}");
                for(var i = 0; i < adjList[v].Count;i++)
                {
                    var item = adjList[v][i];
                    if (!visited[item])
                        DFSUtil(item, visited);
                }
            }
        }

        //邻接矩阵 Adjacent matrix
        public class GraphWithAdjMatrix
        {
            private int n;
            private int[,] adj;

            public GraphWithAdjMatrix(int v)
            {
                this.n = v;
                adj = new int[n, n];
            }

            public void AddEdge(int x, int y)
            {
                adj[x, y] = 1;
            }
            public void Dfs(int v)
            {
                var visited = new bool[this.n];
                DFSUtil(v, visited);
            }
            void DFSUtil(int v, bool[] visited)
            {
                visited[v] = true;
                Console.WriteLine($"{v} is visited");
                for (var i = 0; i < n; i++)
                {
                    if (adj[v, i] == 1 && !visited[i])
                        DFSUtil(i, visited);
                }
            }
        }
    }
}
