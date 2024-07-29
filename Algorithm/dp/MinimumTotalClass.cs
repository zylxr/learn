using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class MinimumTotalClass
    {
        //给定一个三角形 triangle ，找出自顶向下的最小路径和。
        //每一步只能移动到下一行中相邻的结点上。相邻的结点 在这里指的是 下标 与 上一层结点下标 相同或者等于 上一层结点下标 + 1 的两个结点。
        //也就是说，如果正位于当前行的下标 i ，那么下一步可以移动到下一行的下标 i 或 i + 1 。
        //示例 1：
        //输入：triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
        //输出：11
        //解释：如下面简图所示：
        //2
        //3 4
        //6 5 7
        //4 1 8 3
        //自顶向下的最小路径和为 11（即，2 + 3 + 5 + 1 = 11）。
        //示例 2：

        //输入：triangle = [[-10]]
        //输出：-10
        //提示：
        //1 <= triangle.length <= 200
        //triangle[0].length == 1
        //triangle[i].length == triangle[i - 1].length + 1
        //-104 <= triangle[i][j] <= 104
        public int MinimumTotal(List<List<int>> triangle)
        {
            var n = triangle.Count;
            if(n == 0) return 0;
            for(var i=n-2;i>=0;i--)
            {
                var m = triangle[i].Count;
                for(var j=0;j<m;j++)
                {
                    triangle[i][j] += Math.Min(triangle[i + 1][j], triangle[i + 1][j+1]);
                }
            }
            return triangle[0][0];
        }

        public int MinimumTotal1(List<List<int>> triangle)
        {
            var n = triangle.Count;
            if(n == 0) return 0;
            var m = triangle[n - 1].Count;
            var dp = new int[n, m];
            dp[0, 0] = triangle[0][0];
            for(var i=1;i<n;i++)
            {
                var l = triangle[i].Count;
                dp[i, 0] = dp[i - 1, 0] + triangle[i][0];
                for (var j=1;j<l;j++)
                {
                    if (j == l - 1)
                    {
                        dp[i,j] = dp[i-1, j-1] + triangle[i][j];
                    }else
                        dp[i, j] = Math.Min(dp[i-1, j], dp[i-1, j -1]) + triangle[i][j];
                }
            }
            var minTotal = dp[n-1,0];
            for(var i=0;i<m;i++)
            {
                minTotal = Math.Min(minTotal, dp[n - 1, i]);
            }
            return minTotal;
        }
    }
}
