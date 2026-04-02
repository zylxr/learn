using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaximumAmountClass
    {
        //3418. 机器人可以获得的最大金币数
        //给你一个 m x n 的网格。一个机器人从网格的左上角(0, 0) 出发，目标是到达网格的右下角(m - 1, n - 1)。在任意时刻，机器人只能向右或向下移动。

        //网格中的每个单元格包含一个值 coins[i][j]：

        //如果 coins[i][j] >= 0，机器人可以获得该单元格的金币。
        //如果 coins[i][j] < 0，机器人会遇到一个强盗，强盗会抢走该单元格数值的 绝对值 的金币。
        //机器人有一项特殊能力，可以在行程中 最多感化 2个单元格的强盗，从而防止这些单元格的金币被抢走。

        //注意：机器人的总金币数可以是负数。

        //返回机器人在路径上可以获得的 最大金币数 。




        //示例 1：

        //输入： coins = [[0, 1, -1],[1, -2, 3],[2, -3, 4]]

        //输出： 8

        //解释：

        //一个获得最多金币的最优路径如下：

        //从(0, 0) 出发，初始金币为 0（总金币 = 0）。
        //移动到(0, 1)，获得 1 枚金币（总金币 = 0 + 1 = 1）。
        //移动到(1, 1)，遇到强盗抢走 2 枚金币。机器人在此处使用一次感化能力，避免被抢（总金币 = 1）。
        //移动到(1, 2)，获得 3 枚金币（总金币 = 1 + 3 = 4）。
        //移动到(2, 2)，获得 4 枚金币（总金币 = 4 + 4 = 8）。
        //示例 2：

        //输入： coins = [[10, 10, 10],[10, 10, 10]]

        //输出： 40

        //解释：

        //一个获得最多金币的最优路径如下：

        //从(0, 0) 出发，初始金币为 10（总金币 = 10）。
        //移动到(0, 1)，获得 10 枚金币（总金币 = 10 + 10 = 20）。
        //移动到(0, 2)，再获得 10 枚金币（总金币 = 20 + 10 = 30）。
        //移动到(1, 2)，获得 10 枚金币（总金币 = 30 + 10 = 40）。


        //提示：

        //m == coins.length
        //n == coins[i].length
        //1 <= m, n <= 500
        //-1000 <= coins[i][j] <= 1000
        public int MaximumAmount(int[][] coins)
        {
            var m = coins.Length;
            var n = coins[0].Length;
            var dp = new int[m, n, 3];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    for (var k = 0; k < 3; k++) dp[i, j, k] = int.MinValue;
                }
            }
            return DFS(coins, dp, 0, 0, 2);
        }
        private int DFS(int[][] coins, int[,,] memo, int i, int j, int k)
        {
            var m = coins.Length;
            var n = coins[0].Length;
            if (i >= m || j >= n) return int.MinValue;
            var x = coins[i][j];
            if (i == m - 1 && j == n - 1) return k > 0 ? Math.Max(0, x) : x;
            if (memo[i, j, k] != int.MinValue) return memo[i, j, k];
            var res = Math.Max(DFS(coins, memo, i + 1, j, k), DFS(coins, memo, i, j + 1, k)) + x;
            if (k > 0 && x < 0)
            {
                res = Math.Max(res, Math.Max(DFS(coins, memo, i + 1, j, k - 1), DFS(coins, memo, i, j + 1, k - 1)));
            }
            memo[i, j, k] = res;
            return res;
        }
    }
}
