using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class SuperEggDropClass
    {
        //887. 鸡蛋掉落
        //给你 k 枚相同的鸡蛋，并可以使用一栋从第 1 层到第 n 层共有 n 层楼的建筑。

        //已知存在楼层 f ，满足 0 <= f <= n ，任何从 高于 f 的楼层落下的鸡蛋都会碎，从 f 楼层或比它低的楼层落下的鸡蛋都不会破。

        //每次操作，你可以取一枚没有碎的鸡蛋并把它从任一楼层 x 扔下（满足 1 <= x <= n）。如果鸡蛋碎了，你就不能再次使用它。如果某枚鸡蛋扔下后没有摔碎，则可以在之后的操作中 重复使用 这枚鸡蛋。

        //请你计算并返回要确定 f 确切的值 的 最小操作次数 是多少？



        //示例 1：

        //输入：k = 1, n = 2
        //输出：2
        //解释：
        //鸡蛋从 1 楼掉落。如果它碎了，肯定能得出 f = 0 。 
        //否则，鸡蛋从 2 楼掉落。如果它碎了，肯定能得出 f = 1 。 
        //如果它没碎，那么肯定能得出 f = 2 。 
        //因此，在最坏的情况下我们需要移动 2 次以确定 f 是多少。 
        //示例 2：

        //输入：k = 2, n = 6
        //输出：3
        //示例 3：

        //输入：k = 3, n = 14
        //输出：4


        //提示：

        //1 <= k <= 100
        //1 <= n <= 104
        public int SuperEggDrop(int k, int n)
        {
            return dp(k, n);
        }

        Dictionary<int, int> memo = new Dictionary<int, int>();
        public int dp(int k,int n)
        {
            if(memo.ContainsKey(n*100+k))
                return memo[n*100+k];
            var ans = 0;
            if (n == 0) ans = 0;
            else if (k == 1) ans = n;
            else
            {
                int l = 1, h = n;
                while(l+1<h)
                {
                    var x = (l + h) >> 1;
                    var t1 = dp(k - 1, x - 1);
                    var t2 = dp(k, n - x);
                    if (t1 < t2) l = x;
                    else if (t1 > t2) h = x;
                    else
                        l = h = x;
                }
                ans = 1 + Math.Min(Math.Max(dp(k - 1, l - 1), dp(k,n-l)),Math.Max(dp(k-1,h-1),dp(k,n-h)));
            }
            memo.Add(n * 100 + k, ans);
            return ans;
        }
        // Let's find dp2[m] = dp(j, m)
        // Increase our optimal x while we can make our answer better.
        // Notice max(dp[x-1], dp2[m-x]) > max(dp[x], dp2[m-x-1])
        // is simply max(T1(x-1), T2(x-1)) > max(T1(x), T2(x)).
        //这里的 T1(x) 和 T2(x) 实际上是对 dp[x - 1] 和 dp2[m - x] 的简写，
        //分别代表在当前层 x 鸡蛋碎了（即从 x 层往下丢鸡蛋碎了，
        //此时考虑的是前 x-1 层，对应 dp[x - 1]）和鸡蛋没碎
        //（即从 x 层往下丢鸡蛋没碎，此时考虑的是从 x+1 到 m 层，对应 dp2[m - x]）两种情况下的最坏情况尝试次数。
        //这行注释的意思是说，当我们在第 x 层尝试时，如果发现 max(dp[x - 1], dp2[m - x])
        //比 max(dp[x], dp2[m - x - 1]) 大，这意味着增加尝试层数 x 可以减少最坏情况下的尝试次数。
        //换句话说，如果我们把尝试的楼层从 x-1 增加到 x，那么在最坏情况下需要的尝试次数会减少，
        //因此我们应该继续增加 x 直到不能再减少最坏情况下的尝试次数为止。
        public int SuperEggDrop2(int k, int n)
        {
            var dp = new int[n + 1];
            for (var i = 0; i <= n; i++)
                dp[i] = i;
            for(var j=2;j<=k;j++)
            {
                var dp2 = new int[n + 1];
                var x = 1;
                for(var m=1;m<=n;m++)
                {
                    while(x<m && Math.Max(dp[x - 1], dp2[m - x]) > Math.Max(dp[x], dp2[m-x-1]))
                        x++;
                    dp2[m] = 1 + Math.Max(dp[x - 1], dp2[m - x]);
                }
                dp = dp2;
            }
            return dp[n];
        }

        public int SuperEggDrop3(int k, int n)
        {
            if (n == 1) return 1;
            var f = new int[n + 1,k+1];
            for(var i=1;i<=k;i++)
            {
               f[1,i] = 1;

            }
            var ans = -1;
            for(var i=2;i<=n;i++)
            {
                for(var j=1;j<=k;j++)
                {
                    f[i, j] = 1 + f[i - 1, j - 1] + f[i - 1, j];
                }
                if (f[i,k] >=n)
                {
                    ans = i;
                    break;
                }
            }
            return ans;
        }
    }
}
