using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunJuly25
    {
        public static void Run()
        {
            var possibleStringCountClass = new PossibleStringCountClass();
            var possibleStringCountResult = possibleStringCountClass.PossibleStringCount("aabbccdd",7);//5

            var kthCharacterClass = new KthCharacterClass();
            var kthCharacterClassResult = kthCharacterClass.KthCharacter(2, new int[] { 0 });//a
            kthCharacterClassResult = kthCharacterClass.KthCharacter(3, new int[] { 1,0 });//a

            var maxEventsClass = new MaxEventsClass();
            var maxEventsClassResult = maxEventsClass.MaxEvents(new int[][] { new int[] {1,2 },new int[] {2,3 },new int[] {3,4 } });//3
            
            var maxValueClass = new MaxValueClass2();
            var maxValueClass2Result = maxValueClass.MaxValue(new int[][]{ new int[] {1,2,4 },new int[] { 3,4,3},new int[] { 2,3,1} },2);//7
        }
    }
}
