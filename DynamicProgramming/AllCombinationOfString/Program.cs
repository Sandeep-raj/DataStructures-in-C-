using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCombinationOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Hello";
            uniqueString(input);
            Console.ReadKey();
        }

        static void uniqueString(string str)
        {
            HashSet<char> set = new HashSet<char>(str);
            str = "";
            foreach (char c in set)
                str += c;
            doCombinations("", str);
        }

        static void doCombinations(string prefix ,string str)
        {
            if (prefix.Length > 0)
                Console.WriteLine(prefix);
            for(int i = 0; i < str.Length; i++)
            {
                doCombinations(prefix + str.ElementAt(i), str.Substring(i + 1, str.Length - i - 1));
            }
        }
    }
}
