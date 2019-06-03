using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Queue<T>
    {
        protected T[] arr;
        protected int front;
        protected int back;
        public Queue()
        {
            arr = new T[32];
            front = -1;
            back = -1;
        }
        public Queue(int Capacity)
        {
            arr = new T[Capacity];
            front = -1;
            back = -1;
        }
        public virtual void enqueue(T item)
        {
            if (front == -1 && back == -1)
            {
                front++;
            }
            back++;
            arr[back] = item;
        }
        public virtual T dequeue()
        {
            if (front <= back && front != -1)
            {
                T item = arr[front];
                front++;
                if (front > back)
                {
                    front = -1;
                    back = -1;
                }
                return item;
            }
            else
            {
                return default(T);
            }
        }
        public virtual T peek()
        {
            if (front <= back)
            {
                T item = arr[front];
                return item;
            }
            else
            {
                return default(T);
            }
        }
        public virtual bool isEmpty()
        {
            if(front == -1 && back == -1)
            {
                return true;
            }
            return false;
        }
        public virtual void clear()
        {
            front = -1;back = -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> demo = new Queue<int>();
            demo.enqueue(5);
            demo.enqueue(6);
            demo.enqueue(7);
            demo.enqueue(8);

            Console.WriteLine(demo.dequeue());
            Console.WriteLine(demo.dequeue());
            Console.WriteLine(demo.dequeue());
            Console.WriteLine(demo.dequeue());
            Console.ReadKey();
        }
    }
}
