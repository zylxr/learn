using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class NetworkDelayTimeClass
    {
        //743. 网络延迟时间
        //有 n 个网络节点，标记为 1 到 n。

        //给你一个列表 times，表示信号经过 有向 边的传递时间。 times[i] = (ui, vi, wi)，其中 ui 是源节点，vi 是目标节点， wi 是一个信号从源节点传递到目标节点的时间。

        //现在，从某个节点 K 发出一个信号。需要多久才能使所有节点都收到信号？如果不能使所有节点收到信号，返回 -1 。



        //示例 1：



        //输入：times = [[2, 1, 1],[2, 3, 1],[3, 4, 1]], n = 4, k = 2
        //输出：2
        //示例 2：

        //输入：times = [[1, 2, 1]], n = 2, k = 1
        //输出：1
        //示例 3：

        //输入：times = [[1, 2, 1]], n = 2, k = 2
        //输出：-1


        //提示：

        //1 <= k <= n <= 100
        //1 <= times.length <= 6000
        //times[i].length == 3
        //1 <= ui, vi <= n
        //ui != vi
        //0 <= wi <= 100
        //所有(ui, vi) 对都 互不相同（即，不含重复边）

        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            const int INF = int.MaxValue / 2;
            var g = new int[n, n];
            for(var i=0;i<n;i++)
            {
                for(var j= 0;j<n;j++)
                {
                    g[i, j] = INF;
                }
            }
            foreach(var t in times)
            {
                var x = t[0] - 1;
                var y = t[1] - 1;
                g[x, y] = t[2];
            }

            var dist = new int[n];
            Array.Fill(dist, INF);
            dist[k - 1] = 0;
            var used = new bool[n];
            for(var i=0;i<n;i++)
            {
                var x = -1;
                for(var y=0;y<n;y++)
                {
                    if (!used[y] && (x == -1 || dist[y] < dist[x]))
                    {
                        x = y;
                    }
                }
                used[x] = true;
                for (var y = 0; y < n; y++)
                    dist[y] = Math.Min(dist[y], dist[x] + g[x, y]);
            }
            var ans = dist.Max();
            return ans == INF ? -1 : ans;
        }

        public int NetworkDelayTime2(int[][] times, int n, int k)
        {
            const int INF = int.MaxValue / 2;
            var adj = new List<(int, int)>[n];
            for(var i=0;i<n;i++)
            {
                adj[i] = new List<(int, int)>();
            }
            foreach(var t in times)
            {
                adj[t[0]-1].Add((t[1]-1, t[2]));
            }

            var dist = new int[n];
            Array.Fill(dist, INF);
            dist[k - 1] = 0;
            var priorityQueue = new PriorityQueue<int, int>();
            priorityQueue.Enqueue(k - 1, 0);
            var visited = new bool[n];
            while (priorityQueue.Count > 0) { 
                var item = priorityQueue.Dequeue();
                if (visited[item]) continue;
                foreach(var node in adj[item])
                {
                    dist[node.Item1] = Math.Min(dist[node.Item1], dist[item]+node.Item2);
                    priorityQueue.Enqueue(node.Item1, dist[node.Item1]);
                }
                visited[item] = true;
            }
            var ans = dist.Max();
            return ans == INF ? -1 : ans;
        }
    }
}
