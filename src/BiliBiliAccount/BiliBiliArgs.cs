using BiliBiliAPI.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI
{
    public static class BiliBiliArgs
    {
        /// <summary>
        /// 哔哩哔哩账号凭证存储点
        /// </summary>
        public static AccountToken TokenSESSDATA { get; set; } = new AccountToken();
        public static string Cookie { get; set; } = "";

        public static string Refresh_Token { get; set; } = "";
    }
}
