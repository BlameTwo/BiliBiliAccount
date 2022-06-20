using BilibiliAPI;
using BilibiliAPI.Account;
using BiliBiliAPI.GUI.Converter;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Settings;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBili.WinUI3.ViewModels
{
    public class LoginDialogVM:ObservableRecipient
    {
        /// <summary>
        /// 定时器一秒
        /// </summary>
        DispatcherTimer timer = new DispatcherTimer() { Interval = new TimeSpan(0,0,1)};
        public LoginDialogVM()
        {
            IsActive = true;
        }

        public ContentDialog DIalog { get; set; }

        private bool PrimaryEnable;

        public bool _PrimaryEnable
        {
            get { return PrimaryEnable; }
            set 
            {
                //为True说明为账号登陆状态
                if (value == false)
                {
                    timer.Start();
                    if(webview2 != null)
                        webview2.Visibility = Visibility.Collapsed;
                }
                else
                {
                    //这里如果未登录就跳转到前一个页面在跳回来会触发，导致无法输入用户密码。
                    timer.Stop();
                }
                SetProperty(ref PrimaryEnable, value);
            }
        }


        AccountQRLogin api = new AccountQRLogin();

        private AccountLoginArg QR;

        public AccountLoginArg _QR
        {
            get { return QR; }
            set => SetProperty(ref QR, value);
        }

        public void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((e.AddedItems[0] as PivotItem).Header.ToString())
            {
                case "扫码登录":
                    _PrimaryEnable = false;
                    break;
                case "账号密码":
                    _PrimaryEnable = true;
                    break;
            }
        }

        private ImageSource QRImage;

        public ImageSource  _QRImage
        {
            get { return QRImage; }
            set { QRImage = value; OnPropertyChanged(); }
        }

        public   void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Tick += Timer_Tick;
            RefQr();
        }

        async  void RefQr()
        {
            _QR = await api.GetQR();
            _QRImage = await QRConvert.Convert(_QR.Data.PicUrl);
            timer.Start();
        }


        private string User;

        public string _User
        {
            get { return User; }
            set=>SetProperty(ref User, value);
        }


        private string Password;

        public string _Password
        {
            get { return Password; }
            set => SetProperty(ref Password, value);
        }


        public void GetQR()
        {
            RefQr();
        }

        private async  void Timer_Tick(object sender, object e)
        {
            var result = await api.PollQRAuthInfo();
            switch (result.Check)
            {
                case Checkenum.OnTime:
                    Debug.WriteLine("二维码已经失效");
                    break;
                case Checkenum.NULL:
                    Debug.WriteLine("未收录的code状态");
                    break;
                case Checkenum.Yes:
                    Debug.WriteLine($"登录成功！返回值未:\n{result.Body}");
                    BiliBiliArgs.TokenSESSDATA =  WebFormat.GoToken(result.Body);
                    AccountSettings.Write(BiliBiliArgs.TokenSESSDATA);
                    timer.Stop();
                    timer.Tick -= Timer_Tick;
                    this.DIalog.Hide();
                    break;
                case Checkenum.No:
                    Debug.WriteLine("二维码未确认");
                    break;
            }
        }

       
        public void Close()
        {
            DIalog.Hide();
        }

        public async  void LoginClick()
        {
            if (_PrimaryEnable)
            {
                AccountPasswordLogin passlogin = new AccountPasswordLogin();
                var result =  await passlogin.LoginV3(_User, _Password);
                if(result.Data.message == "本次登录环境存在风险, 需使用手机号进行验证或绑定")
                {
                    webview2.Source = new Uri(result.Data.GoUrl);
                    webview2.Visibility = Visibility.Visible;
                }
            }
        }
        public void WebView2_NavigationStarting(WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs args)
        {
            var c = GetFormData(args.Uri);
            if (c == null) return;
            if (c.ContainsKey("access_key"))
            {
                AccountToken token = new AccountToken();
                string mid = "";
                string token2 = "";
                c.TryGetValue("mid", out mid!);
                c.TryGetValue("access_key", out token2!);
                token.Mid = mid; token.SECCDATA = token2;
                BiliBiliArgs.TokenSESSDATA = token;
                AccountSettings.Write(BiliBiliArgs.TokenSESSDATA);
                DIalog.Hide();
            }
        }

        /// <summary>
        /// 将获取的formData存入字典数组
        /// </summary>
        public static Dictionary<String, String> GetFormData(string formData)
        {
            try
            {
                string str = formData.Substring(formData.IndexOf('?') + 1);
                //将参数存入字符数组
                String[] dataArry = str.Split('&');

                //定义字典,将参数按照键值对存入字典中
                Dictionary<String, String> dataDic = new Dictionary<string, string>();
                //遍历字符数组
                for (int i = 0; i <= dataArry.Length - 1; i++)
                {
                    string dataParm = dataArry[i];
                    int dIndex = dataParm.IndexOf("=");
                    string key = dataParm.Substring(0, dIndex);
                    string value = dataParm.Substring(dIndex + 1, dataParm.Length - dIndex - 1);
                    string deValue = System.Web.HttpUtility.UrlDecode(value, System.Text.Encoding.GetEncoding("utf-8"));
                    //将参数以键值对存入字典
                    dataDic.Add(key, deValue);
                }
                return dataDic;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null!;
            }
        }

        WebView2 webview2 { get; set; }
        public void WebViewLoad(object sender, RoutedEventArgs e)
        {
            webview2 = sender as WebView2;
            webview2.NavigationCompleted += WebView2_NavigationCompleted;
            webview2.NavigationStarting += WebView2_NavigationStarting;
        }

        public async void WebView2_NavigationCompleted(WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs args)
        {
            if (sender.Source.Host == "www.bilibili.com")
            {
                webview2.Visibility = Visibility.Collapsed;
                sender.CoreWebView2.Navigate("https://passport.bilibili.com/login/app/third?appkey=27eb53fc9058f8c3&api=http%3A%2F%2Flink.acg.tv%2Fforum.php&sign=67ec798004373253d60114caaad89a8c");
            }
            if (sender.Source.ToString() == "https://passport.bilibili.com/login/app/third?appkey=27eb53fc9058f8c3&api=http%3A%2F%2Flink.acg.tv%2Fforum.php&sign=67ec798004373253d60114caaad89a8c")
            {
                try
                {
                    object obj = await sender.CoreWebView2.ExecuteScriptAsync("document.body.innerText");
                    string result = "";
                    string result2 = obj.ToString()!.Replace(@"\", "").Substring(1);
                    string result3 = result2.Substring(0, result2.Length - 1);
                    string a = JObject.Parse(result3)["data"]!["confirm_uri"]!.ToString();
                    sender.CoreWebView2.Navigate(a);
                    var jj = await sender.CoreWebView2.CookieManager.GetCookiesAsync(sender.CoreWebView2.Source.ToString());
                }
                catch (Exception)
                {

                }
            }
        }

        public void LoginClose(ContentDialog sender, Microsoft.UI.Xaml.Controls.ContentDialogButtonClickEventArgs args)
        {
            args.Cancel = false;
        }
    }
}
