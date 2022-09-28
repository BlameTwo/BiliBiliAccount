using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Account
{

    public class MyTipsData
    {
        /// <summary>
        /// 未读数量
        /// </summary>
        [JsonProperty("at")]
        public string Count { get; set; }
        /// <summary>
        /// 未读点赞
        /// </summary>
        [JsonProperty("like")]
        public string Like { get; set; }

        /// <summary>
        /// 未读回复
        /// </summary>
        [JsonProperty("reply")]
        public string Reply { get; set; }

        /// <summary>
        /// 未读系统信息
        /// </summary>
        [JsonProperty("sys_msg")]
        public string Sys_Message { get; set; }


        /// <summary>
        /// Up助手信息
        /// </summary>
        [JsonProperty("up")]
        public string Up_Message { get; set; }
    }
}
