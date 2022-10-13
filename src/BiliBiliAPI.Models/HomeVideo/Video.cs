using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.HomeVideo
{
    public class Video
    {
        [JsonProperty("items")]
        public List<Item> Item { get; set; }
       
    }

    public class Item
    {
        [JsonProperty("card_type")]
        public string Card_Type { get; set; }

        [JsonProperty("card_goto")]
        public string Card_Goto { get; set; }

        [JsonProperty("goto")]
        public string Goto { get; set; }

        [JsonProperty("param")]
        public string Param { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("three_point")]
        public Three_Point Three_Point { get; set; }

        [JsonProperty("args")]
        public UpArgs UpArg { get; set; }

        [JsonProperty("player_args")]
        public PlayerArgs PlayArg { get; set; }

        [JsonProperty("idx")]
        public string idx { get; set; }

        /// <summary>
        /// 播放数量（字符串）
        /// </summary>
        [JsonProperty("cover_left_text_1")]
        public string PlayerCount { get; set; }

        [JsonProperty("cover_left_1_content_description")]
        public string PlayerCountCaption { get; set; }

        /// <summary>
        /// 历史弹幕数量
        /// </summary>
        [JsonProperty("cover_left_text_2")]
        public string LeftText { get; set; }

        [JsonProperty("cover_left_2_content_description")]
        public string LeftTextCaption { get; set; }

        [JsonProperty("cover_right_text")]
        public string DurationText { get; set; }

        [JsonProperty("cover_right_content_description")]
        public string DurationTextCaption { get; set; }

        [JsonProperty("three_point_v2")]
        public List<Three_Point_V2> Three_Point_V2 { get; set; }
    }

    public class Three_Point_V2
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("reasons")]
        public List<Dis_resource> Reasons { get; set; }

    }



    public class PlayerArgs
    {
        [JsonProperty("aid")]
        public string Aid { get; set; }

        [JsonProperty("cid")]
        public string cid { get; set; }

        [JsonProperty("type")]
        public string VideoType { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        
    }

    public class UpArgs
    {
        [JsonProperty("up_id")]
        public string Mid { get; set; }

        [JsonProperty("up_name")]
        public string Name { get; set; }

        [JsonProperty("rname")]
        public string RName { get; set; }

        [JsonProperty("rid")]
        public string Rid { get; set; }

        
    }

    public class Three_Point
    {
        [JsonProperty("dislike_reasons")]
        public List<Dis_resource> dis_Resources { get; set; }

        [JsonProperty("feedbacks")]
        public List<Dis_resource> FeedBacks { get; set; }

        [JsonProperty("watch_later")]
        public string Watch_Later { get; set; }
    }

    public class Dis_resource
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("toast")]
        public string Toast { get; set; }
    }
}
