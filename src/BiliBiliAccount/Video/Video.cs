using BiliBiliAPI.Models.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BilibiliAPI.Video.Video;

namespace BilibiliAPI.Video
{
    public class Video
    {
        private MyHttpClient HttpClient = new MyHttpClient();

        /// <summary>
        /// 获得视频的基本信息
        /// </summary>
        /// <param name="bvidoravid">视频的avid或bvid</param>
        /// <returns></returns>
        public async Task<VideosContent> GetVideosContent(string id,VideoIDType videoIDType = VideoIDType.BV)
        {
            string url = "";
            if(videoIDType == VideoIDType.BV)
                url = $"http://api.bilibili.com/x/web-interface/view?bvid={id}";
            else
                url = $"http://api.bilibili.com/x/web-interface/view?avid={id}";
            return JsonConvert.ReadObject<VideosContent>(await HttpClient.GetResults(url));
        }

        /// <summary>
        /// 获得视频状态
        /// </summary>
        /// <param name="aid">获得方法:<seealso cref="GetVideosContent(string, VideoIDType)"/>,视频的aid，</param>
        /// <returns></returns>
        public async Task<VideoState> GetVideoState(string aid)
        {
            string url = $"http://api.bilibili.com/archive_stat/stat?aid={aid}";
            return JsonConvert.ReadObject<VideoState>(await HttpClient.GetResults(url));
        }


        public enum VideoIDType
        {
            AV,BV
        }

    }
}
