using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    public class SelectSort
    {
        public void Sort(int[] arr)
        {
            var n = arr.Length;
            for(var i=0;i<n-1;i++)
            {
                var k = i;
                for(var j=i+1;j<n;j++)
                {
                    if (arr[j] < arr[k]) k = j;
                }
                if(k!=i)
                {
                    var tmp = arr[i];
                    arr[i] = arr[k];
                    arr[k] = tmp;
                }
            }
        }
    }
}
