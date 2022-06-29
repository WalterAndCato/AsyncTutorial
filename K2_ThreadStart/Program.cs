using System;
using System.Threading;

namespace ThreadStart
{
    class Program
    {
        static void Main(string[] args)
        {
                System.Threading.ThreadStart @start = StartTread;
                var thread = new Thread(@start);
                thread.Name = "Thread from ThreadStart Delegate";

                ParameterizedThreadStart param = _ParameterizedThreadStart;
                var thread2 = new Thread(param);
                thread2.Name = "Thread from ParameterizedStart Delegate";

                int threehundert = 300;
                string noClosure = "not in the closure space";
                var thread3 = new Thread(
                    () =>
                    {
                        Print();
                        Console.WriteLine(threehundert);
                    }
                );
                thread3.Name = "Thread from Lambda with Closure";
                
                thread.Start();
                thread2.Start(42);
                thread3.Start();
        }

        static void Print()
        {
            string threadName = Thread.CurrentThread.Name;
            System.Console.WriteLine(threadName);
        }

        static void StartTread()
        {
            System.Console.WriteLine("Started a thread");
            Print();
        }

        static void _ParameterizedThreadStart(object obj)
        {
            Console.WriteLine("from parameter " + obj);
            Print();
        }
    }
}