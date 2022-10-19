﻿using BiliBiliAPI.Models;
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

        public async Task<ResultCode<VideoInfo>> GetVideo(VideosContent info,VideoIDType videoIDType, DashEnum dashEnum, FnvalEnum fnvalEnum = FnvalEnum.FLV)
        {
            string url = null;
            string avorbv = videoIDType == VideoIDType.AV ? "avid" : "bvid";
            url = $"http://api.bilibili.com/x/player/playurl?{avorbv}={info.Aid}&cid={info.First_Cid}&fourk=1&qn={(int)dashEnum}";
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
            string url = "https://app.bilibili.com/x/v2/feed/index?device_name=iPad206&device=pad&flush=5&mobi_app=iphone&platform=ios&pull=true";
            var a =  JsonConvert.ReadObject<BiliBiliAPI.Models.HomeVideo.Video>(await HttpClient.GetResults(url));
            foreach (var item in a.Data.Item.ToArray())
            {
                if (string.IsNullOrWhiteSpace(item.Title))
                {
                    a.Data.Item.Remove(item);
                }
            }
            return a;
        }

    }
}
