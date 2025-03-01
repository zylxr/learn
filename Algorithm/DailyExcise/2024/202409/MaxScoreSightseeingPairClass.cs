using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxScoreSightseeingPairClass
    {
        public int MaxScoreSightseeingPair(int[] values)
        {
            var n = values.Length;
            var ans = 0;
            var mx = values[0];
            for(var i=1;i<n; i++)
            {
                ans = Math.Max(ans, mx + values[i] - i);
                mx = Math.Max(mx, values[i] + i);
            }
            return ans;
        }
    }
}
