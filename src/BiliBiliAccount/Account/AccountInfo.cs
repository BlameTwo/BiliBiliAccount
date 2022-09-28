using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.Account
{
    public class AccountInfo
    {
        private MyHttpClient HttpClient = new MyHttpClient();
        public  async  Task<ResultCode<AccountLoginResultData>> GetAccount(AccountToken token)
        {
            return await Task.Run(async () =>
            {
                string url2 = "https://api.bilibili.com/x/space/myinfo";
                string results = await HttpClient.GetResults(url2);
                return JsonConvert.ReadObject<AccountLoginResultData>(results);
            });
        }


        
    }
}
