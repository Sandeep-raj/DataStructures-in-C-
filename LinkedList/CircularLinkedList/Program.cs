using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList
{
    public class Obj
    {
        public int data1;
        public string data2;
        public Obj(int data1, string data2)
        {
            this.data1 = data1;
            this.data2 = data2;
        }
        public override bool Equals(Object obj)
        {

            if ((obj as Obj).data1 == data1 && (obj as Obj).data2 == data2)
                return true;
            return false;
        }
    }
    public class Node<T>
    {
        public T element;
        public Node<T> next;
        public Node()
        {
            this.element = default(T);
            next = null;
        }
        public Node(T item)
        {
            element = item;
            next = null;
        }
    }
    public class CircularLinkedList<T>
    {
        public int Count = 0;
        public Node<T> head;
        public CircularLinkedList()
        {
            head = new Node<T>();
            head.next = head;
        }
        public void Add(T item)
        {
            Node<T> current = head;
            while (current.next != head)
            {
                current = current.next;
            }
            Node<T> newNode = new Node<T>(item);
            current.next = newNode;
            newNode.next = head;
            Count++;
        }
        public void Remove(T item)
        {
            Node<T> current = head;
            while (current.next != head)
            {
                if (current.next.element.Equals(item))
                {
                    Node<T> remItem = current.next;
                    current.next = remItem.next;
                    remItem = null;
                    Count--;
                    return;
                }
                current = current.next;
            }
        }
        public void Insert(T afterItem, T insertItem)
        {
            Node<T> current = head;
            Node<T> insertNode = new Node<T>(insertItem);
            while (current.next != head)
            {
                if (current.next.element.Equals(afterItem))
                {
                    Node<T> temp = current.next.next;
                    current.next.next = insertNode;
                    insertNode.next = temp;
                    Count++;
                    return;
                }
                current = current.next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList<Obj> l = new CircularLinkedList<Obj>();
            l.Add(new Obj(1, "Hello"));
            l.Add(new Obj(2, "Hi"));
            l.Add(new Obj(3, "jimmy"));
            l.Add(new Obj(4, "carpe diem"));
            l.Remove(new Obj(3, "jimmy"));
            l.Insert(new Obj(4, "carpe diem"), new Obj(5, "success"));
        }
    }
}
