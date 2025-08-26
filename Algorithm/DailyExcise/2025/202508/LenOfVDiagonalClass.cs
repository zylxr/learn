using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class LenOfVDiagonalClass
    {
        //3459. 最长 V 形对角线段的长度
        //给你一个大小为 n x m 的二维整数矩阵 grid，其中每个元素的值为 0、1 或 2。

        //V 形对角线段 定义如下：

        //线段从 1 开始。
        //后续元素按照以下无限序列的模式排列：2, 0, 2, 0, ...。
        //该线段：
        //起始于某个对角方向（左上到右下、右下到左上、右上到左下或左下到右上）。
        //沿着相同的对角方向继续，保持 序列模式 。
        //在保持 序列模式 的前提下，最多允许 一次顺时针 90 度转向 另一个对角方向。


        //返回最长的 V 形对角线段 的 长度 。如果不存在有效的线段，则返回 0。



        //示例 1：

        //输入： grid = [[2, 2, 1, 2, 2],[2, 0, 2, 2, 0],[2, 0, 1, 1, 0],[1, 0, 2, 2, 2],[2, 0, 0, 2, 2]]

        //输出： 5

        //解释：



        //最长的 V 形对角线段长度为 5，路径如下：(0,2) → (1,3) → (2,4)，在(2,4) 处进行 顺时针 90 度转向 ，继续路径为(3,3) → (4,2)。

        //示例 2：

        //输入： grid = [[2, 2, 2, 2, 2],[2, 0, 2, 2, 0],[2, 0, 1, 1, 0],[1, 0, 2, 2, 2],[2, 0, 0, 2, 2]]

        //输出： 4

        //解释：



        //最长的 V 形对角线段长度为 4，路径如下：(2,3) → (3,2)，在(3,2) 处进行 顺时针 90 度转向 ，继续路径为(2,1) → (1,0)。

        //示例 3：

        //输入： grid = [[1, 2, 2, 2, 2],[2, 2, 2, 2, 0],[2, 0, 0, 0, 0],[0, 0, 2, 2, 2],[2, 0, 0, 2, 0]]

        //输出： 5

        //解释：



        //最长的 V 形对角线段长度为 5，路径如下：(0,0) → (1,1) → (2,2) → (3,3) → (4,4)。

        //示例 4：

        //输入： grid = [[1]]

        //输出： 1

        //解释：

        //最长的 V 形对角线段长度为 1，路径如下：(0,0)。



        //提示：

        //n == grid.length
        //m == grid[i].length
        //1 <= n, m <= 500
        //grid[i][j] 的值为 0、1 或 2。
        public int LenOfVDiagonal(int[][] grid)
        {
            this.grid = grid;
            m = grid.Length;
            n = grid[0].Length;
            memo = new int[m, n, 4, 2];
            for(var i=0;i<m;i++)
            {
                for(var j=0;j<n;j++)
                {
                    for(var k=0;k<4;k++)
                    {
                        for (var l = 0; l < 2; l++)
                            memo[i, j, k, l] = -1;
                    }
                }
            }
            var res = 0;
            for(var i=0;i<m;i++)
            {
                for(var j=0;j<n;j++)
                {
                    if (grid[i][j]== 1)
                    {
                        for (var direction = 0; direction < 4; direction++)
                            res = Math.Max(res, Dfs(i, j, direction, true, 2) + 1);
                    }
                }
            }
            return res;
        }
        private int Dfs(int cx,int cy, int direction, bool turn,int target)
        {
            var nx = cx + DIRS[direction][0];
            var ny = cy + DIRS[direction][1];
            if (nx < 0 || ny < 0 || nx >= m || ny >= n) return 0;
            var turnInt = turn ? 1 : 0;
            if (memo[nx,ny,direction,turnInt] != -1)return memo[nx,ny,direction,turnInt];
            var maxStep = Dfs(nx, ny, direction, turn, 2 - target);
            if (turn) maxStep = Math.Max(maxStep, Dfs(nx, ny, (direction + 1) % 4, false, 2 - target));
            memo[nx, ny, direction, turnInt] = maxStep + 1;
            return memo[nx,ny,direction,turnInt];
        }
        private readonly int[][] DIRS = new int[][] {
            new int[]{1,1 },
            new int[]{1,-1 },
            new int[]{ -1,-1 },
            new int[]{-1,1 }
        };
        private int[,,,] memo;
        private int[][] grid;
        private int m, n;

    }
}
