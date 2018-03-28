using System;
using System.Java.Threading;
using System.Threading;
using System.Threading.Tasks;

namespace System.Java.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CountDownLatch cdl = new CountDownLatch(10);
            for (int i = 0; i < 10; i++)
            {
                Task t = new Task(() =>
                {
                    Thread.Sleep(1000);
                    cdl.CountDown();
                    Console.WriteLine(cdl.GetCountDownNumber());
                });
                t.Start();
            }
            cdl.Wait();
            Console.WriteLine("over");
            Console.ReadLine();
        }
    }
}
