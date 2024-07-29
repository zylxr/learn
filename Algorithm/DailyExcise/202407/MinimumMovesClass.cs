using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinimumMovesClass
    {
        //给你一个下标从 0 开始的二进制数组 nums，其长度为 n ；另给你一个 正整数 k 以及一个 非负整数 maxChanges 。
        //Alice 在玩一个游戏，游戏的目标是让 Alice 使用 最少 数量的 行动 次数从 nums 中拾起 k 个 1 。游戏开始时，Alice 可以选择数组[0, n - 1] 范围内的任何索引 aliceIndex 站立。
        //如果 nums[aliceIndex] == 1 ，Alice 会拾起一个 1 ，并且 nums[aliceIndex] 变成0（这 不算 作一次行动）。
        //之后，Alice 可以执行 任意数量 的 行动（包括零次），在每次行动中 Alice 必须 恰好 执行以下动作之一：
        //选择任意一个下标 j != aliceIndex 且满足 nums[j] == 0 ，然后将 nums[j] 设置为 1 。这个动作最多可以执行 maxChanges 次。
        //选择任意两个相邻的下标 x 和 y（|x - y| == 1）且满足 nums[x] == 1, nums[y] == 0 ，然后交换它们的值（将 nums[y] = 1 和 nums[x] = 0）。如果 y == aliceIndex，在这次行动后 Alice 拾起一个 1 ，并且 nums[y] 变成 0 。
        //返回 Alice 拾起 恰好 k 个 1 所需的 最少 行动次数。
        //示例 1：
        //输入：nums = [1, 1, 0, 0, 0, 1, 1, 0, 0, 1], k = 3, maxChanges = 1
        //输出：3
        //解释：如果游戏开始时 Alice 在 aliceIndex == 1 的位置上，按照以下步骤执行每个动作，他可以利用 3 次行动拾取 3 个 1 ：

        //游戏开始时 Alice 拾取了一个 1 ，nums[1] 变成了 0。此时 nums 变为[1, 1, 1, 0, 0, 1, 1, 0, 0, 1] 。
        //选择 j == 2 并执行第一种类型的动作。nums 变为[1, 0, 1, 0, 0, 1, 1, 0, 0, 1]
        //选择 x == 2 和 y == 1 ，并执行第二种类型的动作。nums 变为[1, 1, 0, 0, 0, 1, 1, 0, 0, 1] 。由于 y == aliceIndex，Alice 拾取了一个 1 ，nums 变为[1, 0, 0, 0, 0, 1, 1, 0, 0, 1] 。
        //选择 x == 0 和 y == 1 ，并执行第二种类型的动作。nums 变为[0, 1, 0, 0, 0, 1, 1, 0, 0, 1] 。由于 y == aliceIndex，Alice 拾取了一个 1 ，nums 变为[0, 0, 0, 0, 0, 1, 1, 0, 0, 1] 。
        //请注意，Alice 也可能执行其他的 3 次行动序列达成拾取 3 个 1 。

        //示例 2：
        //输入：nums = [0, 0, 0, 0], k = 2, maxChanges = 3
        //输出：4

        //解释：如果游戏开始时 Alice 在 aliceIndex == 0 的位置上，按照以下步骤执行每个动作，他可以利用 4 次行动拾取 2 个 1 ：

        //选择 j == 1 并执行第一种类型的动作。nums 变为[0, 1, 0, 0] 。
        //选择 x == 1 和 y == 0 ，并执行第二种类型的动作。nums 变为[1, 0, 0, 0] 。由于 y == aliceIndex，Alice 拾起了一个 1 ，nums 变为[0, 0, 0, 0] 。
        //再次选择 j == 1 并执行第一种类型的动作。nums 变为[0, 1, 0, 0] 。
        //再次选择 x == 1 和 y == 0 ，并执行第二种类型的动作。nums 变为[1, 0, 0, 0] 。由于y == aliceIndex，Alice 拾起了一个 1 ，nums 变为[0, 0, 0, 0] 。



        //提示：

        //2 <= n <= 105
        //0 <= nums[i] <= 1
        //1 <= k <= 105
        //0 <= maxChanges <= 105
        //maxChanges + sum(nums) >= k

        //方法一：贪心 + 二分
        //考虑 Alice 拾起 1 的两种情况：

        //情况一：先将 aliceIndex 邻近的数字设置为 1，然后交换数字，只需要两次行动就可以拾起一个 1。

        //情况二：令 nums[x] = 1，那么需要 ∣x−aliceIndex∣ 次行动才可以拾起一个 1，根据 x 的取值，又可以区分成两种类型：

        //x∈[aliceIndex−1, aliceIndex+1]，那么最多需要 1 次行动就可以拾起一个 1。

        //x∈/[aliceIndex−1, aliceIndex+1]，那么最少需要 2 次行动才可以拾起一个 1。

        //令 f(aliceIndex) 表示数组 nums 在区间[aliceIndex−1, aliceIndex + 1] 内的元素之和。

        //如果 f(aliceIndex)+maxChanges≥k，那么最少行动次数肯定是先将区间[aliceIndex−1, aliceIndex + 1] 内的所有 1 拾起，然后剩余的 1 根据情况一来拾起。

        //如果 f(aliceIndex)+maxChanges<k，那么可以贪心地先拾起情况一的所有 1，剩余 k−maxChanges 个 1 根据情况二拾起。
        //我们使用 indexSum[i] 记录数组 nums 在区间[0, i) 内所有值为 1 的元素下标之和，使用 sum[i] 记录数组 nums 在区间[0, i) 所有元素之和。
        //要使情况二的行动次数之和最少，那么拾起的 1 距离 aliceIndex 需要尽量近。我们使用二分算法来搜索最短距离 d，使得区间[aliceIndex−d, aliceIndex + d] 内的 1 数目大于等于 k−maxChanges。
        //记选择的区间为[i1, i2]，那么最少行动次数为：
        //indexSum[i2+1]−indexSum[aliceIndex + 1]−aliceIndex×(sum[i2+1]−sum[i + 1])+aliceIndex×(sum[aliceIndex + 1]−sum[i1])−(indexSum[aliceIndex + 1]−indexSum[i1])+2×maxChanges
        //我们可以枚举 aliceIndex，然后取所有结果的最小值。
        public long MinimumMoves1(int[] nums, int k, int maxChanges)
        {
            var n = nums.Length;
            var indexSum = new long[n + 1];
            var sum = new long[n + 1];
            for (var i = 0; i < n; i++)
            {
                indexSum[i + 1] = indexSum[i] + i * nums[i];
                sum[i + 1] = sum[i] + nums[i];
            }
            var res = long.MaxValue;
            for (var i = 0; i < n; i++)
            {
                var fi = F(i, nums);
                if (fi + maxChanges >= k)
                {
                    if (k <= fi)
                    {
                        res = Math.Min(res, (long)k - nums[i]);
                    }
                    else
                        res = Math.Min(res, (long)2 * k - fi - nums[i]);
                    continue;
                }
                var left = 0;
                var right = n;
                while (left <= right)
                {
                    var mid = (left + right) >> 1;
                    var idx1 = Math.Max(i - mid, 0);
                    var idx2 = Math.Min(i + mid, n - 1);
                    if (sum[idx2 + 1] - sum[idx1] >= k - maxChanges)
                    {
                        right = mid - 1;
                    }
                    else left = mid + 1;
                }
                var i1 = Math.Max(i - left, 0);
                var i2 = Math.Min(i + left, n - 1);
                if (sum[i2 + 1] - sum[i1] > k - maxChanges)
                {
                    i1++;
                }
                var count1 = sum[i + 1] - sum[i1];
                var count2 = sum[i2 + 1] - sum[i + 1];
                res = Math.Min(res, indexSum[i2 + 1] - indexSum[i + 1] - i * count2 + i * count1 - (indexSum[i + 1] - indexSum[i1]) + 2 * maxChanges);
            }
            return res;
        }

        //方法二：贪心 + 双指针
        //方法一使用了二分算法选择区间[i1, i2]，我们也可以使用双指针来维护 aliceIndex 对应的[i1, i2]。
        //我们从小到大开始枚举 aliceIndex，记当前枚举的 aliceIndex = i，使用 left 和 right 维护区间的左右端点，
        //leftCount 和 rightCount 维护在区间[left, i) 和[i, right] 的元素之和，leftSum 和 rightSum 维护在区间[left, i) 和[i, right] 的值为 1 的下标之和。
        //在枚举过程中，首先尽量保证左右端点到 i 的距离相等且区间内的元素之和大于等于 k−maxChanges，然后如果区间内的元素之和大于 k−maxChanges，
        //我们需要根据左右端点的距离决定去掉哪些元素，最后最小行动次数为：
        //leftCount×i−leftSum + rightSum−rightCount×i + 2×maxChanges
        //取枚举过程中的最小行动次数的最小值，返回结果。

        public long MinimumMoves2(int[] nums, int k, int maxChanges)
        {
            var n = nums.Length;
            var left = 0;
            var right = -1;
            var leftSum = 0;
            var rightSum = 0;
            var leftCount = 0;
            var rightCount = 0;
            var res = long.MaxValue;
            for(var i=0;i<n;i++)
            {
                if (F(i, nums) + maxChanges >= k)
                {
                    if(k<=F(i, nums))
                    {
                        res = Math.Min(res, k - nums[i]);
                    }else
                    {
                        res = Math.Min(res, (long)2 * k - F(i, nums) - nums[i]);
                    }
                }
                if (k <= maxChanges) continue;
                while(right+1<n &&(right-i<i-left||leftCount+rightCount+maxChanges<k))
                {
                    if (nums[right+1]==1)
                    {
                        rightCount++;
                        rightSum += right + 1;
                    }
                    right++;
                }
                while(leftCount +rightCount+maxChanges>k)
                {
                    if(right-i<i-left||right-i == i-left && nums[left] == 1)
                    {
                        if (nums[left]== 1)
                        {
                            leftCount--;
                            leftSum -= left;
                        }
                        left++;
                    }
                    else
                    {
                        if (nums[right] == 1)
                        {
                            rightCount--;
                            rightSum -= right;
                        }
                        right--;
                    }
                }
                res = Math.Min(res, leftCount * i - leftSum + rightSum - rightCount * i + 2 * maxChanges);
                if (nums[i] == 1)
                {
                    leftCount++;
                    leftSum += i;
                    rightCount--;
                    rightSum -= i;
                }
            }
            return res;
        }

        public int F(int i, int[] nums)
        {
            var x = nums[i];
            if (i - 1 >= 0)
                x += nums[i - 1];
            if(i+1<nums.Length)
                x+= nums[i+1];
            return x;
        }
    }
}
