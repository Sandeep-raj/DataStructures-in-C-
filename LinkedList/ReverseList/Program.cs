using System;
using LinkedList;

namespace ReverseList
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
            Node<string> head = reverseList(list);
            printList(head);
            Console.ReadKey();
        }

        public static Node<string>  reverseList(LinkedList<string> list)
        {
            Node<string> head = null;
            Node<string> curr = list.head.next;

            while(curr != null)
            {
                Node<string> node = curr.next;
                curr.next = head;
                head = curr;
                curr = node;
            }
            Node<string> last = new Node<string>();
            last.next = head;
            head = last;
            return head;
        }

        public static void printList(Node<string> node)
        {
            while(node.next != null)
            {
                Console.WriteLine(node.next.element);
                node = node.next;
            }
        }
    }
}
