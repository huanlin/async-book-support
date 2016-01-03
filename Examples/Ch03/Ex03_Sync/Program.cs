using System;
using System.Net;

namespace Ex03_Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = MyDownloadPage("http://huan-lin.blogspot.com");

            Console.WriteLine("網頁內容總共為 {0} 個字元。", content.Length);
            Console.ReadKey();
        }

        static string MyDownloadPage(string url)
        {
            var client = new WebClient();  
            string content = client.DownloadString(url);
            return content;
        }
    }
}
