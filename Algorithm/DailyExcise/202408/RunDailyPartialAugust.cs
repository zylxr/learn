using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunDailyPartialAugust
    {
        public static void Run()
        {
            var magicDict = new MagicDictionaryClass();
            magicDict.BuildDict(new string[] { "hello", "leetcode" });
            var magicDictResult = magicDict.Search("hello");//false
            magicDictResult = magicDict.Search("hhllo");//true
            magicDictResult = magicDict.Search("hell");//false
            magicDictResult = magicDict.Search("leetcoded");//false

            //使用字典树方法
            magicDict.BuildDict2(new string[] { "hello", "leetcode" });
            magicDictResult = magicDict.Search2("hello");//false
            magicDictResult = magicDict.Search2("hhllo");//true
            magicDictResult = magicDict.Search2("hell");//false
            magicDictResult = magicDict.Search2("leetcoded");//false
        }
    }
}
