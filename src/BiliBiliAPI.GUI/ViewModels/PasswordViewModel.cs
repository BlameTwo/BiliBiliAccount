using BilibiliAPI;
using BilibiliAPI.Account;
using BiliBiliAPI.GUI.Controls;
using BiliBiliAPI.GUI.Event;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Settings;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BiliBiliAPI.GUI.VIewModels
{
    public class PasswordViewModel:ObservableRecipient
    {
        private WebServer browser;
        private AccountLoginResult _LoginResult;

        public PasswordViewModel()
        {
            IsActive = true;

            WinLoaded = new RelayCommand<Window>((win) =>
            {
                this._window = win!;
            });

            PasswordLogin = new RelayCommand(async () =>
            {
                AccountPasswordLogin login = new AccountPasswordLogin();
                var result = await login.LoginV3(_User, _Password);
                switch (result.Data.message)
                {
                    case "本次登录环境存在风险, 需使用手机号进行验证或绑定":
                        //使用返回的URL进行验证
                        browser = new WebServer();
                        browser.NavigationCompleted += Browser_NavigationCompleted;
                        browser.NavigationStarting += Browser_NavigationStarting;
                        browser.Source = new Uri(result.Data.GoUrl);
                        _window!.Content = browser;
                        break;
                    default:
                        break;
                }
            });
        }
        Window _window { get; set; }
        private void Browser_NavigationStarting(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            var c = GetFormData(e.Uri);
            if(c == null) return;
            if (c.ContainsKey("access_key"))
            {
                browser.NavigationStarting -= Browser_NavigationStarting;
                AccountToken token = new AccountToken();
                string mid = "";
                string token2 = "";
                c.TryGetValue("mid", out mid!);
                c.TryGetValue("access_key", out token2!);
                token.Mid = mid; token.SECCDATA = token2;
                AccountSettings.Write(token);
                BiliBiliArgs.TokenSESSDATA = token;
                RefAccount(token);
                return;
            }
        }

        private async void RefAccount(AccountToken token)
        {
            AccountInfo info = new AccountInfo();
            BiliBiliArgs.TokenSESSDATA = token;
            _LoginResult = await info.GetAccount(token);
            MessageBox.Show("登录成功！点击确定跳转");
            WeakReferenceMessenger.Default.Send(new MainEvent() { Controlenum = ControlEnum.User });
            _window.Content = null;
            browser = null;
            
            _window.Close();
            GC.Collect();
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


        private async void Browser_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (browser.Source.Host == "www.bilibili.com")
            {
                browser.CoreWebView2.Navigate("https://passport.bilibili.com/login/app/third?appkey=27eb53fc9058f8c3&api=http%3A%2F%2Flink.acg.tv%2Fforum.php&sign=67ec798004373253d60114caaad89a8c");
            }
            if (browser.Source.ToString() == "https://passport.bilibili.com/login/app/third?appkey=27eb53fc9058f8c3&api=http%3A%2F%2Flink.acg.tv%2Fforum.php&sign=67ec798004373253d60114caaad89a8c")
            {
                try
                {
                    object obj = await browser.CoreWebView2.ExecuteScriptAsync("document.body.innerText");
                    string result = "";
                    string result2 = obj.ToString()!.Replace(@"\", "").Substring(1);
                    string result3 = result2.Substring(0, result2.Length - 1);
                    string a = JObject.Parse(result3)["data"]!["confirm_uri"]!.ToString();
                    browser.CoreWebView2.Navigate(a);
                    var jj = await browser.CoreWebView2.CookieManager.GetCookiesAsync(browser.CoreWebView2.Source.ToString());
                }
                catch (Exception)
                {

                }
            }
        }




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


        public RelayCommand PasswordLogin { get; set; }
        //public RelayCommand<WebServer> LoadMyWeb { get; set; }

        public RelayCommand<Window> WinLoaded { get; set; }
    }
}
