using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DevideAndConquer
{
    public class SegmentSum
    {
       public int Sum(int[] segments,int left, int right)
        {
            var sum = 0;
            if(left == right)
            {
                if (segments[left] > 0) sum = segments[left];
                else sum = 0;
            }
            else
            {
                var mid = (left + right) >> 1;
                var leftSum = Sum(segments, left, mid);
                var rightSum = Sum(segments, mid+1, right);
                var lefts = 0;
                var sleft = 0;
                for(var i=mid;i>=left;i--)
                {
                    lefts += segments[i];
                    if(lefts>sleft)sleft = lefts;
                }

                var rights = 0;
                var sright = 0;
                for(var i=mid+1;i<=right;i++)
                {
                    rights += segments[i];
                    if(rights>sright) sright = rights;
                }
                sum = sleft + sright;
                if(sum<leftSum) sum = leftSum;
                if(sum<rightSum) sum = rightSum;
            }
            return sum;
        }

        public int SumEx(int[] segments, int left, int right)
        {
            //此算法是错误的，因为有中点左右两边的分段和最大值，用来比较的还需要包括中点的分段和，而不是从头开始计算，这会导致最终计算获取的只有一个值
            var sum = 0;
            if (left == right)
            {
                if (segments[left] > 0) sum = segments[left];
                else sum = 0;
            }
            else
            {
                var mid = (left + right) >> 1;
                var leftSum = Sum(segments, left, mid);
                var rightSum = Sum(segments, mid + 1, right);
                var subSum = 0;
                var maxSubSum = 0;
                for (var i = right; i >= left; i--)
                {
                    subSum += segments[i];
                    if (subSum > maxSubSum) maxSubSum = subSum;
                }
                sum = maxSubSum;
                if (sum < leftSum) sum = leftSum;
                if (sum < rightSum) sum = rightSum;
            }
            return sum;
        }
    }
}
