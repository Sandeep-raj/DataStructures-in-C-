using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeLapseClass
{
    public class TimeLapse
    {
        public TimeLapse()
        {
            GC.Collect();
        }
        public long ProcessingTime(Process process)
        {
            return process.Threads[0].TotalProcessorTime.Ticks;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TimeLapse timeLapse = new TimeLapse();
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1);
            }
            Console.WriteLine(timeLapse.ProcessingTime(Process.GetCurrentProcess()));
            Console.ReadKey();
        }
    }
}
