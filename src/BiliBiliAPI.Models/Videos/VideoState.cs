using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BiliBiliAPI.Models.Videos
{
    public class VideoState
    {
        [JsonProperty("aid")]
        public string Aid { get; set; }

        [JsonProperty("view")]
        public int Views { get; set; }

        [JsonProperty("danmaku")]
        public int Danmaku { get; set; }

        [JsonProperty("reply")]
        public int Reply { get; set; }

        [JsonProperty("favorite")]
        public int Favorite { get; set; }

        [JsonProperty("coin")]
        public int Coin { get; set; }

        [JsonProperty("share")]
        public int Share { get; set; }

        /// <summary>
        /// 历史最高排行，没有排行为0
        /// </summary>
        [JsonProperty("his_rank")]
        public int His_rank { get; set; }

        [JsonProperty("like")]
        public int like { get; set; }

        /// <summary>
        /// 禁止转载，0为无，1为禁止
        /// </summary>
        [JsonProperty("no_reprint")]
        public int no_reprint { get; set; }

        /// <summary>
        /// 版权标志，1为自制，2为转载
        /// </summary>
        [JsonProperty("copyright")]
        public int copyright { get; set; }
    }
}
