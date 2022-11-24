using BiliBiliAPI.Models.HomeVideo;
using BiliBiliAPI.Models.Videos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.TopList
{
    public class MustWatchData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("media_id")]
        public string Media_ID { get; set; }

        [JsonProperty("explain")]
        public string SubTitle { get; set; }

        [JsonProperty("list")]
        public List<MustWatchDataItem> List { get; set; }
    }

    public class MustWatchDataItem : VideosContent
    {
        [JsonProperty("achievement")]
        public string Subtitle { get; set; }

        [JsonProperty("")]
    }
}
