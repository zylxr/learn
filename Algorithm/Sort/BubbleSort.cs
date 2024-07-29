using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    public class BubbleSort
    {
        public void Sort(int[] arr)
        {
            var n = arr.Length;
            for(var i=0;i<n-1;i++)
            {
                for(var j=0;j<n-i-1;j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        var tmp = arr[j]; arr[j] = arr[j+1]; arr[j+1] = tmp;
                    }
                }
            }
        }
    }
}
