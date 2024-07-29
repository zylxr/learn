using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class NumTreesClass
    {
        //给你一个整数 n ，求恰由 n 个节点组成且节点值从 1 到 n 互不相同的 二叉搜索树 有多少种？返回满足题意的二叉搜索树的种数。
        //示例 1：
        //输入：n = 3
        //输出：5
        //示例 2：
        //输入：n = 1
        //输出：1
        //提示：
        //1 <= n <= 19
        public int NumTrees(int n)
        {
            //塔兰数 C0=1,Cn = Cn-1*2*(2n+1)/(n+2)
            var sum = 1;
            for(var i=0;i<n;i++)
            {
                sum = sum * 2 * (2 * i + 1) / (i + 2);
            }
            return sum;
        }

        public int NumTreesDp(int n)
        {
            var dp = new int[n+1];
            dp[0] = 1;
            dp[1] = 1;
            for(var i=2;i<=n;i++)
            {
                for(var j=1;j<=i;j++)
                {
                    dp[i] += dp[j-1] * dp[i - j];
                }
            }
            return dp[n];
        }
    }
}
