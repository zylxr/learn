using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaximumSumSubsequenceClass
    {
        //3165. 不包含相邻元素的子序列的最大和
        //给你一个整数数组 nums 和一个二维数组 queries，其中 queries[i] = [posi, xi]。

        //对于每个查询 i，首先将 nums[posi] 设置为 xi，然后计算查询 i 的答案，该答案为 nums 中 不包含相邻元素 的
        //子序列
        //的 最大 和。

        //返回所有查询的答案之和。

        //由于最终答案可能非常大，返回其对 109 + 7 取余 的结果。

        //子序列 是指从另一个数组中删除一些或不删除元素而不改变剩余元素顺序得到的数组。




        //示例 1：

        //输入：nums = [3, 5, 9], queries = [[1, -2],[0, -3]]

        //输出：21

        //解释：
        //执行第 1 个查询后，nums = [3, -2, 9]，不包含相邻元素的子序列的最大和为 3 + 9 = 12。
        //执行第 2 个查询后，nums = [-3,-2,9]，不包含相邻元素的子序列的最大和为 9 。

        //示例 2：

        //输入：nums = [0, -1], queries = [[0, -5]]

        //输出：0

        //解释：
        //执行第 1 个查询后，nums = [-5,-1]，不包含相邻元素的子序列的最大和为 0（选择空子序列）。



        //提示：

        //1 <= nums.length <= 5 * 104
        //-105 <= nums[i] <= 105
        //1 <= queries.length <= 5 * 104
        //queries[i] == [posi, xi]
        //0 <= posi <= nums.length - 1
        //-105 <= xi <= 105
        public const int MOD = 1000000007;
        public int MaximumSumSubsequence(int[] nums, int[][] queries)
        {
            var n = nums.Length;
            var tree = new SegTree(n);
            tree.Init(nums);
            long ans = 0;
            foreach(var q in queries)
            {
                tree.Update(q[0], q[1]);
                ans = (ans + tree.Query()) % MOD;
            }
            return (int)ans;
        }
        
    }

    public class SegTree
    {
        private int n;
        private SegNode[] tree;

        public SegTree(int n)
        {
            this.n = n;
            tree = new SegNode[4 * n + 1];
            for(var i =0;i<tree.Length;i++)
            {
                tree[i] = new SegNode();
            }
        }

        public void Init(int[] nums)
        {
            InternalInit(nums, 1, 1, n);
        }

        public void Update(int x, int v)
        {
            InternalUpdate(1, 1, n, x + 1, v);
        }
        public long Query()
        {
            return tree[1].Best();
        }
        private void InternalInit(int[] nums, int x, int l, int r)
        {
            if (l == r)
            {
                tree[x].Set(nums[l - 1]);
                return;
            }
            var mid = (l+ r) / 2;
            InternalInit(nums,x * 2, l, mid);
            InternalInit(nums, x * 2 + 1, mid + 1, r);
            PushUp(x);

        }

        private void InternalUpdate(int x, int l ,int r, int pos, int v)
        {
            if (l > pos || r < pos) return;
            if (l == r)
            {
                tree[x].Set(v);
                return;
            }
            var mid = (l + r) / 2;
            InternalUpdate(x * 2, l, mid, pos, v);
            InternalUpdate(x * 2 + 1, mid + 1, r, pos, v);
            PushUp(x);
        }
        private void PushUp(int x)
        {
            int l = x*2,r= x*2 + 1;
            tree[x].v00 = Math.Max(tree[l].v00 + tree[r].v10, tree[l].v01 + tree[r].v00);
            tree[x].v01 = Math.Max(tree[l].v00 + tree[r].v11, tree[l].v01 + tree[r].v01);
            tree[x].v10 = Math.Max(tree[l].v10 + tree[r].v10, tree[l].v11 + tree[r].v00);
            tree[x].v11 = Math.Max(tree[l].v10 + tree[r].v11, tree[l].v11+tree[r].v01);
        }
    }
    public class SegNode
    {
        public long v00, v01, v10, v11;
        public SegNode()
        {
            v00 = v01 = v10 = v11 = 0;
        }

        public void Set(long v)
        {
            v00 = v01 = v10 = 0;
            v11 = Math.Max(v, 0);
        }
        public long Best()
        {
            return v11;
        }
    }
}
