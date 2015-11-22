using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ex06_AspNetAppDeadlock.Controllers
{
    public class DemoDeadlockController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage DownloadPage()
        {
            var task = MyDownloadPageAsync("http://huan-lin.blogspot.com");
            var content = task.Result;
            return Request.CreateResponse(string.Format("網頁內容總共為 {0} 個字元。", content.Length));
        }

        private async Task<string> MyDownloadPageAsync(string url)
        {
            var client = new HttpClient();
            string content = await client.GetStringAsync(url); // 這裡會 deadlock!
            return System.Threading.Thread.CurrentThread.ManagedThreadId.ToString(); //content;
        }

        // 解法一：使用 Task.ConfigureAwait(false)。
        // 解法二：從頭到尾都使用 async 方法。
    }
}
