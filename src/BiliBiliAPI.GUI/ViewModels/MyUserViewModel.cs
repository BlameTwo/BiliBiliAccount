using BilibiliAPI;
using BilibiliAPI.Account;
using BiliBiliAPI.GUI.Event;
using BiliBiliAPI.Models;
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
               
            });

            UnLogin = new RelayCommand(() =>
            {
                File.Delete(Models.Settings.AccountSettings.FilePath);
                WeakReferenceMessenger.Default.Send(new MainEvent() { Controlenum = ControlEnum.Login });
            });
        }


        private AccountLoginResult LoginResult;

        public AccountLoginResult _LoginResult
        {
            get { return LoginResult; }
            set => SetProperty(ref LoginResult, value);
        }



        public RelayCommand UnLogin { get; private set; }
        public RelayCommand Loaded { get; private set; }
    }
}
