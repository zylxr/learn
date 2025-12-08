using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class SpecialTripletsClass
    {
        //3583. 统计特殊三元组
        //给你一个整数数组 nums。

        //特殊三元组 定义为满足以下条件的下标三元组(i, j, k)：

        //0 <= i<j<k<n，其中 n = nums.length
        //nums[i] == nums[j]* 2
        //nums[k] == nums[j]* 2
        //返回数组中 特殊三元组 的总数。

        //由于答案可能非常大，请返回结果对 109 + 7 取余数后的值。



        //示例 1：

        //输入： nums = [6, 3, 6]

        //输出： 1

        //解释：

        //唯一的特殊三元组是(i, j, k) = (0, 1, 2)，其中：

        //nums[0] = 6, nums[1] = 3, nums[2] = 6
        //nums[0] = nums[1]* 2 = 3 * 2 = 6
        //nums[2] = nums[1]* 2 = 3 * 2 = 6
        //示例 2：

        //输入： nums = [0, 1, 0, 0]

        //输出： 1

        //解释：

        //唯一的特殊三元组是(i, j, k) = (0, 2, 3)，其中：

        //nums[0] = 0, nums[2] = 0, nums[3] = 0
        //nums[0] = nums[2]* 2 = 0 * 2 = 0
        //nums[3] = nums[2]* 2 = 0 * 2 = 0
        //示例 3：

        //输入： nums = [8, 4, 2, 8, 4]

        //输出： 2

        //解释：

        //共有两个特殊三元组：

        //(i, j, k) = (0, 1, 3)
        //nums[0] = 8, nums[1] = 4, nums[3] = 8
        //nums[0] = nums[1]* 2 = 4 * 2 = 8
        //nums[3] = nums[1]* 2 = 4 * 2 = 8
        //(i, j, k) = (1, 2, 4)
        //nums[1] = 4, nums[2] = 2, nums[4] = 4
        //nums[1] = nums[2]* 2 = 2 * 2 = 4
        //nums[4] = nums[2]* 2 = 2 * 2 = 4


        //提示：

        //3 <= n == nums.length <= 105
        //0 <= nums[i] <= 105
        public int SpecialTriplets(int[] nums)
        {
            var ans = 0;
            var n = nums.Length;
            var mod = 1_000_000_007;
            var cnt = new Dictionary<int, List<int>>();
            var visited = new HashSet<int>();
            for (var i = 0; i < n; i++)
            {
                cnt.TryAdd(nums[i], new List<int>());
                cnt[nums[i]].Add(i);
            }

            for (var i = 0; i < n; i++)
            {
                var num = nums[i];
                if (visited.Contains(num)) continue;
                visited.Add(num);
                var mid = num / 2;
                if (num != mid * 2 || !cnt.ContainsKey(mid) || cnt[num].Count <= 1) continue;
                var ilist = cnt[num];
                var jlist = cnt[mid];
                var pre = 0;
                for (var j = 0; j < ilist.Count; j++)
                {
                    var indexi = ilist[j];
                    for (var j1 = pre; j1 < jlist.Count; j1++)
                    {
                        var index = jlist[j1];
                        if (indexi >= index) continue;
                        var existK = false;
                        for (var k = j + 1; k < ilist.Count; k++)
                        {
                            var indexk = ilist[k];
                            if (indexk <= index) continue;
                            ans = (ans + (ilist.Count - k)) % mod;
                            existK = true;
                            break;
                        }
                        if (!existK) break;
                    }
                }
            }
            return ans;
        }

        public int SpecialTriplets2(int[] nums)
        {
            var ans = 0L;
            var n = nums.Length;
            var mod = 1_000_000_007;
            var cnt = new Dictionary<int, int>();
            var leftcnt = new Dictionary<int, int>();
            for (var i = 0; i < n; i++)
            {
                cnt.TryAdd(nums[i], 0);
                cnt[nums[i]]++;
            }
            foreach (var num in nums)
            {
                var key = 2 * num;
                var l = leftcnt.ContainsKey(key) ? leftcnt[key] : 0;
                leftcnt.TryAdd(num, 0);
                leftcnt[num]++;
                var r = (cnt.ContainsKey(key) ? cnt[key] : 0) - (leftcnt.ContainsKey(key) ? leftcnt[key] : 0);

                ans = (ans + (long)r * l) % mod;
            }

            return (int)ans;
        }
    }
}
