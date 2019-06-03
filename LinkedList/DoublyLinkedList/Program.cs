using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
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
        public Node<T> before;
        public Node<T> after;
        public Node()
        {
            this.element = default(T);
            before = null;
            after = null;
        }
        public Node(T item)
        {
            element = item;
            before = null;
            after = null;
        }
    }
    public class DoublyLinkedList<T>
    {
        public int Count = 0;
        public Node<T> head;
        public DoublyLinkedList()
        {
            head = new Node<T>();
        }
        public void Add(T item)
        {
            Node<T> current = head;
            while (current.after != null)
            {
                current = current.after;
            }
            Node<T> newNode = new Node<T>(item);
            current.after = newNode;
            newNode.before = current;
            Count++;
        }
        public void Remove(T item)
        {
            Node<T> current = head;
            while (current.after != null)
            {
                if (current.after.element.Equals(item))
                {
                    Node<T> temp = current.after.after;
                    current.after = temp;
                    temp.before = current;
                    Count--;
                    return;
                }
                current = current.after;
            }
        }
        public void Insert(T afterItem, T insertItem)
        {
            Node<T> current = head;
            Node<T> insertNode = new Node<T>(insertItem);
            while (current.after != null)
            {
                if (current.after.element.Equals(afterItem))
                {
                    Node<T> temp = current.after.after;
                    current.after.after = insertNode;
                    insertNode.before = current.after;
                    insertNode.after = temp;
                    if(temp!=null)
                    temp.before = insertNode;
                    Count++;
                    return;
                }
                current = current.after;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<Obj> l = new DoublyLinkedList<Obj>();
            l.Add(new Obj(1, "Hello"));
            l.Add(new Obj(2, "Hi"));
            l.Add(new Obj(3, "jimmy"));
            l.Add(new Obj(4, "carpe diem"));
            l.Remove(new Obj(3, "jimmy"));
            l.Insert(new Obj(4, "carpe diem"), new Obj(5, "success"));
        }
    }
}
