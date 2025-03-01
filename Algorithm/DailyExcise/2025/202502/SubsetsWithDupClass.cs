using Algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class SubsetsWithDupClass
    {
        //90. 子集 II
        //给你一个整数数组 nums ，其中可能包含重复元素，请你返回该数组所有可能的
        //子集
        //（幂集）。

        //解集 不能 包含重复的子集。返回的解集中，子集可以按 任意顺序 排列。



        //示例 1：

        //输入：nums = [1, 2, 2]
        //输出：[[],[1],[1, 2],[1, 2, 2],[2],[2, 2]]
        //示例 2：

        //输入：nums = [0]
        //输出：[[],[0]]


        //提示：

        //1 <= nums.length <= 10
        //-10 <= nums[i] <= 10
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);
            var n = nums.Length;
            for(var mask=0;mask< (1<<n);mask++)
            {
                var t = new List<int>();
                var flag = true;
                for(var i=0;i<n;i++)
                {
                    if( (mask & (1<<i)) != 0)
                    {
                        if(i>0 && (mask & (1<<(i-1))) == 0 && nums[i] == nums[i - 1])
                        {
                            flag = false;
                            break;
                        }
                        t.Add(nums[i]);
                    }
                }
                if(flag)
                {
                    result.Add(t);
                }
            }
            return result;
        }

        public IList<IList<int>> SubsetsWithDup2(int[] nums)
        {
            Array.Sort(nums);
            var ans = new List<IList<int>>();
            var t = new List<int>();
            Dfs(false, 0, nums, t, ans);
            return ans;
        }

        private void Dfs(bool choosePre, int cur, int[] nums,List<int> t, IList<IList<int>> ans)
        {
            if(cur == nums.Length)
            {
                ans.Add(new List<int>(t));
                return;
            }
            Dfs(false, cur + 1, nums, t, ans);
            if (!choosePre && cur > 0 && nums[cur - 1] == nums[cur]) return;
            t.Add(nums[cur]);
            Dfs(true, cur + 1, nums, t, ans);
            t.RemoveAt(t.Count - 1);
        }
    }
}
