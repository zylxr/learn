using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class DutchNationalFlagProlem
    {
        //给定一个包含红色、白色和蓝色、共n个元素的数组 nums, 
        //原地对它们进行排序，使得相同颜色的元素相邻，并按照红色、白色、蓝色顺序排列。
        //我们使用整数 0、1和2分别表示红色、白色和蓝色。
        //必须在不使用库内置的 sort 函数的情况下解决这个问题。
        //仅使用常数空间的一趟扫描算法
        public void SortColors(int[] nums)
        {
            var red = 0;
            var white = 0;
            var blue = nums.Length - 1;
            while(white<=blue)
            {
                if (nums[white] == 0)
                {
                    Swap(nums, red, white);
                    red++;
                    white++;
                }
                else if (nums[white] == 1) white++;
                else
                {
                    Swap(nums, white, blue);
                    blue--;
                }
            }
        }

        public void Swap(int[] nums, int i, int j)
        {
            var tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        public void Test()
        {
            var nums = new int[] { 2, 0, 2, 1, 1, 0 };
            SortColors(nums);
            foreach(var num in nums)Console.WriteLine(num); 
        }
    }
}
