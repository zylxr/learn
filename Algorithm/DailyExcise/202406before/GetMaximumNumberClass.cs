﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class GetMaximumNumberClass
    {
        //LCP 57. 打地鼠
        //勇者面前有一个大小为3*3 的打地鼠游戏机，地鼠将随机出现在各个位置，moles[i] = [t, x, y] 表示在第 t 秒会有地鼠出现在(x, y) 位置上，并于第 t+1 秒该地鼠消失。

        //勇者有一把可敲打地鼠的锤子，初始时刻（即第 0 秒）锤子位于正中间的格子(1,1)，锤子的使用规则如下：

        //锤子每经过 1 秒可以往上、下、左、右中的一个方向移动一格，也可以不移动
        //锤子只可敲击所在格子的地鼠，敲击不耗时
        //请返回勇者最多能够敲击多少只地鼠。

        //注意：

        //输入用例保证在相同时间相同位置最多仅有一只地鼠
        //示例 1：

        //输入： moles = [[1, 1, 0],[2, 0, 1],[4, 2, 2]]

        //输出： 2

        //解释： 第 0 秒，锤子位于(1,1) 第 1 秒，锤子移动至(1,0) 并敲击地鼠 第 2 秒，锤子移动至(2,0) 第 3 秒，锤子移动至(2,1) 第 4 秒，锤子移动至(2,2) 并敲击地鼠 因此勇者最多可敲击 2 只地鼠

        //示例 2：

        //输入：moles = [[2, 0, 2],[5, 2, 0],[4, 1, 0],[1, 2, 1],[3, 0, 2]]

        //输出：3

        //解释： 第 0 秒，锤子位于(1,1) 第 1 秒，锤子移动至(2,1) 并敲击地鼠 第 2 秒，锤子移动至(1,1) 第 3 秒，锤子移动至(1,0) 第 4 秒，锤子在(1,0) 不移动并敲击地鼠 第 5 秒，锤子移动至(2,0) 并敲击地鼠 因此勇者最多可敲击 3 只地鼠

        //示例 3：

        //输入：moles = [[0, 1, 0],[0, 0, 1]]

        //输出：0

        //解释： 第 0 秒，锤子初始位于(1,1)，此时并不能敲击(1,0)、(0,1) 位置处的地鼠

        //提示：

        //1 <= moles.length <= 10^5
        //moles[i].length == 3
        //0 <= moles[i][0] <= 10^9
        //0 <= moles[i][1], moles[i][2] < 3

        public int GetMaximumNumber(int[][] moles)
        {
            var data = new List<int[]> { new int[] { 0,1,1} };
            data.AddRange(moles.OrderBy(a => a[0]));
            var dict = new Dictionary<int, int>();
            return DFS(0, data, dict);
        }

        public int DFS(int i, List<int[]> data, Dictionary<int,int> dict)
        {
            if(dict.ContainsKey(i)) return dict[i];
            var res = 0;
            var t = int.MaxValue;
            for(var j=i+1;j<data.Count;j++)
            {
                var model = data[j];
                if (model[0] - t >= 4) break;
                if (model[0] - data[i][0]>= Math.Abs(model[1] - data[i][1]) + Math.Abs(model[2] - data[i][2]))
                {
                    t = Math.Min(t, model[0]);
                    res = Math.Max(res,1+DFS(j,data,dict));
                }
            }
            dict[i] = res;
            return res;
        }
    }
}
