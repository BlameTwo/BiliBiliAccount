
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Account
{
    public class AccountInfo
    {
        private MyHttpClient HttpClient = new MyHttpClient();
        public  async  Task<ResultCode<AccountLoginResultData>> GetAccount(AccountToken token)
        {
            return await Task.Run(async () =>
            {
                string results = await HttpClient.GetResults(Apis.ACCOUNT_INFO_API);
                return JsonConvert.ReadObject<AccountLoginResultData>(results);
            });
        }


        
    }
}
