using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSorting
{
    public class BubbleSort
    {
        public static void Sort(int[] arr)
        {
            int len = arr.Length;
            
            for(int i = 0; i < len - 1; i++) 
                for(int j=0;j< len - 1-i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
        }
    }
    public class SelectionSort
    {
        public static void Sort(int[] arr)
        {
            for(int i=0;i<arr.Length;i++)
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
        }
    }
    public class InsertionSort
    {
        public static void Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int val = arr[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] > val)
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5,4,3,2,1,7,8,9,6 };
            int[] arr1 = (int[])arr.Clone();
            int[] arr3 = (int[])arr.Clone();

            GC.Collect();
            TimeSpan t1 = new TimeSpan();
            BubbleSort.Sort(arr);
            Console.WriteLine(Process.GetCurrentProcess().TotalProcessorTime.Subtract(t1).Ticks);

            GC.Collect();
            TimeSpan t2 = new TimeSpan();
            SelectionSort.Sort(arr1);
            Console.WriteLine(Process.GetCurrentProcess().TotalProcessorTime.Subtract(t2).Ticks);

            GC.Collect();
            TimeSpan t3 = new TimeSpan();
            InsertionSort.Sort(arr3);
            Console.WriteLine(Process.GetCurrentProcess().TotalProcessorTime.Subtract(t3).Ticks);

            for (int i=0;i<arr.Length;i++)
                Console.Write(arr3[i]+" ");
            Console.ReadKey();
        }
    }
}
