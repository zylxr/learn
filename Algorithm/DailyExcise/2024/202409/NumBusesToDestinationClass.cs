using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class NumBusesToDestinationClass
    {
        //815. 公交路线
        //给你一个数组 routes ，表示一系列公交线路，其中每个 routes[i] 表示一条公交线路，第 i 辆公交车将会在上面循环行驶。

        //例如，路线 routes[0] = [1, 5, 7] 表示第 0 辆公交车会一直按序列 1 -> 5 -> 7 -> 1 -> 5 -> 7 -> 1 -> ... 这样的车站路线行驶。
        //现在从 source 车站出发（初始时不在公交车上），要前往 target 车站。 期间仅可乘坐公交车。

        //求出 最少乘坐的公交车数量 。如果不可能到达终点车站，返回 -1 。



        //示例 1：

        //输入：routes = [[1, 2, 7],[3, 6, 7]], source = 1, target = 6
        //输出：2
        //解释：最优策略是先乘坐第一辆公交车到达车站 7 , 然后换乘第二辆公交车到车站 6 。 
        //示例 2：

        //输入：routes = [[7, 12],[4, 5, 15],[6],[15, 19],[9, 12, 13]], source = 15, target = 12
        //输出：-1


        //提示：

        //1 <= routes.length <= 500.
        //1 <= routes[i].length <= 105
        //routes[i] 中的所有值 互不相同
        //sum(routes[i].length) <= 105
        //0 <= routes[i][j] < 106
        //0 <= source, target< 106
        public int NumBusesToDestination(int[][] routes, int source, int target)
        {
            if (source == target) return 0;
            var n = routes.Length;
            var edge = new bool[n, n];
            var dict = new Dictionary<int, IList<int>>();
            for (var i = 0; i < n; i++)
            {
                foreach (var site in routes[i])
                {
                    var list = new List<int>();
                    dict.TryAdd(site, list);
                    foreach (var j in dict[site])
                    {
                        edge[i, j] = edge[j, i] = true;
                    }
                    dict[site].Add(i);
                }
            }
            var dis = new int[n];
            Array.Fill(dis, -1);
            var queue = new Queue<int>();
            if (dict.ContainsKey(source))
            {
                foreach (var bus in dict[source])
                {
                    dis[bus] = 1;
                    queue.Enqueue(bus);
                }
            }
            while (queue.Count > 0)
            {
                var x = queue.Dequeue();
                for (var y = 0; y < n; y++)
                {
                    if (edge[x, y] && dis[y] == -1)
                    {
                        dis[y] = dis[x] + 1;
                        queue.Enqueue(y);
                    }
                }
            }
            var ret = int.MaxValue;
            if(dict.ContainsKey(target))
            {
                foreach(var bus in dict[target])
                {
                    if (dis[bus] != -1)
                        ret =Math.Min(ret,dis[bus]);
                }
            }
            return ret == int.MaxValue ? -1 : ret;
        }
    }
}
