
using BiliBiliAPI.ApiTools;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Tools;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace BiliBiliAPI.Account
{
    public class AccountQRLogin
    {
        private HttpTools HttpClient  = new HttpTools();
        private MyHttpClient MyHttpClient = new();
        Timer time = new Timer();
        /// <summary>
        /// 当前实例的密钥校验码
        /// </summary>
        private string QRKey { get; set; } = "";
        public async Task<ResultCode<AccountLoginData>> GetQR()
        {
            string data = $"local_id={Current.LocalID}";
            //string result = await MyHttpClient.PostResults(Apis.LOGIN_QRKEY_GET, data);
            string result = await HttpClient.PostResults(Apis.LOGIN_QRKEY_GET, data, HttpTools.ResponseEnum.App,null,true);
            var model = JsonConvert.ReadObject<AccountLoginData>(result);
            QRKey = model.Data.QRKey;
            return model;
        }

        public async Task<LoginTrueString> PollQRAuthInfo()
        {
            try
            {
                string data = $"auth_code={QRKey}&guid={Guid.NewGuid()}&local_id={Current.LocalID}";
                string result = await HttpClient.PostResults(Apis.LOGIN_QRKEY_POLL, data, HttpTools.ResponseEnum.App,null,true);
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
