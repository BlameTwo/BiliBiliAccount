using BiliBiliAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.Account
{
    /// <summary>
    /// Logins是一个调用集合，指登陆过后的第一次登录
    /// </summary>
    public static class Logins
    {
        public static Task<AccountLoginResult> Login(AccountToken token)
        {
            return Task.Run(() =>
            {
                AccountInfo info = new AccountInfo();
                return info.GetAccount(token);
            });
        }
    }
}
