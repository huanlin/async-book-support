using System;
using System.Net;
using System.Threading.Tasks;

namespace Ex04_Async
{
    class Program
    {
        static void Main(string[] args)
        {

            var task = MyDownloadPageAsync("http://huan-lin.blogspot.com");

            string content = task.Result;

            Console.WriteLine("網頁內容總共為 {0} 個字元。", content.Length);
            Console.ReadKey();
        }

        static async Task<string> MyDownloadPageAsync(string url)
        {
            var webClient = new WebClient();

            var task = webClient.DownloadStringTaskAsync(url);

            string content = await task;

            return content;
        }
    }
}
