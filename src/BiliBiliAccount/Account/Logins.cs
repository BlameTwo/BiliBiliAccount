using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.Settings;
using BiliBiliAPI.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BiliBiliAPI.Account
{
    /// <summary>
    /// Logins是一个调用集合，指登陆过后的第一次登录
    /// </summary>
    public class Logins
    {

        private HttpTools HttpClient = new HttpTools();

        /// <summary>
        /// 使用保存的Cookie进行登录登录，获取登录信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async  Task<ResultCode<AccountLoginResultData>> Login(AccountToken token)
        {
            return await Task.Run(async () =>
            {
                AccountInfo info = new AccountInfo();
                string str = await HttpClient.GetResults(Apis.APP_LOGIN_NAV, HttpTools.ResponseEnum.Web);
                return await info.GetAccount(token);
            });
        }

        public void Unlogin()
        {
            BiliBiliAPI.Models.Settings.AccountSettings.Delete();
            BiliBiliArgs.TokenSESSDATA = new AccountToken();
            BiliBiliArgs.Cookie = "";
            BiliBiliArgs.Refresh_Token = "";
        }

        /// <summary>
        /// 获得消息
        /// </summary>
        /// <returns></returns>
        public async Task<ResultCode<MyTipsData>> GetTip()
        {
            return await Task.Run(async () =>
            {
                TipInfo info = new TipInfo();
                return await info.GetTips();
            });
        }

        /// <summary>
        /// 获得私信
        /// </summary>
        /// <returns></returns>
        public async Task<ResultCode<MyLetterData>> GetLetter()
        {
            return await Task.Run(async () =>
            {
                TipInfo info = new TipInfo();
                return await info.GetLetter();
            });
        }

        public async Task<AccountToken> RefreshToken()
        {
            var content = $"refresh_token={BiliBiliArgs.TokenSESSDATA.RefToken}";
            var json = await HttpClient.PostResults(Apis.RefreshToken, content,
                HttpTools.ResponseEnum.App);
            return JsonConvert.Deserialize<AccountToken>(JObject.Parse(json).GetValue("data").ToString());
        }
        

        /// <summary>
        /// 获得关注
        /// </summary>
        /// <returns></returns>
        public async Task<ResultCode<MyFolloweData>> GetFllow()
        {
            FollowInfo info = new FollowInfo();
            return await info.GetFollow();
        }


    }
}
