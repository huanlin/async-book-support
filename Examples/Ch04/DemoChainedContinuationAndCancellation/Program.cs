using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoChainedContinuationAndCancellation
{
    class Program
    {
        static void Main(string[] args)
        {
            Task taskA = Task.Run(DoSomething);
            var cancelToken = new CancellationTokenSource();
            Task taskB = taskA.ContinueWith(
                _ => Console.WriteLine("這裡不會執行"), cancelToken.Token);
            Task taskC = taskB.ContinueWith(
                _ => Console.WriteLine("TaskC 執行完畢。"));
            cancelToken.Cancel(); // 取消 taskB

            Console.ReadKey();
        }

        static void DoSomething()
        {
            Thread.Sleep(1500); 
            Console.WriteLine("TaskA 執行完畢。");
        }
    }
}
