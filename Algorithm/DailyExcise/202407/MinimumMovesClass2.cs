using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinimumMovesClass2
    {
        //给你一个大小为 3 * 3 ，下标从 0 开始的二维整数矩阵 grid ，
        //分别表示每一个格子里石头的数目。网格图中总共恰好有 9 个石头，一个格子里可能会有 多个 石头。
        //每一次操作中，你可以将一个石头从它当前所在格子移动到一个至少有一条公共边的相邻格子。
        //请你返回每个格子恰好有一个石头的 最少移动次数 。

        //示例 1：

        //输入：grid = [[1, 1, 0],[1, 1, 1],[1, 2, 1]]
        //输出：3
        //解释：让每个格子都有一个石头的一个操作序列为：
        //1 - 将一个石头从格子(2,1) 移动到(2,2) 。
        //2 - 将一个石头从格子(2,2) 移动到(1,2) 。
        //3 - 将一个石头从格子(1,2) 移动到(0,2) 。
        //总共需要 3 次操作让每个格子都有一个石头。
        //让每个格子都有一个石头的最少操作次数为 3 。
        //示例 2：



        //输入：grid = [[1, 3, 0],[1, 0, 0],[1, 0, 3]]
        //输出：4
        //解释：让每个格子都有一个石头的一个操作序列为：
        //1 - 将一个石头从格子(0,1) 移动到(0,2) 。
        //2 - 将一个石头从格子(0,1) 移动到(1,1) 。
        //3 - 将一个石头从格子(2,2) 移动到(1,2) 。
        //4 - 将一个石头从格子(2,2) 移动到(2,1) 。
        //总共需要 4 次操作让每个格子都有一个石头。
        //让每个格子都有一个石头的最少操作次数为 4 。


        //提示：

        //grid.length == grid[i].length == 3
        //0 <= grid[i][j] <= 9
        //grid 中元素之和为 9 。
        public int MinimumMoves(int[][] grid)
        {
            var more = new List<int[]>();
            var less = new List<int[]>();
            var n = grid.Length;
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (grid[i][j] > 1)
                    {
                        for (var k = 2; k <= grid[i][j]; k++)
                        {
                            more.Add(new int[] { i, j });
                        }
                    }
                    else if (grid[i][j] == 0)
                    {
                        less.Add(new int[] { i, j });
                    }
                }
            }
            var ans = int.MaxValue;
            do
            {
                var steps = 0;
                for (var i = 0; i < more.Count; i++)
                {
                    steps += Math.Abs(less[i][0] - more[i][0]) + Math.Abs(less[i][1] - more[i][1]);
                }
                ans = Math.Min(ans, steps);
            } while (NextPermutation(more));

            return ans;
        }

        public bool NextPermutation(List<int[]> more)
        {
            var p = -1;
            for(var i=0;i<more.Count-1;i++)
            {
                if (more[i][0] < more[i + 1][0] || (more[i][0] == more[i + 1][0]&& more[i][1] < more[i + 1][1]))
                {
                    p = i;
                }
            }
            if (p == -1) return false;

            var q = -1;
            for(var i = p+1;i<more.Count; i++)
            {
                if (more[p][0] < more[i][0] || (more[p][0] == more[i][0] && more[p][1] < more[i][1]))
                {
                    q = i;
                }
            }
            if (q == -1) return false;
            Swap(more, p, q);
            var low = p + 1;
            var high = more.Count-1;
            while(low<high)
            {
                Swap(more, low, high);
                low++;
                high--;
            }
            return true;
        }

        public void Swap(List<int[]> more, int idx1,int idx2)
        {
            if (idx1 < 0 || idx2 < 0) return;
            var tmp = more[idx1];
            more[idx1] = more[idx2];
            more[idx2] = tmp;
        }
    }
}
