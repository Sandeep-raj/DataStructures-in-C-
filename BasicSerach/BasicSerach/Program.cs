using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSerach
{
    public class SequentialSearch
    {
        public static bool Search(int[] arr, int num)
        {
            foreach (int i in arr)
                if (i == num)
                    return true;
            return false;
        }
    }
    public class SelfOrganizingSearch
    {
        public static bool Search(int[] arr, int element)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == element)
                {
                    if (arr.Length * .2 < i)
                    {
                        int temp = arr[i];
                        int k = (int)Math.Floor((decimal)i / 2);
                        arr[i] = arr[(int)Math.Floor((decimal)i / 2)];
                        arr[(int)Math.Floor((decimal)i / 2)] = temp;
                        int z = arr[k];
                    }
                    return true;
                }
            }
            return false;
        }
    }
    public class BinarySearch
    {
        public static bool Search(int[] arr, int element)
        {
            int start = 0;
            int end = arr.Length;
            while (start <= end)
            {
                if (arr[(int)Math.Floor((decimal)(start + end) / 2)] == element)
                {
                    return true;
                }
                else if(arr[(int)Math.Floor((decimal)(start + end) / 2)] > element)
                {
                    end = (int)Math.Floor((decimal)(start + end) / 2) - 1;
                }
                else
                {
                    start = (int)Math.Floor((decimal)(start + end) / 2) + 1;
                }
            }

            return false;
        }
    }
    public class BinarySearchRecursive
    {
        public static bool Search(int[] arr, int start,int end,int element)
        {
            if (start > end)
                return false;
            else if (arr[(int)Math.Floor((decimal)(start + end) / 2)] == element)
                return true;
            else if (arr[(int)Math.Floor((decimal)(start + end) / 2)] > element)
                return Search(arr, start, (int)Math.Floor((decimal)(start + end) / 2) - 1, element);
            else if (arr[(int)Math.Floor((decimal)(start + end) / 2)] < element)
                return Search(arr, (int)Math.Floor((decimal)(start + end) / 2) + 1, end, element);
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            int[] arr = Enumerable.Range(1, 1000).Select(x => x * 3).ToArray<int>();
            
            if (BinarySearchRecursive.Search(arr,0,arr.Length, 2112))
            {
                Console.WriteLine("Number is found");
            }
            else Console.WriteLine("No is missing from the array");
            Console.ReadKey();
        }
    }
}
