using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinimumCostClass7
    {
        //2976. 转换字符串的最小成本 I
        //给你两个下标从 0 开始的字符串 source 和 target ，它们的长度均为 n 并且由 小写 英文字母组成。

        //另给你两个下标从 0 开始的字符数组 original 和 changed ，以及一个整数数组 cost ，其中 cost[i] 代表将字符 original[i] 更改为字符 changed[i] 的成本。

        //你从字符串 source 开始。在一次操作中，如果 存在 任意 下标 j 满足 cost[j] == z  、original[j] == x 以及 changed[j] == y 。你就可以选择字符串中的一个字符 x 并以 z 的成本将其更改为字符 y 。

        //返回将字符串 source 转换为字符串 target 所需的 最小 成本。如果不可能完成转换，则返回 -1 。

        //注意，可能存在下标 i 、j 使得 original[j] == original[i] 且 changed[j] == changed[i] 。



        //示例 1：

        //输入：source = "abcd", target = "acbe", original = ["a", "b", "c", "c", "e", "d"], changed = ["b", "c", "b", "e", "b", "e"], cost = [2, 5, 5, 1, 2, 20]
        //输出：28
        //解释：将字符串 "abcd" 转换为字符串 "acbe" ：
        //- 更改下标 1 处的值 'b' 为 'c' ，成本为 5 。
        //- 更改下标 2 处的值 'c' 为 'e' ，成本为 1 。
        //- 更改下标 2 处的值 'e' 为 'b' ，成本为 2 。
        //- 更改下标 3 处的值 'd' 为 'e' ，成本为 20 。
        //产生的总成本是 5 + 1 + 2 + 20 = 28 。
        //可以证明这是可能的最小成本。
        //示例 2：

        //输入：source = "aaaa", target = "bbbb", original = ["a", "c"], changed = ["c", "b"], cost = [1, 2]
        //输出：12
        //解释：要将字符 'a' 更改为 'b'：
        //- 将字符 'a' 更改为 'c'，成本为 1 
        //- 将字符 'c' 更改为 'b'，成本为 2 
        //产生的总成本是 1 + 2 = 3。
        //将所有 'a' 更改为 'b'，产生的总成本是 3 * 4 = 12 。
        //示例 3：

        //输入：source = "abcd", target = "abce", original = ["a"], changed = ["e"], cost = [10000]
        //输出：-1
        //解释：无法将 source 字符串转换为 target 字符串，因为下标 3 处的值无法从 'd' 更改为 'e' 。


        //提示：

        //1 <= source.length == target.length <= 105
        //source、target 均由小写英文字母组成
        //1 <= cost.length== original.length == changed.length <= 2000
        //original[i]、changed[i] 是小写英文字母
        //1 <= cost[i] <= 106
        //original[i] != changed[i]

        public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
        {
            var res = 0;
            dict = new Dictionary<char, List<(char o, int c)>>();
            for (var i = 0; i < original.Length; i++)
            {
                dict.TryAdd(original[i], new List<(char, int)>());
                dict[original[i]].Add((changed[i], cost[i]));
            }
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] == target[i]) continue;
                var s = source[i];
                var t = target[i];
                var cnt = GetDict(s);
                if (!cnt.ContainsKey(t)) return -1;
                res += cnt[t];
            }
            return res;
        }
        Dictionary<char, List<(char o, int c)>> dict;
        private Dictionary<char, int> GetDict(char s)
        {
            var cnt = new Dictionary<char, int>();
            cnt.Add(s, 0);
            var pq = new PriorityQueue<(char, int), int>();
            var visited = new bool[26];
            Array.Fill(visited, false);
            pq.Enqueue((s, 0), 0);
            while (pq.Count > 0)
            {
                var item = pq.Dequeue();
                var c = item.Item1;
                var dist = item.Item2;
                if (visited[c - 'a'] || !dict.ContainsKey(c)) continue;
                visited[c - 'a'] = true;
                foreach (var neighbor in dict[c])
                {
                    var nc = neighbor.o;
                    var nd = neighbor.c;
                    cnt.TryAdd(nc, int.MaxValue);
                    if (nd + dist < cnt[nc])
                    {
                        cnt[nc] = nd + dist;
                        pq.Enqueue((nc, cnt[nc]), cnt[nc]);
                    }
                }

            }
            return cnt;
        }

        /// <summary>
        /// Flyd 算法
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="original"></param>
        /// <param name="changed"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public long MinimumCost2(string source, string target, char[] original, char[] changed, int[] cost)
        {
            var g = new int[26, 26];
            for(var i=0;i<26;i++)
            {
                for (var j = 0; j < 26; j++)
                    g[i, j] = int.MaxValue / 2;
                g[i, i] = 0;
            }
            var m = original.Length;
            for(var i=0;i<m;i++)
            {
                var idx = original[i] - 'a';
                var idy = changed[i] - 'a';
                g[idx, idy] = cost[i];
            }
            for(var k=0;k<26;k++)
            {
                for(var i=0;i<26; i++)
                {
                    for(var j=0;j<26; j++)
                    {
                        if (g[i,k] != int.MaxValue/2 && g[k,j] != int.MaxValue/2)
                        {
                            g[i, j] = Math.Min(g[i, j], g[i, k] + g[k, j]);
                        }
                    }
                }
            }
            var n = source.Length;
            var ans = 0;
            for(var i=0;i<n;i++)
            {
                var idx = source[i] - 'a';
                var idy = target[i] - 'a';
                if (g[idx, idy] == int.MaxValue / 2) return -1;
                ans += g[idx, idy];
            }
            return ans;
        }
    }
}
