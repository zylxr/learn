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
        }
    }
}
