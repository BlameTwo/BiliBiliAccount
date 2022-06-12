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
    public class Logins
    {

        private MyHttpClient HttpClient = new MyHttpClient();
        public async  Task<AccountLoginResult> Login(AccountToken token)
        {
            return await Task.Run(async () =>
            {
                AccountInfo info = new AccountInfo();
                string str = await HttpClient.GetResults($"http://api.bilibili.com/x/web-interface/nav");
                return await info.GetAccount(token);
            });
        }
    }
}
