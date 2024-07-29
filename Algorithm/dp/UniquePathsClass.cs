using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class UniquePathsClass
    {
        //一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为 “Start” ）。
        //机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为 “Finish” ）。
        //问总共有多少条不同的路径？
        //示例 1：
        //输入：m = 3, n = 7
        //输出：28
        //示例 2：
        //输入：m = 3, n = 2
        //输出：3
        //解释：
        //从左上角开始，总共有 3 条路径可以到达右下角。
        //1. 向右 -> 向下 -> 向下
        //2. 向下 -> 向下 -> 向右
        //3. 向下 -> 向右 -> 向下
        //示例 3：
        //输入：m = 7, n = 3
        //输出：28
        //示例 4：
        //输入：m = 3, n = 3
        //输出：6
        public int UniquePaths(int m, int n)
        {
            var dp = new int[m, n];
            for (var i = 0; i <m; i++)
                dp[i, 0] = 1;
            for (var j = 0; j < n; j++)
                dp[0, j] = 1;
            for(var i= 1;i< m ; i++)
            {
                for(var j = 1;j<n;j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
            return dp[m-1, n-1];
        }

        public int UniquePathsOptimize1(int m,int n)
        {
            var dp = new int[n];
            for (var i = 0; i < n; i++)
                dp[i] = 1;
            for(var i=1;i<m;i++)
            {
                for(var j=1;j<n;j++)
                {
                    dp[j] += dp[j - 1];
                }
            }
            return dp[n - 1];
        }
    }
}
