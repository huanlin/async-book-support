using System;
using System.Net;

namespace Ex03_Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = MyDownloadPage("http://huan-lin.blogspot.com");

            DoOtherWork();

            Console.WriteLine("網頁內容總共為 {0} 個字元。", content.Length);
            Console.ReadKey();
        }

        static string MyDownloadPage(string url)
        {
            var webClient = new WebClient();  // 須引用 System.Net 命名空間。
            string content = webClient.DownloadString(url);
            return content;
        }

        static void DoOtherWork()
        {
            Console.WriteLine("執行其他工作...");
        }
    }
}
