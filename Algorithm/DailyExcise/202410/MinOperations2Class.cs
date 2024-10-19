﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class MinOperations2Class
    {
        //3192. 使二进制数组全部等于 1 的最少操作次数 II
        //给你一个二进制数组 nums 。

        //你可以对数组执行以下操作 任意 次（也可以 0 次）：

        //选择数组中 任意 一个下标 i ，并将从下标 i 开始一直到数组末尾 所有 元素 反转 。
        //反转 一个元素指的是将它的值从 0 变 1 ，或者从 1 变 0 。

        //请你返回将 nums 中所有元素变为 1 的 最少 操作次数。



        //示例 1：

        //输入：nums = [0, 1, 1, 0, 1]

        //输出：4

        //解释：
        //我们可以执行以下操作：

        //选择下标 i = 1 执行操作，得到 nums = [0, 0, 0, 1, 0] 。
        //选择下标 i = 0 执行操作，得到 nums = [1, 1, 1, 0, 1] 。
        //选择下标 i = 4 执行操作，得到 nums = [1, 1, 1, 0, 0] 。
        //选择下标 i = 3 执行操作，得到 nums = [1, 1, 1, 1, 1] 。
        //示例 2：

        //输入：nums = [1, 0, 0, 0]

        //输出：1

        //解释：
        //我们可以执行以下操作：

        //选择下标 i = 1 执行操作，得到 nums = [1, 1, 1, 1] 。



        //提示：

        //1 <= nums.length <= 105
        //0 <= nums[i] <= 1
        public int MinOperations(int[] nums)
        {
            //只考虑 0-1 转换位置
            var n = nums.Length;
            var res = nums[0] == 0 ? 1 : 0;
            for (var i = 1; i < n; i++)
            {
                if ((nums[i - 1] ^ nums[i]) == 1)
                    res++;
            }
            return res;
        }

        public int MinOperations2(int[] nums)
        {
            var operation = 0;
            foreach(var num in nums)
            {
                if (operation % 2 == num) operation++;
            }
            return operation;
        }
    }
}
