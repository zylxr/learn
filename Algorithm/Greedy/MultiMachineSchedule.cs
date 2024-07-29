using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Greedy
{
    public class GreedyTask
    {
        public int Id { get; set; }
        public int Time { get; set; }
    }
    public class MultiMachineSchedule
    {
        //目标是将多个作业分配到多台机器上，使得所有作业完成的总时间（或最大完成时间，取决于具体目标）最小
        //问题描述：设有n个作业，每个作业有其处理时间t[i]，以及m台相同的机器。作业不能被分割，一旦开始在某台机器上处理就必须连续完成。

        //贪心策略：通常采用的贪心策略是将作业按照处理时间从大到小排序，然后依次分配给当前空闲时间最早的机器。
        //多机调度问题是 NP 难问题，到目前还没有有效的算法。对于这类问题，用贪心算法有时能得到较好的近似解。最长时间优先

        
        int IndexOfMin(int[] finishTime)
        {
            var n = finishTime.Length;
            var min = finishTime[0];
            var index = 0;
            for(var i=1;i<n; i++)
            {
                if (finishTime[i]<min)
                {
                    min = finishTime[i];
                    index = i;
                }
            }
            return index;
        }

        public int[] GreedySchedule(GreedyTask[] tasks, int machineNumber)
        {
            //tasks 按照时间长短倒序排序，时间最长的放前面
            tasks = tasks.OrderByDescending(_ => _.Time).ToArray();
            var finishTime = new int[machineNumber];
            var taskLists = new int[machineNumber];

            var i = 0;
            for(i=0;i<machineNumber;i++)
            {
                finishTime[i] += tasks[i].Time;
                taskLists[i] = taskLists[i] * 10 + tasks[i].Id;
            }
            for(;i<tasks.Length;i++)
            {
                var minIndex = IndexOfMin(finishTime);
                taskLists[minIndex]  = taskLists[minIndex]*10+ tasks[i].Id;
                finishTime[minIndex] += tasks[i].Time;
            }
            return taskLists;
        }
    }
}
