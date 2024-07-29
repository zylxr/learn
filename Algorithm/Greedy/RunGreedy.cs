using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Greedy
{
    public class RunGreedy
    {
        public static void Run()
        {
            var multiMachineSchedule = new MultiMachineSchedule();
            var tasks = new GreedyTask[] {
                new GreedyTask{ Id =1,Time = 2 },
                new GreedyTask{ Id =2,Time = 14},
                new GreedyTask{ Id =3,Time = 4},
                new GreedyTask{ Id =4,Time = 16},
                new GreedyTask{ Id =5,Time = 6},
                new GreedyTask{ Id =6,Time = 5},
                new GreedyTask{ Id =7,Time = 3}
            };
            var multiMachineScheduleResult = multiMachineSchedule.GreedySchedule(tasks,3);//时间 17,4|2,7|5,6,3,1
        }
    }
}
