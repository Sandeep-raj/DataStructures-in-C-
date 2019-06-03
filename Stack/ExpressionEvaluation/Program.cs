using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stack;
using System.Collections.Generic;

namespace ExpressionEvaluation
{
    class Program
    {
        static Stack.Stack<int> numbers = new Stack.Stack<int>();
        static Stack.Stack<char> symbol = new Stack.Stack<char>();
        static Dictionary<char, int> Precedence = new Dictionary<char, int>() { { '(',0 } , { '+', 1 }, { '-' , 2}, { '*',3} , { '/',4} };
        static void Main(string[] args)
        {
            
            string input = "10 + ( 7 - 3 )";
            string num = null;
            foreach (char ch in input)
            {
                if((ch - '0') <= 9 && (ch-'0') >= 0)
                {
                    num += ch;
                }
                else
                {
                    if(num != null)
                    numbers.push(Convert.ToInt16(num));
                    num = null;
                }
                if(ch == '+' || ch == '-' || ch == '*' || ch == '/' )
                {
                    if (!symbol.isEmpty())
                    {
                        char oldop = symbol.pop();
                        if (Precedence[oldop] > Precedence[ch])
                        {
                            symbol.push(oldop);
                            Process();
                        }
                        else
                        {
                            symbol.push(oldop);
                        }
                    }
                    symbol.push(ch);
                }
                if(ch == ')')
                {
                    while(symbol.peek() != '(')
                    Process();
                    symbol.pop();
                }
                if(ch == '(')
                {
                    symbol.push(ch);
                }
            }
            if (num != null)
            {
                numbers.push(Convert.ToInt16(num));
            }
            if (!symbol.isEmpty())
            {
                while (!symbol.isEmpty())
                {
                    Process();
                }
            }
            Console.WriteLine(numbers.pop());
            Console.ReadKey();
        }

        static void Process()
        {
            char op = symbol.pop();
            if (op == '+')
            {
                int second = numbers.pop();
                int first = numbers.pop();
                numbers.push(first + second);
            }
            else if (op == '-')
            {
                int second = numbers.pop();
                int first = numbers.pop();
                numbers.push(first - second);
            }
            else if (op == '*')
            {
                int second = numbers.pop();
                int first = numbers.pop();
                numbers.push(first * second);
            }
            else if (op == '/')
            {
                int second = numbers.pop();
                int first = numbers.pop();
                numbers.push(first / second);
            }
        }
    }
}
