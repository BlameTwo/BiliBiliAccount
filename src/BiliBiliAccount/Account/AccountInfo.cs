
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Account
{
    public class AccountInfo
    {
        private HttpTools HttpClient = new HttpTools();
        public  async  Task<ResultCode<AccountLoginResultData>> GetAccount(AccountToken token)
        {
            return await Task.Run(async () =>
            {
                //这里为web网页请求方式
                string results = await HttpClient.GetResults(Apis.ACCOUNT_INFO_API, HttpTools.ResponseEnum.Web);
                return BiliBiliAPI.Models.JsonConvert.ReadObject<AccountLoginResultData>(results);
            });
        }


        
    }
}
