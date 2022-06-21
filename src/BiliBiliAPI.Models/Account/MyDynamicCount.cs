using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Account
{
    public class MyDynamicCount
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("ttl")]
        public string TTl { get; set; }

        [JsonProperty("data")]
        public MyDynamicCountData Data { get; set; }
    }

    public class MyDynamicCountData
    {
        /// <summary>
        /// 我的关注数量
        /// </summary>
        [JsonProperty("following")]
        public string Following { get; set; }

        /// <summary>
        /// 粉丝数量
        /// </summary>
        [JsonProperty("follower")]
        public string Follower { get; set; }

        /// <summary>
        /// 发布的动态数量
        /// </summary>
        [JsonProperty("dynamic_count")]
        public string Dynamic_count { get; set; }
    }
}
