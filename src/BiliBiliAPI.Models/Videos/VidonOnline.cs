using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Videos
{
    public class VidonOnline
    {
        [JsonProperty("total")]
        public string AllCount { get; set; }

        [JsonProperty("count")]
        public string AppCount { get; set; }

        [JsonProperty("show_switch")]
        public ShowSwitch ShowSwitch { get; set; }
        
    }

    public class ShowSwitch
    {
        [JsonProperty("total")]
        public bool Total { get; set; }

        [JsonProperty("count")]
        public bool Count { get; set; }
    }
}
