using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class IsTrionicClass
    {
        //3637. 三段式数组 I
        //给你一个长度为 n 的整数数组 nums。

        //如果存在索引 0 < p<q<n − 1，使得数组满足以下条件，则称其为 三段式数组（trionic）：

        //nums[0...p] 严格 递增，
        //nums[p...q] 严格 递减，
        //nums[q...n − 1] 严格 递增。
        //如果 nums 是三段式数组，返回 true；否则，返回 false。




        //示例 1:

        //输入: nums = [1, 3, 5, 4, 2, 6]

        //输出: true

        //解释:

        //选择 p = 2, q = 4：

        //nums[0...2] = [1, 3, 5] 严格递增(1 < 3 < 5)。
        //nums[2...4] = [5, 4, 2] 严格递减(5 > 4 > 2)。
        //nums[4...5] = [2, 6] 严格递增(2 < 6)。
        //示例 2:

        //输入: nums = [2, 1, 3]

        //输出: false

        //解释:

        //无法选出能使数组满足三段式要求的 p 和 q 。




        //提示:

        //3 <= n <= 100
        //-1000 <= nums[i] <= 1000
        public bool IsTrionic(int[] nums)
        {
            //var n = nums.Length;
            //int p, q, j;
            //long maxsum, sum, res;
            //long ans = long.MinValue;
            //for(var i = 0; i < n; i++)
            //{
            //    j = i + 1;
            //    res = 0;
            //    for (; j < n && nums[j - 1] < nums[j]; j++) ;
            //    p = j - 1;
            //    if (p == i) continue;

            //    res += nums[p] + nums[p - 1];
            //    for (; j < n && nums[j - 1] > nums[j]; j++) res += nums[j];
            //    q = j - 1;
            //    if(q==p || q == n - 1 || nums[j] <= nums[q])
            //    {
            //        i = q;
            //        continue;
            //    }

            //    res += nums[q + 1];
            //    maxsum = 0;
            //    sum = 0;
            //    for(var k = q + 2; k < n && nums[k] > nums[k-1];k++)
            //    {
            //        sum += nums[k];
            //        maxsum = Math.Max(maxsum, sum);
            //    }
            //    res += maxsum;

            //    ans = Math.Max(ans, res);
            //    i = q - 1;
            //}
            //return ans;
            var n = nums.Length;
            int j, p, q;
            j = 1;
            for (; j < n && nums[j - 1] < nums[j]; j++) ;
            p = j - 1;
            if (p == 0) return false;
            for (; j < n && nums[j - 1] > nums[j]; j++) ;
            q = j - 1;
            if (q == p || q == n - 1)
            {
                return false;
            }
            for (; j < n && nums[j] > nums[j - 1]; j++) ;
            if (j == n) return true;
            return false;
        }
        
    }
}
