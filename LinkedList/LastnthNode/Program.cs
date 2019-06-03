using System;
using LinkedList;

namespace LastnthNode
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
            lastNthNode(list,1);
        }

        public static void lastNthNode(LinkedList<string> list,int n)
        {
            Node<string> nthNode = null;
            Node<string> endNode = null;
            nthNode = endNode = list.head.next;
            while (n > 0)
            {
                endNode = endNode.next;
                n--;
            }
            while(endNode.next != null)
            {
                endNode = endNode.next;
                nthNode = nthNode.next;
            }

            Console.WriteLine("The nth node is " + nthNode.element);
            Console.ReadKey();
        }

    }

}
