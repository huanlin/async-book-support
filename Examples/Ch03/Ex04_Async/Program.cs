using System;
using System.Net;
using System.Threading.Tasks;

namespace Ex04_Async
{
    static class Program
    {
        static void Main()
        {

            Console.WriteLine("1: " + DateTime.Now);

            var task = MyDownloadPageAsync("https://www.huanlintalk.com");

            Console.WriteLine("2: " + DateTime.Now);

            string content = task.Result;

            Console.WriteLine("3: " + DateTime.Now);

            Console.WriteLine("網頁內容總共為 {0} 個字元。", content.Length);
        }

        static async Task<string> MyDownloadPageAsync(string url)
        {
            using (var wc = new WebClient())
            {
                await Task.Delay(3000);

                var task = wc.DownloadStringTaskAsync(url);
                string content = await task;
                return content;
            }
        }
    }
}
