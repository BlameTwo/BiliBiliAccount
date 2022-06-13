using BiliBiliAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.Account
{
    public class TipInfo
    {
        private MyHttpClient HttpClient = new MyHttpClient();
        /// <summary>
        /// 消息数量
        /// </summary>
        /// <returns></returns>
        public async Task<MyTips> GetTips()
        {
            return await Task.Run( async() => 
            {
                string url = "http://api.bilibili.com/x/msgfeed/unread";
                string json = await HttpClient.GetResults(url);
                return JsonConvert.ReadObject<MyTips>(json);
            });
        }

        /// <summary>
        /// 私信
        /// </summary>
        /// <returns></returns>
        public async Task<MyLetter> GetLetter()
        {
            return await Task.Run(async () =>
            {
                string url = "http://api.vc.bilibili.com/session_svr/v1/session_svr/single_unread";
                string json = await HttpClient.GetResults(url);
                return JsonConvert.ReadObject<MyLetter>(json);
            });
        }



    }
}
