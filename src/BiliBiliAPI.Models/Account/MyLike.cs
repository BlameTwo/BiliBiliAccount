using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Account
{
    /// <summary>
    /// 关注数量
    /// </summary>
    public class MyFollow
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("ttl")]
        public string TTl { get; set; }

        [JsonProperty("data")]
        public MyFolloweData Data { get; set; }
    }

    public class MyFolloweData
    {
        /// <summary>
        /// 关注数量
        /// </summary>
        [JsonProperty("following")]
        public string following { get; set; }

        /// <summary>
        /// 悄悄地关注数量
        /// </summary>
        [JsonProperty("whisper")]
        public string Whisper { get; set; }

        /// <summary>
        /// 黑名单
        /// </summary>
        [JsonProperty("black")]
        public string Black { get; set; }

        /// <summary>
        /// 粉丝数量
        /// </summary>
        [JsonProperty("follower")]
        public string Follower { get; set; }
    }
}
