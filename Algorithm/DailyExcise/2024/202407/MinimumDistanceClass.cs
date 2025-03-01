using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinimumDistanceClass
    {
        //给你一个下标从 0 开始的数组 points ，它表示二维平面上一些点的整数坐标，其中 points[i] = [xi, yi] 。两点之间的距离定义为它们的曼哈顿距离。

        //请你恰好移除一个点，返回移除后任意两点之间的 最大 距离可能的 最小 值。
        //示例 1：
        //输入：points = [[3, 10],[5, 15],[10, 2],[4, 4]]
        //输出：12
        //解释：移除每个点后的最大距离如下所示：
        //- 移除第 0 个点后，最大距离在点(5, 15) 和(10, 2) 之间，为 |5 - 10| + |15 - 2| = 18 。
        //- 移除第 1 个点后，最大距离在点(3, 10) 和(10, 2) 之间，为 |3 - 10| + |10 - 2| = 15 。
        //- 移除第 2 个点后，最大距离在点(5, 15) 和(4, 4) 之间，为 |5 - 4| + |15 - 4| = 12 。
        //- 移除第 3 个点后，最大距离在点(5, 15) 和(10, 2) 之间的，为 |5 - 10| + |15 - 2| = 18 。
        //在恰好移除一个点后，任意两点之间的最大距离可能的最小值是 12 。
        //示例 2：

        //输入：points = [[1, 1],[1, 1],[1, 1]]
        //输出：0
        //解释：移除任一点后，任意两点之间的最大距离都是 0 。


        //提示：

        //3 <= points.length <= 105
        //points[i].length == 2
        //1 <= points[i][0], points[i][1] <= 108

        //https://oi-wiki.org/geometry/distance/#%E6%9B%BC%E5%93%88%E9%A1%BF%E8%B7%9D%E7%A6%BB%E4%B8%8E%E5%88%87%E6%AF%94%E9%9B%AA%E5%A4%AB%E8%B7%9D%E7%A6%BB%E7%9A%84%E7%9B%B8%E4%BA%92%E8%BD%AC%E5%8C%96
        public int MinimumDistance(int[][] points)
        {
            var sx = new SortedDictionary<int, int>();
            var sy = new SortedDictionary<int, int>();
            foreach(var p in points)
            {
                var diff = p[0] - p[1];
                var sum = p[0] + p[1];
                if(!sx.ContainsKey(diff)) sx[diff] = 0;
                sx[diff]++;
                if(!sy.ContainsKey(sum)) sy[sum] = 0;
                sy[sum]++;
            }
            var res = int.MaxValue;
            foreach(var p in points)
            {
                var diff = p[0] - p[1];
                var sum = p[0] + p[1];
                sx[diff]--;
                if (sx[diff] == 0)sx.Remove(diff);
                sy[sum]--;
                if (sy[sum] == 0) sy.Remove(sum);
                res = Math.Min(res,Math.Max(sx.Last().Key - sx.First().Key,sy.Last().Key - sy.First().Key));

                if (!sx.ContainsKey(diff)) sx[diff] = 0;
                sx[diff]++;
                if (!sy.ContainsKey(sum)) sy[sum] = 0;
                sy[sum]++;
            }
            return res;
        }
    }
}
