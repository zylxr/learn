using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithm.Graph.DFS;

namespace Algorithm.Graph
{
    public class RunGraphUtil
    {
        public static void RunGraph()
        {
            var graphWithAdjMatrix = new GraphWithAdjMatrix(4);
            graphWithAdjMatrix.AddEdge(0, 1);
            graphWithAdjMatrix.AddEdge(0, 2);
            graphWithAdjMatrix.AddEdge(1, 2);
            graphWithAdjMatrix.AddEdge(2,0);
            graphWithAdjMatrix.AddEdge(2, 3);
            graphWithAdjMatrix.AddEdge(3,3);
            var startVertex = 2;
            Console.WriteLine($"Depth First Traversal Starting from vertex {startVertex}");
            graphWithAdjMatrix.Dfs(2);

            var graphWithAdjList = new GraphWithAdjList(4);
            graphWithAdjList.AddEdge(0, 1);
            graphWithAdjList.AddEdge(0, 2);
            graphWithAdjList.AddEdge(1, 2);
            graphWithAdjList.AddEdge(2, 0);
            graphWithAdjList.AddEdge(2, 3);
            graphWithAdjList.AddEdge(3, 3);
            Console.WriteLine($"Depth First Traversal using AdjList Starting from vertex {startVertex}");
            graphWithAdjList.DFS(2);

            var graphWithAdjListBFS = new BFSGraphWithAdjList(4);
            graphWithAdjListBFS.AddEdge(0, 1);
            graphWithAdjListBFS.AddEdge(0, 2);
            graphWithAdjListBFS.AddEdge(1, 2);
            graphWithAdjListBFS.AddEdge(2, 0);
            graphWithAdjListBFS.AddEdge(2, 3);
            graphWithAdjListBFS.AddEdge(3, 3);
            Console.WriteLine($"Breadth First Traversal using AdjList Starting from vertex {startVertex}");
            graphWithAdjListBFS.BFS(2);

            var graphWithAdjMatrixBFS = new BFSGraphWithAdjMatrix(4);
            graphWithAdjMatrixBFS.AddEdge(0, 1);
            graphWithAdjMatrixBFS.AddEdge(0, 2);
            graphWithAdjMatrixBFS.AddEdge(1, 2);
            graphWithAdjMatrixBFS.AddEdge(2, 0);
            graphWithAdjMatrixBFS.AddEdge(2, 3);
            graphWithAdjMatrixBFS.AddEdge(3, 3);
            Console.WriteLine($"Breadth First Traversal using Adj Matrix Starting from vertex {startVertex}");
            graphWithAdjMatrixBFS.BFS(2);

            var primMST = new PrimMST(5);
            primMST.AddEdge(0, 1, 2);
            primMST.AddEdge(0, 3, 6);
            primMST.AddEdge(1, 2, 3);
            primMST.AddEdge(1, 3, 8);
            primMST.AddEdge(1, 4, 5);
            primMST.AddEdge(2, 4, 7);
            primMST.AddEdge(3, 4, 9);
            primMST.MST();

            var kruskalMST = new KruskalMST(4);
            kruskalMST.AddEdge(0, 1, 10);
            kruskalMST.AddEdge(0, 2, 6);
            kruskalMST.AddEdge(0, 3, 5);
            kruskalMST.AddEdge(1, 2, 15);
            kruskalMST.AddEdge(2, 3, 4);

            var mst_wt = kruskalMST.MST();

            var dijkstraWithAdjList = new DijkstraWithAdjLink(9);
            dijkstraWithAdjList.AddEdge(0, 1, 4);
            dijkstraWithAdjList.AddEdge(0, 7, 8);
            dijkstraWithAdjList.AddEdge(1, 2, 8);
            dijkstraWithAdjList.AddEdge(1, 7, 11);
            dijkstraWithAdjList.AddEdge(2, 8, 2);
            dijkstraWithAdjList.AddEdge(2, 3, 7);
            dijkstraWithAdjList.AddEdge(2, 5, 4);
            dijkstraWithAdjList.AddEdge(3, 4, 9);
            dijkstraWithAdjList.AddEdge(3, 5, 14);
            dijkstraWithAdjList.AddEdge(4, 5, 10);
            dijkstraWithAdjList.AddEdge(5, 6, 2);
            dijkstraWithAdjList.AddEdge(6, 7, 1);
            dijkstraWithAdjList.AddEdge(6, 8, 6);
            dijkstraWithAdjList.AddEdge(7, 8, 7);

            var distances = dijkstraWithAdjList.Dijkstra(0); // Find shortest paths from vertex 0

            Console.WriteLine("Vertex \t\tDistance from Source");
            for (int i = 0; i < distances.Length; ++i)
                Console.WriteLine(i + "\t\t" + distances[i]);


            var dijkstraWithAdjMatrix = new DijkstraWithAdjMatrix(9);
            dijkstraWithAdjMatrix.AddEdge(0, 1, 4);
            dijkstraWithAdjMatrix.AddEdge(0, 7, 8);
            dijkstraWithAdjMatrix.AddEdge(1, 2, 8);
            dijkstraWithAdjMatrix.AddEdge(1, 7, 11);
            dijkstraWithAdjMatrix.AddEdge(2, 8, 2);
            dijkstraWithAdjMatrix.AddEdge(2, 3, 7);
            dijkstraWithAdjMatrix.AddEdge(2, 5, 4);
            dijkstraWithAdjMatrix.AddEdge(3, 4, 9);
            dijkstraWithAdjMatrix.AddEdge(3, 5, 14);
            dijkstraWithAdjMatrix.AddEdge(4, 5, 10);
            dijkstraWithAdjMatrix.AddEdge(5, 6, 2);
            dijkstraWithAdjMatrix.AddEdge(6, 7, 1);
            dijkstraWithAdjMatrix.AddEdge(6, 8, 6);
            dijkstraWithAdjMatrix.AddEdge(7, 8, 7);

            distances = dijkstraWithAdjMatrix.Dijkstra(0); // Find shortest paths from vertex 0

            Console.WriteLine("Vertex \t\tDistance from Source");
            for (int i = 0; i < distances.Length; ++i)
                Console.WriteLine(i + "\t\t" + distances[i]);

            var INF = decimal.MaxValue;
            decimal[,] graph = { { 0, 3, INF, 7 },
                   { INF, 0, 4, 1 },
                   { 1, INF, 0, 5 },
                   { INF, INF, INF, 0 } };
            var floyWarshal = new FloydWarshallGraph();
            floyWarshal.FloydWarshall(graph);
        }
    }
}
