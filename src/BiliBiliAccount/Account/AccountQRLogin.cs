using BilibiliAPI.ApiTools;
using BiliBiliAPI.Models.Account;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace BilibiliAPI.Account
{
    public class AccountQRLogin
    {
        private MyHttpClient HttpClient  = new MyHttpClient();
        Timer time = new Timer();
        /// <summary>
        /// 当前实例的密钥校验码
        /// </summary>
        private string QRKey { get; set; } = "";
        public async Task<AccountLoginArg> GetQR()
        {
            string url = "https://passport.bilibili.com/x/passport-tv-login/qrcode/auth_code";
            string data = $"local_id={Current.LocalID}";
            string result = await HttpClient.PostResults(url, data, ApiProvider.AndroidTVKey);
            var model =  JsonConvert.ReadObject<AccountLoginArg>(result);
            QRKey = model.Data.QRKey;
            return model;
        }

        public async Task<LoginTrueString> PollQRAuthInfo()
        {
            try
            {
                string url = "https://passport.bilibili.com/x/passport-tv-login/qrcode/poll";
                string data = $"auth_code={QRKey}&guid={Guid.NewGuid()}&local_id={Current.LocalID}";
                string result = await HttpClient.PostResults(url, data, ApiProvider.AndroidTVKey);
                var jo =  JObject.Parse(result);
                switch (jo["code"].ToString())
                {
                    case "86039":
                        return new LoginTrueString() { Check = Checkenum.No };
                    case "86038":
                        return new LoginTrueString() { Check = Checkenum.OnTime };
                    case "0":
                        return new LoginTrueString() { Check = Checkenum.Yes, Body = jo["data"]!.ToString() };
                    default:
                        return new LoginTrueString() { Check = Checkenum.NULL };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("错误！");
                return null!;
            }
        }


        




    }


}
