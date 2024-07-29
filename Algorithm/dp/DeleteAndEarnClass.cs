using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class DeleteAndEarnClass
    {
        //给你一个整数数组 nums ，你可以对它进行一些操作。
        //每次操作中，选择任意一个 nums[i] ，删除它并获得 nums[i] 的点数。之后，你必须删除 所有 等于 nums[i] - 1 和 nums[i] + 1 的元素。

        //开始你拥有 0 个点数。返回你能通过这些操作获得的最大点数。
        //示例 1：

        //输入：nums = [3,4,2]
        //输出：6
        //解释：
        //删除 4 获得 4 个点数，因此 3 也被删除。
        //之后，删除 2 获得 2 个点数。总共获得 6 个点数。
        //示例 2：
        //输入：nums = [2,2,3,3,3,4]
        //输出：9
        //解释：
        //删除 3 获得 3 个点数，接着要删除两个 2 和 4 。
        //之后，再次删除 3 获得 3 个点数，再次删除 3 获得 3 个点数。
        //总共获得 9 个点数。
        public int DeleteAndEarn(int[] nums)
        {
            var maxNum = 0;
            foreach(var num in nums)
            {
                 maxNum = Math.Max(num,maxNum);
            }
            var sum = new int[maxNum+1];
            foreach (var num in nums)
                sum[num] += num;
            var pre = 0;
            var cur = 0;
            for(var i=0;i<sum.Length;i++)
            {
                if (i == 0) {
                    pre = sum[i];
                    continue;
                }
                if(i == 1)
                {
                    cur = Math.Max(pre, sum[i]);
                    continue;
                }
                var tmp = cur;
                cur = Math.Max(sum[i]+pre, cur);
                pre = tmp;
            }
            return cur;
        }


    }
}
