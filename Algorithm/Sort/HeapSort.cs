using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    public class HeapSort
    {
        public void HeadAdjust(int[] arr, int s,int m)
        {
            var tmp = arr[s];
            for(var j=2*s+1;j<=m; j=2*j+1)
            {
                if (j < m && arr[j] < arr[j + 1]) j++;
                if (tmp >= arr[j]) break;
                arr[s] = arr[j];
                s = j;
            }
            arr[s] = tmp;
        }

        public void Sort(int[] arr)
        {
            var n = arr.Length;
            for (var i = n / 2 - 1; i >= 0; i--)
                HeadAdjust(arr, i, n - 1);
            for(var i=n-1;i>0;i--)
            {
                var tmp = arr[0];
                arr[0] = arr[i];
                arr[i] = tmp;
                HeadAdjust(arr, 0, i-1);
            }
        }
    }
}
