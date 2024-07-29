using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    public class MergeSortAlgorithm
    {
        void Merge(int[] arr, int s,int m,int n)
        {
            var k = 0;
            var temp = new int[n - s + 1];
            var i = m+1;
            var start = s;
            for(; i<=n && s<=m;k++)
            {
                if (arr[s] < arr[i]) temp[k] = arr[s++];
                else temp[k] = arr[i++];
            }
            for(;i<=n;k++)
            {
                temp[k] = arr[i++];
            }
            for (; s <= m;k++)
                temp[k] = arr[s++];
            for (var j = 0; j < k; j++)
                arr[start++] = temp[j];
        }

        void MSort(int[] arr,int s, int t)
        {
            if(s<t)
            {
                var mid = (s + t) >> 1;
                MSort(arr, s, mid);
                MSort(arr, mid + 1, t);
                Merge(arr, s, mid, t);
            }
        }

        public void MergeSort(int[] arr)
        {
            var n = arr.Length;
            MSort(arr, 0, n - 1);
        }
    }
}
