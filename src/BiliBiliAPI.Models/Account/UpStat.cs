using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Account
{
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
