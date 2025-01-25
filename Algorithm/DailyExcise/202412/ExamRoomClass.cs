using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class ExamRoomClass
    {
        //855. 考场就座
        //在考场里，有 n 个座位排成一行，编号为 0 到 n - 1。

        //当学生进入考场后，他必须坐在离最近的人最远的座位上。如果有多个这样的座位，他会坐在编号最小的座位上。(另外，如果考场里没有人，那么学生就坐在 0 号座位上。)

        //设计一个模拟所述考场的类。

        //实现 ExamRoom 类：

        //ExamRoom(int n) 用座位的数量 n 初始化考场对象。
        //int seat() 返回下一个学生将会入座的座位编号。
        //void leave(int p) 指定坐在座位 p 的学生将离开教室。保证座位 p 上会有一位学生。


        //示例 1：

        //输入：
        //["ExamRoom", "seat", "seat", "seat", "seat", "leave", "seat"]
        //[[10], [], [], [], [], [4], []]
        //输出：
        //[null, 0, 9, 4, 2, null, 5]
        //解释：
        //ExamRoom examRoom = new ExamRoom(10);
        //examRoom.seat(); // 返回 0，房间里没有人，学生坐在 0 号座位。
        //examRoom.seat(); // 返回 9，学生最后坐在 9 号座位。
        //examRoom.seat(); // 返回 4，学生最后坐在 4 号座位。
        //examRoom.seat(); // 返回 2，学生最后坐在 2 号座位。
        //examRoom.leave(4);
        //examRoom.seat(); // 返回 5，学生最后坐在 5 号座位。


        //提示：

        //1 <= n <= 109
        //保证有学生正坐在座位 p 上。
        //seat 和 leave 最多被调用 104 次。

        private int n;
        private SortedSet<int> seats;
        private PriorityQueue<int[], int[]> pq;
        public ExamRoomClass(int n)
        {
            this.n = n;
            this.seats = new SortedSet<int>();
            this.pq = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((p1, p2) => {
                var d1 = p1[1] - p1[0];
                var d2 = p2[1] - p2[0];
                return d1/2 == d2/2 ? (p1[0] > p2[0] ? 1 : -1) : (d1 / 2 < d2 / 2 ? 1 : -1);
            }));
        }

        public int Seat()
        {
            if(seats.Count == 0)
            {
                seats.Add(0);
                return 0;
            }
            var left = seats.Min;
            var right = n - 1 - seats.Max;
            while(seats.Count >=2)
            {
                var p = pq.Peek();
                if (seats.Contains(p[0]) && seats.Contains(p[1]) && seats.GetViewBetween(p[0] + 1, n - 1).Min == p[1])
                {
                    var d = p[1] - p[0];
                    if (d / 2 < right || d / 2 <= left) break;
                    pq.Dequeue();
                    pq.Enqueue(new int[] { p[0], p[0]+d/2 },new int[] { p[0], p[0]+d/2 });
                    pq.Enqueue(new int[] { p[0] + d / 2, p[1] },new int[] { p[0] + d / 2, p[1] });
                    seats.Add(p[0] + d / 2);
                    return p[0] + d / 2;
                }
                pq.Dequeue();
            }
            if (right > left)
            {
                pq.Enqueue(new int[] { seats.Max,n-1}, new int[] {seats.Max,n-1 });
                seats.Add(n - 1);
                return n - 1;
            }else
            {
                pq.Enqueue(new int[] {0, seats.Min }, new int[] { 0, seats.Min });
                seats.Add(0);
                return 0;
            }
        }

        public void Leave(int p)
        {
            if(p != seats.Min && p != seats.Max)
            {
                var prev = seats.GetViewBetween(0, p - 1).Max;
                var next = seats.GetViewBetween(p + 1, n - 1).Min;
                pq.Enqueue(new int[] {prev,next }, new int[] {prev,next });
            }
            seats.Remove(p);
        }
    }
}
