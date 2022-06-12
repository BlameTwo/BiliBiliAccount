using BilibiliAPI;
using BilibiliAPI.Account;
using BilibiliAPI.Models;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Settings;
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
            MessageBox.Show($"登录名为:{_LoginResult.Data.Name}，等级为:{_LoginResult.Data.Level}");
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
    }
}
