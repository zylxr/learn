using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Algorithm.DailyExcise
{
    public class DistributeCandiesClass
    {
        //给你两个正整数 n 和 limit 。

        //请你将 n 颗糖果分给 3 位小朋友，确保没有任何小朋友得到超过 limit 颗糖果，请你返回满足此条件下的 总方案数 。
        //示例 1：

        //输入：n = 5, limit = 2
        //输出：3
        //解释：总共有 3 种方法分配 5 颗糖果，且每位小朋友的糖果数不超过 2 ：(1, 2, 2) ，(2, 1, 2) 和(2, 2, 1) 。

        //示例 2：
        //输入：n = 3, limit = 3
        //输出：10
        //解释：总共有 10 种方法分配 3 颗糖果，且每位小朋友的糖果数不超过 3 ：(0, 0, 3) ，(0, 1, 2) ，(0, 2, 1) ，(0, 3, 0) ，(1, 0, 2) ，(1, 1, 1) ，(1, 2, 0) ，(2, 0, 1) ，(2, 1, 0) 和(3, 0, 0) 。
 

        //提示：

        //1 <= n <= 50
        //1 <= limit <= 50
        public int DistributeCandiesByEnum(int n, int limit)
        {
            var ans = 0;
            for(var i=0;i<=limit;i++)
            {
                for(var j=0;j<=limit;j++)
                {
                    var k = n - i - j;
                    if (k > limit||k<0) continue;
                    ans++;
                }
            }
            return ans;
        }

        //枚举第一个小朋友分得 x 颗糖果，那么还剩下 n−x 颗糖果，此时有两种情况：
        //n−x>limit×2，至少有一个小朋友会分得大于 limit颗糖果，此时不存在合法方案。
        //n−x≤limit×2，对于第二个小朋友来说，至少得分得 max⁡(0, n−x−limit) 颗糖果，
        //才能保证第三个小朋友分得的糖果不超过 limit 颗。同时至多能拿到 min⁡(limit, n−x) 颗糖果。
        public int DistributeCandiesByOptimization(int n, int limit)
        {
            var ans = 0;
            for(var i=0;i<=Math.Min(limit,n);i++)
            {
                if(n-i>2* limit) continue;
                ans += Math.Min(n - i, limit) - Math.Max(0, n - i - limit) + 1;
            }
            return ans;
        }

        //也可以采用常规计数的思想，用所有方案减去不合法的方案。使用组合数学的容斥原理，用所有的方案数减去至少有一个小朋友分得超过 limit颗糖果。
        //但会重复计算至少有两个小朋友分得超过 limit 颗糖果，因此把这部分加回来。
        //计算这部分的时候又会重复计算三个小朋友都分得超过 limit 颗糖果的方案，因此再减去这部分方案数。
        //对于所有的方案数，因为允许小朋友分得 0 颗糖果，问题可转化为在 n+3 颗糖果中插两块板，使得每位小朋友至少分得一颗糖果。
        //在 n+3 颗糖果中有 n+2 个空位，故方案数为 Cn+2^2，这里使用 C来表示组合数。
        //至少有一个小朋友分得超过 limit 颗糖果的方案数，可以先给任意一个小朋友分得 limit+1 颗糖果，此时问题转化为将 n−limit−1 颗糖果分给三个小朋友，
        //故方案数为 C3^1×Cn−(limit+1)+2^2。
        //至少有两个小朋友分得超过 limit 颗糖果的方案数，可以先给任意两个小朋友分得 limit+1 颗糖果，
        //此时问题转化为将 n−(limit+1)×2 颗糖果分给三个小朋友，故方案数为 C3^2×Cn−(limit+1)×2+2^2。
        //至少有三个小朋友分得超过 limit 颗糖果的方案数，可以先给三个小朋友分得 limit+1 颗糖果，
        //此时问题转化为将 n−(limit+1)×3 颗糖果分给三个小朋友，故方案数为 Cn−(limit+1)×3+2^2
        //最后整理方案数为 Cn+2^2−C3^1×Cn−(limit+1)+2^2+C3^2×Cn−(limit+1)×2+2^2−Cn−(limit+1)×3+2^2。

        public int DistributeCandiesByRongChi(int n, int limit)
        {
            return calc(n + 2) - 3 * calc(n + 2 - (limit + 1)) + 3 * calc(n + 2 - (limit + 1) * 2) - calc(n + 2 - 3 * (limit + 1));
        }

        public int calc(int x)
        {
            return x < 0 ? 0 : x * (x - 1) >> 1;
        }
    }
}
