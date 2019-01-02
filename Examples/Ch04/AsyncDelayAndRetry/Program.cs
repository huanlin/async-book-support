using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncDelayAndRetry
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Task task = Task.Run(() => MyDownloadPageAsync("xyz"));

            while (task.IsCompleted == false)
            { } // 等待工作執行完畢

            if (task.IsFaulted)        // 若非同步工作執行失敗
            {
                throw task.Exception;  // 便拋出異常
            }
            Console.ReadLine();
        }

        private static async Task<string> MyDownloadPageAsync(string url)
        {
            const int MaxRetryCount = 3;  // 最多重試 3 次

            using (var client = new HttpClient()) // 先前範例都省略 using，這裡補上。
            {
                for (int i = 0; i < MaxRetryCount; i++)
                {
                    try
                    {
                        return await client.GetStringAsync(url);
                    }
                    catch (Exception ex)
                    {
                        // 忽略錯誤。
                        Console.WriteLine("第 {0} 次失敗: {1}", i + 1, ex.Message);
                    }
                    await Task.Delay(TimeSpan.FromSeconds(i + 1));
                }

                // 最後一次失敗就讓它拋出異常。
                return await client.GetStringAsync(url);
            }
        }
    }
}