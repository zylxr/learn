using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunDailySeptempber
    {
        public static void Run()
        {
            var maxConsecutiveAnswerClass = new MaxConsecutiveAnswersClass();
            var maxConsecutiveAnswerResult = maxConsecutiveAnswerClass.MaxConsecutiveAnswers("TTFF",2);//4

            var maxStrengthClass = new MaxStrengthClass();
            var maxStrengthResult = maxStrengthClass.MaxStrength(new int[] { 3, -1, -5, 2, 5, -9 });//1350
            maxStrengthResult = maxStrengthClass.MaxStrength1(new int[] { 3, -1, -5, 2, 5, -9 });//1350
        }
    }
}
