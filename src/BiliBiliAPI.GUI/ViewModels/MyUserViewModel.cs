using BilibiliAPI;
using BilibiliAPI.Account;
using BiliBiliAPI.GUI.Event;
using BiliBiliAPI.GUI.Windows;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.Settings;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BiliBiliAPI.GUI.VIewModels
{
    public class MyUserViewModel:ObservableObject
    {
        public AccountToken token = AccountSettings.Read();
        public MyUserViewModel()
        {
            Loaded = new RelayCommand(async () =>
            {
                Logins logins = new Logins();

                BiliBiliArgs.TokenSESSDATA = token;
                _LoginResult = await logins.Login(token);
                if(_LoginResult == null)
                {
                    MessageBox.Show("信息错误，或者计算机已经断网，\n即将退出…………");
                    System.Environment.Exit(0);
                }
            });

            UnLogin = new RelayCommand(() =>
            {
                File.Delete(Models.Settings.AccountSettings.FilePath);
                WeakReferenceMessenger.Default.Send(new MainEvent() { Controlenum = ControlEnum.Login });
            });

            OpenSearch = new RelayCommand(() =>
            {
                SearchWindow search = new SearchWindow();
                search.Show();
            });
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



        public RelayCommand UnLogin { get; private set; }

        public RelayCommand OpenSearch { get; private set; }
        public RelayCommand Loaded { get; private set; }
    }
}
