using System;
using System.Threading.Tasks;

namespace DemoAsyncVoid
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TestVoidAsync();
            }
            catch (Exception ex) // 捕捉不到 TestVoidAsync 方法所拋出的異常!
            {
                Console.WriteLine(ex);  
            }
        }

        static async void TestVoidAsync()
        {
            await Task.Delay(1000);
            throw new Exception("error");
        }
    }
}
