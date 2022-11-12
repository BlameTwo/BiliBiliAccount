using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.ApiTools
{
    public static class Current
    {
        static Current()
        {
            if (HasInit is bool value && value == false)
            {
                HasInit = true;
                Radom = new Random();
                HttpClient = new MyHttpClient();
                LocalID = Guid.NewGuid().ToString();
            }
        }
        public static string LocalID { get; private set; }
        private static object HasInit { get; set; } = false;
        public static Random Radom { get; private set; }
        public static MyHttpClient HttpClient { get; private set; }
    }
}
