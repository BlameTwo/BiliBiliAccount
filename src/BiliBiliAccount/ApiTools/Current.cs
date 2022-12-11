using BiliBiliAPI.Tools;
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
                HttpClient = new HttpTools();
                LocalID = Guid.NewGuid().ToString();
                Build = "5520400";
            }
        }
        public static string LocalID { get; private set; }
        private static object HasInit { get; set; } = false;
        public static Random Radom { get; private set; }
        public static HttpTools HttpClient { get; private set; }

        public static string Build { get; private set; }
    }
}
