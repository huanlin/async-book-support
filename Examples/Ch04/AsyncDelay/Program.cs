using System;
using System.Threading.Tasks;

namespace AsyncDelay
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run(() => MyTaskAsync());
            Console.WriteLine("已經返回 Main()");

            Console.ReadLine();
        }

        static async Task MyTaskAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine("非同步工作結束");
        }
    }
}
