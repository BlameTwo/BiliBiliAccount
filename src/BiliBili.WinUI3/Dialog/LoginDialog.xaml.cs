using BiliBili.WinUI3.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BiliBili.WinUI3.Dialog
{
    public sealed partial class LoginDialog : UserControl
    {
        public LoginDialog()
        {
            this.InitializeComponent();
            this.DataContext = vm;
        }



        public ContentDialog  MyDialog
        {
            get { return (ContentDialog )GetValue(MyDialogProperty); }
            set { SetValue(MyDialogProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDialog.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDialogProperty =
            DependencyProperty.Register("MyDialog", typeof(ContentDialog ), typeof(LoginDialog), new PropertyMetadata(null,new PropertyChangedCallback((s, e) =>
            {
                var mycontrol = s as LoginDialog;
                mycontrol.vm.DIalog = e.NewValue as ContentDialog;
            })));



        LoginDialogVM vm = new LoginDialogVM();

        Storyboard _storyboard = null;
        private void QRImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            _storyboard = new Storyboard();
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = TimeSpan.FromSeconds(1);
            da.From = 0;
            da.To = 1;
            Storyboard.SetTarget(da, QRImage);
            Storyboard.SetTargetProperty(da, "Image.Opacity");
            _storyboard.Children.Add(da);
            _storyboard.Begin();
        }

    }
}
