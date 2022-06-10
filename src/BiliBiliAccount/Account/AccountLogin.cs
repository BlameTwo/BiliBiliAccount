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
        /// <summary>
        /// 当前实例的密钥校验码
        /// </summary>
        private string QRKey { get; set; } = "";
        public async Task<AccountLoginArg> GetQR()
        {
            string jo =  await MyWebClient.Get("https://passport.bilibili.com/qrcode/getLoginUrl", MyWebClient.DataType.JSON);
            var model =  JsonConvert.ReadObject<AccountLoginArg>(jo);
            QRKey = model.Data.QRKey;
            return model;
        }


        public async Task<LoginTrueString> Check()
        {
            Dictionary<string, string> checkper = new Dictionary<string, string>();
            LoginTrueString resule = new LoginTrueString();
            checkper.Add("oauthKey", QRKey);
            var result = await MyWebClient.Post("https://passport.bilibili.com/qrcode/getLoginInfo", checkper);
            var oj = JObject.Parse(result.Body);
            if (oj == null)
            {
                return new LoginTrueString() { Check = Checkenum.NULL };
            }
            if (oj["data"]!.ToString()! == "-2")
            {
                return new LoginTrueString() { Check = Checkenum.OnTime };
            }
            if (oj["data"]!.ToString() == "-4")
            {
                return new LoginTrueString() { Check = Checkenum.No };
            }
            if (oj["data"]!.ToString() == "-5")
            {
                return new LoginTrueString() { Check = Checkenum.YesOrNo };
            }
            if (oj.ContainsKey("code"))
            {
                if (oj["code"]!.ToString() == "0")
                {
                    BiliBiliArgs.Cookie = result.Cookies;
                    return new LoginTrueString() { Body = oj.ToString(), Check =  Checkenum.Yes};
                }
            }
            return new LoginTrueString() { Check = Checkenum.NULL };
        }




    }


}
