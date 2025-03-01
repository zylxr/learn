using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class JudgeSquareSumClass
    {
        //633. 平方数之和
        //给定一个非负整数 c ，你要判断是否存在两个整数 a 和 b，使得 a2 + b2 = c 。



        //示例 1：

        //输入：c = 5
        //输出：true
        //解释：1 * 1 + 2 * 2 = 5
        //示例 2：

        //输入：c = 3
        //输出：false


        //提示：

        //0 <= c <= 231 - 1

        public bool JudgeSquareSum(int c)
        {
            for(var a =0;a*a<=c;a++)
            {
                var b = (int)Math.Sqrt(c - a * a);
                if(a*a +b*b == c) return true;
            }
            return false;
        }

        public bool JudgeSquareSum2(int c)
        {
            long left = 0;
            long right = (long)Math.Sqrt(c);
            while(left<=right)
            {
                var sum = (long)(left*left +right*right);
                if (sum == c) return true;
                else if (sum > c) right--;
                else left++;
            }
            return false;
        }
    }
}
