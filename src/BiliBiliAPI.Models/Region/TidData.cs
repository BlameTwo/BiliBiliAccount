using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Region
{
    public class TidList
    {

        public List<TidData> Data { get; set; }
    }

    public class TidData: TidDataBase
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("children")]
        public List<TidDataBase> Children { get; set; } 

        /// <summary>
        /// 是否为动画相关
        /// </summary>
        [JsonProperty("is_bangumi")]
        public string IsAnimation { get; set; }
    }

    public class TidDataBase
    {
        [JsonProperty("tid")]
        public string Tid { get; set; }

        [JsonProperty("reid")]
        public string Region { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("goto")]
        public string GoTo { get; set; }

        [JsonProperty("param")]
        public string Param { get; set;  }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
