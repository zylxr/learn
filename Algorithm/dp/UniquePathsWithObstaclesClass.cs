using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class UniquePathsWithObstaclesClass
    {
        //一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为 “Start” ）。
        //机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为 “Finish”）。
        //现在考虑网格中有障碍物。那么从左上角到右下角将会有多少条不同的路径？
        //网格中的障碍物和空位置分别用 1 和 0 来表示。
        //示例 1：
        //输入：obstacleGrid = [[0,0,0],[0,1,0],[0,0,0]]
        //输出：2
        //解释：3x3 网格的正中间有一个障碍物。
        //从左上角到右下角一共有 2 条不同的路径：
        //1. 向右 -> 向右 -> 向下 -> 向下
        //2. 向下 -> 向下 -> 向右 -> 向右
        //示例 2：
        //输入：obstacleGrid = [[0,1],[0,0]]
        //输出：1
        //提示：
        //m == obstacleGrid.length
        //n == obstacleGrid[i].length
        //1 <= m, n <= 100
        //obstacleGrid[i][j] 为 0 或 1
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var m = obstacleGrid.Length;
            if(m== 0 || obstacleGrid[0].Length== 0) return 0;
            var n = obstacleGrid[0].Length;
            var dp = new int[m, n];
                
            for (var i =0;i<m;i++)
            {
                for(var j =0;j<n;j++)
                {
                    if(i ==0)
                    {
                        if (obstacleGrid[i][j] == 1)
                            dp[i, j] = 0;
                        else if (j > 0)
                            dp[i, j] = Math.Min(dp[i, j - 1], 1);
                        else
                            dp[i, j] = 1;
                        continue;
                    }
                    if(j == 0)
                    {
                        if (obstacleGrid[i][j] == 1)
                            dp[i, j] = 0;
                        else if (i > 0)
                            dp[i, j] = Math.Min(dp[i-1, j ], 1);
                        else
                            dp[i, j] = 1;
                        continue;
                    }
                    if (obstacleGrid[i][j] == 1)
                    {
                        dp[i, j] = 0;
                    }else
                    {
                        dp[i, j] = dp[i - 1, j]+dp[i, j - 1];
                    }
                }
            }
            return dp[m-1, n-1];

        }

        /// <summary>
        /// 滚动数组，降低空间复杂度
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstaclesOptimize(int[][] obstacleGrid)
        {
            var m = obstacleGrid.Length;
            if (m == 0 || obstacleGrid[0].Length == 0) return 0;
            var n = obstacleGrid[0].Length;
            var dp = new int[n];
            if (obstacleGrid[0][0] == 0) dp[0] = 1;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        dp[i] = 0;
                    }
                    else if(j>0 && obstacleGrid[i][j] == 0) 
                    {
                        dp[i] += dp[j-1];
                    }
                }
            }
            return dp[n-1];

        }
    }
}
