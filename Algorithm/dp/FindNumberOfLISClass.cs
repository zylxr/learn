using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class FindNumberOfLISClass
    {
        //给定一个未排序的整数数组 nums ， 返回最长递增子序列的个数 。

        //注意 这个数列必须是 严格 递增的。
        //示例 1:

        //输入: [1,3,5,4,7]
        //输出: 2
        //解释: 有两个最长递增子序列，分别是[1, 3, 4, 7] 和[1, 3, 5, 7]。
        //示例 2:

        //输入: [2,2,2,2,2]
        //输出: 5
        //解释: 最长递增子序列的长度是1，并且存在5个子序列的长度为1，因此输出5。
 

        //提示: 

        //1 <= nums.length <= 2000
        //-106 <= nums[i] <= 106
        public int FindNumberOfLIS1(int[] nums)
        {
            var n = nums.Length;
            var dp = new int[n];
            var maxLen = 0;
            var counts = new int[n];
            var countNum = 0;
            for (var i = 0; i < n; i++)
            {
                dp[i] = 1;
                counts[i] = 1;
                if (i == 0)
                {
                    dp[i] = 1;
                    maxLen = 1;
                    counts[i] = 1;
                    continue;
                }
                for (var j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (dp[j] + 1 > dp[i])
                        {
                            dp[i] = dp[j] + 1;
                            counts[i] = counts[j];
                        }
                        else if (dp[j] + 1 == dp[i])
                        {
                            counts[i] += counts[j];
                        }
                    }
                }
                maxLen = Math.Max(maxLen, dp[i]);
            }
            
            for(var i=0;i<n;i++)
            {
                if (dp[i] == maxLen)
                    countNum += counts[i];
            }
            return countNum;
        }

        public int FindNumberOfLIS(int[] nums)
        {
            IList<IList<int>> d = new List<IList<int>>();
            IList<IList<int>> cnt = new List<IList<int>>();
            foreach (int v in nums)
            {
                int i = BinarySearch1(d.Count, d, v);
                int c = 1;
                if (i > 0)
                {
                    int k = BinarySearch2(d[i - 1].Count, d[i - 1], v);
                    c = cnt[i - 1][cnt[i - 1].Count - 1] - cnt[i - 1][k];
                }
                if (i == d.Count)
                {
                    IList<int> dIList = new List<int>();
                    dIList.Add(v);
                    d.Add(dIList);
                    IList<int> cntIList = new List<int>();
                    cntIList.Add(0);
                    cntIList.Add(c);
                    cnt.Add(cntIList);
                }
                else
                {
                    d[i].Add(v);
                    int cntSize = cnt[i].Count;
                    cnt[i].Add(cnt[i][cntSize - 1] + c);
                }
            }

            int count1 = cnt.Count, count2 = cnt[count1 - 1].Count;
            return cnt[count1 - 1][count2 - 1];
        }

        public int BinarySearch1(int n, IList<IList<int>> d, int target)
        {
            int l = 0, r = n;
            while (l < r)
            {
                int mid = (l + r) / 2;
                IList<int> list = d[mid];
                if (list[list.Count - 1] >= target)
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;
        }

        public int BinarySearch2(int n, IList<int> list, int target)
        {
            int l = 0, r = n;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (list[mid] < target)
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;
        }

    }
}
