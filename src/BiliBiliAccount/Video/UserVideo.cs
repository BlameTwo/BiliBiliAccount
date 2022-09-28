using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.Video
{
    public class UserVideo
    {
        MyHttpClient MyHttpClient = new MyHttpClient();

        /// <summary>
        /// 点赞视频
        /// </summary>
        /// <param name="flage">是否点赞</param>
        /// <param name="aid">视频aid</param>
        /// <returns></returns>
        public async  Task<ResultCode<LikeToast>> LikeVideo(bool flage,string aid)
        {
            int fl = Convert.ToInt32(!flage);
            string content = $"aid={aid}&like={fl}";
            return JsonConvert.ReadObject<LikeToast>(await MyHttpClient.PostResults("http://app.bilibili.com/x/v2/view/like",content));
        }
    }
}
