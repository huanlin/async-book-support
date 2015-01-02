using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex01_ThreadStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(MyTask);
            t1.Start();

            for (int i = 0; i < 500; i++)
            {
                Console.Write(".");
            }
        }

        static void MyTask()
        {
            for (int i = 0; i < 500; i++)
            {
                Console.Write("[" + Thread.CurrentThread.ManagedThreadId + "]");
            }
        }
    }
}
