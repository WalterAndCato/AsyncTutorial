using System;
using System.Threading;

namespace K2_ThreadStop
{
    class Program
    {
        static void Main(string[] args)
        {


            // var thread = new Thread(() => System.Console.WriteLine("stopped after this!"));
            // thread.Start();
            // string state = thread.ThreadState == ThreadState.Stopped ? "Was stopped" : "still running";
            // System.Console.WriteLine(state);

            var thread = new Thread(StopPerRequest);
            thread.Start();
            
            Thread.Sleep(500);
            _shouldStop = true;
            System.Console.WriteLine("finished business thread");
        }

        static bool _shouldStop = false;
        
        private static void StopPerRequest()
        {
            int i = 0;
            while (!_shouldStop)
            {
                i++;
                BusinessLogic(i);
            }
        }

        private static void BusinessLogic(int i)
        {
            Thread.Sleep(200);
            System.Console.WriteLine("some business operartion-number: " + i);
        }
    }
}