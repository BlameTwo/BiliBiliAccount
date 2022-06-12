using BilibiliAPI;
using BilibiliAPI.Account;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Settings;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
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
        }


        private AccountLoginResult LoginResult;

        public AccountLoginResult _LoginResult
        {
            get { return LoginResult; }
            set => SetProperty(ref LoginResult, value);
        }




        public RelayCommand Loaded { get; private set; }
    }
}
