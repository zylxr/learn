using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MyCalendarTwoClass
    {
        //731. 我的日程安排表 II
        //实现一个程序来存放你的日程安排。如果要添加的时间内不会导致三重预订时，则可以存储这个新的日程安排。

        //当三个日程安排有一些时间上的交叉时（例如三个日程安排都在同一时间内），就会产生 三重预订。

        //事件能够用一对整数 startTime 和 endTime 表示，在一个半开区间的时间[startTime, endTime) 上预定。实数 x 的范围为  startTime <= x < endTime。

        //实现 MyCalendarTwo 类：

        //MyCalendarTwo() 初始化日历对象。
        //boolean book(int startTime, int endTime) 如果可以将日程安排成功添加到日历中而不会导致三重预订，返回 true。否则，返回 false 并且不要将该日程安排添加到日历中。


        //示例 1：

        //输入：
        //["MyCalendarTwo", "book", "book", "book", "book", "book", "book"]
        //[[], [10, 20], [50, 60], [10, 40], [5, 15], [5, 10], [25, 55]]
        //输出：
        //[null, true, true, true, false, true, true]

        //解释：
        //MyCalendarTwo myCalendarTwo = new MyCalendarTwo();
        //myCalendarTwo.book(10, 20); // 返回 True，能够预定该日程。
        //myCalendarTwo.book(50, 60); // 返回 True，能够预定该日程。
        //myCalendarTwo.book(10, 40); // 返回 True，该日程能够被重复预定。
        //myCalendarTwo.book(5, 15);  // 返回 False，该日程导致了三重预定，所以不能预定。
        //myCalendarTwo.book(5, 10); // 返回 True，能够预定该日程，因为它不使用已经双重预订的时间 10。
        //myCalendarTwo.book(25, 55); // 返回 True，能够预定该日程，因为时间段 [25, 40) 将被第三个日程重复预定，时间段 [40, 50) 将被单独预定，而时间段 [50, 55) 将被第二个日程重复预定。


        //提示：

        //0 <= start<end <= 109
        //最多调用 book 1000 次。

        //利用线段树，假设我们开辟了数组 arr[0,⋯, 109 ]，初始时每个元素的值都为 0，
        //对于每次行程预定的区间[start, end) ，则我们将区间中的元素 arr[start,⋯, end−1] 中的每个元素加 1，
        //如果数组 arr 的最大元素大于 2 时，此时则出现某个区间被安排了 2 次上，
        //此时返回 false，同时将数组区间 arr[start,⋯, end−1] 进行减 1 即可恢复。
        //实际我们不必实际开辟数组 arr，可采用动态线段树，
        //懒标记 lazy 标记区间[l, r] 进行累加的次数，tree 记录区间[l, r] 的最大值，每次动态更新线段树即可。

        Dictionary<int, int[]> tree;
        public MyCalendarTwoClass()
        {
            tree = new Dictionary<int, int[]>();
        }
        public bool Book(int start,int end)
        {
            Update(start, end - 1, 1, 0, 1000000000, 1);
            if (!tree.ContainsKey(1)) tree.Add(1, new int[2]);
            if (tree[1][0]>2)
            {
                Update(start, end - 1, -1, 0, 1000000000, 1);
                return false;
            }
            return true;
        }

        public void Update(int start,int end, int val, int l,int r,int idx)
        {
            if (r < start || end < l) return;
            if (!tree.ContainsKey(idx)) tree.Add(idx, new int[2]);
            if(start<=l && r<=end)
            {
                tree[idx][0] += val;
                tree[idx][1] += val;
            }
            else
            {
                var mid = (l + r) >> 1;
                Update(start, end, val, l, mid, 2 * idx);
                Update(start, end, val, mid + 1, r, 2 * idx + 1);
                if(!tree.ContainsKey(2*idx))
                    tree.Add(2 * idx, new int[2]);
                if (!tree.ContainsKey(2 * idx + 1))
                    tree.Add(2 * idx + 1, new int[2]);
                tree[idx][0] = tree[idx][1] + Math.Max(tree[2 * idx][0], tree[2 * idx + 1][0]);
            }
        }
    }
}
