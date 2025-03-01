using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class CheckRecordClass
    {
        //学生出勤记录 II
        //可以用字符串表示一个学生的出勤记录，其中的每个字符用来标记当天的出勤情况（缺勤、迟到、到场）。记录中只含下面三种字符：
        //'A'：Absent，缺勤
        //'L'：Late，迟到
        //'P'：Present，到场
        //如果学生能够 同时 满足下面两个条件，则可以获得出勤奖励：

        //按 总出勤 计，学生缺勤（'A'）严格 少于两天。
        //学生 不会 存在 连续 3 天或 连续 3 天以上的迟到（'L'）记录。
        //给你一个整数 n ，表示出勤记录的长度（次数）。请你返回记录长度为 n 时，可能获得出勤奖励的记录情况 数量 。答案可能很大，所以返回对 109 + 7 取余 的结果。




        //示例 1：

        //输入：n = 2
        //输出：8
        //解释：
        //有 8 种长度为 2 的记录将被视为可奖励：
        //"PP" , "AP", "PA", "LP", "PL", "AL", "LA", "LL" 
        //只有"AA"不会被视为可奖励，因为缺勤次数为 2 次（需要少于 2 次）。
        //示例 2：

        //输入：n = 1
        //输出：3
        //示例 3：

        //输入：n = 10101
        //输出：183236316


        //提示：

        //1 <= n <= 105
        public int CheckRecord(int n)
        {
            const int MOD = 1000000007;
            var dp = new int[n + 1, 2, 3];
            dp[0, 0, 0] = 1;
            for (var i = 1; i <= n; i++)
            {
                //以 P 结尾的数量
                for (var j = 0; j <= 1; j++)
                {
                    for (var k = 0; k <= 2; k++)
                    {
                        dp[i, j, 0] = (dp[i, j, 0] + dp[i - 1, j, k]) % MOD;
                    }
                }
                //以 A 结尾的数量
                for (var k = 0; k <= 2; k++)
                {
                    dp[i, 1, 0] = (dp[i, 1, 0] + dp[i - 1, 0, k]) % MOD;
                }
                //以 L结尾的数量
                for (var j = 0; j <= 1; j++)
                {
                    for (var k = 1; k <= 2; k++)
                    {
                        dp[i, j, k] = (dp[i, j, k] + dp[i - 1, j, k - 1]) % MOD;
                    }
                }
            }
            var sum = 0;
            for(var j=0;j<=1;j++)
            {
                for(var k=0;k<=2;k++)
                {
                    sum = (sum + dp[n,j,k]) % MOD;
                }
            }
            return sum;
        }

        public int CheckRecord1(int n)
        {
            const int MOD = 1000000007;
            var dp = new int[2, 3];
            dp[0, 0] = 1;
            for(var i=1;i<=n;i++)
            {
                var dpNew = new int[2, 3];
                //以 P 结尾的数量
                for(var j=0;j<=1;j++)
                {
                    for(var k=0;k<=2;k++)
                    {
                        dpNew[j,0] = (dpNew[j, 0] + dp[j,k]) % MOD;
                    }
                }
                //以 A结尾的数量
                for(var k=0;k<=2;k++)
                {
                    dpNew[1,0] = (dpNew[1, 0] + dp[0,k]) % MOD;
                }

                //以 L 结尾的数量
                for(var j=0;j<=1;j++)
                {
                    for(var k=1;k<=2;k++)
                    {
                        dpNew[j,k] = (dpNew[j, k] + dp[j,k-1]) % MOD;
                    }
                }
                dp = dpNew;
            }
            var sum = 0;
            for(var j=0;j<=1;j++)
            {
                for (var k = 0; k <= 2; k++)
                    sum = (sum + dp[j, k]) % MOD;
            }
            return sum;
        }

        public int CheckRecord2(int n)
        {
            var mat = new long[,]
                {
                    { 1, 1, 0, 1, 0, 0 },
                    { 1, 0, 1, 1, 0, 0 },
                    { 0, 0, 0,1,1,0 },
                    { 0, 0, 0,1,0,1 },
                    { 0, 0, 0,1,0,0 }
                };
            var res = Pow(mat, n);
            var sum = 0;
            for(var i=0;i<6;i++)
                sum = (sum + (int)res[0,i]) % MOD;
            return sum;
        }

        public long[,] Pow(long[,] mat, int n)
        {
            var ret = new long[,]{ 
                {1,0,0,0,0,1},
                { 0,1,0,0,0 ,0}, 
                { 0,0,1,0,0,0},
                { 0,0,0,1,0,0 },
                { 0,0,0,0,1,0 },
                { 0,0,0,0,0,1 }
            };
            while(n>0)
            {
                if ((n & 1) == 1)
                {
                    ret = Multiply(ret, mat);
                }
                n >>= 1;
                mat = Multiply(mat, mat);
            }
            return ret;
        }

        public long[,] Multiply(long[,] a, long[,] b)
        {
            var rows = a.GetLength(0);
            var columns =b.GetLength(1);
            var temp = b.GetLength(0);
            var c = new long[rows, columns];
            for(var i=0;i<rows;i++)
            {
                for(var j=0;j<columns;j++) 
                {
                    for(var k=0;k<temp;k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                        c[i, j] %= MOD;
                    }
                }
            }
            return c;
        }

        const int MOD = 1000000007;
    }
}
