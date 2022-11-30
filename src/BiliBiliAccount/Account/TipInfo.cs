using BilibiliAPI;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Account
{
    public class TipInfo
    {
        private MyHttpClient HttpClient = new MyHttpClient();
        /// <summary>
        /// 消息数量
        /// </summary>
        /// <returns></returns>
        public async Task<ResultCode<MyTipsData>> GetTips()
        {
            return await Task.Run( async() => 
            {
                string json = await HttpClient.GetResults(Apis.MY_TIP_COUNT);
                return JsonConvert.ReadObject<MyTipsData>(json);
            });
        }

        /// <summary>
        /// 私信
        /// </summary>
        /// <returns></returns>
        public async Task<ResultCode<MyLetterData>> GetLetter()
        {
            return await Task.Run(async () =>
            {
                string json = await HttpClient.GetResults(Apis.MY_LETTER_COUNT);
                return JsonConvert.ReadObject<MyLetterData>(json);
            });
        }



    }
}
