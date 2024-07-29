using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class TrapClass
    {
        //给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。
        //示例 1：
        //输入：height = [0,1,0,2,1,0,1,3,2,1,2,1]
        //输出：6
        //解释：上面是由数组[0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1] 表示的高度图，在这种情况下，可以接 6 个单位的雨水（蓝色部分表示雨水）。 
        //示例 2：

        //输入：height = [4,2,0,3,2,5]
        //输出：9


        //提示：

        //n == height.length
        //1 <= n <= 2 * 104
        //0 <= height[i] <= 105
        public int Trap(int[] height)
        {
            var n = height.Length;
            var leftMax = new int[n];
            var rightMax = new int[n];
            leftMax[0] = height[0];
            for(var i=1;i<n;i++)
            {
                leftMax[i] = Math.Max(leftMax[i-1], height[i]);
            }
            rightMax[n-1] = height[n-1];
            for(var i=n-2;i>=0;i--)
            {
                rightMax[i] = Math.Max(rightMax[i+1], height[i]);
            }
            var ans = 0;
            for (var i = 0; i < n; i++)
            {
                ans += Math.Min(leftMax[i], rightMax[i]) - height[i];
            }
            return ans;
        }

        public int TrapByStack(int[] height)
        {
            var n = height.Length;
            var stack = new Stack<int>();
            var ans = 0;
            for(var i=0;i<n;i++)
            {
                while(stack.Count>0 && height[stack.Peek()] < height[i])
                {
                    var top = stack.Pop();
                    if (stack.Count == 0) break;
                    var left = stack.Peek();
                    var width = i - left - 1;
                    var h = Math.Min(height[left], height[i]) - height[top];
                    ans += h * width;
                }
                stack.Push(i);
            }
            return ans;
        }
        public int TrapByDoubleLink(int[] height)
        {
            var n = height.Length;
            var leftMax = 0;
            var rightMax = 0;
            var left = 0;
            var right = n-1;
            var ans = 0;
            while (left < right)
            {
                leftMax = Math.Max(height[left], leftMax);
                rightMax= Math.Max(height[right], rightMax);
                if (height[left]< height[right])
                {
                    ans += leftMax - height[left];
                    left = left + 1;
                }else
                {
                    ans += rightMax - height[right];
                    right = right - 1;
                }
            }
            return ans;
        }
    }
}
