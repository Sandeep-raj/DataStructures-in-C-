using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalToMultibaseConversion
{
    class Program
    {
        static Stack.Stack<int> bitArray = new Stack.Stack<int>();
        static void Main(string[] args)
        {
            int inputNumber = 17;
            Convert(inputNumber, 2);
            while (!bitArray.isEmpty())
            {
                Console.Write(bitArray.pop());
            }
            Console.ReadKey();
        }
        static void Convert(int inputNumber,int baseValue)
        {
            while(inputNumber != 0)
            {
                bitArray.push(inputNumber % baseValue);
                inputNumber /= baseValue;
            }
        }
    }
}
