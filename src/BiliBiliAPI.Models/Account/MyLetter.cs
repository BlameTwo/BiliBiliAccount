using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Account
{
    /// <summary>
    /// 私信
    /// </summary>
    public class MyLetterData
    {
        /// <summary>
        /// 未关注的人的私信数量
        /// </summary>
        [JsonProperty("unfollow_unread")]
        public string Unfollow_unread { get; set; }

        /// <summary>
        /// 已经关注的人的私信数量
        /// </summary>
        [JsonProperty("follow_unread")]
        public string Follow_unread { get; set; }

    }
}
