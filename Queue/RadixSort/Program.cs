using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue;

namespace RadixSort
{
    class Program
    {
        static void radixSort(ref int[] arr,int index)
        {
            Queue<int>[] radices = new Queue<int>[10];
            radices = Enumerable.Range(0, 10).Select(x => new Queue<int>()).ToArray();
            int[] result = new int[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                radices[((int)(arr[i] / index)) % 10].enqueue(arr[i]);
            }
            int count = 0;
            for(int i = 0; i <= 9; i++)
            {
                while (!radices[i].isEmpty())
                {
                    result[count] = radices[i].dequeue();
                    count++;
                }
            }
            arr = result;
        }
        static int getMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (max < arr[i])
                    max = arr[i];
            return max;
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 12, 3, 23, 16, 7, 0, 9, 43 };
            int max = getMax(arr);
            for (int i = 1; max / i > 0; i *= 10)
            {
                radixSort(ref arr, i);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
