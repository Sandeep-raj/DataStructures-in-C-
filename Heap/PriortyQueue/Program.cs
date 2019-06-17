using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PriortyQueue
{

    public class task
    {
        public Process process;
        public int priority;

        public task(Process process,int priority)
        {
            this.process = process;
            this.priority = priority;
        }
    }

    public class PriorityQueue<T>
    {
        public T[] tasks;
        public int upperIndex;
        public int capacity;

        public PriorityQueue()
        {
            capacity = 32;
            tasks = new T[32];
            upperIndex = -1;
        }
        public PriorityQueue(int capacity)
        {
            this.capacity = capacity;
            tasks = new T[capacity];
            upperIndex = -1;
        }
        public int getParent(int index)
        {
            return (index - 1) / 2;
        }
        public void Insert(T data)
        {
            if (upperIndex + 1 < capacity)
            {
                upperIndex++;
                tasks[upperIndex] = data;
                HeapifyUp(tasks, upperIndex);
            }
        }
        public void HeapifyUp(T[] arr, int index)
        {
            task[] arrtask;
            if (typeof(T).Name.Contains("task"))
            {
                arrtask = arr as task[];
                if (getParent(index) >= 0 && arrtask[index].priority > arrtask[getParent(index)].priority)
                {
                    task temp = arrtask[getParent(index)];
                    arrtask[getParent(index)] = arrtask[index];
                    arrtask[index] = temp;
                    HeapifyUp(arr, getParent(index));
                }
            }
        }
        public T GetMaximum()
        {
            T max = tasks[0];
            tasks[0] = tasks[upperIndex];
            upperIndex--;
            HeapifyDown(tasks, 0);
            return max;
        }
        public void HeapifyDown(T[] arr, int index)
        {
            int minIndex = getMaximumChild(index);
            if (minIndex != -1)
            {
                T temp = arr[minIndex];
                arr[minIndex] = arr[index];
                arr[index] = temp;
                HeapifyDown(arr, minIndex);
            }
        }
        public int getMaximumChild(int index)
        {
            int temp = -1;
            if (typeof(T).Name.Contains("task"))
            {
                task[] taskarr = tasks as task[];
                if (2 * index + 2 <= upperIndex)
                {
                    temp = (taskarr[2 * index + 1].priority > taskarr[2 * index + 2].priority ? 2 * index + 1 : 2 * index + 2);
                }
                else if (2 * index + 1 == upperIndex)
                {
                    temp = 2 * index + 1;
                }

                if (temp != -1)
                {
                    temp = taskarr[temp].priority > taskarr[index].priority ? temp : -1;
                }
            }
            return temp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<task> queue = new PriorityQueue<task>();
            Thread[] thread = new Thread[7];
            Random rand = new Random(100);
            for(int i = 0; i < 7; i++)
            {
                int priority = rand.Next(100);
                queue.Insert(new task(CreateProcess("C:\\Users\\gurus\\Desktop\\DummyApplication.exe", priority.ToString()), priority));
            }
            
            for(int i = 0; i < 7; i++)
            {
                task t = queue.GetMaximum();
                thread[i] = new Thread(new ThreadStart(() => RunProcess(t.process)));
                thread[i].Start();
            }
            Console.ReadKey();
        }

        public static Process CreateProcess(string path,string args)
        {
            Process process = new Process();
            try
            {
                process.StartInfo = new ProcessStartInfo()
                {
                    FileName = path,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return process;
        }
        public static void RunProcess(Process process)
        {
            process.Start();

            while (!process.StandardOutput.EndOfStream)
            {
                var line = process.StandardOutput.ReadLine();
                Console.WriteLine(line);
            }
            process.WaitForExit();
        }
    }
}
