using BiliBiliAPI.Models.Account.Dynamic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Account
{
    public class HistoryData
    {
        [JsonProperty("cursor")] public Cursor Cursor { get; set; }

        [JsonProperty("list")] public List<HisToryDataItem> Items { get; set; }
    }

    public enum GetHistoryType
    {
        AV = 1,
        PGC = 2,
        Live = 3,
        Article_list = 4,
        Article = 5
    }

    public static class HistoryTools
    {
        public static string Convert(this GetHistoryType type)
        {
            switch (type)
            {
                case GetHistoryType.AV:
                    return "archive";
                case GetHistoryType.PGC:
                    return "pgc";
                case GetHistoryType.Live:
                    return "live";
                case GetHistoryType.Article_list:
                    return "article-list";
                case GetHistoryType.Article:
                    return "article";
                default:
                    return "archive";
            }
        }
    }

    public class HisToryDataItem
    {
        [JsonProperty("title")]public string Title { get; set; }
        [JsonProperty("long_title")]public string LongTitle { get; set; }
        [JsonProperty("cover")]public string Cover { get; set; }
        [JsonProperty("covers")]public List<string> Covers { get; set; }

        [JsonProperty("uri")]public string Uri { get; set; }

        [JsonProperty("history")]public HisToryDataItem_History History { get; set; }

        [JsonProperty("videos")]public int VideoPage { get; set; }

        [JsonProperty("author_name")]public string UpName { get; set; }
        [JsonProperty("author_face")]public string UpFace { get; set; }
        [JsonProperty("author_mid")]public string UpMid { get; set; }

        /// <summary>
        /// 查看时间戳
        /// </summary>
        [JsonProperty("view_at")]public long ViewTime { get; set; }

        /// <summary>
        /// 引用与投稿或PGC，单位为秒，为观看进度
        /// </summary>
        [JsonProperty("progress")]public long Progress { get; set; }

        /// <summary>
        ///方片角标
        /// </summary>
        [JsonProperty("badge")] public string Badge { get; set; }

        /// <summary>
        /// 视频的分P标题
        /// </summary>
        [JsonProperty("show_title")]public string ShowTitle { get; set; }


        /// <summary>
        /// 视频总时长
        /// </summary>
        [JsonProperty("duration")]public long Duration { get; set; }


        [JsonProperty("current")]public string Current { get; set; }

        /// <summary>
        /// PGC的总计集数
        /// </summary>
        [JsonProperty("total")]public int Total { get; set; }

        /// <summary>
        /// 最新分P或最新分集的信息
        /// </summary>
        [JsonProperty("new_desc")]public string NewDesc { get; set; }

        /// <summary>
        /// 是否完结
        /// </summary>
        [JsonProperty("is_finish")]public string IsFinish { get; set; }

        /// <summary>
        /// 是否收藏
        /// </summary>
        [JsonProperty("is_fav")]public string IsFave { get; set; }

        /// <summary>
        /// 当前历史记录的Kid，也就是历史记录的ID
        /// </summary>
        [JsonProperty("kid")]public long Kid { get; set; }

        /// <summary>
        /// 子区名称
        /// </summary>
        [JsonProperty("tag_name")]public string TagName { get; set; }

        /// <summary>
        /// 直播状态，0为未直播，1相反。
        /// </summary>
        [JsonProperty("live_status")]public string Live_Status { get; set; }
    }

    public class HisToryDataItem_History
    {
        /// <summary>
        /// 此属性对应"P:BiliBiliAPI.Models.Account.Cursor.Business"
        /// </summary>
        [JsonProperty("oid")]public string Oid { get; set; }

        [JsonProperty("epid")] public string Epid { get;set; }

        [JsonProperty("bvid")]public string Bvid { get; set; }

        /// <summary>
        /// 视频的分P，仅对于投稿视频
        /// </summary>
        [JsonProperty("page")]public string Page { get; set; }

        /// <summary>
        /// 视频的Cid
        /// </summary>
        [JsonProperty("cid")]public string Cid { get; set; }

        /// <summary>
        /// 观看到的分P标题，仅对于视频
        /// </summary>
        [JsonProperty("part")]public string Part { get; set; }
        /// <summary>
        /// 此项目的属性，是投稿还是直播或其他属性
        /// </summary>
        [JsonProperty("business")]public string Business { get; set; }

        /// <summary>
        /// 在那个平台观看的代码：
        /// 1 3 5 7：手机端 2：web端 4 6：pad端 33：TV端 0：其他
        /// </summary>
        [JsonProperty("dt")]public string Dt { get; set; }

    }

    public class Cursor
    {
        [JsonProperty("max")]public string Max { get; set; }
        [JsonProperty("view_at")]public string View_At { get; set; }

        [JsonProperty("business")]public string Business { get; set; }

        [JsonProperty("ps")]public int Ps { get; set; }
    }
}
