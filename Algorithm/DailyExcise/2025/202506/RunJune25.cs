using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunJune25
    {
        public static void Run()
        {
            var candyClass = new CandyClass();
            var candyClassResult = candyClass.Candy(new int[] { 1, 0, 2 });//5
            candyClassResult = candyClass.Candy(new int[] { 1, 3, 2, 2, 1 });//7
            candyClassResult = candyClass.Candy(new int[] { 1, 2, 3, 1, 0 });//9

            candyClassResult = candyClass.Candy2(new int[] { 1, 2, 3, 1, 0 });//9
            candyClassResult = candyClass.Candy3(new int[] { 1, 2, 3, 1, 0 });//9

            var maxCandiesClass2 = new MaxCandiesClass2();
            var maxCandiesClass2Result = maxCandiesClass2.MaxCandies(
                new int[] { 1, 0, 1, 0 },
                new int[] { 7, 5, 4, 100 },
                new int[][] { new int[] { },new int[] { },new int[] { 1 },new int[] { } },
                new int[][] { new int[] {1,2 },new int[] {3 },new int[] { },new int[] { } },
                new int[] { 0 }
                );//16

            var answerStringClass = new AnswerStringClass();
            var answerStringClassResult = answerStringClass.AnswerString("aann",2);//nn
            answerStringClassResult = answerStringClass.AnswerString2("aann", 2);//nn
            answerStringClassResult = answerStringClass.AnswerString3("aann", 2);//nn

            var smallestQuivalenStringClass = new SmallestEquivalentStringClass();
            var smallestQuivalenStrngClassResult = smallestQuivalenStringClass.SmallestEquivalentString("parker", "morris", "parser");//makkek
        
            var robotWithStringClass = new RobotWithStringClass();
            var robotWithStringClassResult = robotWithStringClass.RobotWithString("zza");//azz

            var clearStarsClass = new ClearStarsClass();
            var clearStarsClassResult = clearStarsClass.ClearStars("aaba*");//aab

            var findKthNumberClass = new FindKthNumberClass();
            var findKthNumberClassResult = findKthNumberClass.FindKthNumber(13,2);//10
        }
    }
}
