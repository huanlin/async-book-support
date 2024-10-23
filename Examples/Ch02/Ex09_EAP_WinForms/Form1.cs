using System.Net;

namespace Ex09_EAP_WinForms2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Log(string s, params object[] args)
        {
            listBox1.Items.Add(string.Format(s, args));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log("UI ����� ID: {0}", Thread.CurrentThread.ManagedThreadId);
            using (var client = new WebClient())
            {
                client.DownloadStringCompleted += WebDownloadStringCompleted;
                client.DownloadStringAsync(new Uri("http://huan-lin.blogspot.com"));
            }
        }
        private void WebDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            // Note: �i�H�b�o�̼��g��s UI ���{���X�A�ӵL���B�~�g�{�������� UI ������C
            Log("�D�P�B�u�@�����ƥ�Ĳ�o������ ID: {0}", Thread.CurrentThread.ManagedThreadId);
            label1.Text = string.Format("�U�����������e���׬� {0} �r���C", e.Result.Length);
        }
    }
}
