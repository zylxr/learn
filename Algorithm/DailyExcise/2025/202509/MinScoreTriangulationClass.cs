using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinScoreTriangulationClass
    {
        //1039. 多边形三角剖分的最低得分
        //你有一个凸的 n 边形，其每个顶点都有一个整数值。给定一个整数数组 values ，其中 values[i] 是第 i 个顶点的值（即 顺时针顺序 ）。

        //假设将多边形 剖分 为 n - 2 个三角形。对于每个三角形，该三角形的值是顶点标记的乘积，三角剖分的分数是进行三角剖分后所有 n - 2 个三角形的值之和。

        //返回 多边形进行三角剖分后可以得到的最低分 。



        //示例 1：



        //输入：values = [1, 2, 3]
        //输出：6
        //解释：多边形已经三角化，唯一三角形的分数为 6。
        //示例 2：



        //输入：values = [3, 7, 4, 5]
        //输出：144
        //解释：有两种三角剖分，可能得分分别为：3*7*5 + 4*5*7 = 245，或 3*4*5 + 3*4*7 = 144。最低分数为 144。
        //示例 3：



        //输入：values = [1, 3, 1, 4, 1, 5]
        //输出：13
        //解释：最低分数三角剖分的得分情况为 1*1*3 + 1*1*4 + 1*1*5 + 1*1*1 = 13。


        //提示：

        //n == values.length
        //3 <= n <= 50
        //1 <= values[i] <= 100

        public int MinScoreTriangulation(int[] values)
        {
            var ans = 0;
            var n = values.Length;
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < n; i++)
            {
                dict[i] = n - 1;
            }
            Array.Sort(values);
            var low1 = 0;
            var low2 = 1;
            var cnt = 0;
            for (var i = n - 1; i > -1; i--)
            {
                var m = values[i];
                dict[i]--;
                if (dict[low1] == 0) low1 += 2;
                if (dict[low2] == 0) low2 += 2;
                ans += m * values[low1] * values[low2];
                cnt++;
                dict[low1]--;
                dict[low2]--;
                if (cnt == n - 2) break;
            }
            return ans;
        }

        public int MinScoreTriangulation2(int[] values)
        {
            this.n = values.Length;
            this.values = values;
            return Dp(0, n - 1);
        }

        public int[] values;
        public int n;
        public Dictionary<int,int> memo = new Dictionary<int,int>();
        public int Dp(int i,int j)
        {
            if (i + 2 > j) return 0;
            if(i+2==j)return values[i] * values[i + 1]*values[i + 2];
            var key = i * n + j;
            if(!memo.ContainsKey(key))
            {
                var minScore = int.MaxValue;
                for(var k=i+1;k<j;k++)
                {
                    minScore = Math.Min(minScore, values[i] * values[k] * values[j] + Dp(i, k) + Dp(k,j));
                }
                memo[key] = minScore;
            }
            return memo[key];
        }
    }
}
