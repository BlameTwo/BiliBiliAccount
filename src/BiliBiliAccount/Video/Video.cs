using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static BilibiliAPI.Video.Video;

namespace BilibiliAPI.Video
{
    public class Video
    {
        private MyHttpClient HttpClient = new MyHttpClient();


        /// <summary>
        /// 获得视频的Web页面信息
        /// </summary>
        /// <param name="bvidoravid">视频的avid或bvid</param>
        /// <returns></returns>
        public async Task<ResultCode<VideosContent>> GetVideosContent(string id,VideoIDType videoIDType = VideoIDType.BV)
        {
            string url = "";
            if(videoIDType == VideoIDType.BV)
                url = $"https://app.bilibili.com/x/v2/view?bvid={id}";
            else
                url = $"https://app.bilibili.com/x/v2/view?avid={id}";
            object a = JsonConvert.ReadObject<VideosContent>(await HttpClient.GetResults(url));

            return (ResultCode<VideosContent>)a;
        }

        /// <summary>
        /// 获得视频状态
        /// </summary>
        /// <param name="aid">获得方法:<seealso cref="GetVideosContent(string, VideoIDType)"/>,视频的aid，</param>
        /// <returns></returns>
        public async Task<ResultCode<VideoState>> GetVideoState(string aid)
        {
            string url = $"http://api.bilibili.com/archive_stat/stat?aid={aid}";
            return JsonConvert.ReadObject<VideoState>(await HttpClient.GetResults(url));
        }

        public async Task<ResultCode<VideoInfo>> GetVideo(VideosContent info,VideoIDType videoIDType)
        {
            string url = null;
            switch (videoIDType)
            {
                case VideoIDType.AV:
                    url = $"http://api.bilibili.com/x/player/playurl?avid={info.Aid}&cid={info.First_Cid}&fourk=1&qn=120";
                    break;
                case VideoIDType.BV:
                    url = $"http://api.bilibili.com/x/player/playurl?bvid={info.Aid}&cid={info.First_Cid}&fourk=1&qn=120";
                    break;
            }
            if (url != null)
                return JsonConvert.ReadObject<VideoInfo>(await HttpClient.GetResults(url));
            else
                return new ResultCode<VideoInfo>() { Code = "信息错误" };
        }

    }
}
