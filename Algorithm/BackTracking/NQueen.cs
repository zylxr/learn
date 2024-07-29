using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.BackTracking
{
    public class NQueen
    {
        bool Place(int index, int[] col)
        {
            for(var i=1;i<index;i++)
            {
                var col_differ  = Math.Abs(col[index] - col[i]);
                var row_differ = Math.Abs(index - i);
                if (col[i] == col[index] || col_differ == row_differ) return false;
            }
            return true;
        }

        public int FindNQueen(int n)
        {
            var col = new int[n + 1];
            var index = 1;
            var answerNum = 0;
            while(index>0)
            {
                col[index]++;
                while (col[index]<=n && !Place(index, col)) col[index]++;//寻找皇后的位置
                if (col[index] <= n)//最后一个皇后放置成功
                {
                    if (index == n)
                    {
                        answerNum++;
                        for (var i = 1; i <= n; i++) col[index]++;
                    }
                    else//继续寻找下一个皇后的位置
                    {
                        index++;
                        col[index] = 0;
                    }
                }
                else
                    index--;//当前皇后无法放置，回溯至上一个皇后

            }
            return answerNum;
        }

        // 判断当前皇后位置是否冲突
         bool IsPositionSafe(int row, int col, int[] columns)
        {
            for (int i = 0; i < row; i++)
            {
                // 检查列冲突
                if (columns[i] == col)
                {
                    return false;
                }
                // 检查对角线冲突
                if (Math.Abs(columns[i] - col) == row - i)
                {
                    return false;
                }
            }
            return true;
        }

        // 使用回溯法寻找解
        public int FindNQueenSolutions(int n)
        {
            int[] columns = new int[n]; // 存储每行皇后的列位置
            return SolveNQueens(n, 0, columns);
        }

        // 递归函数，放置第row行的皇后
         int SolveNQueens(int n, int row, int[] columns)
        {
            if (row == n)
            {
                // 找到一个解，返回1表示解的数量增加
                return 1;
            }

            int solutions = 0;
            for (int col = 0; col < n; col++)
            {
                if (IsPositionSafe(row, col, columns))
                {
                    // 放置皇后并递归到下一行
                    columns[row] = col;
                    solutions += SolveNQueens(n, row + 1, columns);
                }
            }

            return solutions;
        }
    }
}
