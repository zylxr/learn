using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class KthSmallestProductClass
    {
        //2040. 两个有序数组的第 K 小乘积
        //给你两个 从小到大排好序 且下标从 0 开始的整数数组 nums1 和 nums2 以及一个整数 k ，请你返回第 k （从 1 开始编号）小的 nums1[i] * nums2[j] 的乘积，其中 0 <= i<nums1.length 且 0 <= j<nums2.length 。



        //示例 1：

        //输入：nums1 = [2, 5], nums2 = [3, 4], k = 2
        //输出：8
        //解释：第 2 小的乘积计算如下：
        //- nums1[0]* nums2[0] = 2 * 3 = 6
        //- nums1[0] * nums2[1] = 2 * 4 = 8
        //第 2 小的乘积为 8 。
        //示例 2：

        //输入：nums1 = [-4, -2, 0, 3], nums2 = [2, 4], k = 6
        //输出：0
        //解释：第 6 小的乘积计算如下：
        //- nums1[0]* nums2[1] = (-4) * 4 = -16
        //- nums1[0] * nums2[0] = (-4) * 2 = -8
        //- nums1[1] * nums2[1] = (-2) * 4 = -8
        //- nums1[1] * nums2[0] = (-2) * 2 = -4
        //- nums1[2] * nums2[0] = 0 * 2 = 0
        //- nums1[2] * nums2[1] = 0 * 4 = 0
        //第 6 小的乘积为 0 。
        //示例 3：

        //输入：nums1 = [-2, -1, 0, 1, 2], nums2 = [-3, -1, 2, 4, 5], k = 3
        //输出：-6
        //解释：第 3 小的乘积计算如下：
        //- nums1[0]* nums2[4] = (-2) * 5 = -10
        //- nums1[0] * nums2[3] = (-2) * 4 = -8
        //- nums1[4] * nums2[0] = 2 * (-3) = -6
        //第 3 小的乘积为 -6 。



        //提示：

        //1 <= nums1.length, nums2.length <= 5 * 104
        //-105 <= nums1[i], nums2[j] <= 105
        //1 <= k <= nums1.length* nums2.length
        //nums1 和 nums2 都是从小到大排好序的。
        public long KthSmallestProduct(int[] nums1, int[] nums2, long k)
        {
            var n1 = nums1.Length;
            long left = -1_000_000_000_0L, right = 1_000_000_000_0L;
            while(left<=right)
            {
                var mid = (left+right)/2;
                var count = 0L;
                for (var i = 0; i < n1; i++) count += F(nums2, nums1[i], mid);
                if (count < k) left = mid + 1;
                else right = mid - 1;
            }
            return left;
        }
        int F(int[] nums2,long x1,long v)
        {
            var n2 = nums2.Length;
            int left = 0, right = n2 - 1;
            while(left<=right) 
            {
                var mid = (left+right)/2;
                long prod = (long)nums2[mid] * x1;
                if ((x1 >= 0 && prod <= v) || (x1 < 0 && prod > v))
                    left = mid + 1;
                else
                {
                     right = mid - 1;
                }
            }
            if (x1 >= 0) return left;
            else
            {
                return n2 - left;
            }
        }

        public long KthSmallestProduct2(int[] nums1, int[] nums2, long k)
        {
            var n1 = nums1.Length;
            var n2 = nums2.Length;
            var pos1 = 0;
            var pos2 = 0;
            while (pos1 <= n1 && nums1[pos1] < 0) pos1++;
            while(pos2 <=n2 && nums2[pos2] < 0) pos2++;
            long left = -1_000_000_000_0L, right = 1_000_000_000_0L;
            while(left <= right)
            {
                long mid = (left+right)/2;
                var count = 0L;
                int i1 = 0, i2 = pos2 - 1;
                while(i1<pos1 && i2>=0)
                {
                    if ((long)nums1[i1] * nums2[i2] > mid) i1++;
                    else
                    {
                        count += pos1 - i1;
                        i2--;
                    }
                }
                i1 = pos1;
                i2 = n2 - 1;
                while(i1<n1&&i2>=pos1)
                {
                    if ((long)nums1[i1] * nums2[i2] > mid) i2--;
                    else
                    {
                        count += i2 - pos2 + 1;
                        i1++;
                    }
                }

                i1 = 0;
                i2 = pos2;
                while(i1<pos1&& i2<n2)
                {
                    if ((long)nums1[i1] * nums2[i2] > mid) i2++;
                    else
                    {
                        count += n2 - i2;
                        i1++;
                    }
                }
                i1 = pos1;
                i2 = 0;
                while(i1<n1&& i2<pos2)
                {
                    if ((long)nums1[i2] * nums2[i2] > mid) i1++;
                    else
                    {
                        count += n1 - i1;
                        i2++;
                    }
                }
                if (count < k) left = mid + 1;
                else right = mid - 1;
            }
            return left;
        }
    }
}
