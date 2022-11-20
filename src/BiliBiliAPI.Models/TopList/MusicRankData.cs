using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.TopList
{
    public class MusicRankData
    {
        [JsonProperty("music_id")]
        public string Music_ID { get; set; }

        [JsonProperty("music_title")]
        public string Title { get; set; }

        [JsonProperty("singer")]
        public string Singer { get; set; }

        [JsonProperty("album")]
        public string Album { get; set; }

        [JsonProperty("mv_aid")]
        public string MVAid { get; set; }

        [JsonProperty("mv_bvid")]
        public string MVBvid { get; set; }

        [JsonProperty("mv_cover")]
        public string MVCover { get; set; }

        [JsonProperty("heat")]
        public string Heat { get; set; }

        [JsonProperty("rank")]
        public string RankNumber { get; set; }

        [JsonProperty("can_listen")]
        public bool CanListen { get; set; }

        [JsonProperty("recommendation")]
        public string Recommand { get; set; }

        [JsonProperty("creation_aid")]
        public string CreateAid { get; set; }

        [JsonProperty("creation_bvid")]
        public string CreateBvid { get; set; }

        [JsonProperty("creation_cover")]
        public string CreateCover { get; set; }

        [JsonProperty("creation_title")]
        public string CreateTitle { get; set; }

        [JsonProperty("creation_up")]
        public string CreateUpDateTime { get; set; }

        [JsonProperty("creation_nickname")]
        public string CreateNickName { get; set; }

        [JsonProperty("creation_duration")]
        public int CreateDuration { get; set; }

        [JsonProperty("creation_play")]
        public string CreatePlay { get; set; }

        [JsonProperty("creation_reason")]
        public string CreateReason { get; set; }

        [JsonProperty("achievements")]
        public List<string> Achievements { get; set; }
    }

    public class MusicRankItem
    {
        [JsonProperty("list")]
        public List<MusicRankData> Items { get; set; }
    }
}
