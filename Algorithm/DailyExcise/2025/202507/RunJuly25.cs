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
        
            var maxFreeTimeClass = new MaxFreeTimeClass();
            var maxFreeTimeClassResult = maxFreeTimeClass.MaxFreeTime(5,1,new int[] { 1, 3 },new int[] {2,5 });//2

            maxFreeTimeClassResult = maxFreeTimeClass.MaxFreeTime2(5, 1, new int[] { 1, 3 }, new int[] { 2, 5 });//2

            var maxFreeTimeClass2 = new MaxFreeTimeClass2();
            var maxFreeTimeClass2Result = maxFreeTimeClass2.MaxFreeTime(5,new int[] { 1,3},new int[] {2,5 });//2
            maxFreeTimeClass2Result = maxFreeTimeClass2.MaxFreeTime2(5, new int[] { 1, 3 }, new int[] { 2, 5 });//2

            var countDaysClass = new CountDaysClass();
            var countDaysClassResult = countDaysClass.CountDays(10,new int[][] { new int[] { 5,7} ,new int[] { 1,3},new int[] { 9,10} });//2

            var earliestClass = new EarliestAndLatestClass();
            var earliestClassResult = earliestClass.EarliestAndLatest(11,2,4);//[3,4]

            var maximumLengthClass = new MaximumLengthClass3();
            var maximumLengthClassResult = maximumLengthClass.MaximumLength(new int[] { 1, 2, 3, 4 });//4

            var maximumLengthClass4 = new MaximumLengthClass4();
            var maximumLengthClassResult4 = maximumLengthClass4.MaximumLength(new int[] { 1, 4, 2, 3, 1, 4 },3); //4

            var minimumDiffClass = new MinimumDifferenceClass2();
            var minimumDiffClassResult = minimumDiffClass.MinimumDifference(new int[] {3,1,2 });//-1

            var removeSubfolderClass = new RemoveSubfoldersClass();
            var removeSubFolderClassResult = removeSubfolderClass.RemoveSubfolders(new string[] { "/a", "/a/b", "/c/d", "/c/d/e", "/c/f" });//["/a","/c/d","/c/f"]

            removeSubFolderClassResult = removeSubfolderClass.RemoveSubfolders2(new string[] { "/a", "/a/b", "/c/d", "/c/d/e", "/c/f" });//["/a","/c/d","/c/f"]
        
            var maximumUniqueSubarrayClass = new MaximumUniqueSubarrayClass();
            var maximumUniqueSubArrayClassResult = maximumUniqueSubarrayClass.MaximumUniqueSubarray(new int[] { 4, 2, 4, 5, 6 });//17

            maximumUniqueSubArrayClassResult = maximumUniqueSubarrayClass.MaximumUniqueSubarray2(new int[] { 4, 2, 4, 5, 6 });//17
        
            var maximumGainClass = new MaximumGainClass();
            var maximumGainClassResult = maximumGainClass.MaximumGain("cdbcbbaaabab",4,5);//19

            maximumGainClassResult = maximumGainClass.MaximumGain("aabbaaxybbaabb", 5, 4);//20
        }
    }
}
