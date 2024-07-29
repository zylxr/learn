using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    public class RadixSort
    {
        int getMax(int[] arr)
        {
            var max = arr[0];
            for(var i=1;i < arr.Length;i++)
            {
                if (arr[i] > max)max= arr[i];
            }
            return max;
        }
        void CountingSort(int[] arr,int exp)
        {
            var output = new int[arr.Length];
            var count = new int[10];
            for(var i=0;i < arr.Length; i++)
            {
                count[(arr[i] / exp) % 10]++;
            }
            for(var i =1;i<10;i++)
            {
                count[i] += count[i - 1];
            }
            for(var i=arr.Length-1;i>=0;i--)
            {
                output[count[(arr[i]/exp)%10]-1] = arr[i];
                count[(arr[i]/exp)%10]--;
            }
            for(var i=0;i<arr.Length;i++)
            {
                arr[i] = output[i];
            }
        }
        public void Sort(int[] arr)
        {
            var max =getMax(arr);
            var exp = 1;
            while(max / exp > 0)
            {
                CountingSort(arr, exp);
                exp *= 10;
            }
        }
    }
}
