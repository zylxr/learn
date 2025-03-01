using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunJan25
    {
        public static void Run()
        {
            var myCalendarTwo = new MyCalendarTwoClass();
            Console.WriteLine(myCalendarTwo.Book(10, 20)); // 返回 True，能够预定该日程。
            Console.WriteLine(myCalendarTwo.Book(50, 60)); // 返回 True，能够预定该日程。
            Console.WriteLine(myCalendarTwo.Book(10, 40)); // 返回 True，该日程能够被重复预定。
            Console.WriteLine(myCalendarTwo.Book(5, 15));  // 返回 False，该日程导致了三重预定，所以不能预定。
            Console.WriteLine(myCalendarTwo.Book(5, 10)); // 返回 True，能够预定该日程，因为它不使用已经双重预订的时间 10。
            Console.WriteLine(myCalendarTwo.Book(25, 55)); // 返回 True，能够预定该日程，因为时间段 [25, 40) 将被第三个日程重复预定，时间段 [40, 50) 将被单独预定，而时间段 [50, 55) 将被第二个日程重复预定。

            var myCalendarThree = new MyCalendarThreeClass3();
            Console.WriteLine(myCalendarThree.Book(10, 20)); // 返回 1 ，第一个日程安排可以预订并且不存在相交，所以最大 k 次预订是 1 次预订。
            Console.WriteLine(myCalendarThree.Book(50, 60)); // 返回 1 ，第二个日程安排可以预订并且不存在相交，所以最大 k 次预订是 1 次预订。
            Console.WriteLine(myCalendarThree.Book(10, 40)); // 返回 2 ，第三个日程安排 [10, 40) 与第一个日程安排相交，所以最大 k 次预订是 2 次预订。
            Console.WriteLine(myCalendarThree.Book(5, 15)); // 返回 3 ，剩下的日程安排的最大 k 次
            Console.WriteLine(myCalendarThree.Book(5, 10)); // 返回 3
            Console.WriteLine(myCalendarThree.Book(25, 55)); // 返回 3

            var maxConsecutiveClass = new MaxConsecutiveClass();
            var maxConsecutiveResult = maxConsecutiveClass.MaxConsecutive(2, 9, new int[] { 4, 6 });//3

            var validSubstringCountClass = new ValidSubstringCountClass();
            var validSubstringCountResult = validSubstringCountClass.ValidSubstringCount("bcca", "abc");//1
            validSubstringCountResult = validSubstringCountClass.ValidSubstringCount2("abcabc", "abc");//10

            var minOperationsClass = new MinOperationsClass2();
            var minOperationsResult = minOperationsClass.MinOperations(new int[] { 2, 11, 10, 1, 3 }, 10);//2

            var minSubArrayLenClass = new MinimumSubarrayLengthClass();
            var minSubArrayLenResult = minSubArrayLenClass.MinimumSubarrayLength(new int[] { 2,1,8 }, 10);//3

            var maxValueClass = new MaxValueClass();
            var maxValueResult = maxValueClass.MaxValue(new int[] { 4,2,5,6,7 },2);//2

            var piles = new List<IList<int>> {
                    new List<int>{ 1,100,3},
                    new List<int>{ 7,8,9 }
                };
            var maxValueOfCoinsClass = new MaxValueOfCoinsClass();
            var maxValueOfCoinsResult = maxValueOfCoinsClass.MaxValueOfCoins(piles, 2);//101

            piles = new List<IList<int>> { 
                new List<int>{ 48, 14, 23, 38, 33, 79, 3, 52, 73, 58, 49, 23, 74, 44, 69, 76, 83, 41, 46, 32, 28 }
            };
            maxValueOfCoinsResult = maxValueOfCoinsClass.MaxValueOfCoins(piles, 10);//421

            var maxCoinsClass = new MaxCoinsClass();
            var maxCoinsResult = maxCoinsClass.MaxCoins(new int[] { 2, 4, 1, 2, 7, 8 });//9

            var maximuPointsClass = new MaximumPointsClass();
            var maximuPointsResult = maximuPointsClass.MaximumPoints(
                new int[][] { new int[] {0,1 },new int[] { 1,2},new int[] { 2,3} }, 
                new int[] { 10,10,3,3 },5);//11

            var minimuCoinsClass = new MinimumCoinsClass();
            var minimumCoinsResult = minimuCoinsClass.MinimumCoins(new int[] { 3,1,2});//4

            var minimuMoneyClass = new MinimumMoneyClass();
            var minimumMoneyResult = minimuMoneyClass.MinimumMoney(new int[][] { new int[] {2,1 },new int[] {5,0 },new int[] {4,2 } });//10
            minimumMoneyResult = minimuMoneyClass.MinimumMoney(
                    new int[][] { 
                        new int[] { 7,2 }, 
                        new int[] { 0,10 }, 
                        new int[] { 5,0 },
                        new int[] { 4,1 },
                        new int[] { 5,8 },
                        new int[] { 5,9 }
                    });//18

            var jumpClass = new JumpClass();
            var jumpResult = jumpClass.Jump(new int[] { 2, 3, 1, 1, 4 });//2
            jumpResult = jumpClass.Jump(new int[] { 1 });//0

            jumpResult = jumpClass.Jump2(new int[] { 2, 3, 1, 1, 4 });//2

            jumpResult = jumpClass.Jump3(new int[] { 2, 3, 1, 1, 4 });//2

            var intersectClass = new IntersectClass();
            var insertResult = intersectClass.Intersect(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 });//[4,9]

        }
    }
}
