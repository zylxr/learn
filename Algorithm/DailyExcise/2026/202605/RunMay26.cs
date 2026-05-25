using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunMay26
    {
        public static void Run()
        {
            var canReadClass = new CanReachClass();
            var canReadClassResult = canReadClass.CanReach("01101110",2,3);//false
            canReadClassResult = canReadClass.CanReach("011010", 2, 3);//
                                                                       //
            canReadClassResult = canReadClass.CanReach2("011010", 2, 3);//true
        }
    }
}
