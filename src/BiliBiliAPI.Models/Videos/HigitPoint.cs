using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Videos
{
    /// <summary>
    /// 高能进度条
    /// </summary>
    public class HigitPoint
    {
        /// <summary>
        /// 采样视频的间隔时间
        /// </summary>
        [JsonProperty("step_sec")]
        public string Sec { get; set; }

        /// <summary>
        /// 作用尚不明确
        /// </summary>
        [JsonProperty("tagstr")]
        public string Tag { get; set; }

        /// <summary>
        /// 高能进度条数据
        /// </summary>
        [JsonProperty("events")]
        public  Event Event { get; set; }
    }

    public class Event
    {
        [JsonProperty("default")]
        public List<long> Defaults { get; set; }
    }
}
