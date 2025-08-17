using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class JudgePoint24Class
    {
        //679. 24 点游戏
        //给定一个长度为4的整数数组 cards 。你有 4 张卡片，每张卡片上都包含一个范围在[1, 9] 的数字。您应该使用运算符['+', '-', '*', '/'] 和括号 '(' 和 ')' 将这些卡片上的数字排列成数学表达式，以获得值24。

        //你须遵守以下规则:

        //除法运算符 '/' 表示实数除法，而不是整数除法。
        //例如， 4 /(1 - 2 / 3)= 4 /(1 / 3)= 12 。
        //每个运算都在两个数字之间。特别是，不能使用 “-” 作为一元运算符。
        //例如，如果 cards = [1, 1, 1, 1] ，则表达式 “-1 -1 -1 -1” 是 不允许 的。
        //你不能把数字串在一起
        //例如，如果 cards = [1, 2, 1, 2] ，则表达式 “12 + 12” 无效。
        //如果可以得到这样的表达式，其计算结果为 24 ，则返回 true ，否则返回 false 。



        //示例 1:

        //输入: cards = [4, 1, 8, 7]
        //输出: true
        //解释: (8-4) * (7-1) = 24
        //示例 2:

        //输入: cards = [1, 2, 1, 2]
        //输出: false



        //提示:

        //cards.length == 4
        //1 <= cards[i] <= 9

        public bool JudgePoint24(int[] cards)
        {
            var list = new List<double>();
            foreach (var num in cards) list.Add(num);
            return Solve(list);
        }
        private const int TARGET = 24;
        private const double EPSILON = 1e-6;
        private const int ADD = 0, MULTIPLY = 1, SUBTRACT = 2, DIVIDE = 3;

        public bool Solve(List<double> list)
        {
            if(list.Count == 0) return false;
            if(list.Count == 1)return Math.Abs(list[0]-TARGET)< EPSILON;
            var size = list.Count;
            for(var i=0;i<size;i++)
            {
                for(var j=0;j<size;j++)
                {
                    if(i!=j)
                    {
                        var list2 = new List<double>();
                        for(var k=0;k<size;k++)
                        {
                            if (k != i && k != j)
                                list2.Add(list[k]);
                        }
                        for(var k=0;k<4;k++)
                        {
                            if (k < 2 && i > j) continue;
                            if (k == ADD) list2.Add(list[i] + list[j]);
                            else if(k== MULTIPLY) list2.Add(list[i] * list[j]);
                            else if(k== SUBTRACT) list2.Add(list[i] -list[j]);
                            else if(k==DIVIDE)
                            {
                                if (Math.Abs(list[j]) < EPSILON) continue;
                                list2.Add(list[i] / list[j]);
                            }
                            if (Solve(list2)) return true;
                            list2.RemoveAt(list2.Count - 1);
                        }
                    }
                }
            }
            return false;
        }
    }
}
