using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class FindMaximumEleganceClass
    {
        //给你一个长度为 n 的二维整数数组 items 和一个整数 k 。

        //items[i] = [profiti, categoryi]，其中 profiti 和 categoryi 分别表示第 i 个项目的利润和类别。

        //现定义 items 的 子序列 的 优雅度 可以用 total_profit + distinct_categories2 计算，其中 total_profit 是子序列中所有项目的利润总和，distinct_categories 是所选子序列所含的所有类别中不同类别的数量。

        //你的任务是从 items 所有长度为 k 的子序列中，找出 最大优雅度 。

        //用整数形式表示并返回 items 中所有长度恰好为 k 的子序列的最大优雅度。

        //注意：数组的子序列是经由原数组删除一些元素（可能不删除）而产生的新数组，且删除不改变其余元素相对顺序。



        //示例 1：

        //输入：items = [[3, 2],[5, 1],[10, 1]], k = 2
        //输出：17
        //解释：
        //在这个例子中，我们需要选出长度为 2 的子序列。
        //其中一种方案是 items[0] = [3, 2] 和 items[2] = [10, 1] 。
        //子序列的总利润为 3 + 10 = 13 ，子序列包含 2 种不同类别[2, 1] 。
        //因此，优雅度为 13 + 22 = 17 ，可以证明 17 是可以获得的最大优雅度。 
        //示例 2：

        //输入：items = [[3, 1],[3, 1],[2, 2],[5, 3]], k = 3
        //输出：19
        //解释：
        //在这个例子中，我们需要选出长度为 3 的子序列。 
        //其中一种方案是 items[0] = [3, 1] ，items[2] = [2, 2] 和 items[3] = [5, 3] 。
        //子序列的总利润为 3 + 2 + 5 = 10 ，子序列包含 3 种不同类别[1, 2, 3] 。 
        //因此，优雅度为 10 + 32 = 19 ，可以证明 19 是可以获得的最大优雅度。
        //示例 3：

        //输入：items = [[1, 1],[2, 1],[3, 1]], k = 3
        //输出：7
        //解释：
        //在这个例子中，我们需要选出长度为 3 的子序列。
        //我们需要选中所有项目。
        //子序列的总利润为 1 + 2 + 3 = 6，子序列包含 1 种不同类别[1] 。
        //因此，最大优雅度为 6 + 12 = 7 。


        //提示：

        //1 <= items.length == n <= 105
        //items[i].length == 2
        //items[i][0] == profiti
        //items[i][1] == categoryi
        //1 <= profiti <= 109
        //1 <= categoryi <= n 
        //1 <= k <= n

        //首先将二维整数数组 items 按照 profit 从大到小进行排序。当子序列为前 k 个项目时，子序列的利润总和 total_profit 最大，
        //但是 distinct_categories 不一定为最大。考虑第 k+1 个项目时，如果将它与已选的 k 个项目之一进行替换，那么显然只能使 distinct_categories 增加，是否替换有几种情况：
        //如果 k+1个项目与已选的 k 个项目的已有类别相同，那么选择它后，distinct_categories 不会增加，但是 total_profit 可能会减少，总体优雅度不会增加，所以不选择该项目。
        //如果 k+1个项目与已选的 k个项目的已有类别都不相同，那么选择它后，对应的替换项目有两种情况：
        //如果对应的替换项目的类别只出现一次，那么替换后，distinct_categories 不变，总体优雅度也不会增加，所以不选择该项目。

        //如果对应的替换项目的类别出现两次以上，取利润最小的项目进行替换，那么替换后，distinct_categories 会增加，总体优雅度有可能增加，
        //所以可以选择该项目。（如果现在不选择该项目，后续出现类似的情况时，因为利润是从大到小排序的，总体优雅度不会更大。）

        //经过以上分类讨论后，我们知道每次考虑新增一个项目时，只有一种情况可能使总体优雅度更大。在求解过程中，我们可以使用栈来维护在已选的 k 个项目中，
        //类别出现两次以上且利润非最大的所有项目，同时因为项目已经按照利润从大到小排序，所以栈顶元素为利润类别出现两次以上且利润最小的项目。求得以上所有可能的子序列的优雅度，取最大值为结果。
        public long FindMaximumElegance(int[][] items, int k)
        {
            Array.Sort(items, (item0, item1) => item1[0] - item0[0]);
            var categories = new HashSet<int>();
            var stack = new Stack<int>();
            var res = 0;
            var profit = 0;
            for (var i = 0; i < items.Length; i++)
            {
                if(i<k)
                {
                    profit += items[i][0];
                    if (!categories.Add(items[i][1]))
                    {
                        stack.Push(items[i][0]);
                    }
                }else if(stack.Count>0 && !categories.Contains(items[i][1]))
                {
                    profit += items[i][0] - stack.Pop();
                    categories.Add(items[i][1]);
                }
                res = Math.Max(res, profit+categories.Count*categories.Count);
            }
            return res;
        }
    }
}
