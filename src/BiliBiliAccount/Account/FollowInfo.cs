using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.Account
{
    /// <summary>
    /// 粉丝相关
    /// </summary>
    public class FollowInfo
    {
        private MyHttpClient HttpClient = new MyHttpClient();

        /// <summary>
        /// 获得本身关注
        /// </summary>
        /// <returns></returns>
        public async  Task<ResultCode<MyFolloweData>> GetFollow()
        {
            return await Task.Run(async () =>
            {
                return JsonConvert.ReadObject<MyFolloweData>(await Get("http://api.bilibili.com/x/msgfeed/unread"));
            });
        }


        /// <summary>
        /// UP主播放量简单统计信息
        /// </summary>
        /// <returns></returns>
        public async Task<ResultCode<UpStatData>> GetUp()
        {
            return await Task.Run(async () =>
            {
                return JsonConvert.ReadObject<UpStatData>(await Get("http://api.bilibili.com/x/space/upstat?mid={BiliBiliArgs.TokenSESSDATA.Mid}"));
            });
        }


        public async Task<ResultCode<UpImageData>> GetUpImage()
        {
            return await Task.Run(async () =>
            {
                return  JsonConvert.ReadObject<UpImageData>(await Get("http://api.vc.bilibili.com/link_draw/v1/doc/upload_count?uid={BiliBiliArgs.TokenSESSDATA.Mid}"));
            });
        }

        public async Task<string> Get(string url)
        {
            return await Task.Run(async () =>
            {
                string url = $"http://api.vc.bilibili.com/link_draw/v1/doc/upload_count?uid={BiliBiliArgs.TokenSESSDATA.Mid}";
                string json = await HttpClient.GetResults(url);
                return json;
            });
        }
    }
}
