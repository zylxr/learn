using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class SeparateSquaresClass2
    {
        //3454. 分割正方形 II
        //给你一个二维整数数组 squares ，其中 squares[i] = [xi, yi, li] 表示一个与 x 轴平行的正方形的左下角坐标和正方形的边长。

        //找到一个最小的 y 坐标，它对应一条水平线，该线需要满足它以上正方形的总面积 等于 该线以下正方形的总面积。

        //答案如果与实际答案的误差在 10-5 以内，将视为正确答案。

        //注意：正方形 可能会 重叠。重叠区域只 统计一次 。




        //示例 1：

        //输入： squares = [[0, 0, 1],[2, 2, 1]]

        //输出： 1.00000

        //解释：



        //任何在 y = 1 和 y = 2 之间的水平线都会有 1 平方单位的面积在其上方，1 平方单位的面积在其下方。最小的 y 坐标是 1。

        //示例 2：

        //输入： squares = [[0, 0, 2],[1, 1, 1]]

        //输出： 1.00000

        //解释：



        //由于蓝色正方形和红色正方形有重叠区域且重叠区域只统计一次。所以直线 y = 1 将正方形分割成两部分且面积相等。



        //提示：

        //1 <= squares.length <= 5 * 104
        //squares[i] = [xi, yi, li]
        //squares[i].length == 3
        //0 <= xi, yi <= 109
        //1 <= li <= 109
        //所有正方形的总面积不超过 1015
        public double SeparateSquares(int[][] squares)
        {
            // 存储事件: (y坐标, 类型, 左边界, 右边界)
            List<int[]> events = new List<int[]>();
            SortedSet<int> xsSet = new SortedSet<int>();

            foreach (var sq in squares)
            {
                int x = sq[0], y = sq[1], l = sq[2];
                int xr = x + l;
                events.Add(new int[] { y, 1, x, xr });
                events.Add(new int[] { y + l, -1, x, xr });
                xsSet.Add(x);
                xsSet.Add(xr);
            }

            // 按y坐标排序事件
            events.Sort((a, b) => a[0].CompareTo(b[0]));
            // 离散化坐标
            int[] xs = xsSet.ToArray();
            // 初始化线段树
            SegmentTree segTree = new SegmentTree(xs);

            List<long> psum = new List<long>();
            List<int> widths = new List<int>();
            long totalArea = 0;
            int prev = events[0][0];

            // 扫描：计算总面积和记录中间状态
            foreach (var eventItem in events)
            {
                int y = eventItem[0], delta = eventItem[1], xl = eventItem[2], xr = eventItem[3];
                int len = segTree.Query();
                totalArea += (long)len * (y - prev);
                segTree.Update(xl, xr, delta);
                // 记录前缀和和宽度
                psum.Add(totalArea);
                widths.Add(segTree.Query());
                prev = y;
            }

            // 计算目标面积（向上取整的一半）
            long target = (totalArea + 1) / 2;
            // 二分查找第一个大于等于target的位置
            int idx = BinarySearch(psum, target);
            // 获取对应的面积、宽度和高度
            double area = psum[idx];
            int width = widths[idx], height = events[idx][0];

            return height + (totalArea - area * 2) / (width * 2.0);
        }

        private int BinarySearch(List<long> list, long target)
        {
            int left = 0;
            int right = list.Count - 1;
            int result = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (list[mid] < target)
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return result;
        }

        public class SegmentTree
        {
            private int[] count;
            private int[] covered;
            private int[] xs;
            private int n;

            public SegmentTree(int[] xs_)
            {
                xs = xs_;
                n = xs.Length - 1;
                count = new int[4 * n];
                covered = new int[4 * n];
            }

            private void Modify(int qleft, int qright, int qval, int left, int right, int pos)
            {
                if (xs[right + 1] <= qleft || xs[left] >= qright)
                {
                    return;
                }
                if (qleft <= xs[left] && xs[right + 1] <= qright)
                {
                    count[pos] += qval;
                }
                else
                {
                    int mid = (left + right) / 2;
                    Modify(qleft, qright, qval, left, mid, pos * 2 + 1);
                    Modify(qleft, qright, qval, mid + 1, right, pos * 2 + 2);
                }

                if (count[pos] > 0)
                {
                    covered[pos] = xs[right + 1] - xs[left];
                }
                else
                {
                    if (left == right)
                    {
                        covered[pos] = 0;
                    }
                    else
                    {
                        covered[pos] = covered[pos * 2 + 1] + covered[pos * 2 + 2];
                    }
                }
            }

            public void Update(int qleft, int qright, int qval)
            {
                Modify(qleft, qright, qval, 0, n - 1, 0);
            }

            public int Query()
            {
                return covered[0];
            }
        }
    }
}
