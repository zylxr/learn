using Algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class ShortestDistanceAfterQueriesClass
    {
        //3243. 新增道路查询后的最短距离 I
        //给你一个整数 n 和一个二维整数数组 queries。

        //有 n 个城市，编号从 0 到 n - 1。初始时，每个城市 i 都有一条单向道路通往城市 i + 1（ 0 <= i<n - 1）。

        //queries[i] = [ui, vi] 表示新建一条从城市 ui 到城市 vi 的单向道路。每次查询后，你需要找到从城市 0 到城市 n - 1 的最短路径的长度。

        //返回一个数组 answer，对于范围[0, queries.length - 1] 中的每个 i，answer[i] 是处理完前 i + 1 个查询后，从城市 0 到城市 n - 1 的最短路径的长度。



        //示例 1：

        //输入： n = 5, queries = [[2, 4], [0, 2], [0, 4]]

        //输出： [3, 2, 1]

        //解释：



        //新增一条从 2 到 4 的道路后，从 0 到 4 的最短路径长度为 3。



        //新增一条从 0 到 2 的道路后，从 0 到 4 的最短路径长度为 2。



        //新增一条从 0 到 4 的道路后，从 0 到 4 的最短路径长度为 1。

        //示例 2：

        //输入： n = 4, queries = [[0, 3], [0, 2]]

        //输出： [1, 1]

        //解释：



        //新增一条从 0 到 3 的道路后，从 0 到 3 的最短路径长度为 1。



        //新增一条从 0 到 2 的道路后，从 0 到 3 的最短路径长度仍为 1。



        //提示：

        //3 <= n <= 500
        //1 <= queries.length <= 500
        //queries[i].length == 2
        //0 <= queries[i][0] < queries[i][1] < n
        //1 < queries[i][1] - queries[i][0]
        //查询中没有重复的道路。
        public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
        {
            var neighbors = new List<List<int>>();
            for (var i = 0; i < n; i++)
                neighbors.Add(new List<int>());
            for (var i = 0; i < n - 1; i++)
                neighbors[i].Add(i + 1);
            var res = new int[queries.Length];
            for(var i=0;i<queries.Length; i++)
            {
                neighbors[queries[i][0]].Add(queries[i][1]);
                res[i] = BFS(n, neighbors);
            }
            return res;
        }

        public int BFS(int n,List<List<int>> neighbors)
        {
            var dist = new int[n];
            for (var i = 0; i < n; i++)
                dist[i] = -1;
            var queue = new Queue<int>();
            queue.Enqueue(0);
            dist[0] = 0;
            while(queue.Count>0)
            {
                var x = queue.Dequeue();
                foreach(var y in neighbors[x])
                {
                    if (dist[y]>=0)continue;
                    queue.Enqueue(y);
                    dist[y] = dist[x] + 1;
                }
            }
            return dist[n - 1];
        }
    
        public int[] ShortestDistanceAfterQueries2(int n, int[][] queries)
        {
            var prev = new List<List<int>>();
            for (var i = 0; i < n; i++)
            {
                prev.Add(new List<int>());
            }
            var dp = new int[n];
            for(var i=1;i<n;i++)
            {
                prev[i].Add(i - 1);
                dp[i] = i;
            }
            var res = new int[queries.Length];
            for(var i=0;i<queries.Length;i++)
            {
                prev[queries[i][1]].Add(queries[i][0]);
                for(var v= queries[i][1];v<n;v++)
                {
                    foreach (var u in prev[v])
                        dp[v] = Math.Min(dp[v], dp[u] + 1);
                }
                res[i] = dp[n - 1];
            }
            return res;
        }
    }
}
