using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class PermuteUniqueClass
    {
        //47. 全排列 II
        //给定一个可包含重复数字的序列 nums ，按任意顺序 返回所有不重复的全排列。




        //示例 1：

        //输入：nums = [1, 1, 2]
        //输出：
        //[[1, 1, 2],
        //[1, 2, 1],
        //[2, 1, 1]]
        //示例 2：

        //输入：nums = [1, 2, 3]
        //输出：[[1, 2, 3],[1, 3, 2],[2, 1, 3],[2, 3, 1],[3, 1, 2],[3, 2, 1]]


        //提示：

        //1 <= nums.length <= 8
        //-10 <= nums[i] <= 10
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            vis = new bool[nums.Length];
            Array.Sort(nums);
            var ans = new List<IList<int>>();
            var perm = new List<int>();
            Backtrack(nums, ans, 0,perm);
            return ans;
        }

        private void Backtrack(int[] nums, IList<IList<int>> ans, int idx, IList<int> perm)
        {
            if(idx == nums.Length)
            {
                ans.Add(new List<int>(perm));
                return;
            }
            for(var i =0;i< nums.Length;i++)
            {
                if (vis[i] || i>0 && nums[i] == nums[i-1]&& !vis[i-1])
                    continue;
                perm.Add(nums[i]);
                vis[i] = true;
                Backtrack(nums, ans, idx + 1, perm);
                vis[i] = false;
                perm.RemoveAt(perm.Count - 1);
            }
        }
        private IList<bool> vis;
    }
}
