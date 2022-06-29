using System;
using System.IO;
using System.Threading;

namespace K2
{
    class Program
    {

        [ThreadStatic] 
        private static int _local = 42;

        private static int _global = 42;

        private static ThreadLocal<int> _tLocal = new ThreadLocal<int>(() => 42);

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(Increment);
                {
                    thread.Name = $"Thread-Nr [{i}]";
                    thread.Start();
                    Thread.Sleep(50);
                }
            }

            Console.ReadKey();
        }

        private static void Increment()
        {
            _local++;
            string threadName = Thread.CurrentThread.Name;
            Console.WriteLine($"{threadName} - Local: [{_tLocal}]");
            Console.WriteLine($"{threadName} - Global: [{++_global}]");
        }
    }
}