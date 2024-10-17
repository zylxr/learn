﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class CountBattleshipsClass
    {
        //给你一个大小为 m x n 的矩阵 board 表示甲板，其中，每个单元格可以是一艘战舰 'X' 或者是一个空位 '.' ，返回在甲板 board 上放置的 战舰 的数量。
        //战舰 只能水平或者垂直放置在 board 上。换句话说，战舰只能按 1 x k（1 行，k 列）或 k x 1（k 行，1 列）的形状建造，其中 k 可以是任意大小。两艘战舰之间至少有一个水平或垂直的空位分隔 （即没有相邻的战舰）。
        //示例 1：
        //输入：board = [["X", ".", ".", "X"],[".", ".", ".", "X"],[".", ".", ".", "X"]]
        //输出：2
        //示例 2：
        //输入：board = [["."]]
        //输出：0
        //提示：

        //m == board.length
        //n == board[i].length
        //1 <= m, n <= 200
        //board[i][j] 是 '.' 或 'X'
        public int CountBattleships1(char[][] board)
        {
            var row = board.Length;
            var col = board[0].Length;
            var ans = 0;
            for(var i=0;i<row;i++)
            {
                for(var j=0;j<col;j++)
                {
                    if(board[i][j] =='X')
                    {
                        board[i][j] = '.';
                        for(var k=j+1;k<col && board[i][k]=='X';k++)
                        {
                            board[i][k] = '.';
                        }

                        for(var k=i+1;k<row && board[k][j]=='X';k++)
                            board[k][j] = '.';
                        ans++;
                    }
                }
            }
            return ans;
        }

        public int CountBattleships2(char[][] board)
        {
            var row = board.Length;
            var col = board[0].Length;
            var ans = 0;
            for (var i = 0; i < row; i++)
            {
                for(var j = 0; j < col; j++)
                {
                    if(board[i][j] == 'X')
                    {
                        if (i > 0 && board[i - 1][j] == 'X') continue;
                        if (j > 0 && board[i][j - 1] == 'X') continue;
                        ans++;
                    }
                }
            }
            return ans;
        }
    }
}