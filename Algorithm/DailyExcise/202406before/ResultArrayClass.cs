using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Algorithm.DailyExcise
{
    public class ResultArrayClass
    {
        //给你一个下标从 1 开始、长度为 n 的整数数组 nums 。
        //现定义函数 greaterCount ，使得 greaterCount(arr, val) 返回数组 arr 中 严格大于 val 的元素数量。

        //你需要使用 n 次操作，将 nums 的所有元素分配到两个数组 arr1 和 arr2 中。在第一次操作中，将 nums[1] 追加到 arr1 。在第二次操作中，将 nums[2] 追加到 arr2 。之后，在第 i 次操作中：

        //如果 greaterCount(arr1, nums[i]) > greaterCount(arr2, nums[i]) ，将 nums[i] 追加到 arr1 。
        //如果 greaterCount(arr1, nums[i]) < greaterCount(arr2, nums[i]) ，将 nums[i] 追加到 arr2 。
        //如果 greaterCount(arr1, nums[i]) == greaterCount(arr2, nums[i]) ，将 nums[i] 追加到元素数量较少的数组中。
        //如果仍然相等，那么将 nums[i] 追加到 arr1 。
        //连接数组 arr1 和 arr2 形成数组 result 。例如，如果 arr1 == [1, 2, 3] 且 arr2 == [4, 5, 6] ，那么 result = [1, 2, 3, 4, 5, 6] 。

        //返回整数数组 result 。
        //示例 1：

        //输入：nums = [2, 1, 3, 3]
        //输出：[2, 3, 1, 3]
        //解释：在前两次操作后，arr1 = [2] ，arr2 = [1] 。
        //在第 3 次操作中，两个数组中大于 3 的元素数量都是零，并且长度相等，因此，将 nums[3] 追加到 arr1 。
        //在第 4 次操作中，两个数组中大于 3 的元素数量都是零，但 arr2 的长度较小，因此，将 nums[4] 追加到 arr2 。
        //在 4 次操作后，arr1 = [2, 3] ，arr2 = [1, 3] 。
        //因此，连接形成的数组 result 是[2, 3, 1, 3] 。

        //示例 2：
        //输入：nums = [5, 14, 3, 1, 2]
        //输出：[5, 3, 1, 2, 14]
        //解释：在前两次操作后，arr1 = [5] ，arr2 = [14] 。
        //在第 3 次操作中，两个数组中大于 3 的元素数量都是一，并且长度相等，因此，将 nums[3] 追加到 arr1 。
        //在第 4 次操作中，arr1 中大于 1 的元素数量大于 arr2 中的数量（2 > 1），因此，将 nums[4] 追加到 arr1 。
        //在第 5 次操作中，arr1 中大于 2 的元素数量大于 arr2 中的数量（2 > 1），因此，将 nums[5] 追加到 arr1 。
        //在 5 次操作后，arr1 = [5, 3, 1, 2] ，arr2 = [14] 。
        //因此，连接形成的数组 result 是[5, 3, 1, 2, 14] 。
        //示例 3：

        //输入：nums = [3, 3, 3, 3]
        //输出：[3, 3, 3, 3]
        //解释：在 4 次操作后，arr1 = [3, 3] ，arr2 = [3, 3] 。
        //因此，连接形成的数组 result 是[3, 3, 3, 3] 。


        //提示：

        //3 <= n <= 105
        //1 <= nums[i] <= 109
        public int[] ResultArray(int[] nums)
        {
            //根据题意，要实现 greaterCount\textit{ greaterCount}
            //greaterCount 函数，需要快速查找一个有序结构中，严格大于 val\textit{ val}
            //val 的元素数量。我们可以使用「树状数组」来实现这个数据结构，其它「线段树」结构也可以实现相同功能。

            //首先，因为我们只关心数组元素的大小关系，我们可以将数组「离散化」。

            //然后我们根据题意进行模拟，初始化两个数组和其对应的树，依次遍历原数组中的元素，根据题目条件，将元素加入到对应数组中，并将元素离散化后的数组索引加入到树中。

            //最后，返回连接数组即可。
            var n = nums.Length;
            var sortedNums = nums.Take(n).ToArray();
            Array.Sort(sortedNums);
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < sortedNums.Length; i++)
            {
                dict.TryAdd(sortedNums[i], i + 1);
            }

            var tree1 = new BinaryIndexTree(n);
            var tree2 = new BinaryIndexTree(n);
            var arr1 = new List<int>();
            var arr2 = new List<int>();
            tree1.Add(dict[nums[0]]);
            tree2.Add(dict[nums[1]]);
            arr1.Add(nums[0]);
            arr2.Add(nums[1]);
            for(var i=2;i<n;i++)
            {
                var count1 = arr1.Count - tree1.Get(dict[nums[i]]);
                var count2 = arr2.Count - tree2.Get(dict[nums[i]]);
                if(count1>count2 ||(count1 == count2 && arr1.Count<=arr2.Count))
                {
                    arr1.Add(nums[i]);
                    tree1.Add(dict[nums[i]]);
                }
                else
                {
                    arr2.Add(nums[i]);
                    tree2.Add(dict[nums[i]]);
                }
            }
            var count = 0;
            var ret = new int[n];
            for(var i=0;i<arr1.Count;i++)
                ret[count++] = arr1[i];
            for(var i=0;i<arr2.Count;i++)
                ret[count++] = arr2[i];
            return ret;            
        }

        //树状数组（Binary Indexed Tree，简称BIT），也被称为Fenwick树，是由Peter M. Fenwick于1994年发明的一种数据结构
        //它主要用于高效地处理数组中的动态单点更新（修改）和区间查询（求和）问题，
        //特别是在处理大量这类操作时表现出极高的效率。树状数组的核心优势在于，无论是更新还是查询操作，时间复杂度都可以保持在O(log n)，其中n是数组的长度。
        public class BinaryIndexTree
        {
            private int[] _tree;

            public BinaryIndexTree(int n)
            {
                _tree = new int[n+1];
            }

            public void Add(int i)
            {
                while (i < _tree.Length)
                {
                    _tree[i]++;
                    i += i & -i;// 相当于去掉最低位的1,返回非负整数x 在二进制表示下，第一个1和后面的0表示的数值（十进制的值）。
                }
            }

            public int Get(int i)
            {
                var sum = 0;
                while(i>0)
                {
                    sum += _tree[i];
                    i -= i & -i;// 移除最低位的1
                }
                return sum;
            }
        }
    }
}
