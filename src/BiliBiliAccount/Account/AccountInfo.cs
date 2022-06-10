using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.Account
{
    public class AccountInfo
    {
        public async  Task<string> GetAccount()
        {
            if(BiliBiliArgs.TokenSESSDATA.SECCDATA== null)
            {
                return "";
            }
            string a = await  MyWebClient.Get($"http://account.bilibili.com/site/getCoin?SESSDATA={BiliBiliArgs.TokenSESSDATA.SECCDATA}", MyWebClient.DataType.JSON,BiliBiliArgs.Cookie);

            return a;
        }
    }
}
