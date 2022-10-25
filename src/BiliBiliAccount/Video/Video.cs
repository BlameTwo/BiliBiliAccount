using BilibiliAPI.ApiTools;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.HomeVideo;
using BiliBiliAPI.Models.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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
                url = $"https://app.bilibili.com/x/v2/view?aid={id}";
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

        public async Task<ResultCode<VideoInfo>> GetVideo(VideosContent info,VideoIDType videoIDType, int dashEnum = 0, FnvalEnum fnvalEnum = FnvalEnum.FLV)
        {
            string url = null;
            string avorbv = videoIDType == VideoIDType.AV ? "avid" : "bvid";
            string value = videoIDType == VideoIDType.AV ? $"{info.Aid}" : $"{info.Bvid}";
            if(dashEnum == 0)
            {
                url = $"http://api.bilibili.com/x/player/playurl?{avorbv}={value}&cid={info.First_Cid}&mid={BiliBiliArgs.TokenSESSDATA.Mid}&qn=64&otype=json&platform=web&fnval=4048&fnver=0&fourk=1";
            }
            else
            {
                url = $"http://api.bilibili.com/x/player/playurl?{avorbv}={value}&cid={info.First_Cid}&mid={BiliBiliArgs.TokenSESSDATA.Mid}&qn={(int)dashEnum}&otype=json&platform=web&fnval=4048&fnver=0&fourk=1";
            }
            
            if (url != null)
                return JsonConvert.ReadObject<VideoInfo>(await HttpClient.GetResults(url));
            else
                return new ResultCode<VideoInfo>() { Code = "信息错误" };
        }

        /// <summary>
        /// 获得高能进度条数据条
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public async Task<HigitPoint> GetPoint(string cid)
        {
            //http://bvc.bilivideo.com/pbp/data?cid=239973476
            string url = $"http://bvc.bilivideo.com/pbp/data?cid={cid}";
            return JsonConvert.Deserialize<HigitPoint>(await HttpClient.GetResults(url));
        }

        public async Task<ResultCode<VidonOnline>> GetVideoOnline(VideosContent info, string cid = null)
        {
            string url = "";
            if (!string.IsNullOrWhiteSpace(cid))
            {
                url = $"http://api.bilibili.com/x/player/online/total?bvid={info.Bvid}&cid={cid}";
            }
            else
            {
                url = $"http://api.bilibili.com/x/player/online/total?bvid={info.Bvid}&cid={info.First_Cid}";
            }
            return JsonConvert.ReadObject<VidonOnline>(await HttpClient.GetResults(url));
        }

        public async Task<ResultCode<BiliBiliAPI.Models.HomeVideo.Video>> GetHomeVideo()
        {
            return await GetUrl(VideoType.Home);
        }

        enum VideoType
        {
            Home,Hot
        }

        async Task<ResultCode<BiliBiliAPI.Models.HomeVideo.Video>> GetUrl(VideoType videoType)
        {
            string url = "";
            switch (videoType)
            {
                case VideoType.Home:
                    url = "https://app.bilibili.com/x/v2/feed/index?device_name=iPad206&device=pad&bulid=6235200&mobi_app=iphone&platform=ios&pull=true";
                    break;
                case VideoType.Hot:
                    url = "https://app.bilibili.com/x/v2/show/popular/index?device_name=iPad206&device=pad&bulid=6235200&mobi_app=iphone&platform=ios&pull=true";
                    break;
            }
            var result = JsonConvert.ReadObject<BiliBiliAPI.Models.HomeVideo.Video>(await HttpClient.GetResults(url));
            var list = result.Data.Item.Where(p => !string.IsNullOrWhiteSpace(p.Title));
            result.Data.Item = list.ToList();
            return result;
        }

        public async Task<BiliBiliAPI.Models.HomeVideo.HotVideo> GetHotVideo()
        {
            var url = "https://app.bilibili.com/x/v2/show/popular/index?";
            var text = "device_name=iPad206&device=pad&bulid=6235200&mobi_app=iphone&platform=ios&pull=true";
            string jo = await HttpClient.GetResults(url, ApiProvider.AndroidTVKey, text);
            var result = JsonConvert.Deserialize<BiliBiliAPI.Models.HomeVideo.HotVideo>(jo);
            var list = result.Item.Where(p => !string.IsNullOrWhiteSpace(p.Title));
            result.Item = list.ToList();
            return result;
        }

    }
}
