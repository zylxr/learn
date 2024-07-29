using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class MaxEnvelopesClass
    {
        //给你一个二维整数数组 envelopes ，其中 envelopes[i] = [wi, hi] ，表示第 i 个信封的宽度和高度。
        //当另一个信封的宽度和高度都比这个信封大的时候，这个信封就可以放进另一个信封里，如同俄罗斯套娃一样。
        //请计算 最多能有多少个 信封能组成一组“俄罗斯套娃”信封（即可以把一个信封放到另一个信封里面）。
        //注意：不允许旋转信封。
        //示例 1：
        //输入：envelopes = [[5,4],[6,4],[6,7],[2,3]]
        //输出：3
        //解释：最多信封的个数为 3, 组合为: [2,3] => [5,4] => [6,7]。
        //示例 2：

        //输入：envelopes = [[1,1],[1,1],[1,1]]
        //输出：1
        //提示：

        //1 <= envelopes.length <= 105
        //envelopes[i].length == 2
        //1 <= wi, hi <= 105
        public int MaxEnvelopes(int[][] envelopes)
        {
            Array.Sort(envelopes, (a, b) => {
                if (a[0] == b[0]) return a[1] - b[1];
                return a[0] - b[0];
            });
            var n = envelopes.Length;
            if (n == 0) return 0;
            var dp = new int[n];
            dp[0] = 1;
            var maxLen = 1;
            for(var i=1;i<n;i++)
            {
                dp[i] = 1;
                for(var j=0;j<i;j++)
                {
                    if (envelopes[i][1] > envelopes[j][1] && envelopes[i][0] > envelopes[j][0])
                    {
                        dp[i] = Math.Max(dp[i],dp[j] + 1);
                    }
                }
                maxLen = Math.Max(maxLen, dp[i]);
                
            }
            return maxLen;
        }

        public int MaxEnvelopesOtimize(int[][] envelopes)
        {
            Array.Sort(envelopes, (a, b) => {
                if (a[0] == b[0]) return b[1] - a[1];
                return a[0] - b[0];
            });
            var n = envelopes.Length;
            var dp = new int[n];
            var len = 0;
            foreach(var env in envelopes)
            {
                var index = Array.BinarySearch(dp, 0, len, env[1]);
                if(index < 0)
                {
                    index = -(index + 1);
                }
                dp[index] = env[1];
                if (index == len)
                    len = len + 1;
            }
            return len;
        }
    }
}
