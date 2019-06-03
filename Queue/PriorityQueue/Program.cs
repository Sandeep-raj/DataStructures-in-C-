using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue;

namespace PriorityQueue
{
    public class Process
    {
        int priority;
        string name;

        public int Priority
        {
            get
            {
                return priority;
            }

            set
            {
                priority = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Process(int priority,string name)
        {
            this.Priority = priority;
            this.Name = name;
        }
    }
    class PriorityQueue : Queue.Queue<Process>
    {
        
        public override void enqueue(Process item)
        {
            Process temp = item;
            if (!isEmpty())
            {
                for(int i = front; i <= back; i++)
                {
                    if(arr[i].Priority > temp.Priority)
                    {
                        Process x = arr[i];
                        arr[i] = temp;
                        temp = x;
                    }
                }
            }
            else { front++; }
            back++;
            arr[back] = temp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue pqueue = new PriorityQueue();
            pqueue.enqueue(new Process(3, "p1"));
            pqueue.enqueue(new Process(5, "p2"));
            pqueue.enqueue(new Process(9, "p3"));
            pqueue.enqueue(new Process(4, "p4"));
            pqueue.enqueue(new Process(7, "p5"));
            Console.WriteLine(pqueue.dequeue().Name);
            Console.WriteLine(pqueue.dequeue().Name);
            Console.WriteLine(pqueue.dequeue().Name);
            Console.WriteLine(pqueue.dequeue().Name);
            Console.WriteLine(pqueue.dequeue().Name);
            Console.ReadKey();
        }
    }
}
