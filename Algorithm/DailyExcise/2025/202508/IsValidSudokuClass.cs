using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class IsValidSudokuClass
    {
        //36. 有效的数独
        //请你判断一个 9 x 9 的数独是否有效。只需要 根据以下规则 ，验证已经填入的数字是否有效即可。

        //数字 1-9 在每一行只能出现一次。
        //数字 1-9 在每一列只能出现一次。
        //数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。（请参考示例图）


        //注意：

        //一个有效的数独（部分已被填充）不一定是可解的。
        //只需要根据以上规则，验证已经填入的数字是否有效即可。
        //空白格用 '.' 表示。


        //示例 1：


        //输入：board = 
        //[["5", "3", ".", ".", "7", ".", ".", ".", "."]
        //,["6", ".", ".", "1", "9", "5", ".", ".", "."]
        //,[".", "9", "8", ".", ".", ".", ".", "6", "."]
        //,["8", ".", ".", ".", "6", ".", ".", ".", "3"]
        //,["4", ".", ".", "8", ".", "3", ".", ".", "1"]
        //,["7", ".", ".", ".", "2", ".", ".", ".", "6"]
        //,[".", "6", ".", ".", ".", ".", "2", "8", "."]
        //,[".", ".", ".", "4", "1", "9", ".", ".", "5"]
        //,[".", ".", ".", ".", "8", ".", ".", "7", "9"]]
        //输出：true
        //示例 2：

        //输入：board = 
        //[["8", "3", ".", ".", "7", ".", ".", ".", "."]
        //,["6", ".", ".", "1", "9", "5", ".", ".", "."]
        //,[".", "9", "8", ".", ".", ".", ".", "6", "."]
        //,["8", ".", ".", ".", "6", ".", ".", ".", "3"]
        //,["4", ".", ".", "8", ".", "3", ".", ".", "1"]
        //,["7", ".", ".", ".", "2", ".", ".", ".", "6"]
        //,[".", "6", ".", ".", ".", ".", "2", "8", "."]
        //,[".", ".", ".", "4", "1", "9", ".", ".", "5"]
        //,[".", ".", ".", ".", "8", ".", ".", "7", "9"]]
        //输出：false
        //解释：除了第一行的第一个数字从 5 改为 8 以外，空格内其他数字均与 示例1 相同。 但由于位于左上角的 3x3 宫内有两个 8 存在, 因此这个数独是无效的。


        //提示：

        //board.length == 9
        //board[i].length == 9
        //board[i][j] 是一位数字（1-9）或者 '.'
        public bool IsValidSudoku(char[][] board)
        {
            var m = board.Length;
            var n = board[0].Length;
            for (var i = 0; i < m; i++)
            {
                var dict = new Dictionary<char, int>();
                for (var j = 0; j < n; j++)
                {
                    if (board[i][j] == '.') continue;
                    dict.TryAdd(board[i][j], 0);
                    dict[board[i][j]]++;
                }
                var result = dict.Where(_ => _.Value > 1);
                if (result.Count() > 0) return false;
            }
            for (var j = 0; j < n; j++)
            {
                var dict = new Dictionary<char, int>();
                for (var i = 0; i < m; i++)
                {
                    if (board[i][j] == '.') continue;
                    dict.TryAdd(board[i][j], 0);
                    dict[board[i][j]]++;
                }
                var result = dict.Where(_ => _.Value > 1);
                if (result.Count() > 0) return false;
            }
            for (var i = 0; i < m; i += 3)
            {
                
                for (var j = 0; j < n; j += 3)
                {
                    var dict = new Dictionary<char, int>();
                    for (var k = 0; k < 9; k++)
                    {
                        var x = k / 3;
                        var y = k % 3;
                        if (board[i + x][j + y] == '.') continue;
                        dict.TryAdd(board[i + x][j + y], 0);
                        dict[board[i + x][j + y]]++;
                    }
                    var result = dict.Where(_ => _.Value > 1);
                    if (result.Count() > 0) return false;
                }

            }
            return true;
        }

        public bool IsValidSudoku2(char[][] board)
        {
            var m = board.Length;
            var n = board[0].Length;
            var rows = new int[m,n];
            var columns = new int[m,n];
            var subboxes = new int[3,3,9];
            for(var i=0;i<m;i++)
            {
                for(var j=0;j<n;j++)
                {
                    var c = board[i][j];
                    if (c == '.') continue;
                    var index = c - '0' - 1;
                    rows[i,index]++;
                    columns[j,index]++;
                    subboxes[i / 3, j % 3,index]++;
                    if (rows[i, index] > 1 || columns[j, index] > 1 || subboxes[i / 3, j % 3, index] > 1) return false;
                }
            }
            return true;
        }
    }
}
