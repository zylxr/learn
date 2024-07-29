using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    public class QuickSort
    {
        public int Partition(int[] arr,int low,int high)
        {
            var i = low;
            var j = high;
            var pivot = arr[i];
            while(i<j)
            {
                while (i < j && arr[j] >= pivot) j--;
                arr[i] = arr[j];
                while (i < j && arr[i] <= pivot) i++;
                arr[j] = arr[i];
            }
            arr[i] = pivot;
            return i;
        }

        public void Sort(int[] arr,int low,int high)
        {
            if (low >= high) return;
            var mid = Partition(arr,low,high);
            Sort(arr,low,mid-1);
            Sort(arr,mid+1,high);
        }
    }
}
