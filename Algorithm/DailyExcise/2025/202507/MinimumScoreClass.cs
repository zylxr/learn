using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinimumScoreClass
    {
        //2322. 从树中删除边的最小分数
        //存在一棵无向连通树，树中有编号从 0 到 n - 1 的 n 个节点， 以及 n - 1 条边。

        //给你一个下标从 0 开始的整数数组 nums ，长度为 n ，其中 nums[i] 表示第 i 个节点的值。另给你一个二维整数数组 edges ，长度为 n - 1 ，其中 edges[i] = [ai, bi] 表示树中存在一条位于节点 ai 和 bi 之间的边。

        //删除树中两条 不同 的边以形成三个连通组件。对于一种删除边方案，定义如下步骤以计算其分数：

        //分别获取三个组件 每个 组件中所有节点值的异或值。
        //最大 异或值和 最小 异或值的 差值 就是这一种删除边方案的分数。
        //例如，三个组件的节点值分别是：[4, 5, 7]、[1, 9] 和[3, 3, 3] 。三个异或值分别是 4 ^ 5 ^ 7 = 6、1 ^ 9 = 8 和 3 ^ 3 ^ 3 = 3 。最大异或值是 8 ，最小异或值是 3 ，分数是 8 - 3 = 5 。
        //返回在给定树上执行任意删除边方案可能的 最小 分数。



        //示例 1：


        //输入：nums = [1, 5, 5, 4, 11], edges = [[0, 1],[1, 2],[1, 3],[3, 4]]
        //输出：9
        //解释：上图展示了一种删除边方案。
        //- 第 1 个组件的节点是[1, 3, 4] ，值是[5, 4, 11] 。异或值是 5 ^ 4 ^ 11 = 10 。
        //- 第 2 个组件的节点是[0] ，值是[1] 。异或值是 1 = 1 。
        //- 第 3 个组件的节点是[2] ，值是[5] 。异或值是 5 = 5 。
        //分数是最大异或值和最小异或值的差值，10 - 1 = 9 。
        //可以证明不存在分数比 9 小的删除边方案。
        //示例 2：


        //输入：nums = [5, 5, 2, 4, 4, 2], edges = [[0, 1],[1, 2],[5, 2],[4, 3],[1, 3]]
        //输出：0
        //解释：上图展示了一种删除边方案。
        //- 第 1 个组件的节点是[3, 4] ，值是[4, 4] 。异或值是 4 ^ 4 = 0 。
        //- 第 2 个组件的节点是[1, 0] ，值是[5, 5] 。异或值是 5 ^ 5 = 0 。
        //- 第 3 个组件的节点是[2, 5] ，值是[2, 2] 。异或值是 2 ^ 2 = 0 。
        //分数是最大异或值和最小异或值的差值，0 - 0 = 0 。
        //无法获得比 0 更小的分数 0 。


        //提示：

        //n == nums.length
        //3 <= n <= 1000
        //1 <= nums[i] <= 108
        //edges.length == n - 1
        //edges[i].length == 2
        //0 <= ai, bi<n
        //ai != bi
        //edges 表示一棵有效的树
        public int MinimumScore(int[] nums, int[][] edges)
        {
            var n = nums.Length;
            var e = new List<List<int>>();
            for(var i=0;i<n;i++)e.Add(new List<int>());
            foreach(var v in edges)
            {
                e[v[0]].Add(v[1]);
                e[v[1]].Add(v[0]);
            }
            var sum = 0;
            foreach (var x in nums) sum ^= x;

            var res = int.MaxValue;
            Func<int, int, int> dfs = null;
            Func<int,int,int,int,int> dfs2 = null;

            dfs2 = (x, f, oth, anc) => {
                var son = nums[x];
                foreach(var y in e[x])
                {
                    if (y == f) continue;
                    son ^=dfs2(y,x,oth,anc);
                }
                if (f == anc) return son;
                res = Math.Min(res, Calc(oth, son, sum ^ oth ^ son));
                return son;
            };

            dfs = (x, f) =>
            {
                var son = nums[x];
                foreach(var y in e[x])
                {
                    if (y == f) continue;
                    son ^= dfs(y, x);
                }
                foreach(var y in e[x])
                {
                    if (y == f) dfs2(y, x, son, x);
                }
                return son;
            };
            dfs(0, -1);
            return res;
        }

        public int Calc(int part1,int part2,int part3)
        {
            return Math.Max(part1, Math.Max(part2, part3)) - Math.Min(part1, Math.Min(part2, part3));;
        }

        public int MinimumScore2(int[] nums, int[][] edges)
        {
            var n = nums.Length;
            var adj = new List<List<int>>();
            for(var i=0;i<n;i++)adj.Add(new List<int>());
            foreach(var e in edges)
            {
                adj[e[0]].Add(e[1]);
                adj[e[1]].Add(e[0]);
            }

            var sum = new int[n];
            var in_ = new int[n];
            var out_ = new int[n];
            var cnt = 0;
            Dfs22(0, -1, nums, adj, sum, in_, out_, ref cnt);

            var res = int.MaxValue;
            for(var u=1;u<n;u++)
            {
                for(var v=u+1; v<n;v++)
                {
                    if (in_[v] > in_[u] && in_[v] < out_[u]) res = Math.Min(res, Calc(sum[0] ^ sum[u], sum[u] ^ sum[v], sum[v]));
                    else if (in_[u] > in_[v] && in_[u] < out_[v]) res = Math.Min(res, Calc(sum[0] ^ sum[v], sum[v] ^ sum[u], sum[u]));
                    else res = Math.Min(res, Calc(sum[0] ^ sum[u] ^ sum[v], sum[u], sum[v]));
                }
            }
            return res;
        }

        private void Dfs22(int x, int fa, int[] nums,List<List<int>> adj, int[] sum, int[] in_, int[] out_,ref int cnt)
        {
            in_[x] = cnt++;
            sum[x] = nums[x];
            foreach(var y in adj[x])
            {
                if (y == fa) continue;
                Dfs22(y,x,nums,adj,sum, in_, out_,ref cnt);
                sum[x] ^= sum[y];
            }
            out_[x] = cnt;
        }
    }
}
