using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_ArrayList
{
    public class ParamArray
    {
        public static void fun(string name,params int[] arr)
        {
            int sum = 0;
            foreach(int i in arr)
            {
                sum += i;
            }
            Console.WriteLine(name+" "+sum);
        }
    }

    public class JaggedArray
    {
        public static void fun(int[][] arr, int rows, Dictionary<int,int> dict)
        {
            for(int i = 0; i < rows; i++)
            {
                arr[i] = new int[dict[i]];
                for(int j = 0; j < dict[i]; j++)
                {
                    arr[i][j] = j;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ParamArray.fun("sandeep", 2, 3, 4, 5, 6);
            int[][] arr = new int[5][];
            JaggedArray.fun(arr, 5, new Dictionary<int, int>() {
                {0 , 5},
                {1 , 2},
                {2 , 3},
                {3 , 8},
                {4 , 7}
            });
            Console.ReadKey();
        }
    }
}
