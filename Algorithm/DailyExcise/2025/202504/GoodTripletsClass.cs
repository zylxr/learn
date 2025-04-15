using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class GoodTripletsClass
    {
        //2179. 统计数组中好三元组数目

        //给你两个下标从 0 开始且长度为 n 的整数数组 nums1 和 nums2 ，两者都是[0, 1, ..., n - 1] 的 排列 。

        //好三元组 指的是 3 个 互不相同 的值，且它们在数组 nums1 和 nums2 中出现顺序保持一致。换句话说，如果我们将 pos1v 记为值 v 在 nums1 中出现的位置，pos2v 为值 v 在 nums2 中的位置，那么一个好三元组定义为 0 <= x, y, z <= n - 1 ，且 pos1x<pos1y < pos1z 和 pos2x<pos2y<pos2z 都成立的 (x, y, z) 。

        //请你返回好三元组的 总数目 。




        //示例 1：

        //输入：nums1 = [2, 0, 1, 3], nums2 = [0, 1, 2, 3]
        //输出：1
        //解释：
        //总共有 4 个三元组 (x, y, z) 满足 pos1x<pos1y<pos1z ，分别是 (2,0,1) ，(2,0,3) ，(2,1,3) 和(0,1,3) 。
        //这些三元组中，只有(0,1,3) 满足 pos2x<pos2y < pos2z 。所以只有 1 个好三元组。
        //示例 2：

        //输入：nums1 = [4, 0, 1, 3, 2], nums2 = [4, 1, 0, 2, 3]
        //输出：4
        //解释：总共有 4 个好三元组 (4,0,3) ，(4,0,2) ，(4,1,3) 和(4,1,2) 。


        //提示：

        //n == nums1.length == nums2.length
        //3 <= n <= 105
        //0 <= nums1[i], nums2[i] <= n - 1
        //nums1 和 nums2 是[0, 1, ..., n - 1] 的排列。
        public long GoodTriplets(int[] nums1, int[] nums2)
        {
            //效率低，时间上会超时
            var dict = new Dictionary<int, int>();

            var n = nums2.Length;
            for (var i = 0; i < n; i++)
            {
                dict.TryAdd(nums2[i], i);
            }
            var ans = 0;
            for (var x = 0; x < n - 2; x++)
            {
                for (var y = x + 1; y < n - 1; y++)
                {
                    for (var z = y + 1; z < n; z++)
                    {
                        if (dict[nums1[x]] < dict[nums1[y]] && dict[nums1[y]] < dict[nums1[z]]) ans++;
                    }
                }
            }
            return ans;
        }

        public long GoodTriplets2(int[] nums1, int[] nums2)
        {
            var n = nums1.Length;
            var pos2 = new int[n];
            var reversedIndexMapping = new int[n];
            for (var i = 0; i < n; i++)
                pos2[nums2[i]] = i;
            for (var i = 0; i < n; i++)
                reversedIndexMapping[pos2[nums1[i]]] = i;
            var tree = new FenwickTreee(n);
            var res = 0L;
            for(var val =0;val<n;val++)
            {
                var pos = reversedIndexMapping[val];
                var left = tree.Query(pos);
                tree.Update(pos, 1);
                var right = (n - 1 - pos) - (val - left);
                res += (long)left * right;
            }
            return res;
        }

        public class FenwickTreee
        {
            private int[] tree;
            public FenwickTreee(int size)
            {
                tree = new int[size + 1];
            }
            public void Update(int index,int delta)
            {
                index++;
                while(index<tree.Length)
                {
                    tree[index] += delta;
                    index += index & -index;
                }
            }

            public int Query(int index)
            {
                index++;
                int res = 0;
                while(index>0)
                {
                    res += tree[index];
                    index -= index & -index;
                }
                return res;
            }
        }
    }
}
