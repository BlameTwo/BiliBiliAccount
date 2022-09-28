using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.User
{
    /// <summary>
    /// 用户面板信息
    /// </summary>
    public class Users
    {
        ///
        private MyHttpClient HttpClient = new MyHttpClient();

        /// <summary>
        /// 获得用户的基本信息
        /// </summary>
        /// <param name="mid">用户的mid</param>
        /// <returns></returns>
        public async Task<ResultCode<AccountLoginResultData>> GetUser(string mid)
        {
            string url = $"http://api.bilibili.com/x/space/acc/info?mid={mid}";
            return JsonConvert.ReadObject<AccountLoginResultData>(await HttpClient.GetResults(url));
        }
    }
}
