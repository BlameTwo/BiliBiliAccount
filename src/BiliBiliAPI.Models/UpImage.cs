using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models
{
    /// <summary>
    /// UP的相簿投稿
    /// </summary>
    public class UpImage
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("ttl")]
        public string TTl { get; set; }

        [JsonProperty("data")]
        public UpImageData Data {get;set;}
    }

    public class UpImageData
    {
        /// <summary>
        /// 总计
        /// </summary>
        [JsonProperty("all_count")]
        public string All_Count { get; set; }

        /// <summary>
        /// 绘画数量
        /// </summary>
        [JsonProperty("draw_count")]
        public string Draw_Count { get; set; }

        /// <summary>
        /// 摄影数量
        /// </summary>
        [JsonProperty("photo_count")]
        public string Photo_Count { get; set; }

        /// <summary>
        /// 图片动态数量
        /// </summary>
        [JsonProperty("daily_count")]
        public string Daily_count { get; set; }
    }
}
