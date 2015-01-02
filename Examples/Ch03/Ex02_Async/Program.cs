using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Ex02_Async
{
    class Program
    {
        static void ShowThreadInfo(int num, string msg)
        {
            Console.WriteLine("({0}) T{1}: {2}", num, Thread.CurrentThread.ManagedThreadId, msg);
        }

        static void Main(string[] args)
        {
            ShowThreadInfo(1, "在 Main() 中， 正要起始非同步工作 DownloadPageAsync()。");

            var task = DownloadPageAsync("http://huan-lin.blogspot.com");

            ShowThreadInfo(3, "在 Main() 中， 已經起始非同步工作 DownloadPageAsync()，但尚未取得工作結果。");

            string content = task.Result;

            ShowThreadInfo(5, "在 Main() 中，已經完成非同步工作 DownloadPageAsync() 並取得結果。");

            Console.WriteLine("網頁內容總共為 {0} 個字元。", content.Length);
            Console.ReadKey();
        }

        static async Task<string> DownloadPageAsync(string url)
        {
            ShowThreadInfo(2, "在 DownloadPageAsync() 中，正要起始非同步工作 DownloadStringTaskAsync()。");

            var webClient = new WebClient();  // 須引用 System.Net 命名空間。
            string content = await webClient.DownloadStringTaskAsync(url);

            ShowThreadInfo(4, "在 DownloadPageAsync() 中， 已經完成非同步工作 DownloadStringTaskAsync()。");

            return content;
        }
    }
}
