using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello";
            doPermutation("", str);
            Console.ReadKey();

        }
        static void doPermutation(string prefix,string str)
        {
            int n = str.Length;
            if (n == 2) Console.WriteLine(prefix);
            else
            {
                for(int i=0;i< n; i++)
                {
                    doPermutation(prefix + str.ElementAt(i), str.Substring(0, i) + str.Substring(i + 1, n - i - 1));
                }
            }
        }
    }
}
