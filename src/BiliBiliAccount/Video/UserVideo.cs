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

        /// <summary>
        /// 获得视频的投币数量
        /// </summary>
        /// <param name="av_bv">视频号</param>
        /// <param name="type">视频的类型</param>
        /// <returns></returns>
        public async Task<ResultCode<VideoConis>> GetConis(string av_bv, VideoIDType type)
        {
            string url = "";
            switch (type)
            {
                case VideoIDType.AV:
                    url = $"http://api.bilibili.com/x/web-interface/archive/coins?aid={av_bv}";
                    break;
                case VideoIDType.BV:

                    url = $"http://api.bilibili.com/x/web-interface/archive/coins?bvid={av_bv}";
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrWhiteSpace(url))
            {
                return JsonConvert.ReadObject<VideoConis>(await MyHttpClient.GetResults(url));
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 投币视频
        /// </summary>
        /// <param name="multiply">投币数量</param>
        /// <param name="aid">视频aid</param>
        /// <param name="islike">是否同时点赞</param>
        /// <returns></returns>
        public async Task<ResultCode<VideoToConis>> CoinsVideo(int multiply,string aid, bool islike = false)
        {
            int like = islike ? 1 : 0;
            string content = $"aid={aid}&multiply={multiply}&select_like={like}";
            return JsonConvert.ReadObject<VideoToConis>(await MyHttpClient.PostResults("https://app.biliapi.net/x/v2/view/coin/add?",content));
        }

    }
}
