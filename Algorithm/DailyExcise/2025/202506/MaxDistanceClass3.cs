using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxDistanceClass3
    {
        //3443. K 次修改后的最大曼哈顿距离
        //给你一个由字符 'N'、'S'、'E' 和 'W' 组成的字符串 s，其中 s[i] 表示在无限网格中的移动操作：

        //'N'：向北移动 1 个单位。
        //'S'：向南移动 1 个单位。
        //'E'：向东移动 1 个单位。
        //'W'：向西移动 1 个单位。
        //初始时，你位于原点(0, 0)。你 最多 可以修改 k 个字符为任意四个方向之一。

        //请找出在 按顺序 执行所有移动操作过程中的 任意时刻 ，所能达到的离原点的 最大曼哈顿距离 。

        //曼哈顿距离 定义为两个坐标点(xi, yi) 和(xj, yj) 的横向距离绝对值与纵向距离绝对值之和，即 |xi - xj| + |yi - yj|。



        //示例 1：

        //输入：s = "NWSE", k = 1

        //输出：3

        //解释：

        //将 s[2] 从 'S' 改为 'N' ，字符串 s 变为 "NWNE" 。

        //移动操作 位置(x, y)   曼哈顿距离 最大值
        //s[0] == 'N'	(0, 1)	0 + 1 = 1	1
        //s[1] == 'W'	(-1, 1)	1 + 1 = 2	2
        //s[2] == 'N'	(-1, 2)	1 + 2 = 3	3
        //s[3] == 'E'	(0, 2)	0 + 2 = 2	3
        //执行移动操作过程中，距离原点的最大曼哈顿距离是 3 。

        //示例 2：

        //输入：s = "NSWWEW", k = 3

        //输出：6

        //解释：

        //将 s[1] 从 'S' 改为 'N' ，将 s[4] 从 'E' 改为 'W' 。字符串 s 变为 "NNWWWW" 。

        //执行移动操作过程中，距离原点的最大曼哈顿距离是 6 。



        //提示：

        //1 <= s.length <= 105
        //0 <= k <= s.length
        //s 仅由 'N'、'S'、'E' 和 'W' 。
        public int MaxDistance(string s, int k)
        {
            //方法一：分步求解
            //思路及解法
            //对于任意一个给定的字符串，我们可以求出该字符串对应的曼哈顿距离，即：
            //∣sumN−sumS∣+∣sumE−sumW∣其中，sumN、sumS、sumE、sumW
            //分别表示给定字符串中 ‘N’、‘S’、‘E’、‘W’ 的个数。
            //当我们尝试修改该字符串中的字母时，会出现三种情况：

            //修改横向或纵向中数量较少（不为 0）的字母后，该字符串对应的曼哈顿距离增大，且增量为 2。
            //修改横向或纵向中数量较多的字母后，该字符串对应的曼哈顿距离减小，且增量为 −2。
            //不修改字母，该字符串对应的曼哈顿距离不变。
            //易知只有第一种情况会导致字符串曼哈顿距离增大，因此我们将整个修改过程拆分为两步：

            //第一步：修改纵向中数量较少的字母，若该字母的数量大于 k，则只修改 k 个，剩余修改次数为 t = 0 次；若该字母的数量小于 k，则全部修改，剩余修改次数设为 t 次。

            //第二步：修改横向中数量较少的字母，若该字母的数量大于 t，则只修改 t 个；若该字母的数量小于 t，则全部修改。

            //由于题目要求找出在 按顺序 执行所有移动操作过程中的 任意时刻，所能达到的离原点的 最大曼哈顿距离，以上步骤需要在遍历字符串的过程中进行，并取最大值。
            var ans = 0;
            int north = 0, south = 0, east = 0, west = 0;
            foreach (var it in s)
            {
                switch(it)
                {
                    case 'N':
                        north++;
                        break;
                    case 'S':
                        south++;
                        break;
                    case 'E':
                        east++; break;
                    case 'W':
                        west++; break;
                }

                var times1 = Math.Min(Math.Min(north, south), k);
                var times2 = Math.Min(Math.Min(east, west), k - times1);
                ans = Math.Max(ans, Count(north, south, times1) + Count(east, west, times2));
            }
            return ans;
        }
        private int Count(int drt1,int drt2,int times)
        {
            return Math.Abs(drt1 - drt2) + times * 2;
        }

        public int MaxDistance2(string s, int k)
        {
            //在方法一的分析中，我们不难发现：两个方向中数量较少的字母能改则改是最优策略。

            //因此，将两个方向中较少的字母当作一个整体，若整体数量大于 k，则修改任意 k 个字母，该字符串对应的曼哈顿距离增大 2×k。

            //若整体数量小于 k，则此时两个方向中较少的字母会被全部修改，剩余的修改也不需要进行了，该字符串对应的曼哈顿距离即为该字符串的长度。
            var latitude = 0;
            var longitude = 0;
            var ans = 0;
            var n = s.Length;
            for(var i=0;i<n;i++)
            {
                switch(s[i])
                {
                    case 'N':
                        latitude++;break;
                    case 'S':
                        latitude--;break;
                    case 'E':
                        longitude++;break;
                    case 'W':
                        longitude--;break;
                }
                ans = Math.Max(ans, Math.Min(Math.Abs(latitude) + Math.Abs(longitude) + k * 2, i + 1));
            }
            return ans;
        }
    }
}
