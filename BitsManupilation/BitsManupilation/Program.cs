using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsManupilation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5];
            Generate(arr, 5, 0);
            Console.ReadKey();
        }

        static void Generate(int[] arr,int n,int i)
        {
            if (i == n)
            {
                foreach (int x in arr)
                    Console.Write(x);
                Console.WriteLine();
                return;
            }
            arr[i] = 0;
            Generate(arr, n, i + 1);

            arr[i] = 1;
            Generate(arr, n, i + 1);
        }
    }
}
