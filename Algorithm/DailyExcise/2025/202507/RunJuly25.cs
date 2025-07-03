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
        }
    }
}
