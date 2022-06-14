using BilibiliAPI;
using BilibiliAPI.Account;
using BiliBiliAPI.GUI.Event;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Settings;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Web.WebView2.Wpf;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace BiliBiliAPI.GUI.VIewModels
{
    public class LoginViewModel:ObservableObject
    {
        System.Windows.Threading.DispatcherTimer time = new System.Windows.Threading.DispatcherTimer();
        public LoginViewModel()
        {
            Loaded = new RelayCommand(() =>
            {
                refQR();
            });
            RefQR = new RelayCommand(() =>
            {
                refQR();
            });

            PasswordLogin = new RelayCommand(async () =>
            {
                AccountPasswordLogin login = new AccountPasswordLogin();
                var result = await login.LoginV3(_User, _Password);
                switch (result.Data.message)
                {
                    case "本次登录环境存在风险, 需使用手机号进行验证或绑定":
                        browser!.Visibility = Visibility.Visible;
                        browser!.Source = new Uri(result.Data.GoUrl);
                        break;
                    default:
                        break;
                }
            });
            LoadMyWeb = new RelayCommand<WebView2>((arg)=>
            {
                browser = arg!;
                browser.NavigationCompleted += Browser_NavigationCompleted;
            });


            TabSelected = new RelayCommand<TabItem>((arg) =>
            {
                switch (arg!.Header.ToString())
                {
                    case "账号密码登录":
                        time.Stop();
                        break;
                    case "扫码登录":
                        refQR();
                        break;
                }
            });
        }

        private async void Browser_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if(browser.Source.Host == "www.bilibili.com")
            {
                var b = await browser.CoreWebView2.CookieManager.GetCookiesAsync(browser.Source.AbsoluteUri);
                AccountToken token = new AccountToken();
                foreach (var item in b)
                {
                    if(item.Name == "SESSDATA")
                    {
                        token.SECCDATA = item.Value;
                    }
                }
                Logins logins = new Logins();
                BiliBiliArgs.TokenSESSDATA = token;
                var c = await logins.Test("https://passport.bilibili.com/login/app/third?appkey=27eb53fc9058f8c3&api=http%3A%2F%2Flink.acg.tv%2Fforum.php&sign=67ec798004373253d60114caaad89a8c");
            }
            
            
        }


        

        AccountLogin api = new AccountLogin();

        private AccountLoginArg QR;

        public AccountLoginArg _QR
        {
            get { return QR; }
            set => SetProperty(ref QR, value);
        }

        async void refQR()
        {
            _QR = await api.GetQR();
            time.Interval = new TimeSpan(0,0,1);
            time.Tick += Time_Tick;
            time.Start();
        }

        private async  void Time_Tick(object? sender, EventArgs e)
        {
            var result = await api.PollQRAuthInfo();
            switch (result.Check)
            {
                case Checkenum.OnTime:
                    Debug.WriteLine("二维码已经失效");
                    break;
                //case Checkenum.Post:
                //    break;
                case Checkenum.NULL:
                    Debug.WriteLine("未收录的code状态");
                    break;
                case Checkenum.Yes:
                    Debug.WriteLine($"登录成功！携带的返回值为:\n{result.Body}");
                    var result2  =  WebFormat.UrlToClass(result.Body);
                    AccountSettings.Write(result2);
                    BiliBiliArgs.TokenSESSDATA = result2;
                    RefAccount(result2);
                    time.Stop();
                    break;
                case Checkenum.No:
                    Debug.WriteLine($"二维码尚未确认");
                    break;
            }
        }

        private async void RefAccount(AccountToken token)
        {
            AccountInfo info = new AccountInfo();
            _LoginResult = await info.GetAccount(token);
            MessageBox.Show("登录成功！点击确定跳转");
            WeakReferenceMessenger.Default.Send(new MainEvent() { Controlenum = ControlEnum.User});
        }


        private AccountLoginResult LoginResult;

        public AccountLoginResult _LoginResult
        {
            get { return LoginResult; }
            set => SetProperty(ref LoginResult, value);
        }


        private BitmapImage QRImage;

        public BitmapImage _QRImage
        {
            get { return QRImage; }
            set => SetProperty(ref QRImage, value);
        }

        public RelayCommand RefQR { get; private set; }
        public RelayCommand Loaded { get; private set; }

        private string User;

        public string _User
        {
            get { return User; }
            set => SetProperty(ref User, value);
        }


        private string Password;

        public string _Password
        {
            get { return Password; }
            set => SetProperty(ref Password, value);
        }
        public WebView2 browser { get; set; }
        public RelayCommand<WebView2> LoadMyWeb { get; set; }





        public RelayCommand PasswordLogin { get; set; }

        public RelayCommand<TabItem> TabSelected { get; set; }
    }
}
