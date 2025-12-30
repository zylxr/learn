using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class NumMagicSquaresInsideClass
    {
        //840. 矩阵中的幻方
        //3 x 3 的幻方是一个填充有 从 1 到 9  的不同数字的 3 x 3 矩阵，其中每行，每列以及两条对角线上的各数之和都相等。

        //给定一个由整数组成的row x col 的 grid，其中有多少个 3 × 3 的 “幻方” 子矩阵？

        //注意：虽然幻方只能包含 1 到 9 的数字，但 grid 可以包含最多15的数字。



        //示例 1：



        //输入: grid = [[4, 3, 8, 4],[9, 5, 1, 9],[2, 7, 6, 2]
        //输出: 1
        //解释: 
        //下面的子矩阵是一个 3 x 3 的幻方：

        //而这一个不是：

        //总的来说，在本示例所给定的矩阵中只有一个 3 x 3 的幻方子矩阵。
        //示例 2:

        //输入: grid = [[8]]
        //输出: 0


        //提示:

        //row == grid.length
        //col == grid[i].length
        //1 <= row, col <= 10
        //0 <= grid[i][j] <= 15

        public int NumMagicSquaresInside(int[][] grid)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            var count = 0;
            for(var r=0;r<rows-2;r++)
            {
                for(var c=0;c<cols-2;c++)
                {
                    if (grid[r + 1][c + 1] != 5) continue;
                    if (IsMagicSquare(grid[r][c], grid[r][c + 1], grid[r][c + 2],
                        grid[r + 1][c], grid[r + 1][c + 1], grid[r + 1][c + 2],
                        grid[r + 2][c], grid[r + 2][c + 1], grid[r + 2][c + 2]
                        )) count++;

                }
            }
            return count;
        }
        private bool IsMagicSquare(params int[] vals)
        {
            var freqency = new int[16];
            foreach (var val in vals)
            {
                if (val < 1 || val > 9) return false;
                freqency[val]++;
            }
            for (var num = 1; num <= 9; num++) if (freqency[num] != 1) return false;
            return (vals[0] + vals[1] + vals[2]==15&&
                    vals[3] + vals[4] + vals[5] == 15 &&
                    vals[6]+ vals[7] + vals[8] == 15 &&
                    vals[0] + vals[3] + vals[6] == 15 &&
                    vals[1] + vals[4] + vals[7] == 15 &&
                    vals[2] + vals[5] + vals[8] == 15 &&
                    vals[0] + vals[4] + vals[8] == 15  &&
                    vals[2] + vals[4] + vals[6] == 15

                    );
        }
    }
}
