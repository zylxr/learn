using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    public class InsertSort
    {
        public void Sort(int[] arr)
        {
            var n = arr.Length;
            for(var i=1;i<n; i++)
            {
                var tmp = arr[i];
                var j = i - 1;
                for(j=i-1;j>=0 && arr[j]>tmp;j--) arr[j + 1] = arr[j];
                arr[j+1] = tmp;
            }
        }
    }
}
