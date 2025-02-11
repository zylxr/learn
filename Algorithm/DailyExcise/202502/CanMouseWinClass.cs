using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class CanMouseWinClass
    {
        //1728. 猫和老鼠 II
        //一只猫和一只老鼠在玩一个叫做猫和老鼠的游戏。

        //它们所处的环境设定是一个 rows x cols 的方格 grid ，其中每个格子可能是一堵墙、一块地板、一位玩家（猫或者老鼠）或者食物。

        //玩家由字符 'C' （代表猫）和 'M' （代表老鼠）表示。
        //地板由字符 '.' 表示，玩家可以通过这个格子。
        //墙用字符 '#' 表示，玩家不能通过这个格子。
        //食物用字符 'F' 表示，玩家可以通过这个格子。
        //字符 'C' ， 'M' 和 'F' 在 grid 中都只会出现一次。
        //猫和老鼠按照如下规则移动：

        //老鼠 先移动 ，然后两名玩家轮流移动。
        //每一次操作时，猫和老鼠可以跳到上下左右四个方向之一的格子，他们不能跳过墙也不能跳出 grid 。
        //catJump 和 mouseJump 是猫和老鼠分别跳一次能到达的最远距离，它们也可以跳小于最大距离的长度。
        //它们可以停留在原地。
        //老鼠可以跳跃过猫的位置。
        //游戏有 4 种方式会结束：

        //如果猫跟老鼠处在相同的位置，那么猫获胜。
        //如果猫先到达食物，那么猫获胜。
        //如果老鼠先到达食物，那么老鼠获胜。
        //如果老鼠不能在 1000 次操作以内到达食物，那么猫获胜。
        //给你 rows x cols 的矩阵 grid 和两个整数 catJump 和 mouseJump ，双方都采取最优策略，如果老鼠获胜，那么请你返回 true ，否则返回 false 。



        //示例 1：



        //输入：grid = ["####F", "#C...", "M...."], catJump = 1, mouseJump = 2
        //输出：true
        //解释：猫无法抓到老鼠，也没法比老鼠先到达食物。
        //示例 2：



        //输入：grid = ["M.C...F"], catJump = 1, mouseJump = 4
        //输出：true
        //示例 3：

        //输入：grid = ["M.C...F"], catJump = 1, mouseJump = 3
        //输出：false
        //示例 4：

        //输入：grid = ["C...#", "...#F", "....#", "M...."], catJump = 2, mouseJump = 5
        //输出：false
        //示例 5：

        //输入：grid = [".M...", "..#..", "#..#.", "C#.#.", "...#F"], catJump = 3, mouseJump = 1
        //输出：true


        //提示：

        //rows == grid.length
        //cols = grid[i].length
        //1 <= rows, cols <= 8
        //grid[i][j] 只包含字符 'C' ，'M' ，'F' ，'.' 和 '#' 。
        //grid 中只包含一个 'C' ，'M' 和 'F' 。
        //1 <= catJump, mouseJump <= 8

        //方法一：拓扑排序
        //概述

        //给定的网格包含 rows 行和 cols 列，网格中的单元格总数是 total = rows×cols。每个单元格对应一个编号，第 i 行第 j 列的单元格编号是 i×cols+j，其中 0≤i<rows，0≤j<cols。

        //首先遍历网格，得到猫和老鼠初始时所在的单元格以及食物所在的单元格，然后计算获胜方。

        //求解简化问题

        //这道题规定了移动次数上限为 1000，如果在 1000 次移动之内老鼠不能获胜，则猫获胜。可以首先考虑一个简化问题，在没有移动次数上限的情况下计算获胜方。该简化问题可以使用拓扑排序得到结果。

        //游戏中的状态由老鼠的位置、猫的位置和轮到移动的一方三个因素决定。初始时，只有边界情况的胜负结果已知，其余所有状态的结果都初始化为未知。边界情况为直接确定胜负的情况，包括三种情况：

        //猫和老鼠在同一个单元格，无论在哪个单元格，都是猫获胜；

        //猫和食物在同一个单元格，无论老鼠在哪个单元格，都是猫获胜；

        //老鼠和食物在同一个单元格，只要猫和食物不在同一个单元格，无论猫在哪个单元格，都是老鼠获胜。

        //从边界情况出发遍历其他情况。对于当前状态，可以得到老鼠所在的单元格、猫所在的单元格和轮到移动的一方，根据当前状态可知上一轮的所有可能状态，其中上一轮的移动方和当前的移动方相反，上一轮的移动方在上一轮状态和当前状态所在的单元格相同或不同（注意可以停留在原地）。假设当前状态是老鼠所在的单元格编号是 mouse，猫所在的单元格编号是 cat，则根据当前的移动方，可以得到上一轮的所有可能状态：

        //如果当前的移动方是老鼠，则上一轮的移动方是猫，上一轮状态中老鼠所在的单元格编号是 mouse，猫所在的单元格编号可能是 cat 或者向四个方向之一跳跃到达的单元格编号，跳跃的距离不超过 catJump 且不能跳过墙及不能跳出网格；

        //如果当前的移动方是猫，则上一轮的移动方是老鼠，上一轮状态中猫所在的单元格编号是 cat，老鼠所在的单元格编号可能是 mouse 或者向四个方向之一跳跃到达的单元格编号，跳跃的距离不超过 mouseJump 且不能跳过墙及不能跳出网格。

        //对于上一轮的每一种可能的状态，如果该状态的结果已知，则不需要重复计算该状态的结果，只有对结果未知的状态，才需要计算该状态的结果。对于上一轮的移动方，只有当可以确定上一轮状态是必胜状态或者必败状态时，才更新上一轮状态的结果。

        //如果上一轮的移动方和当前状态的获胜方相同，由于当前状态为上一轮的移动方的必胜状态，因此上一轮的移动方一定可以移动到当前状态而获胜，上一轮状态为上一轮的移动方的必胜状态。

        //如果上一轮的移动方和当前状态的获胜方不同，则上一轮的移动方需要尝试其他可能的移动，可能有以下三种情况：

        //如果存在一种移动可以到达上一轮的移动方的必胜状态，则上一轮状态为上一轮的移动方的必胜状态；

        //如果所有的移动都到达上一轮的移动方的必败状态，则上一轮状态为上一轮的移动方的必败状态；

        //如果所有的移动都不能到达上一轮的移动方的必胜状态，但是存在一种移动可以到达上一轮的移动方的未知状态，则上一轮状态为上一轮的移动方的未知状态。

        //其中，对于必败状态与未知状态的判断依据为上一轮的移动方可能的移动是都到达必败状态还是可以到达未知状态。为了实现必败状态与未知状态的判断，需要记录每个状态的度，初始时每个状态的度为当前玩家在当前单元格可以到达的单元格数，由于可以停留在原地，因此初始时每个状态的度为当前玩家在当前单元格可以跳跃到达的单元格数加 1。

        //遍历过程中，从当前状态出发遍历上一轮的所有可能状态，如果上一轮状态的结果未知且上一轮的移动方和当前状态的获胜方不同，则将上一轮状态的度减 1。如果上一轮状态的度减少到 0，则从上一轮状态出发到达的所有状态都是上一轮的移动方的必败状态，因此上一轮状态也是上一轮的移动方的必败状态。

        //在确定上一轮状态的结果（必胜或必败）之后，即可从上一轮状态出发，遍历其他的未知状态。当没有更多的状态可以确定胜负结果时，遍历结束，此时即可得到初始状态的结果。

        //求解原始问题

        //上述解法为简化问题的解法，没有考虑移动次数的上限。由于移动次数的限制只会影响到平局以及老鼠获胜的条件，因此只需要对平局和老鼠获胜的情况考虑移动次数。

        //平局对应上述解法中的未知状态，表示当猫和老鼠都按照最优策略参与游戏时，双方都无法在有限的移动次数内到达食物所在的单元格，移动次数一定会超过老鼠获胜的上限，因此未知状态对应的结果都是猫获胜。

        //如果在简化问题中，从初始状态开始游戏的结果是老鼠获胜，即老鼠先到达食物，则在原始问题中，需要计算从初始状态至老鼠到达食物的移动次数，只有当移动次数不超过 1000 时，老鼠才能获胜，否则猫获胜。

        //为了计算从初始状态至老鼠到达食物的移动次数，在拓扑排序的过程中除了记录每个状态的结果以外，还需要记录从边界情况到达每个状态的移动次数，等价于从每个状态到边界情况的移动次数。每个状态对应的移动次数计算方法如下：

        //边界情况可以直接确定胜负，因此移动次数为 0；

        //如果状态 s 
        //1
        //​
        //和状态 s 
        //2
        //​
        //相邻（即状态 s 
        //2
        //​
        //是状态 s 
        //1
        //​
        //的上一轮的状态之一），且状态 s 
        //1
        //​
        //的结果和移动次数已知，记状态 s 
        //1
        //​
        //的移动次数为 x，如果可以确定状态 s 
        //2
        //​
        //的结果，则状态 s 
        //2
        //​
        //的移动次数为 x+1。

        //证明

        //对于上述解法的正确性证明，需要证明两点，一是未知状态的正确性，二是移动次数的正确性。

        //证明一：未知状态的正确性

        //遍历结束之后，如果一个状态的结果未知，则该状态满足以下两个条件：

        //从该状态出发，任何移动都无法到达该状态的移动方的必胜状态；

        //从该状态出发，存在一种移动可以到达未知状态。

        //对于结果未知的状态，如果其实际结果是该状态的移动方必胜，则一定存在一个下一轮状态，为当前状态的移动方的必胜状态，在根据下一轮状态的结果标记当前状态的结果时会将当前状态标记为当前状态的移动方的必胜状态，和结果未知矛盾。

        //对于结果未知的状态，如果其实际结果是该状态的移动方必败，则所有的下一轮状态都为当前状态的移动方的必败状态，在根据下一轮状态的结果标记当前状态的结果时会将当前状态标记为当前状态的移动方的必败状态，和结果未知矛盾。

        //因此，对于结果不是任何一方必胜的状态，实际结果一定是未知。根据游戏规则，未知状态表示在该状态下当猫和老鼠都按照最优策略参与游戏时，双方都无法在有限的移动次数内到达食物所在的单元格，移动次数一定会超过老鼠获胜的上限，因此未知状态对应的结果都是猫获胜。

        //证明二：移动次数的正确性

        //在考虑移动次数的情况下，每个玩家的最优策略应满足以下三点：

        //当自己可以到达必胜状态时，应将移动次数最小化；

        //当自己无法到达必胜状态时，如果可以避免自己到达必败状态，则应到达未知状态；

        //当无法避免自己到达必败状态时，应将移动次数最大化。

        //由于拓扑排序的实现方式是广度优先搜索，因此拓扑排序的过程中遍历状态的顺序为移动次数递增的顺序。

        //边界情况的移动次数为 0。从已知状态出发计算未知状态的结果和移动次数，将已知状态记为 s 
        //1
        //​
        //，未知状态记为 s 
        //2
        //​
        //，且状态 s 
        //1
        //​
        //和状态 s 
        //2
        //​
        //相邻（即状态 s 
        //2
        //​
        //是状态 s 
        //1
        //​
        //的上一轮的状态之一），记状态 s 
        //1
        //​
        //的移动次数为 x，考虑以下两种情况。

        //如果状态 s 
        //2
        //​
        //的移动方和状态 s 
        //1
        //​
        //的获胜方相同，则状态 s 
        //2
        //​
        //的移动方会移动到状态 s 
        //1
        //​
        //从而确保胜利，因此状态 s 
        //2
        //​
        //的移动方必胜，移动次数为 x+1，且该移动次数为状态 s 
        //2
        //​
        //到边界情况的最少移动次数。

        //假设存在另一个已知状态 s 
        //3
        //​
        //的获胜方和状态 s 
        //1
        //​
        //相同且状态 s 
        //3
        //​
        //的移动次数小于 x，则状态 s 
        //3
        //​
        //在状态 s 
        //1
        //​
        //之前被遍历，在遍历到状态 s 
        //3
        //​
        //时就会更新状态 s 
        //2
        //​
        //的结果，和遍历到状态 s 
        //1
        //​
        //时状态 s 
        //2
        //​
        //的结果未知矛盾。因此状态 s 
        //2
        //​
        //的最少移动次数为 x+1。

        //如果状态 s 
        //2
        //​
        //的移动方和状态 s 
        //1
        //​
        //的获胜方不同，则只有当状态 s 
        //2
        //​
        //的所有相邻状态都已知是状态 s 
        //2
        //​
        //的移动方的必败状态时，才能确定状态 s 
        //2
        //​
        //的移动方必败。如果在遍历到状态 s 
        //1
        //​
        //时可以确定状态 s 
        //2
        //​
        //的结果为移动方必败，则在遍历到状态 s 
        //1
        //​
        //之前，状态 s 
        //2
        //​
        //的所有相邻状态都已经遍历过，即状态 s 
        //1
        //​
        //是最后一个遍历到的状态 s 
        //2
        //​
        //的相邻状态，因此在状态 s 
        //2
        //​
        //的所有相邻状态中，状态 s 
        //1
        //​
        //的移动次数最多，状态 s 
        //2
        //​
        //的移动次数是 x+1 符合必败状态下将移动次数最大化。
        public bool CanMouseWin(string[] grid, int catJump, int mouseJump)
        {
            this.rows = grid.Length;
            this.cols = grid[0].Length;
            this.grid = grid;
            this.catJump = catJump;
            this.mouseJump = mouseJump;
            var startMouse = -1;
            var startCat = -1;
            for(var i=0;i<rows;i++)
            {
                for(var j=0;j<cols;j++)
                {
                    var c = grid[i][j];
                    if (c == 'M')
                        startMouse = GetPos(i, j);
                    else if (c == 'C')
                        startCat = GetPos(i, j);
                    else if (c == 'F')
                        food = GetPos(i, j);
                }
            }
            var total = rows * cols;
            degrees = new int[total, total, 2];
            results = new int[total, total, 2, 2];
            var queue = new Queue<Tuple<int, int, int>>();
            for(var mouse =0;mouse< total;mouse++)
            {
                var mouseRow = mouse / cols;
                var mouseCol = mouse % cols;
                if (grid[mouseRow][mouseCol] == '#') continue;
                for(var cat=0;cat <total;cat++)
                {
                    var catRow = cat / cols;
                    var catCol = cat % cols;
                    if (grid[catRow][catCol] == '#') continue;
                    degrees[mouse, cat, MOUSE_TURN]++;
                    degrees[mouse, cat, CAT_TURN]++;
                    foreach(var dir in dirs)
                    {
                        for(int row = mouseRow + dir[0],col = mouseCol+ dir[1],jump=1; row>=0 && row< rows && col>=0 
                            && col<cols && grid[row][col] !='#' && jump <=mouseJump;
                            row += dir[0],col += dir[1],jump++)
                        {
                            var nextMouse = GetPos(row, col);
                            var nextCat = GetPos(catRow, catCol);
                            degrees[nextMouse, nextCat, MOUSE_TURN]++;
                        }
                        for(int row = catRow + dir[0],col=catCol+ dir[1],jump=1;row>=0 && row<rows 
                            && col>=0 && col<cols && grid[row][col]!='#' && jump<=catJump;
                            row += dir[0],col+=dir[1],jump++)
                        {
                            var nextMouse = GetPos(mouseRow, mouseCol);
                            var nextCat = GetPos(row, col);
                            degrees[nextMouse, nextCat, CAT_TURN]++;
                        }
                    }
                }
            }
            //猫和老鼠在同一个单元格，猫获胜
            for(var pos=0;pos<total;pos++)
            {
                var row = pos / cols;
                var col = pos % cols;
                if (grid[row][col] == '#') continue;
                results[pos, pos, MOUSE_TURN, 0] = CAT_WIN;
                results[pos, pos, MOUSE_TURN, 1] = 0;
                results[pos, pos, CAT_TURN, 0] = CAT_WIN;
                results[pos, pos, CAT_TURN, 1] = 0;
                queue.Enqueue(new Tuple<int, int, int>(pos,pos,MOUSE_TURN));
                queue.Enqueue(new Tuple<int, int, int>(pos,pos,CAT_TURN));
            }

            //猫和食物在同一个单元格，猫获胜
            for(var mouse=0;mouse<total;mouse++)
            {
                var mouseRow = mouse / cols;
                var mouseCol = mouse % cols;
                if (grid[mouseRow][mouseCol] == '#' || mouse == food) continue;
                results[mouse, food, MOUSE_TURN, 0] = CAT_WIN;
                results[mouse, food, MOUSE_TURN, 1] = 0;
                results[mouse, food, CAT_TURN, 0] = CAT_WIN;
                results[mouse, food, CAT_TURN, 1] = 0;
                queue.Enqueue(new Tuple<int, int, int>(mouse, food, MOUSE_TURN));
                queue.Enqueue(new Tuple<int, int, int>(mouse, food, CAT_TURN));
            }
            //老鼠和食物在同一个单元格且猫和食物不在同一个单元格，老鼠获胜
            for(var cat =0;cat<total;cat++)
            {
                var catRow = cat / cols;
                var catCol = cat % cols;
                if (grid[catRow][catCol] == '#'|| cat == food) continue;
                results[food, cat, MOUSE_TURN, 0] = MOUSE_WIN;
                results[food, cat, MOUSE_TURN, 1] = 0;
                results[food, cat, CAT_TURN, 0] = MOUSE_WIN;
                results[food, cat, CAT_TURN, 1] = 0;
                queue.Enqueue(new Tuple<int, int, int>(food,cat,MOUSE_TURN));
                queue.Enqueue(new Tuple<int, int, int>(food,cat, CAT_TURN));
            }

            //拓扑排序
            while (queue.Count > 0)
            {
                var state = queue.Dequeue();
                var mouse = state.Item1;
                var cat = state.Item2;
                var turn = state.Item3;
                var result = results[mouse, cat, turn, 0];
                var moves = results[mouse, cat, turn, 1];
                var preStates = GetPrevStates(mouse, cat, turn);
                foreach (var prevState in preStates)
                {
                    var prevMouse = prevState.Item1;
                    var prevCat = prevState.Item2;
                    var prevTurn = prevState.Item3;
                    if (results[prevMouse, prevCat, prevTurn, 0] == UNKOWN)
                    {
                        var canWin = (result == MOUSE_WIN && prevTurn == MOUSE_TURN
                            || result == CAT_WIN && prevCat == CAT_TURN);
                        if(canWin)
                        {
                            results[prevMouse, prevCat, prevTurn, 0] = result;
                            results[prevMouse, prevCat, prevTurn, 1] = moves + 1;
                            queue.Enqueue(new Tuple<int, int, int>(prevMouse, prevCat,prevTurn));
                        }else
                        {
                            degrees[prevMouse, prevCat, prevTurn]--;
                            if (degrees[prevMouse, prevCat,prevTurn] == 0)
                            {
                                var loseResult = prevTurn == MOUSE_TURN ? CAT_WIN : MOUSE_WIN;
                                results[prevMouse, prevCat, prevTurn, 0] = loseResult;
                                results[prevMouse, prevCat, prevTurn, 1] = moves + 1;
                                queue.Enqueue(new Tuple<int, int, int>(prevMouse,prevCat,prevTurn));
                            }
                        }
                    }
                }
            }
            return results[startMouse, startCat, MOUSE_TURN, 0] == MOUSE_WIN
                && results[startMouse, startCat, MOUSE_TURN, 1]<=MAX_MOVES;
        }
        const int MOUSE_TURN = 0;
        const int CAT_TURN = 1;
        const int UNKOWN = 0;
        const int MOUSE_WIN = 1;
        const int CAT_WIN = 2;
        const int MAX_MOVES = 1000;
        int[][] dirs = { new int[] { -1, 0 }, new int[] { 1, 0 },new int[] { 0, -1 }, new int[] { 0, 1 } };
        int rows;
        int cols;
        string[] grid;
        int catJump,mouseJump;
        int food;
        int[,,] degrees;
        int[,,,] results;

        public IList<Tuple<int,int,int>> GetPrevStates(int mouse,int cat,int turn)
        {
            var prevStates = new List<Tuple<int,int,int>>();
            var mouseRow = mouse / cols;
            var mouseCol = mouse % cols;
            var catRow = cat / cols;
            var catCol = cat % cols;
            var prevTurn = turn == MOUSE_TURN ? CAT_TURN : MOUSE_TURN;
            var maxJump = prevTurn == MOUSE_TURN ? mouseJump : catJump;
            var startRow = prevTurn == MOUSE_TURN ? mouseRow : catRow;
            var startCol = prevTurn == MOUSE_TURN ? mouseCol: catCol;
            prevStates.Add(new Tuple<int, int, int>(mouse, cat, prevTurn));
            foreach(var dir in dirs)
            {
                for(int i = startRow + dir[0], j = startCol + dir[1],jump=1;i>=0 && i<rows && j>=0 && j<cols
                    && grid[i][j] !='#' && jump <= maxJump; i += dir[0], j += dir[1],jump++)
                {
                    var preMouseRow = prevTurn == MOUSE_TURN ? i : mouseRow;
                    var preMouseCol = prevTurn == MOUSE_TURN ? j : mouseCol;
                    var preCatRow = prevTurn == MOUSE_TURN ? catRow : i;
                    var preCatCol = prevTurn == MOUSE_TURN ? catCol:j;
                    var preMouse = GetPos(preMouseRow, preMouseCol);
                    var preCat = GetPos(preCatRow, preCatCol);
                    prevStates.Add(new Tuple<int, int, int>(preMouse,preCat,prevTurn));
                }
            }
            return prevStates;
        }
        public int GetPos(int row, int col)
        {
            return row * cols + col;
        }
    }

    
}
