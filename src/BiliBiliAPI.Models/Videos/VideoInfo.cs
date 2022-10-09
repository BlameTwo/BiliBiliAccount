using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Videos
{
    public class VideoInfo
    {
        [JsonProperty("from")]
        public string from { get; set; }
        [JsonProperty("result")]
        public string result { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
        [JsonProperty("quality")]
        public string Quality { get; set; }

        /// <summary>
        /// 视频长度
        /// </summary>
        [JsonProperty("timelength")]
        public string TimeLength { get; set; }

        [JsonProperty("accept_format")]
        public string VideoFormat { get; set; }

        /// <summary>
        /// 视频清晰度列表
        /// </summary>
        [JsonProperty("accept_description")]
        public List<string> Description { get; set; }

        /// <summary>
        /// 视频清晰度代码
        /// </summary>
        [JsonProperty("accept_quality")]
        public List<string> Accept_Code { get; set; }

        /// <summary>
        /// 视频流编码ID
        /// </summary>
        [JsonProperty("video_codecid")]
        public string VideoCodeCid { get; set; }

        [JsonProperty("durl")]
        public List<Durl> Durl { get; set; }

        [JsonProperty("support_formats")]
        public List<Supports> Supports { get; set; }

        [JsonProperty("dash")]
        public string Dash { get; set; }

        [JsonProperty("last_play_time")]
        public long LastPlay { get; set; }

        [JsonProperty("last_play_cid")]
        public long LastCid { get; set; }
    }

    public class Supports
    {
        [JsonProperty("quality")]
        public string Quality { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("new_description")]
        public string NowDescription { get; set; }

        [JsonProperty("superscript")]
        public string Superscript { get; set; }

        [JsonProperty("codecs")]
        public string Codecs { get; set; }
    }

    public class Durl
    {
        /// <summary>
        /// 分段序号
        /// </summary>
        [JsonProperty("order")]
        public string Order { get; set; }
        /// <summary>
        /// 视频长度
        /// </summary>
        [JsonProperty("length")]
        public string Length { get; set; }

        /// <summary>
        /// 视频大小，单位为Byte
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// 视频Url
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("backup_url")]
        public List<string> Backup_Url { get; set; }
    }
}
