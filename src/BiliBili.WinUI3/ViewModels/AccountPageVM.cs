
using BiliBili.WinUI3;
using BiliBili.WinUI3.Dialog;
using BiliBili.WinUI3.WindowHelpers;
using BilibiliAPI;
using BilibiliAPI.Account;
using BilibiliAPI.User;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.Settings;
using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Foundation.Metadata;

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
                _LoginResult = (await logins.Login(token)).Data;
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
                    LoginDialog login = new LoginDialog();
                    ContentDialog CD = new ContentDialog
                    {
                        Content = login 
                    };
                    if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8))
                    {
                        CD.XamlRoot = (App.MainWindow as Home).MyGrid.XamlRoot;
                    }
                    login.MyDialog = CD;
                    ContentDialogResult result = await CD.ShowAsync();
                    break;
                case "退出登录":
                    File.Delete(AccountSettings.FilePath);
                    _LoginResult = new AccountLoginResultData();
                    break;
            }
            MyLoaded(null, null);
        }


        public void NewWindow()
        {
            ScrollViewer view = new ScrollViewer() { Padding = new Thickness(10)};
            string str = File.ReadAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BiliBiliSettings\MD\LoginMD.md");
            MarkdownTextBlock textblock = new MarkdownTextBlock() { Text = str ,Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255,30,30,30 ))};
            view.Content = textblock;
            var newWindow = CreateWindows.GetWindow("登录源码", view);
            newWindow.Activate();
        }

        private MyTipsData MyTip;

        public MyTipsData _MyTip
        {
            get { return MyTip; }
            set => SetProperty(ref MyTip, value);
        }


        private AccountLoginResultData LoginResult;

        public AccountLoginResultData _LoginResult
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
