using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MaxmiumScoreClass
    {
        //力扣挑战赛」心算项目的挑战比赛中，要求选手从 N 张卡牌中选出 cnt 张卡牌，若这 cnt 张卡牌数字总和为偶数，则选手成绩「有效」且得分为 cnt 张卡牌数字总和。 给定数组 cards 和 cnt，其中 cards[i] 表示第 i 张卡牌上的数字。 请帮参赛选手计算最大的有效得分。若不存在获取有效得分的卡牌方案，则返回 0。

        //示例 1：

        //输入：cards = [1, 2, 8, 9], cnt = 3

        //输出：18

        //解释：选择数字为 1、8、9 的这三张卡牌，此时可获得最大的有效得分 1+8+9=18。

        //示例 2：

        //输入：cards = [3, 3, 1], cnt = 1

        //输出：0

        //解释：不存在获取有效得分的卡牌方案。

        //提示：

        //1 <= cnt <= cards.length <= 10^5
        //1 <= cards[i] <= 1000
        public int MaxmiumScore(int[] cards, int cnt)
        {
            Array.Sort(cards);
            var ans = 0;
            var tmp = 0;
            var odd = -1;
            var even = -1;
            var end = cards.Length - cnt;
            for(var i=cards.Length-1; i>=end;i--)
            {
                tmp += cards[i];
                if ((cards[i] & 1) == 0)
                    even = cards[i];
                else
                    odd = cards[i];
            }
            if ((tmp & 1) == 0) return tmp;
            for(var i=cards.Length - cnt-1;i>=0;i--)
            {
                if ((cards[i] & 1) ==0 )
                {
                    if (odd != -1)
                    {
                        ans = Math.Max(ans, tmp - odd + cards[i]);
                        break;
                    }
                }
            }

            for(var i= cards.Length - cnt-1; i>=0;i--)
            {
                if((cards[i] & 1) != 0)
                {
                    if(even != -1)
                    {
                        ans = Math.Max(ans,tmp - even + cards[i]);
                        break;
                    }
                }
            }
            return ans;
        }
    }
}
