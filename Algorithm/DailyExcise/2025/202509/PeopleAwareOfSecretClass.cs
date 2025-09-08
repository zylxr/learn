using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class PeopleAwareOfSecretClass
    {
        //2327. 知道秘密的人数
        //在第 1 天，有一个人发现了一个秘密。

        //给你一个整数 delay ，表示每个人会在发现秘密后的 delay 天之后，每天 给一个新的人 分享 秘密。同时给你一个整数 forget ，表示每个人在发现秘密 forget 天之后会 忘记 这个秘密。一个人 不能 在忘记秘密那一天及之后的日子里分享秘密。

        //给你一个整数 n ，请你返回在第 n 天结束时，知道秘密的人数。由于答案可能会很大，请你将结果对 109 + 7 取余 后返回。




        //示例 1：

        //输入：n = 6, delay = 2, forget = 4
        //输出：5
        //解释：
        //第 1 天：假设第一个人叫 A 。（一个人知道秘密）
        //第 2 天：A 是唯一一个知道秘密的人。（一个人知道秘密）
        //第 3 天：A 把秘密分享给 B 。（两个人知道秘密）
        //第 4 天：A 把秘密分享给一个新的人 C 。（三个人知道秘密）
        //第 5 天：A 忘记了秘密，B 把秘密分享给一个新的人 D 。（三个人知道秘密）
        //第 6 天：B 把秘密分享给 E，C 把秘密分享给 F 。（五个人知道秘密）
        //示例 2：

        //输入：n = 4, delay = 1, forget = 3
        //输出：6
        //解释：
        //第 1 天：第一个知道秘密的人为 A 。（一个人知道秘密）
        //第 2 天：A 把秘密分享给 B 。（两个人知道秘密）
        //第 3 天：A 和 B 把秘密分享给 2 个新的人 C 和 D 。（四个人知道秘密）
        //第 4 天：A 忘记了秘密，B、C、D 分别分享给 3 个新的人。（六个人知道秘密）


        //提示：

        //2 <= n <= 1000
        //1 <= delay<forget <= n

        public int PeopleAwareOfSecret(int n, int delay, int forget)
        {
            var dp = new long[n + 1, 2];
            dp[1, 0] = 1;
            dp[1, 1] = 1;
            for (var i = 2; i <= n; i++)
            {
                dp[i, 0] = dp[i - 1, 0];
                var addIndex = Math.Max(i - delay, 0);
                var decIndex = Math.Max(0, i - forget);
                for (var j = decIndex + 1; j <= addIndex; j++)
                {
                    dp[i, 1] = (dp[i, 1] + dp[j, 1]) % MOD;
                }
                dp[i, 0] = (dp[i, 0] + dp[i, 1]) % MOD;



                dp[i, 0] = (dp[i, 0] - dp[decIndex, 1] + MOD) % MOD;
            }
            return (int)dp[n, 0];
        }
        public int PeopleAwareOfSecret2(int n, int delay, int forget)
        {
            var know = new LinkedList<int[]>();
            var share = new LinkedList<int[]>();
            know.AddLast(new int[] { 1, 1 });
            int knowCnt = 1, shareCnt = 0;
            for(var i=2;i<=n;i++)
            {
                if(know.First != null && know.First.Value[0] == i-delay)
                {
                    var first = know.First.Value;
                    know.RemoveFirst();
                    knowCnt = (knowCnt - first[1]+MOD) % MOD;
                    shareCnt = (shareCnt + first[1]) % MOD;
                    share.AddLast(first);
                }
                if(share.First!=null && share.First.Value[0] == i-forget)
                {
                    var first = share.First.Value;
                    share.RemoveFirst();
                    shareCnt = (shareCnt -  first[1]+MOD) % MOD;
                }
                if(share.First!=null)
                {
                    knowCnt = (knowCnt + shareCnt) % MOD;
                    know.AddLast(new int[] { i, shareCnt });
                }
            }
            return (knowCnt + shareCnt) % MOD;
        }
        private readonly int MOD = 1_000_000_007;
    }
}
