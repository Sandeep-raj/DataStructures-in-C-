using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyApplication
{
    public class Dummy
    {
        public static string fun(string instance)
        {
            return $"{instance} : Fun";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Dummy.fun(args[0]));
        }
    }
}
