﻿using BiliBiliAPI.Models.Videos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.TopList
{
    public class Videos
    {
        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("list")]
        public List<TopVideo> List { get; set; }
    }

    public class TopVideo: VideosContent
    {
        [JsonProperty("short_link")]
        public string Link { get; set; }

        [JsonProperty("short_link_v2")]
        public string Link_V2 { get; set; }

        [JsonProperty("first_frame")]
        public string First_Frame { get; set; }

        [JsonProperty("pub_location")]
        public string IP_City { get; set;}

        [JsonProperty("score")]
        public string Score { get; set; }

    }
}
