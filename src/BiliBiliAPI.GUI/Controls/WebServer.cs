using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.GUI.Controls
{
    public class WebServer:WebView2,IDisposable
    {
        public void Dispost()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                return;
            }
            //告诉自己已经被释放
            disposing = true;
        }
        ~WebServer()
        {
            Dispose(false);
        }
    }
}
