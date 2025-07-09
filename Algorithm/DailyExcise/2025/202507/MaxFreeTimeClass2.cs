using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxFreeTimeClass2
    {
        //3440. 重新安排会议得到最多空余时间 II
        //给你一个整数 eventTime 表示一个活动的总时长，这个活动开始于 t = 0 ，结束于 t = eventTime 。

        //同时给你两个长度为 n 的整数数组 startTime 和 endTime 。它们表示这次活动中 n 个时间 没有重叠 的会议，其中第 i 个会议的时间为[startTime[i], endTime[i]] 。

        //你可以重新安排 至多 一个会议，安排的规则是将会议时间平移，且保持原来的 会议时长 ，你的目的是移动会议后 最大化 相邻两个会议之间的 最长 连续空余时间。

        //请你返回重新安排会议以后，可以得到的 最大 空余时间。

        //注意，会议 不能 安排到整个活动的时间以外，且会议之间需要保持互不重叠。

        //注意：重新安排会议以后，会议之间的顺序可以发生改变。



        //示例 1：

        //输入：eventTime = 5, startTime = [1, 3], endTime = [2, 5]

        //输出：2

        //解释：



        //将[1, 2] 的会议安排到[2, 3] ，得到空余时间[0, 2] 。

        //示例 2：

        //输入：eventTime = 10, startTime = [0, 7, 9], endTime = [1, 8, 10]

        //输出：7

        //解释：



        //将[0, 1] 的会议安排到[8, 9] ，得到空余时间[0, 7] 。

        //示例 3：

        //输入：eventTime = 10, startTime = [0, 3, 7, 9], endTime = [1, 4, 8, 10]

        //输出：6

        //解释：



        //将[3, 4] 的会议安排到[8, 9] ，得到空余时间[1, 7] 。

        //示例 4：

        //输入：eventTime = 5, startTime = [0, 1, 2, 3, 4], endTime = [1, 2, 3, 4, 5]

        //输出：0

        //解释：

        //活动中的所有时间都被会议安排满了。



        //提示：

        //1 <= eventTime <= 109
        //n == startTime.length == endTime.length
        //2 <= n <= 105
        //0 <= startTime[i] < endTime[i] <= eventTime
        //endTime[i] <= startTime[i + 1] 其中 i 在范围[0, n - 2] 之间。
        public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
        {
            var n = startTime.Length;
            var q = new bool[n];
            int t1 = 0, t2 = 0;
            for(var i=0;i<n;i++)
            {
                if (endTime[i] - startTime[i] <= t1) q[i] = true;
                t1 = Math.Max(t1, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));
                if (endTime[n - i - 1] - startTime[n - i - 1] <= t2) q[i - i - 1] = true;
                t2 = Math.Max(t2, (i == 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
            }
            var res = 0;
            for(var i=0;i<n;i++)
            {
                var left = i == 0 ? 0 : endTime[i - 1];
                var right = i == n - 1 ? eventTime : startTime[i + 1];
                if (q[i]) res = Math.Max(res, right - left);
                else res = Math.Max(res, right - left - (endTime[i]- startTime[i]));
            }
            return res;
        }

        public int MaxFreeTime2(int eventTime, int[] startTime, int[] endTime)
        {
            var n = startTime.Length;
            var res = 0;
            for(int i=0,t1=0,t2=0;i<n;i++)
            {
                var left1 = i==0?0:endTime[i-1];
                var right1 = i==n-1?eventTime : startTime[i+1];
                if (endTime[i] - startTime[i]<=t1)res = Math.Max(res, right1-left1);
                t1 = Math.Max(t1, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));
                res = Math.Max(res, right1 - left1 - (endTime[i] - startTime[i]));

                var left2 = i == n - 1 ? 0 : endTime[n - i - 2];
                var right2 = i==0?eventTime: startTime[n-i];
                if (endTime[n - i - 1] - startTime[n-i-1]<=t2)res = Math.Max(res,right2 - left2);
                t2 = Math.Max(t2, (i == 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
            }
            return res;
        }
    }
}
