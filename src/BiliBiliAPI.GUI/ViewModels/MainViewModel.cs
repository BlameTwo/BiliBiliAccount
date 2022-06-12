
using BiliBiliAPI.GUI.Controls;
using BiliBiliAPI.GUI.Event;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using MainEvent = BiliBiliAPI.GUI.Event.MainEvent;

namespace BiliBiliAPI.GUI.VIewModels
{
    public class MainViewModel:ObservableRecipient, IRecipient<MainEvent>
    {
        public MainViewModel()
        {
           IsActive = true;

            Loaded = new RelayCommand(() =>
            {
                if(Models.Settings.AccountSettings.Read() == null)
                {
                    Receive(new MainEvent() { Controlenum = ControlEnum.Login });
                }
                else
                {

                    Receive(new MainEvent() { Controlenum = ControlEnum.User });
                }
            });
        }


        private object ControlObject;

        public object _ControlObject
        {
            get { return ControlObject; }
            set => SetProperty(ref ControlObject, value);
        }

        public RelayCommand Loaded { get; private set; }

        public void Receive(MainEvent message)
        {
            switch (message.Controlenum)
            {
                case ControlEnum.Login:
                    _ControlObject = new LoginControl();
                    break;
                case ControlEnum.User:
                    _ControlObject = new MyUserControl();
                    break;
            }
        }
    }


}
