using BilibiliAPI;
using BilibiliAPI.Account;
using BiliBiliAPI.GUI.Controls;
using BiliBiliAPI.GUI.Event;
using BiliBiliAPI.GUI.Windows;
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
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
            GoPassword = new RelayCommand(() =>
            {
                PassowrdLogin passowrdLogin = new PassowrdLogin();
                passowrdLogin.ShowDialog();
            });
        }



       


        AccountQRLogin api = new AccountQRLogin();

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
                    var result2  =  WebFormat.GoToken(result.Body);
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
            BiliBiliArgs.TokenSESSDATA = token;
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


        private ImageSource QRImage;

        public ImageSource _QRImage
        {
            get { return QRImage; }
            set => SetProperty(ref QRImage, value);
        }

        public RelayCommand RefQR { get; private set; }
        public RelayCommand Loaded { get; private set; }

        public RelayCommand GoPassword { get; set; }
    }
}
