using System;
using LinkedList;

namespace FindMidpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("Sandeep");
            list.Add("Deepanshu");
            list.Add("Vineet");
            list.Add("Abhishek");
            list.Add("Gaurav");
            Node<string> mid = FindMidpoint(list);
            Console.WriteLine("The mid value is " + mid.element);
            Console.ReadKey();
        }

        public static Node<string> FindMidpoint(LinkedList<string> list)
        {
            Node<string> mid = null;
            Node<string> end = null;

            mid = end = list.head.next;
            while(end.next != null && end.next.next != null)
            {
                mid = mid.next;
                end = end.next.next;
            }
            return mid;
        }
    }
}
