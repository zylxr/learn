using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class LargestTriangleAreaClass
    {
        //812. 最大三角形面积
        //给你一个由 X-Y 平面上的点组成的数组 points ，其中 points[i] = [xi, yi] 。从其中取任意三个不同的点组成三角形，返回能组成的最大三角形的面积。与真实值误差在 10-5 内的答案将会视为正确答案。



        //示例 1：


        //输入：points = [[0, 0],[0, 1],[1, 0],[0, 2],[2, 0]]
        //输出：2.00000
        //解释：输入中的 5 个点如上图所示，红色的三角形面积最大。
        //示例 2：

        //输入：points = [[1, 0],[0, 0],[0, 1]]
        //输出：0.50000


        //提示：

        //3 <= points.length <= 50
        //-50 <= xi, yi <= 50
        //给出的所有点 互不相同

        public double LargestTriangleArea(int[][] points)
        {
            var n = points.Length;
            var ret = 0.0;
            for (var i = 0; i < n; i++) { 
                for(var j=i+1;j<n;j++)
                {
                    for (var k = j + 1; k < n; k++)
                        ret = Math.Max(ret, TriangleArea(points[i][0], points[i][1], points[j][0], points[j][1], points[k][0], points[k][1]));
                }
            }
            return ret;
        }
        public double TriangleArea(int x1,int y1, int x2,int y2,int x3,int y3)
        {
            return 0.5 * Math.Abs(x1 * y2 + x2 * y3 + x3 * y1 - x1 * y3 - x2 * y1 - x3 * y2);
        }

        

    }
}
