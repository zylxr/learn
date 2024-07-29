using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class NumTilingsClass
    {
        //有两种形状的瓷砖：一种是 2 x 1 的多米诺形，另一种是形如 "L" 的托米诺形。两种形状都可以旋转。
        //给定整数 n ，返回可以平铺 2 x n 的面板的方法的数量。返回对 109 + 7 取模 的值。
        //平铺指的是每个正方形都必须有瓷砖覆盖。两个平铺不同，当且仅当面板上有四个方向上的相邻单元中的两个，使得恰好有一个平铺有一个瓷砖占据两个正方形。
        //示例 1:
        //输入: n = 3
        //输出: 5
        //解释: 五种不同的方法如上所示。

        //示例 2:
        //输入: n = 1
        //输出: 1

        public int NumTilings(int n)
        {
            var mod = 1000000000 + 7;
            var dp = new int[n+1, 4];
            //一个正方形都没有被覆盖，记为状态 0；
            //只有上方的正方形被覆盖，记为状态 1；
            //只有下方的正方形被覆盖，记为状态 2；
            //上下两个正方形都被覆盖，记为状态 3。
            dp[0, 3] = 1;
            for (var i=1;i<=n;i++)
            {
                dp[i, 0] = dp[i - 1, 3]%mod;
                dp[i, 1] = (dp[i - 1, 0] + dp[i - 1, 2])%mod;
                dp[i, 2] = (dp[i - 1, 0] + dp[i - 1, 1])%mod;
                dp[i, 3] = (dp[i - 1, 0] + dp[i - 1, 1] + dp[i - 1, 2] + dp[i-1,3])%mod;
            }
            return dp[n, 3];
        }
    }
}
