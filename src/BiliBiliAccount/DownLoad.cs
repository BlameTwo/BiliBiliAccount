using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static PInvoke.Kernel32;

namespace BiliBiliAPI
{
    public class DowlLoadArgs:EventArgs
    {
        public int Progress { get; set; }
        public object sender { get; set; }
    }

    public class DownLoad
    {
        public delegate void ChangedEventHandle(object sender, DowlLoadArgs args);


        /// <summary>
        /// 下载进度更改
        /// </summary>
        public event ChangedEventHandle ProgressChanged;

        private  HttpClient HttpClient;
        public WebClient wc = new WebClient();
        public DownLoad()
        {
            HttpClient = new HttpClient();
        }

        public void DownLoadAsync(string url)
        {
            wc.Headers.Add("Cookie", BiliBiliArgs.Cookie);
            wc.Headers.Add("User-Agent",
                        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.13; rv:56.0) Gecko/20100101 Firefox/56.0");
            wc.Headers.Add("Origin", "https://www.bilibili.com");
            wc.Headers.Add("Referer", "https://www.bilibili.com");
            wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            Uri uri = new Uri(url);
            wc.DownloadFileAsync(uri,"Test.mp4");
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
        }

        private void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("下载完毕");
        }
        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage);
        }
    }
}
