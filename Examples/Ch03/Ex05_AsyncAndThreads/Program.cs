using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Ex05_AsyncAndThreads
{
    class Program
    {
        static void ShowThreadInfo(int num, string msg)
        {
            Console.WriteLine("({0}) T{1}: {2}", num, Thread.CurrentThread.ManagedThreadId, msg);
        }

        static void Main(string[] args)
        {
            ShowThreadInfo(1, "正要起始非同步工作 MyDownloadPageAsync()。");

            var task = MyDownloadPageAsync("http://huan-lin.blogspot.com");

            ShowThreadInfo(4, "非同步工作 MyDownloadPageAsync() 的控制流已返回，但尚未取得工作結果。");

            string content = task.Result;

            ShowThreadInfo(6, "已經取得 MyDownloadPageAsync() 的結果。");

            Console.WriteLine("網頁內容總共為 {0} 個字元。", content.Length);
            Console.ReadKey();
        }

        static async Task<string> MyDownloadPageAsync(string url)
        {
            ShowThreadInfo(2, "正要呼叫 WebClient.DownloadStringTaskAsync()。");            

            var webClient = new WebClient();
            var task = webClient.DownloadStringTaskAsync(url);

            ShowThreadInfo(3, "已經起始非同步工作 WebClient.DownloadStringTaskAsync()。");

            string content = await task;

            ShowThreadInfo(5, "已經取得 WebClient.DownloadStringTaskAsync() 的結果。");

            return content;
        }
    }
}
