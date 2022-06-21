using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Videos
{
    /// <summary>
    /// 视频基本信息
    /// </summary>
    public class Videos
    {
        /// <summary>
        /// BV号
        /// </summary>
        [JsonProperty("bvid")]
        public string Bvid { get; set; }
        /// <summary>
        /// AV号
        /// </summary>
        [JsonProperty("aid")]
        public string Aid { get; set; }

        /// <summary>
        /// 分P
        /// </summary>
        [JsonProperty("videos")]
        public string PageCount { get; set; }

        /// <summary>
        /// 分区内容
        /// </summary>
        [JsonProperty("tid")]
        public string Tid { get; set; }

        /// <summary>
        /// 小分区文字
        /// </summary>
        [JsonProperty("tname")]
        public string TidSmallName { get; set; }

        /// <summary>
        /// 1为原创，2为转载
        /// </summary>
        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        /// <summary>
        /// 视频封面
        /// </summary>
        [JsonProperty("pic")]
        public string VideoImage { get; set; }

        /// <summary>
        /// 稿件标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 发布时间的时间戳
        /// </summary>
        [JsonProperty("pubdate")]
        public string UpDataTime { get; set; }

        /// <summary>
        /// 用户投稿信息
        /// </summary>
        [JsonProperty("ctime")]
        public string UserUpdata { get; set; }

        /// <summary>
        /// 视频简介
        /// </summary>
        [JsonProperty("desc")]
        public string VideoDEsc { get; set; }

        /// <summary>
        /// 新版视频简介
        /// </summary>
        [JsonProperty("desc_v2")]
        public NewDesc Desc_V2 { get; set; }

        /// <summary>
        /// 视频状态信息
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("duration")]
        public string All_Duration { get; set; }

        /// <summary>
        /// 撞车了，这个是AID
        /// </summary>
        [JsonProperty("forward")]
        public string Forward { get; set; }

        /// <summary>
        /// 参与活动的ID
        /// </summary>
        [JsonProperty("mission_id")]
        public string Mission_id { get; set; }

        /// <summary>
        /// 重新定向URL，番剧和影视存在
        /// </summary>
        [JsonProperty("redirect_url")]
        public string Redirect_Url { get; set; }

        /// <summary>
        /// 视频同步发布的的动态的文字内容
        /// </summary>
        [JsonProperty("dynamic")]
        public string dynamic { get; set; }

        /// <summary>
        /// 第一P视频的CID
        /// </summary>
        [JsonProperty("cid")]
        public string First_Cid { get; set; }

        /// <summary>
        /// 第一P的分辨率
        /// </summary>
        [JsonProperty("dimension")]
        public string Screen_Size { get; set; }

        [JsonProperty("rights")]
        public CopyRight Right { get; set; }

        [JsonProperty("owner")]
        public Up Up { get; set; }

        [JsonProperty("stat")]
        public Stat Stat { get; set; }

        [JsonProperty("pages")]
        public List<Page> Pages { get; set; }
    }

    public class NewDesc
    {
        /// <summary>
        /// 包含换行符的简介信息
        /// </summary>
        [JsonProperty("raw_text")]
        public string Text { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("biz_id")]
        public string Biz_Id { get; set; }
    }

    public class CopyRight
    {

        /// <summary>
        /// 是否支持充电
        /// </summary>
        public string elec { get; set; }

        /// <summary>
        /// 是否能下载，1为ok，0为不行
        /// </summary>
        public string download { get; set; }

        /// <summary>
        /// 是否为电影
        /// </summary>
        public string movie { get; set; }

        /// <summary>
        /// 是否需要额外付费
        /// </summary>
        public string pay { get; set; } 
        
        /// <summary>
        /// 是否高码率
        /// </summary>
        public string hd5 { get; set; }

        /// <summary>
        /// 是否显示转载，1为显示，0为不显示
        /// </summary>
        public string no_reprint { get; set; }

        /// <summary>
        /// 是否为UGC付费电影
        /// </summary>
        public string ugc_pay { get; set; }

        /// <summary>
        /// 是否为互动视频
        /// </summary>
        public string is_stein_gate { get; set; }

        /// <summary>
        /// 是否联合投稿
        /// </summary>
        public string is_cooperation { get; set; }
    }

    public class Up
    {
        /// <summary>
        /// UP主的UID
        /// </summary>
        [JsonProperty("mid")]
        public string mid { get; set; }

        [JsonProperty("face")]
        public string Face { get; set; }

        [JsonProperty("face")]
        public string Name { get; set; }
    }


    public class Stat
    {
        /// <summary>
        /// AV号
        /// </summary>
        [JsonProperty("aid")]
        public string Aid { get; set; }

        /// <summary>
        /// 播放数量
        /// </summary>
        [JsonProperty("view")]
        public string Views { get; set; }

        /// <summary>
        /// 弹幕数量
        /// </summary>
        [JsonProperty("danmaku")]
        public string DanMaku { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        [JsonProperty("评论数量")]
        public string Reply { get; set; }

        /// <summary>
        ///收藏
        /// </summary>
        [JsonProperty("favorite")]
        public string Favorite { get; set; }

        /// <summary>
        /// 投币
        /// </summary>
        [JsonProperty("coin")]
        public string coin { get; set; }

        /// <summary>
        /// 分享
        /// </summary>
        [JsonProperty("share")]
        public string Share { get; set; }

        /// <summary>
        /// 当前排名
        /// </summary>
        [JsonProperty("now_rank")]
        public string Now_Rank { get; set; }

        /// <summary>
        /// 历史最高排名
        /// </summary>
        [JsonProperty("his_rank")]
        public string His_Rank { get; set; }

        /// <summary>
        /// 点赞
        /// </summary>
        [JsonProperty("like")]
        public string Like { get; set; }

        /// <summary>
        /// 点踩的数量
        /// </summary>
        [JsonProperty("dislike")]
        public string DisLike { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        [JsonProperty("evaluation")]
        public string Evaluation { get; set; }

        /// <summary>
        /// 警告信息
        /// </summary>
        [JsonProperty("argue_msg")]
        public string ArgueMessage { get; set; }
    }

    public class Page
    {
        [JsonProperty("cid")]
        public string Cid { get; set; }

        /// <summary>
        /// 当前分页
        /// </summary>
        [JsonProperty("page")]
        public string page { get; set; }

        /// <summary>
        /// 来源，默认为B站，qq为腾讯，hunan为芒果
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// 分P标题
        /// </summary>
        [JsonProperty("part")]
        public string Title { get; set; }

        /// <summary>
        /// 分P时常，以秒为单位
        /// </summary>
        [JsonProperty("duration")]
        public string Duration { get; set; }

        /// <summary>
        /// 站外视频vid
        /// </summary>
        [JsonProperty("vid")]
        public string Vid { get; set; }

        /// <summary>
        /// 站外Link
        /// </summary>
        [JsonProperty("weblink")]
        public string Link { get; set; }

        [JsonProperty("dimension")]
        public PageDimension PageDim { get; set; }
    }

    public class PageDimension
    {

        /// <summary>
        /// 款
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// 是否宽高对换，0为正常，1为对换
        /// </summary>
        [JsonProperty("rotate")]
        public string Rotate { get; set; }
    }
}
