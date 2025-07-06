using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxEventsClass
    {
        //1353. 最多可以参加的会议数目
        //给你一个数组 events，其中 events[i] = [startDayi, endDayi] ，表示会议 i 开始于 startDayi ，结束于 endDayi 。

        //你可以在满足 startDayi <= d <= endDayi 中的任意一天 d 参加会议 i 。在任意一天 d 中只能参加一场会议。

        //请你返回你可以参加的 最大 会议数目。



        //示例 1：



        //输入：events = [[1, 2],[2, 3],[3, 4]]
        //输出：3
        //解释：你可以参加所有的三个会议。
        //安排会议的一种方案如上图。
        //第 1 天参加第一个会议。
        //第 2 天参加第二个会议。
        //第 3 天参加第三个会议。
        //示例 2：

        //输入：events= [[1, 2],[2, 3],[3, 4],[1, 2]]
        //输出：4


        //提示：​​​​​​

        //1 <= events.length <= 105
        //events[i].length == 2
        //1 <= startDayi <= endDayi <= 105
        public int MaxEvents(int[][] events)
        {
            var n = events.Length;
            var maxDay = 0;
            foreach (var e in events) maxDay = Math.Max(maxDay, e[1]);
            var pq = new PriorityQueue<int, int>();
            Array.Sort(events, (a, b) => a[0].CompareTo(b[0]));
            var res = 0;
            for (int i = 1, j = 0; i <= maxDay; i++)
            {
                while (j < n && events[j][0] <= i)
                {
                    pq.Enqueue(events[j][1], events[j][1]);
                    j++;
                }
                while (pq.Count > 0 && pq.Peek() < i) pq.Dequeue();
                if (pq.Count > 0)
                {
                    pq.Dequeue();
                    res++;
                }
            }
            return res;
        }
    }
}
