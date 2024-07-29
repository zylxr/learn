using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public class FloydWarshallGraph
    {
        public void FloydWarshall(decimal[,] graph)
        {
            var  n = graph.GetLength(0);
            var dist = new decimal[n, n];
            for(var i=0;i < n; i++)
            {
                for(var j=0;j < n; j++)
                {
                    dist[i,j] = graph[i,j];
                }
            }

            for (var k = 0; k < n; k++) 
            {
                for(var j=0;j < n;j++)
                {
                    for (var i = 0; i < n; i++)
                    {
                        // Relaxation step: If going through k makes a shorter path, update distance
                        if ( dist[i,k] !=decimal.MaxValue && dist[k,j] != decimal.MaxValue && dist[i, j] > dist[i, k] + dist[k, j])
                        {
                            dist[i,j] = dist[i, k] + dist[k,j];
                        }
                    }
                }
            }

            // Print the shortest distance matrix
            PrintDistanceMatrix(dist);
        }

        // Function to print the distance matrix
        void PrintDistanceMatrix(decimal[,] dist)
        {
            Console.WriteLine($"Shortest distance matrix");
            for(var i = 0;i<dist.GetLength(0);i++)
            {
                for(var j=0;j<dist.GetLength(1);j++)
                {
                    if (dist[i,j] == decimal.MaxValue)
                    {
                        Console.WriteLine($"INF".PadLeft(7));
                    }else
                    {
                        Console.WriteLine($"{dist[i,j]}".PadLeft(7));
                    }
                }
            }
        }
    }
}
