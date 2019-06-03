using System;
using LinkedList;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(41);
            list.Add(22);
            list.Add(93);
            list.Add(64);
            list.Add(51);
            list.Add(33);
            list.Add(25);
            InsertionSort(list);
        }

        public static void InsertionSort(LinkedList<int> list)
        {
            Node<int> head = list.head;
            Node<int> curr = head;
            while (curr.next != null)
            {

                Node<int> arrLimit = curr.next;
                Node<int> item = arrLimit.next;
                Node<int> itemLimit = item.next;

                arrLimit.next = itemLimit;
                Node<int> iter = head;

                while (iter.next != itemLimit)
                {
                    if (iter.next.element > item.element)
                    {
                        Node<int> temp = iter.next;
                        iter.next = item;
                        item.next = temp;
                        break;
                    }
                    iter = iter.next;
                }
                if (iter.next == itemLimit)
                {
                    Node<int> temp = iter.next;
                    iter.next = item;
                    item.next = temp;
                }
                curr = curr.next;

            }
            Node<int> final = curr;
            list.Remove(final.element);
            curr = head;
            while (curr.next != null)
            {
                if(curr.next.element > final.element)
                {
                    Node<int> temp = curr.next;
                    curr.next = final;
                    final.next = temp;
                    break;
                }
                curr = curr.next;
            }
        }
    }
}
