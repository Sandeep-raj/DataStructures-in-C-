using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack<T>
    {
        private T[] arr;
        private int size;
        private int top;
        public Stack()
        {
            size = int.MaxValue;
            arr = new T[1000];
            top = -1;
        }
        public Stack(int size)
        {
            this.size = size;
            arr = new T[size];
            top = -1;
        }
        public void push(T n)
        {
            if (top < size - 1)
            {
                top++;
                arr[top] = n;
                Console.WriteLine("Element pushed into stack");
            }
            else
            {
                Console.WriteLine("Stack is full");
            }
        }
        public T pop()
        {
            if (top >= 0)
            {
                Console.WriteLine("Element has been poped");
                T element = arr[top];
                top--;
                return element;
            }
            else
                return default(T);
        }
        public T peek()
        {
            if (top >= 0)
            {
                return arr[top];
            }
            else
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
        }
        public void clear()
        {
            top = -1;
        }
        public bool isEmpty()
        {
            return (top >= 0) ? false : true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.push(7);
            stack.push(11);
            stack.push(3);
            
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());

            Console.ReadKey();
        }
    }
}
