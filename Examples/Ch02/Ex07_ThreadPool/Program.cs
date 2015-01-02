using System;
using System.Threading;

namespace Ex07_ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(MyTask));

            for (int i = 0; i < 500; i++)
            {
                Console.Write(".");
            }
        }

        static void MyTask(object state)
        {
            for (int i = 0; i < 500; i++)
            {
                Console.Write("[" + Thread.CurrentThread.ManagedThreadId + "]");
            }
        }
    }
}
