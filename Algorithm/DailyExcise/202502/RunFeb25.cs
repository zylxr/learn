using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunFeb25
    {
        public static void Run()
        {
            var validPalindromeClass = new ValidPalindromeClass();
            var validPalindrome = validPalindromeClass.ValidPalindrome("abca");//true

            var subsetsWithDupClass = new SubsetsWithDupClass();
            var subsetsWithDup = subsetsWithDupClass.SubsetsWithDup(new int[] { 1, 2, 2 });//[[],[1],[1,2],[1,2,2],[2],[2,2]]
            subsetsWithDup = subsetsWithDupClass.SubsetsWithDup(new int[] { 1,1 });//[[],[1],[1,1]]

            subsetsWithDup = subsetsWithDupClass.SubsetsWithDup2(new int[] { 1, 1 });//[[],[1],[1,1]]

            var permuteUniqueClass = new PermuteUniqueClass();
            var permuteUnique = permuteUniqueClass.PermuteUnique(new int[] { 1, 1, 2 });//[[1,1,2],[1,2,1],[2,1,1]]
        }
    }
}
