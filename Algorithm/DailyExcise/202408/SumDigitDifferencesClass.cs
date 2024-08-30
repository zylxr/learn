using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class SumDigitDifferencesClass
    {
        //3153. 所有数对中数位不同之和
        //你有一个数组 nums ，它只包含 正 整数，所有正整数的数位长度都 相同 。

        //两个整数的 数位不同 指的是两个整数 相同 位置上不同数字的数目。

        //请你返回 nums 中 所有 整数对里，数位不同之和。



        //示例 1：

        //输入：nums = [13, 23, 12]

        //输出：4

        //解释：
        //计算过程如下：
        //- 13 和 23 的数位不同为 1 。
        //- 13 和 12 的数位不同为 1 。
        //- 23 和 12 的数位不同为 2 。
        //所以所有整数数对的数位不同之和为 1 + 1 + 2 = 4 。

        //示例 2：

        //输入：nums = [10, 10, 10, 10]

        //输出：0

        //解释：
        //数组中所有整数都相同，所以所有整数数对的数位不同之和为 0 。



        //提示：

        //2 <= nums.length <= 105
        //1 <= nums[i] < 109
        //nums 中的整数都有相同的数位长度。

        public long SumDigitDifferences(int[] nums)
        {
            var res = 0;
            var n = nums.Length;
            while (nums[0]>0)
            {
                var cnt = new int[10];
                for(var i=0;i<n;i++)
                {
                    cnt[nums[i] % 10]++;
                    nums[i] /= 10;
                }
                for (var i = 0; i < 10; i++)
                    res += (cnt[i] * (n - cnt[i]));
            }
            return res / 2;
        }
    }
}
