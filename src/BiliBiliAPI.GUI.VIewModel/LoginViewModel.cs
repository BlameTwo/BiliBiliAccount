using BilibiliAPI;
using BilibiliAPI.Account;
using BilibiliAPI.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Media.Imaging;

namespace BiliBiliAPI.GUI.VIewModel
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
            var result =await api.Check();
            switch (result.Check)
            {
                case Checkenum.OnTime:
                    Debug.WriteLine("超时！正在重新尝试");
                    break;
                case Checkenum.Post:
                    Debug.WriteLine("Post错误！！正在重新尝试");
                    break;
                case Checkenum.NULL:
                    Debug.WriteLine("未收录的code！正在重新尝试");
                    break;
                case Checkenum.YesOrNo:

                    Debug.WriteLine("请在手机上点击确定登录！");
                    break;
                case Checkenum.Yes:
                    Debug.WriteLine("登录成功！");
                    var Jo = JObject.Parse(result.Body);
                    BiliBiliArgs.TokenSESSDATA = WebFormat.UrlToClass(Jo["data"]!["url"]!.ToString());
                    BiliBiliArgs.Refresh_Token = Jo["data"]!["refresh_token"]!.ToString();
                    RefAccount();
                    time.Stop();
                    break;
                case Checkenum.No:
                    Debug.WriteLine("未检测到扫码！");
                    break;
            }
        }

        private async  void RefAccount()
        {
            AccountInfo info = new AccountInfo();
            string value = await  info.GetAccount();
        }

        private BitmapImage QRImage;

        public BitmapImage _QRImage
        {
            get { return QRImage; }
            set => SetProperty(ref QRImage, value);
        }

        public RelayCommand RefQR { get; private set; }
        public RelayCommand Loaded { get; private set; }
    }
}
