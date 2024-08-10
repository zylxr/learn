using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class LeftmostBuildingQueriesClass
    {
        //找到 Alice 和 Bob 可以相遇的建筑
        //给你一个下标从 0 开始的正整数数组 heights ，其中 heights[i] 表示第 i 栋建筑的高度。

        //如果一个人在建筑 i ，且存在 i<j 的建筑 j 满足 heights[i] < heights[j] ，那么这个人可以移动到建筑 j 。

        //给你另外一个数组 queries ，其中 queries[i] = [ai, bi] 。第 i 个查询中，Alice 在建筑 ai ，Bob 在建筑 bi 。

        //请你能返回一个数组 ans ，其中 ans[i] 是第 i 个查询中，Alice 和 Bob 可以相遇的 最左边的建筑 。如果对于查询 i ，Alice 和 Bob 不能相遇，令 ans[i] 为 -1 。




        //示例 1：

        //输入：heights = [6, 4, 8, 5, 2, 7], queries = [[0, 1], [0, 3], [2, 4], [3, 4], [2, 2]]
        //输出：[2, 5, -1, 5, 2]
        //解释：第一个查询中，Alice 和 Bob 可以移动到建筑 2 ，因为 heights[0] < heights[2] 且 heights[1] < heights[2] 。
        //第二个查询中，Alice 和 Bob 可以移动到建筑 5 ，因为 heights[0] < heights[5] 且 heights[3] < heights[5] 。
        //第三个查询中，Alice 无法与 Bob 相遇，因为 Alice 不能移动到任何其他建筑。
        //第四个查询中，Alice 和 Bob 可以移动到建筑 5 ，因为 heights[3] < heights[5] 且 heights[4] < heights[5] 。
        //第五个查询中，Alice 和 Bob 已经在同一栋建筑中。
        //对于 ans[i] != -1 ，ans[i] 是 Alice 和 Bob 可以相遇的建筑中最左边建筑的下标。
        //对于 ans[i] == -1 ，不存在 Alice 和 Bob 可以相遇的建筑。
        //示例 2：

        //输入：heights = [5, 3, 8, 2, 6, 1, 4, 6], queries = [[0, 7], [3, 5], [5, 2], [3, 0], [1, 6]]
        //输出：[7, 6, -1, 4, 6]
        //解释：第一个查询中，Alice 可以直接移动到 Bob 的建筑，因为 heights[0] < heights[7] 。
        //第二个查询中，Alice 和 Bob 可以移动到建筑 6 ，因为 heights[3] < heights[6] 且 heights[5] < heights[6] 。
        //第三个查询中，Alice 无法与 Bob 相遇，因为 Bob 不能移动到任何其他建筑。
        //第四个查询中，Alice 和 Bob 可以移动到建筑 4 ，因为 heights[3] < heights[4] 且 heights[0] < heights[4] 。
        //第五个查询中，Alice 可以直接移动到 Bob 的建筑，因为 heights[1] < heights[6] 。
        //对于 ans[i] != -1 ，ans[i] 是 Alice 和 Bob 可以相遇的建筑中最左边建筑的下标。
        //对于 ans[i] == -1 ，不存在 Alice 和 Bob 可以相遇的建筑。



        //提示：

        //1 <= heights.length <= 5 * 104
        //1 <= heights[i] <= 109
        //1 <= queries.length <= 5 * 104
        //queries[i] = [ai, bi]
        //0 <= ai, bi <= heights.length - 1
        public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
        {
            var n = queries.Length;
            var ans = new int[n];
            var m = heights.Length;
            Array.Fill(ans, -1);
            for(var i=0;i<n;i++)
            {
                var q = queries[i];
                var maxIndex = Math.Max(q[0], q[1]);
                if (heights[q[0]] <=heights[maxIndex] && heights[q[1]]<=heights[maxIndex]&& heights[q[0]]!= heights[q[1]] || q[0] == q[1])
                {
                    ans[i] = maxIndex;
                    continue;
                }
                var maxheight = Math.Max(heights[q[0]], heights[q[1]]);
                for(var j=maxIndex+1;j<m;j++)
                {
                    if(maxheight< heights[j])
                    {
                        ans[i] = j;
                        break;
                    }
                }
                
            }
            return ans;
        }

        /// <summary>
        /// 线段树
        /// </summary>
        int[] zd;
        public int[] LeftmostBuildingQueries2(int[] heights, int[][] queries)
        {
            var n = heights.Length;
            var m = queries.Length;
            var ans = new int[m];
            zd = new int[4 * n];
            Build(1, n, 1, heights);
            for(var i=0;i<m;i++)
            {
                var a = queries[i][0];
                var b = queries[i][1];
                if(a>b)
                {
                    var tmp = a;
                    a = b;
                    b = tmp;
                }
                if(a==b || heights[a] < heights[b])
                {
                    ans[i] = b;
                    continue;
                }
                ans[i] = Query(b + 1, heights[a],1,n,1)-1;
            }
            return ans;
        }
        public void Build(int l, int r, int rt, int[] heights)
        {
            if (l == r)
            {
                zd[rt] = heights[l - 1];
                return;
            }
            var mid = (l + r) >> 1;
            Build(l,mid,rt<<1,heights);
            Build(mid + 1, r, rt << 1|1, heights);
            zd[rt] = Math.Max(zd[rt << 1], zd[rt << 1 |1]);
        }

        public int Query(int pos,int val, int l,int r,int rt)
        {
            if (val >= zd[rt]) return 0;
            if (l == r)return l;
            var mid =(l + r) >> 1;
            if(pos<=mid)
            {
                var res = Query(pos, val, l, mid, rt << 1);
                if(res != 0)return res;
            }
            return Query(pos, val, mid + 1, r, rt << 1 | 1);
        }

        public int[] LeftmostBuildingQueries3(int[] heights, int[][] queries)
        {
            var n = heights.Length;
            var m = queries.Length;
            var ans = new int[m];
            var query = new IList<Tuple<int, int>>[n];
            for(var i=0;i<n;i++)
            {
                query[i] = new List<Tuple<int, int>>();
            }
            var st = new List<int>();
            for (var i = 0; i < m; i++)
            {
                var a = queries[i][0];
                var b = queries[i][1];
                if (a > b)
                {
                    var tmp = a;
                    a = b;
                    b = tmp;
                }
                if (a == b || heights[a] < heights[b])
                {
                    ans[i] = b;
                    continue;
                }
                query[b].Add(new Tuple<int, int>(i, heights[a]));
            }
            var top = -1;
            for(var i=n-1;i>=0;i--)
            {
                for (var j = 0; j < query[i].Count;j++)
                {
                    var q = query[i][j].Item1;
                    var val = query[i][j].Item2;
                    if(top == -1 || heights[st[0]]<=val)
                    {
                        ans[q] = -1;
                        continue;
                    }
                    var l = 0;
                    var r = top;
                    while(l<=r)
                    {
                        var mid = (l + r) >> 1;
                        if (heights[st[mid]] > val)
                        {
                            l = mid + 1;
                        }
                        else
                            r = mid - 1;
                    }
                    ans[q] = st[r];
                }
                while (top >= 0 && heights[st[top]] <= heights[i])
                {
                    st.RemoveAt(st.Count - 1);
                    top--;
                }
                st.Add(i);
                top++;
            }
            return ans;
        }
    }
}
