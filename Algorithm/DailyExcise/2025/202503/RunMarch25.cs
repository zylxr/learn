using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunMarch25
    {
        public static void Run()
        {
            var partitionClass = new PartitionClass();
            var partitionResult = partitionClass.Partition("aab");//[["a","a","b"],["aa","b"]]
        }
    }
}
