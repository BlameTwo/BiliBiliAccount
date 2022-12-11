using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.PGC
{
    public class PGC
    {
        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("ttl")]
        public string TTl { get; set; }

        [JsonProperty("result")]
        public PGCArg Result { get; set; }
    }

    public class PGCArg
    {
        [JsonProperty("activity")]
        public Activity Activity { get; set; }

        /// <summary>
        /// 网页背景风脉你
        /// </summary>
        [JsonProperty("bkg_cover")]
        public string Web_Back_Image { get; set; }

        /// <summary>
        /// 封面
        /// </summary>
        [JsonProperty("cover")]
        public string Cover { get; set; }

        /// <summary>
        /// 国家标签
        /// </summary>
        [JsonProperty("areas")]
        public List<Areas> Areas { get; set; }

        /// <summary>
        /// 剧集列表
        /// </summary>
        [JsonProperty("episodes")]
        public List<Episodes> Episodes { get; set; }


        /// <summary>
        /// 简介
        /// </summary>
        [JsonProperty("evaluate")]
        public string Evaluate { get; set; }

        /// <summary>
        /// 剧集的mmid
        /// </summary>
        [JsonProperty("media_id")]
        public string Media_ID { get; set; }

        [JsonProperty("new_ep")]
        public New_EP2 New_EP2 { get; set; }

        [JsonProperty("payment")]
        public Payment Payment { get; set; }

        /// <summary>
        /// 是否为VIP
        /// </summary>
        public bool IsVip
        {
            get
            {
                if (Payment.Tip.IndexOf("大会员") == -1)
                    return false;
                else
                    return true;
            }
        }

        [JsonProperty("rating")]
        public Rating Rating { get; set; }

        [JsonProperty("record")]
        public string CopyRight { get; set; }

        /// <summary>
        /// 番剧ID
        /// </summary>
        [JsonProperty("season_id")]
        public string SSID { get; set; }

        [JsonProperty("season_title")]
        public string Season_Title { get; set; }

        [JsonProperty("seasons")]
        public List<Seasons> Seasons { get; set; }

        [JsonProperty("section")]
        public List<Section> Sections { get; set; }


        [JsonProperty("share_copy")]
        public string Share_Copy { get; set; }

        [JsonProperty("share_copy_title")]
        public string Share_Sub_Title { get; set; }

        [JsonProperty("share_url")]
        public string Share_Url { get; set; }

        /// <summary>
        /// 方形封面
        /// </summary>
        [JsonProperty("square_cover")]
        public string Square_cover { get; set; }

        [JsonProperty("stat")]
        public PGCState State { get; set; }

        /// <summary>
        /// 剧集副标题
        /// </summary>
        [JsonProperty("subtitle")]
        public string SubTitle { get; set; }

        [JsonProperty("Title")]
        public string Title { get;set; }

        /// <summary>
        /// 是否完结
        /// </summary>
        [JsonProperty("total")]
        public bool Total { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
    }

    public class New_EP2
    {
        [JsonProperty("desc")]
        public string DescTitle { get; set; }

        /// <summary>
        /// 最新一集的EPID
        /// </summary>
        [JsonProperty("id")]
        public string EPID { get; set; }

        /// <summary>
        /// 是否是最新发布
        /// </summary>
        [JsonProperty("new_ep")]
        public string IsNew { get; set; }

        /// <summary>
        /// 最新剧集的标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class Activity
    {
        [JsonProperty("head_bg_url")]
        public string Head_BG_Url { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }




    }

    public class Episodes
    {
        [JsonProperty("aid")]
        public string AId { get; set; }

        [JsonProperty("badge")]
        public string Badge { get; set; }

        [JsonProperty("badge_type")]
        public int Badge_Type { get; set; }

        [JsonProperty("bvid")]
        public string Bvid { get; set; }

        [JsonProperty("cid")]
        public string Cid { get; set; }

        /// <summary>
        /// 剧集封面
        /// </summary>
        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("dimension")]
        public Dimension Dimension { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// 单集epid
        /// </summary>
        [JsonProperty("id")]
        public string Epid { get; set; }

        [JsonProperty("link")]
        public string IDLink { get; set; }


        [JsonProperty("long_title")]
        public string Title { get; set; }

        [JsonProperty("pub_time")]
        public long CTime { get; set; }

        [JsonProperty("pv")]
        public string Num { get; set; }

        [JsonProperty("release_date")]
        public string Release_date { get; set; }


        [JsonProperty("share_copy")]
        public string Title2 { get; set; }

        [JsonProperty("short_link")]
        public string ShortLink { get; set; }

        [JsonProperty("title")]
        public string LightTitle { get; set; }
    }

    public class Dimension
    {
        [JsonProperty("height")]
        public int VideoHeight { get; set; }

        /// <summary>
        /// 是否支持长和宽调换
        /// </summary>
        [JsonProperty("rotate")]
        public int Rotate { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class Areas
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Payment
    {
        public string Tip { get; set; }
    }

    public class Rating
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("score")]
        public double Rate { get; set; }
    }

    public class Seasons
    {
        [JsonProperty("badge")]
        public string Badge { get; set; }

        [JsonProperty("badge_type")]
        public string BadgeType { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("horizontal_cover_1610")]
        public string Horizontal_Light_Cover { get; set; }

        [JsonProperty("horizontal_cover_169")]
        public string Horizontal_Large_Cover { get; set; }

        [JsonProperty("media_id")]
        public string MMid { get; set; }

        [JsonProperty("new_ep")]
        public Seasons_New_ep seasons_New_Ep { get; set; }

        [JsonProperty("season_id")]
        public string SSID { get; set; }

        [JsonProperty("season_title")]
        public string SSTitle { get; set; }

        [JsonProperty("season_type")]
        public int SeasonType { get; set; }

        [JsonProperty("stat")]
        public Seasons_State State { get; set; }
    }

    public class Section
    {
        [JsonProperty("title")]
        public string Title { get; set; }


        [JsonProperty("episodes")]
        public List<SectionEpisodes> SectionEpisodes { get; set; }
    }

    public class Seasons_State
    {

        /// <summary>
        /// 收藏数量
        /// </summary>
        [JsonProperty("favorites")]
        public long LikeCount { get; set; }

        /// <summary>
        /// 追剧人数
        /// </summary>
        [JsonProperty("series_follow")]
        public long Series { get; set; }

        /// <summary>
        /// 观看数量
        /// </summary>
        [JsonProperty("views")]
        public long Views { get; set; }
    }
    public class Seasons_New_ep
    {
        [JsonProperty("cover")]
        public string cover { get; set; }

        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("index_show")]
        public string Title_Show { get; set; }


    }
    public class SectionEpisodes
    {
        [JsonProperty("aid")]
        public string AId { get; set; }

        [JsonProperty("bvid")]
        public string Bvid { get; set; }

        [JsonProperty("cid")]
        public string Cid { get; set; }
        [JsonProperty("cover")]
        public string cover { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("long_title")]
        public string Title { get; set; }


        /// <summary>
        /// 发布时间
        /// </summary>
        [JsonProperty("pub_time")]
        public long Public_Time { get; set; }

        [JsonProperty("share_copy")]
        public string Title2 { get; set; }

        [JsonProperty("short_link")]
        public string Short_link { get; set; }

        [JsonProperty("stat")]
        public VideoState VideoState { get; set; }

        [JsonProperty("subtitle")]
        public string Title3 { get; set; }
    }
    public class VideoState
    {
        public int coin { get; set; }

        public int danmakus { get; set; }

        public int likes { get; set; }

        public int play { get; set; }

        public string reply { get; set; }
    }

    public class PGCState : VideoState
    {
        public int favorite { get; set; }
        public int favorites { get; set; }

        public int share { get; set; }
    }
}
