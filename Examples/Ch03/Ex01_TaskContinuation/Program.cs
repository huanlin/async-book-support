using System;
using System.Threading.Tasks;

namespace Ex01_TaskContinuation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("程式開始");

            Task taskA =
                Task.Run(
                    () => Console.WriteLine("開始 Task A...."))
                .ContinueWith(
                    antecedentTask => 
                    {
                        Console.WriteLine("從 Task A 接續的工作....");
                        System.Threading.Thread.Sleep(4000); // 等待幾秒
                    } );

            Task taskB =
                taskA.ContinueWith(
                    antecedentTask =>
                    {
                        Console.WriteLine("從 Task A 接續開始 Task B....");
                    } );
            Task taskC = 
                taskA.ContinueWith(
                    antecedentTask => Console.WriteLine("從 Task A 接續開始 Task C....") );

            Task.WaitAll(taskB, taskC);

            Console.WriteLine("程式結束");
        }
    }
}
