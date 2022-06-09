using BilibiliAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace BilibiliAPI.Account
{
    public class AccountLogin
    {
        Timer time = new Timer();

        public async Task<AccountLoginArg> GetQR()
        {
            string jo =  await MyWebClient.Get("http://passport.bilibili.com/qrcode/getLoginUrl", MyWebClient.DataType.JSON);
            return JsonConvert.ReadObject<AccountLoginArg>(jo);
        }

    }
}
