using BilibiliAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI
{
    public static class BiliBiliArgs
    {
        public static AccountToken TokenSESSDATA { get; set; } = new AccountToken();
        public static string Cookie { get; set; } = "";

        public static string Refresh_Token { get; set; } = "";
    }
}
