using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class KnightProbabilityClass
    {
        //688. 骑士在棋盘上的概率
        //在一个 n x n 的国际象棋棋盘上，一个骑士从单元格(row, column) 开始，并尝试进行 k 次移动。行和列是 从 0 开始 的，所以左上单元格是(0,0) ，右下单元格是(n - 1, n - 1) 。

        //象棋骑士有8种可能的走法，如下图所示。每次移动在基本方向上是两个单元格，然后在正交方向上是一个单元格。

        //每次骑士要移动时，它都会随机从8种可能的移动中选择一种(即使棋子会离开棋盘)，然后移动到那里。

        //骑士继续移动，直到它走了 k 步或离开了棋盘。

        //返回 骑士在棋盘停止移动后仍留在棋盘上的概率 。

        //示例 1：

        //输入: n = 3, k = 2, row = 0, column = 0
        //输出: 0.0625
        //解释: 有两步(到(1,2)，(2,1))可以让骑士留在棋盘上。
        //在每一个位置上，也有两种移动可以让骑士留在棋盘上。
        //骑士留在棋盘上的总概率是0.0625。
        //示例 2：

        //输入: n = 1, k = 0, row = 0, column = 0
        //输出: 1.00000


        //提示:

        //1 <= n <= 25
        //0 <= k <= 100
        //0 <= row, column <= n - 1

        public double KnightProbability(int n, int k, int row, int column)
        {
            var dirs = new int[][] {
               new int[]{-2, -1 },
               new int[]{-2, 1 },
               new int[]{2, -1},
               new int[]{2, 1},
               new int[]{-1, -2},
               new int[]{-1, 2},
               new int[]{1, -2},
               new int[]{1, 2},
            };
            var dp = new double[k + 1, n, n];
            for (var step = 0; step <= k; step++)
            {
                for(var i=0;i<n;i++)
                {
                    for(var j=0;j<n;j++)
                    {
                        if (step == 0)
                            dp[step, i, j] = 1;
                        else
                        {
                            foreach(var dir in dirs)
                            {
                                var dx = i +  dir[0];
                                var dy = j +  dir[1];
                                if (dx >= 0 && dx < n && dy >= 0 && dy < n)
                                    dp[step, i, j] += dp[step - 1, dx, dy] / 8;
                            }
                        }
                    }
                }
            }
            return dp[k, row, column];
        }
    }
}
