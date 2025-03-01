using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class DistinctNamesClass
    {
        //2306. 公司命名
        //给你一个字符串数组 ideas 表示在公司命名过程中使用的名字列表。公司命名流程如下：

        //从 ideas 中选择 2 个 不同 名字，称为 ideaA 和 ideaB 。
        //交换 ideaA 和 ideaB 的首字母。
        //如果得到的两个新名字 都 不在 ideas 中，那么 ideaA ideaB（串联 ideaA 和 ideaB ，中间用一个空格分隔）是一个有效的公司名字。
        //否则，不是一个有效的名字。
        //返回 不同 且有效的公司名字的数目。



        //示例 1：

        //输入：ideas = ["coffee", "donuts", "time", "toffee"]
        //输出：6
        //解释：下面列出一些有效的选择方案：
        //- ("coffee", "donuts")：对应的公司名字是 "doffee conuts" 。
        //- ("donuts", "coffee")：对应的公司名字是 "conuts doffee" 。
        //- ("donuts", "time")：对应的公司名字是 "tonuts dime" 。
        //- ("donuts", "toffee")：对应的公司名字是 "tonuts doffee" 。
        //- ("time", "donuts")：对应的公司名字是 "dime tonuts" 。
        //- ("toffee", "donuts")：对应的公司名字是 "doffee tonuts" 。
        //因此，总共有 6 个不同的公司名字。

        //下面列出一些无效的选择方案：
        //- ("coffee", "time")：在原数组中存在交换后形成的名字 "toffee" 。
        //- ("time", "toffee")：在原数组中存在交换后形成的两个名字。
        //- ("coffee", "toffee")：在原数组中存在交换后形成的两个名字。
        //示例 2：

        //输入：ideas = ["lack", "back"]
        //输出：0
        //解释：不存在有效的选择方案。因此，返回 0 。


        //提示：

        //2 <= ideas.length <= 5 * 104
        //1 <= ideas[i].length <= 10
        //ideas[i] 由小写英文字母组成
        //ideas 中的所有字符串 互不相同

        public long DistinctNames(string[] ideas)
        {
            var dict = new Dictionary<string, string>();
            foreach (var idea in ideas)
            {
                dict.TryAdd(idea, idea);
            }
            long ans = 0;
            var n = ideas.Length;
            for (var i = 1; i < n; i++)
            {
                for (var j = i - 1; j >= 0; j--)
                {
                    var newName1 = ideas[i][0] + ideas[j].Substring(1);
                    var newName2 = ideas[j][0] + ideas[i].Substring(1);
                    if (!dict.ContainsKey(newName1) && !dict.ContainsKey(newName2)) ans += 2;
                }
            }
            return ans;
        }

        public long DistinctNames2(string[] ideas)
        {
            var names = new Dictionary<char, ISet<string>>();
            foreach(var idea in ideas)
            {
                names.TryAdd(idea[0], new HashSet<string>());
                names[idea[0]].Add(idea.Substring(1));
            }
            long ans = 0;
            foreach(var pair in names)
            {
                var preA = pair.Key;
                var setA = pair.Value;
                foreach(var pairB in names)
                {
                    var preB = pairB.Key;
                    var setB = pairB.Value;
                    if (preA == preB) continue;
                    var intersect = GetIntersectSize(setA,setB);
                    ans += (long)(setA.Count - intersect) * (setB.Count - intersect);
                }
            }
            return ans;
        }
        public int GetIntersectSize(ISet<string> a ,ISet<string> b)
        {
            var ans = 0;
            foreach(var s in a)
            {
                if (b.Contains(s)) ans++;
            }
            return ans;
        }
    }
}
