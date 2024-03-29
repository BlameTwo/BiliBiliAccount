﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.HomeVideo
{
    /// <summary>
    /// 新首页的推荐视频
    /// </summary>
    public class HomeData
    {
        [JsonProperty("mid")] public string Mid { get; set; }
        [JsonProperty("item")] public List<HomeDataItem> Items { get; set; }
    }

    public class HomeDataItem
    {
        [JsonProperty("id")] public string Aid { get; set; }
        [JsonProperty("bvid")] public string Bvid { get; set; }
        [JsonProperty("cid")] public string Cid { get; set; }
        [JsonProperty("goto")] public string Goto { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("pic")] public string Cover { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("duration")] public string Duration { get; set; }
        [JsonProperty("pubdate")] public string CrateDate { get; set; }
        [JsonProperty("av_feature")] public object AV_feature { get; set; }
        [JsonProperty("owner")] public Owner Owner { get; set; }
        [JsonProperty("stat")] public HomeVideoStat Stat { get; set; }

        [JsonProperty("rcmd_reason")] public Rcmd SubTitle { get; set; }
    }

    public class Rcmd
    {
        [JsonProperty("content")] public string Content { get; set; }

        [JsonProperty("reason_type")] public int Type { get; set; }
    }

    public class Owner
    {
        [JsonProperty("mid")] public string Mid { get; set; }
        [JsonProperty("name")] public string UpName { get; set; }
        [JsonProperty("face")] public string Cover { get; set; }
    }

    public class HomeVideoStat
    {
        [JsonProperty("view")] public int View { get; set; }
        [JsonProperty("like")] public int Like { get; set; }
        [JsonProperty("danmaku")] public int Danmaku { get; set; }
    }

}
