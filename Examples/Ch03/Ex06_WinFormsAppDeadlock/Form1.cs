using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex06_WinFormsAppDeadlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = GetStringAsync().Result; // 程式會當掉!
        }

        static HttpClient _httpClient = new HttpClient();

        private async Task<string> GetStringAsync()
        {
            return await _httpClient.GetStringAsync("https://www.google.com");
        }
    }
}
