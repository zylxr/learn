using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunMarch26
    {
        public static void Run()
        {
            var minSwapClass2 = new MinSwapsClass2();
            var minSwapClass2Result = minSwapClass2.MinSwaps(new int[][] {
                new int[]{ 0,0,1},
                new int[]{ 1,1,0},
                new int[]{ 1,0,0}
            });//3

            var findKthBitClass = new FindKthBitClass();
            var findKthBitClassResult = findKthBitClass.FindKthBit(4,11);//"1"

            var minFlipsClass3 = new MinFlipsClass3();
            var minFlipsClass3Result = minFlipsClass3.MinFlips("111000");//2
            minFlipsClass3Result = minFlipsClass3.MinFlips2("111000");//2
        }
    }
}
