using BiliBiliAPI.Models.Videos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.TopList
{
    public class EveryoneList
    {
        [JsonProperty("list")]
        public List<EveryoneWeakData> List { get; set; }
    }

    public class EveryoneWeakData
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        /// 每周的霸榜
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }


    public class WeakItem
    {
        [JsonProperty("config")]
        public Config Config { get; set; }

        [JsonProperty("reminder")]
        public string Title { get; set; }

        [JsonProperty("list")]
        public List<WeakItemData> Items { get; set; }
    }

    public class Config
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("subject")]
        public string SubJect { get; set; }

        [JsonProperty("stime")]
        public string Stime { get; set; }

        [JsonProperty("etime")]
        public string Etime { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("name")]
        public string  Name { get; set; }

        [JsonProperty("lable")]
        public string Lable { get; set; }

        [JsonProperty("hint")]
        public string Hint { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("share_title")]
        public string Title { get; set; }

        [JsonProperty("share_subtitle")]
        public string Title2 { get; set; }

        [JsonProperty("media_id")]
        public string MMID { get; set; }
    }

    public class WeakItemData : VideosContent
    {
        [JsonProperty("rcmd_reason")]
        public string Bottom_Text { get; set; }


        [JsonProperty("pub_location")]
        public string IP_Loaction { get; set; }
    }
}
