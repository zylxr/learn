using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class FractionToDecimalClass
    {
        //166. 分数到小数
        //给定两个整数，分别表示分数的分子 numerator 和分母 denominator，以 字符串形式返回小数 。

        //如果小数部分为循环小数，则将循环的部分括在括号内。

        //如果存在多个答案，只需返回 任意一个 。

        //对于所有给定的输入，保证 答案字符串的长度小于 104 。




        //示例 1：

        //输入：numerator = 1, denominator = 2
        //输出："0.5"
        //示例 2：

        //输入：numerator = 2, denominator = 1
        //输出："2"
        //示例 3：

        //输入：numerator = 4, denominator = 333
        //输出："0.(012)"


        //提示：

        //-231 <= numerator, denominator <= 231 - 1
        //denominator != 0
        public string FractionToDecimal(int numerator, int denominator)
        {
            var nLong = (long)numerator;
            var nD = (long)denominator;
            if(nLong%nD == 0)return (nLong/nD).ToString();

            var sb = new StringBuilder();
            if (nLong < 0 ^ nD < 0) sb.Append('-');
            nLong = Math.Abs(nLong);
            nD = Math.Abs(nD);
            var integerPart = nLong / nD;
            sb.Append(integerPart);
            sb.Append('.');

            var factionPart = new StringBuilder();
            var remainderIndexDict  = new Dictionary<long, int>();
            var remainder = nLong % nD;
            var index = 0;
            while(remainder!=0 && !remainderIndexDict.ContainsKey(remainder))
            {
                remainderIndexDict.Add(remainder, index);
                remainder *= 10;
                factionPart.Append(remainder / nD);
                remainder %= nD;
                index++;
            }
            if(remainder !=0)
            {
                var insertIndex = remainderIndexDict[remainder];
                factionPart.Insert(insertIndex, '(');
                factionPart.Append(')');
            }
            sb.Append(factionPart.ToString());
            return sb.ToString();
        }
        
    }
}
