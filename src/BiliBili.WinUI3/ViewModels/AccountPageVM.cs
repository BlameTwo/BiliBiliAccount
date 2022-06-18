using BiliBili.WinUI3;
using BiliBili.WinUI3.Dialog;
using BilibiliAPI;
using BilibiliAPI.Account;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Settings;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BiliBiliAPI.GUI.VIewModels
{
    public class AccountPageVM : ObservableObject
    {
        public AccountToken token = AccountSettings.Read();
        public AccountPageVM()
        {
            //File.Delete(Models.Settings.AccountSettings.FilePath);

        }

        Logins logins = new Logins();
        public async void MyLoaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(AccountSettings.FilePath))
            {
                token = AccountSettings.Read();
                BiliBiliArgs.TokenSESSDATA = token;
                _LoginResult = await logins.Login(token);
                if (_LoginResult == null)
                {
                    _ButtonText = "登录";
                }
                else
                {
                    _ButtonText = "退出登录";
                }
            }
            else
            {
                _ButtonText = "登录";
            }
            

        }


        public async  void MyButton_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Content.ToString())
            {
                case "登录":
                    LoginDialog Logindialog = new LoginDialog();
                    Logindialog.XamlRoot = (App.MainWindow as Home).MyFrame.XamlRoot;
                    await Logindialog.ShowAsync();
                    break;
                case "退出登录":
                    File.Delete(AccountSettings.FilePath);
                    _LoginResult.Data = new AccountLoginResultData();
                    break;
            }
            MyLoaded(null, null);
        }


        private MyTips MyTip;

        public MyTips _MyTip
        {
            get { return MyTip; }
            set => SetProperty(ref MyTip, value);
        }


        private AccountLoginResult LoginResult;

        public AccountLoginResult _LoginResult
        {
            get { return LoginResult; }
            set => SetProperty(ref LoginResult, value);
        }


        private string ButtonText;

        public string _ButtonText
        {
            get { return ButtonText; }
            set => SetProperty(ref ButtonText, value);
        }



    }
}
