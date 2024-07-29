using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sort
{
    public class RunSort
    {
        public static void Run()
        {
            var bubbleSort = new BubbleSort();
            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
            Console.WriteLine("原始数组：");
            PrintArray(arr);

            bubbleSort.Sort(arr);

            
            Console.WriteLine("排序后的数组：");
            PrintArray(arr);

            //Select Sort
            arr =new int[] { 64, 34, 25, 12, 22, 11, 90 };
            var selectSort = new SelectSort();
            Console.WriteLine("原始数组：");
            PrintArray(arr);
            selectSort.Sort(arr);
            Console.WriteLine("Select排序后的数组：");
            PrintArray(arr);

            arr = new int[] { 64, 34, 25, 12, 22, 11, 90 };
            var insertSort = new InsertSort();
            Console.WriteLine("原始数组：");
            PrintArray(arr);
            insertSort.Sort(arr);
            Console.WriteLine("Insert排序后的数组：");
            PrintArray(arr);

            arr = new int[] { 64, 34, 25, 12, 22, 11, 90 };
            var quickSort = new QuickSort();
            Console.WriteLine("原始数组：");
            PrintArray(arr);
            quickSort.Sort(arr,0,arr.Length-1);
            Console.WriteLine("Quick排序后的数组：");
            PrintArray(arr);

            arr = new int[] { 64, 34, 25, 12, 22, 11, 90 };
            var heapSort = new HeapSort();
            Console.WriteLine("原始数组：");
            PrintArray(arr);
            heapSort.Sort(arr);
            Console.WriteLine("Heap排序后的数组：");
            PrintArray(arr);

            arr = new int[] { 64, 34, 25, 12, 22, 11, 90 };
            var mergeSort = new MergeSortAlgorithm();
            Console.WriteLine("原始数组：");
            PrintArray(arr);
            mergeSort.MergeSort(arr);
            Console.WriteLine("Merge 排序后的数组：");
            PrintArray(arr);

            arr = new int[] { 64, 34, 25, 12, 22, 11, 90 };
            var radixSort = new RadixSort();
            Console.WriteLine("原始数组：");
            PrintArray(arr);
            radixSort.Sort(arr);
            Console.WriteLine("Radix 排序后的数组：");
            PrintArray(arr);
        }

        static void PrintArray(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
