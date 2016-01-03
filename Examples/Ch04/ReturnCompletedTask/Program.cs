using System;
using System.Threading.Tasks;

namespace ReturnCompletedTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                IMyCache myCache = new MyCache();
                var s = await myCache.GetDataAsync();
                System.Console.WriteLine(s);
            });

            Console.ReadLine();
        }
    }

    interface IMyCache
    {
        Task<string> GetDataAsync();
    }

    class MyCache : IMyCache
    {
        public Task<string> GetDataAsync()
        {
            return Task.FromResult("hello");
        }
    }
}
