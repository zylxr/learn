using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxFreeTimeClass
    {
        //3439. 重新安排会议得到最多空余时间 I
        //给你一个整数 eventTime 表示一个活动的总时长，这个活动开始于 t = 0 ，结束于 t = eventTime 。

        //同时给你两个长度为 n 的整数数组 startTime 和 endTime 。它们表示这次活动中 n 个时间 没有重叠 的会议，其中第 i 个会议的时间为[startTime[i], endTime[i]] 。

        //你可以重新安排 至多 k 个会议，安排的规则是将会议时间平移，且保持原来的 会议时长 ，你的目的是移动会议后 最大化 相邻两个会议之间的 最长 连续空余时间。

        //移动前后所有会议之间的 相对 顺序需要保持不变，而且会议时间也需要保持互不重叠。

        //请你返回重新安排会议以后，可以得到的 最大 空余时间。

        //注意，会议 不能 安排到整个活动的时间以外。



        //示例 1：

        //输入：eventTime = 5, k = 1, startTime = [1, 3], endTime = [2, 5]

        //输出：2

        //解释：



        //将[1, 2] 的会议安排到[2, 3] ，得到空余时间[0, 2] 。

        //示例 2：

        //输入：eventTime = 10, k = 1, startTime = [0, 2, 9], endTime = [1, 4, 10]

        //输出：6

        //解释：



        //将[2, 4] 的会议安排到[1, 3] ，得到空余时间[3, 9] 。

        //示例 3：

        //输入：eventTime = 5, k = 2, startTime = [0, 1, 2, 3, 4], endTime = [1, 2, 3, 4, 5]

        //输出：0

        //解释：

        //活动中的所有时间都被会议安排满了。



        //提示：

        //1 <= eventTime <= 109
        //n == startTime.length == endTime.length
        //2 <= n <= 105
        //1 <= k <= n
        //0 <= startTime[i] < endTime[i] <= eventTime
        //endTime[i] <= startTime[i + 1] 其中 i 在范围[0, n - 2] 之间。
        public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
        {
            //方法一：贪心 + 前缀和
            //根据题意，平移一个会议可以将该会议左右两侧相邻的空余时间段进行合并，
            //那么对 k 个会议进行平移时，最多可以将 k+1 个空余时间段进行合并（当且仅当 k 个会议相邻）。
            //当进行平移的 k 个相邻的会议固定时，令合并的第一个空余时间段的开始时间为 left，
            //合并的最后一个空余时间段的结束时间为 right，
            //那么合并的 k+1 个空余时间段的总长等于总时间间隔 right−left 减去 k 个会议的时间总长。

            //预计算 n 个会议的时间前缀和 sum，方便后续计算相邻 k 个会议的时间总长。
            //然后枚举 k 个相邻会议最右边的会议为 i，显然 i≥k−1，
            //那么 k 个相邻会议为区间[i−k + 1, i]，我们计算以下几个值：
            //k 个会议时间总长 sum[i + 1]−sum[i−k + 1]
            //合并的第一个空余时间段的开始时间：
            //lefti=
            //      0  if i≤k−1
            //      endTime[i−k] if i > k−1
            //​
            //最后一个空余时间段的结束时间：
            //righti=
            //  eventTime if i = n−1
            //  startTime[i + 1] if i //= n−1
            //​

            //那么就可以计算合并的 k+1 个空余时间段的总长 righti−lefti−(sum[i + 1]−sum[i−k + 1])，
            //最终返回所有枚举结果的最大值。
            var n = startTime.Length;
            var sum = new int[n + 1];
            var res = 0;
            for (var i = 0; i < n; i++) sum[i + 1] = sum[i] + endTime[i] - startTime[i];
            for(var i=k-1;i<n;i++)
            {
                var right = i == n - 1 ? eventTime : startTime[i + 1];
                var left = i == k - 1 ? 0 : endTime[i - k];
                res = Math.Max(res, right - left - (sum[i + 1] - sum[i - k + 1]));
            }
            return res;
        }

        public int MaxFreeTime2(int eventTime, int k, int[] startTime, int[] endTime)
        {
            //方法二：贪心 + 滑动窗口
            //方法一中，我们使用了会议时长的前缀和数组来计算 k 个相邻会议的时间总长，
            //这里同样可以使用滑动窗口来计算 k 个相邻会议的时间总长。
            //具体地，我们使用 t 来计算窗口内会议的时间总长，依次将会议 i 加入窗口：

            //将 i 加入窗口中，计算 t = t + endTime[i]−startTime[i]

            //根据方法一计算 lefti  和 righti ，那么窗口内的会议平移时，合并的空余时间段的总长为 righti −lefti −t

            //如果窗口的会议数量等于 k，即 i≥k−1 时，需要将会议 i−k + 1 移出窗口，
            //保证后续加入会议时窗口内会议的数量小于等于 k，计算 t = t−(endTime[i−k + 1]−startTime[i−k + 1])

            //返回合并的空余时间段总长的最大值。
            var n = startTime.Length;
            var res = 0;
            var t = 0;
            for(var i=0;i<n;i++)
            {
                t += endTime[i] - startTime[i];
                var left = i <= k - 1 ? 0 : endTime[i - k];
                var right = i == n - 1 ? eventTime : startTime[i + 1];
                res = Math.Max(res, right - left - t);
                if (i >= k - 1)
                    t -= endTime[i - k + 1] - startTime[i - k + 1];
            }
            return res;
        }
            
    }
}
