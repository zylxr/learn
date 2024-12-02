using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class TotalNQueensClass
    {
        //52. N 皇后 II
        //n 皇后问题 研究的是如何将 n 个皇后放置在 n × n 的棋盘上，并且使皇后彼此之间不能相互攻击。

        //给你一个整数 n ，返回 n 皇后问题 不同的解决方案的数量。




        //示例 1：


        //输入：n = 4
        //输出：2
        //解释：如上图所示，4 皇后问题存在两个不同的解法。
        //示例 2：

        //输入：n = 1
        //输出：1


        //提示：

        //1 <= n <= 9
        public int TotalNQueens(int n)
        {
            var columns = new HashSet<int>();
            var diagonals1 = new HashSet<int>();
            var diagonals2 = new HashSet<int>();
            return BackTrack(n, 0, columns, diagonals1, diagonals2);
        }

        private int BackTrack(int n, int row, HashSet<int> columns, HashSet<int> diagonals1, HashSet<int> diagonals2)
        {
            if (row == n) return 1;
            var count = 0;
            for(var i=0;i<n;i++)
            {
                if (columns.Contains(i)) continue;
                var diagonal1 = row - i;
                if (diagonals1.Contains(diagonal1)) continue;
                var diagonal2 = row + i;
                if (diagonals2.Contains(diagonal2))
                    continue;
                columns.Add(i);
                diagonals1.Add(diagonal1);
                diagonals2.Add(diagonal2);
                count += BackTrack(n, row + 1, columns, diagonals1, diagonals2);
                columns.Remove(i);
                diagonals1.Remove(diagonal1);
                diagonals2.Remove(diagonal2);
            }
            return count;
        }
   

        public int TotalNQueens2(int n)
        {
            return Solve(n, 0, 0, 0, 0);
        }

        public int Solve(int n, int row, int columns, int diagonals1, int diagonals2)
        {
            if (row == n) return 1;
            var count = 0;
            var availablePositions = ((1 << n) - 1) & (~(columns | diagonals1 | diagonals2));
            while(availablePositions !=0)
            {
                var position = availablePositions & (-availablePositions);
                availablePositions = availablePositions & (availablePositions -1);
                count += Solve(n, row+1,columns|position, (diagonals1|position)<<1, (diagonals2|position)>>1);
            }
            return count;
        }
    }
}
