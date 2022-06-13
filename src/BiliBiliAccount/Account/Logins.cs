using BiliBiliAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.Account
{
    /// <summary>
    /// Logins是一个调用集合，指登陆过后的第一次登录
    /// </summary>
    public class Logins
    {

        private MyHttpClient HttpClient = new MyHttpClient();

        /// <summary>
        /// 使用保存的Cookie进行登录登录
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async  Task<AccountLoginResult> Login(AccountToken token)
        {
            return await Task.Run(async () =>
            {
                AccountInfo info = new AccountInfo();
                string str = await HttpClient.GetResults($"http://api.bilibili.com/x/web-interface/nav");
                return await info.GetAccount(token);
            });
        }

        /// <summary>
        /// 获得消息
        /// </summary>
        /// <returns></returns>
        public async Task<MyTips> GetTip()
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
        public async Task<MyLetter> GetLetter()
        {
            return await Task.Run(async () =>
            {
                TipInfo info = new TipInfo();
                return await info.GetLetter();
            });
        }


        /// <summary>
        /// 测试接口
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> Test(string url)
        {
            return await Task.Run(async () =>
            {
                AccountInfo info = new AccountInfo();
                string str = await HttpClient.GetResults(url);
                return str;
            });
        }

        /// <summary>
        /// 获得关注
        /// </summary>
        /// <returns></returns>
        public async Task<MyFollow> GetFllow()
        {
            FollowInfo info = new FollowInfo();
            return await info.GetFollow();
        }


    }
}
