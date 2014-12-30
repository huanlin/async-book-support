using System;
using System.Net;
using System.Threading.Tasks;

namespace DemoSyncToAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = DownloadPageAsync("http://huan-lin.blogspot.com");
            string content = task.Result;

            Console.WriteLine("網頁內容總共為 {0} 個字元。", content.Length);
            Console.ReadKey();
        }

        static async Task<string> DownloadPageAsync(string url)
        {
            var webClient = new WebClient();  // 須引用 System.Net 命名空間。
            string content = await webClient.DownloadStringTaskAsync(url);
            return content;
        }
    }
}
