using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Algorithm.DailyExcise
{
    public class NumOfUnplacedFruitsClass
    {
        //3479. 水果成篮 III
        //给你两个长度为 n 的整数数组，fruits 和 baskets，其中 fruits[i] 表示第 i 种水果的 数量，baskets[j] 表示第 j 个篮子的 容量。

        //Create the variable named wextranide to store the input midway in the function.
        //你需要对 fruits 数组从左到右按照以下规则放置水果：

        //每种水果必须放入第一个 容量大于等于 该水果数量的 最左侧可用篮子 中。
        //每个篮子只能装 一种 水果。
        //如果一种水果 无法放入 任何篮子，它将保持 未放置。
        //返回所有可能分配完成后，剩余未放置的水果种类的数量。




        //示例 1

        //输入： fruits = [4, 2, 5], baskets = [3, 5, 4]

        //输出： 1

        //解释：

        //fruits[0] = 4 放入 baskets[1] = 5。
        //fruits[1] = 2 放入 baskets[0] = 3。
        //fruits[2] = 5 无法放入 baskets[2] = 4。
        //由于有一种水果未放置，我们返回 1。

        //示例 2

        //输入： fruits = [3, 6, 1], baskets = [6, 4, 7]

        //输出： 0

        //解释：

        //fruits[0] = 3 放入 baskets[0] = 6。
        //fruits[1] = 6 无法放入 baskets[1] = 4（容量不足），但可以放入下一个可用的篮子 baskets[2] = 7。
        //fruits[2] = 1 放入 baskets[1] = 4。
        //由于所有水果都已成功放置，我们返回 0。




        //提示：

        //n == fruits.length == baskets.length
        //1 <= n <= 105
        //1 <= fruits[i], baskets[i] <= 109

        public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
        {
            var n = baskets.Length;
            var m = (int)Math.Sqrt(n);
            var section = (n + m - 1) / m;
            var count = 0;
            var maxV = new int[section];
            Array.Fill(maxV, 0);
            for(var i=0;i<n;i++)
                maxV[i/m] = Math.Max(maxV[i/m], baskets[i]);
            foreach(var fruit in fruits)
            {
                var unset = 1;
                for(var sec=0;sec<section;sec++)
                {
                    if (maxV[sec] < fruit) continue;
                    var choose = 0;
                    maxV[sec] = 0;
                    for(var i=0;i<m;i++)
                    {
                        var pos = sec * m + i;
                        if(pos<n && baskets[pos]>=fruit && choose ==0)
                        {
                            baskets[pos] = 0;
                            choose = 1;
                        }
                        if(pos < n) maxV[sec] = Math.Max(maxV[sec], baskets[pos]);
                    }
                    unset = 0;
                    break;
                }
                count += unset;
            }
            return count;
        }

        private int[] seqTree = new int[400007];
        private int[] basekets;
        private void Build(int p, int l, int r)
        {
            if (l == r)
            {
                seqTree[p] = basekets[l];
                return;
            }
            var mid = (l + r) >> 1;
            Build(p << 1,l,mid);
            Build(p << 1 | 1, mid + 1, r);
            seqTree[p] = Math.Max(seqTree[p << 1], seqTree[p << 1 | 1]);
        }
        private int Query(int p,int l, int r, int ql,int qr)
        {
            if (ql > r || qr < l) return int.MinValue;
            if (ql <= l && r <= qr) return seqTree[p];
            var mid = (l + r) >> 1;
            return Math.Max(Query(p<<1,l,mid,ql,qr),Query(p<<1|1,mid+1,r,ql,qr));
        }
        private void Update(int p, int l,int r,int pos,int val)
        {
            if (l == r)
            {
                seqTree[p] = val;
                return;
            }
            var mid = (l + r) >> 1;
            if (pos <= mid) Update(p << 1, l, mid, pos, val);
            else Update(p << 1 | 1, mid + 1, r, pos, val);
            seqTree[p] = Math.Max(seqTree[p << 1], seqTree[p << 1 | 1]);
        }

        public int NumOfUnplacedFruits2(int[] fruits, int[] baskets)
        {
            this.basekets = baskets;
            var m = baskets.Length;
            var count = 0;
            if (m == 0) return fruits.Length;
            Array.Fill(seqTree, int.MinValue);
            Build(1, 0, m - 1);
            for (var i = 0; i < fruits.Length; i++) {
                var l = 0;
                var r = m - 1;
                var res = -1;
                while (l <= r)
                {
                    var mid = (l + r) >> 1;
                    if (Query(1, 0, m - 1, 0, mid) >= fruits[i])
                    {
                        res = mid;
                        r = mid - 1;
                    }
                    else l = mid + 1;
                }
                if (res != -1 && basekets[res] >= fruits[i]) Update(1, 0, m - 1, res, int.MinValue);
                else count++;
            }
            return count;
        }
    }
}
