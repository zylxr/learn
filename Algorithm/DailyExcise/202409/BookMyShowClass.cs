using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Algorithm.DailyExcise
{
    public class BookMyShowClass
    {
        //2286. 以组为单位订音乐会的门票
        //一个音乐会总共有 n 排座位，编号从 0 到 n - 1 ，每一排有 m 个座椅，编号为 0 到 m - 1 。你需要设计一个买票系统，针对以下情况进行座位安排：

        //同一组的 k 位观众坐在 同一排座位，且座位连续 。
        //k 位观众中 每一位 都有座位坐，但他们 不一定 坐在一起。
        //由于观众非常挑剔，所以：

        //只有当一个组里所有成员座位的排数都 小于等于 maxRow ，这个组才能订座位。每一组的 maxRow 可能 不同 。
        //如果有多排座位可以选择，优先选择 最小 的排数。如果同一排中有多个座位可以坐，优先选择号码 最小 的。
        //请你实现 BookMyShow 类：

        //BookMyShow(int n, int m) ，初始化对象，n 是排数，m 是每一排的座位数。
        //int[] gather(int k, int maxRow) 返回长度为 2 的数组，表示 k 个成员中 第一个座位 的排数和座位编号，这 k 位成员必须坐在 同一排座位，且座位连续 。换言之，返回最小可能的 r 和 c 满足第 r 排中[c, c + k - 1] 的座位都是空的，且 r <= maxRow 。如果 无法 安排座位，返回[] 。
        //boolean scatter(int k, int maxRow) 如果组里所有 k 个成员 不一定 要坐在一起的前提下，都能在第 0 排到第 maxRow 排之间找到座位，那么请返回 true 。这种情况下，每个成员都优先找排数 最小 ，然后是座位编号最小的座位。如果不能安排所有 k 个成员的座位，请返回 false 。


        //示例 1：

        //输入：
        //["BookMyShow", "gather", "gather", "scatter", "scatter"]
        //[[2, 5], [4, 0], [2, 0], [5, 1], [5, 1]]
        //输出：
        //[null, [0, 0], [], true, false]

        //解释：
        //BookMyShow bms = new BookMyShow(2, 5); // 总共有 2 排，每排 5 个座位。
        //bms.gather(4, 0); // 返回 [0, 0]
        //        // 这一组安排第 0 排 [0, 3] 的座位。
        //bms.gather(2, 0); // 返回 []
        //        // 第 0 排只剩下 1 个座位。
        //        // 所以无法安排 2 个连续座位。
        //bms.scatter(5, 1); // 返回 True
        //        // 这一组安排第 0 排第 4 个座位和第 1 排 [0, 3] 的座位。
        //bms.scatter(5, 1); // 返回 False
        //        // 总共只剩下 2 个座位。


        //提示：

        //1 <= n <= 5 * 104
        //1 <= m, k <= 109
        //0 <= maxRow <= n - 1
        //gather 和 scatter 总 调用次数不超过 5 * 104 次。

        private int rows;
        private int cols;
        private HashSet<(int, int)> hs;
        private int[] minTree;
        private int[] sumTree;
        public BookMyShowClass(int n, int m)
        {
            rows = n;
            cols = m;
            hs = new HashSet<(int, int)>();
            minTree = new int[4 * n];
            sumTree = new int[4 * n];
        }

        private void Modify(int i, int l, int r, int index, int val)
        {
            if (l == r)
            {
                minTree[i] = val;
                sumTree[i] = val;
                return;
            }
            var mid = (l + r) >> 1;
            if (index <= mid)
                Modify(i << 1, l, mid, index, val);
            else
                Modify(i << 1 | 1, mid + 1, r, index, val);
            minTree[i] = Math.Min(minTree[i << 1], minTree[i << 1 | 1]);
            sumTree[i] = sumTree[i << 1] + sumTree[i << 1 | 1];
        }
        private int QueryMinRow(int i, int l,int r,int val)
        {
            if(l==r)
            {
                if (minTree[i] > val) return rows;
                return l;
            }
            var mid = (l + r) >> 1;
            if (minTree[i << 1] <= val)
                return QueryMinRow(i << 1, l, mid, val);
            else
                return QueryMinRow(i << 1 | 1, mid + 1, r, val);
        }
        private long QuerySum(int i, int l, int r,int l2,int r2)
        {
            if (r < l2 || l > r2) return 0;
            if (l >= l2 && r <= r2) return sumTree[i];
            var mid = (l + r) >> 1;
            return QuerySum(i << 1, l, mid, l2, r2) + QuerySum(i << 1 | 1, mid + 1, r, l2, r2);
        }

        public int[] Gather2(int k, int maxRow)
        {
            var i = QueryMinRow(1, 0, rows-1, cols - k);
            if (i > maxRow) return new int[0];
            long used = QuerySum(1, 0, rows - 1, i, i);
            Modify(1, 0, rows - 1, i, (int)(used + k));
            return new int[] {i,(int)used };
        }
        public bool Scatter2(int k, int maxRow)
        {
            long usedTotal = QuerySum(1, 0, rows - 1, 0, maxRow);
            if ((maxRow + 1L) * cols - usedTotal < k) return false;
            var i = QueryMinRow(1, 0, rows - 1, cols - 1);
            while(true)
            {
                long used = QuerySum(1, 0, rows - 1, i, i);
                if(cols-used>=k)
                {
                    Modify(1, 0, rows - 1, i, (int)(used + k));
                    break;
                }
                k -= cols - (int)used;
                Modify(1, 0, rows - 1, i, cols);
                i++;
            }
            return true;
        }
        public int[] Gather(int k, int maxRow)
        {
            var max = Math.Min(maxRow, rows);
            if (k > cols || maxRow < 0) return [];
            var tmp = new HashSet<(int,int)>();
            for (var i = 0; i <= max; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    var t = j;
                    while (t - j < k&& t<cols && !hs.Contains((i,t)))
                    {
                        tmp.Add((i, t));
                        t++;
                    }
                    if (t - j == k)
                    {
                        hs.UnionWith(tmp);
                        return new int[] { i, j };
                    }
                    else tmp.Clear();
                }
            }
            return [];
        }

        public bool Scatter(int k, int maxRow)
        {
            if (maxRow < 0) return false;
            var max = Math.Min(maxRow, rows);
            var tmp = new HashSet<(int, int)>();
            for (var i = 0; i <= max; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (!hs.Contains((i, j)))
                    {
                        tmp.Add((i, j));
                    }
                    if (tmp.Count == k)
                    {
                        hs.UnionWith(tmp);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
