using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Videos
{
    public class LikeToast
    {
        [JsonProperty("toast")]
        public string TipText { get; set; }
    }

    public class VideoConis
    {
        [JsonProperty("multiply")]
        public string multiply { get; set; }
    }

    public class VideoToConis
    {
        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// 同时点赞返回结果
        /// </summary>
        [JsonProperty("like")]
        public string Like { get; set; }

        [JsonProperty("guide")]
        public ToConisGuide Guide { get; set; }
    }

    public class ToConisGuide
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
