using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models
{
    /// <summary>
    /// UP主统计，一般用于账号为Up的人使用
    /// </summary>
    public class UpStat
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("ttl")]
        public string TTl { get; set; }

        [JsonProperty("data")]
        public UpStatData Data { get; set; }
    }
    public class UpStatData
    {
        [JsonProperty("archive")]
        public Archive _Archive { get; set; }

        [JsonProperty("article")]
        public Article _Article { get; set; }

        [JsonProperty("likes")]
        public string LikeCount { get; set; }
    }


    public class Archive
    {
        [JsonProperty("view")]
        public string View { get; set; }
    }

    public class Article
    {
        [JsonProperty("view")]
        public string View { get; set; }
    }
}
