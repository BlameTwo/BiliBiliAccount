using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models
{
    public class AccountLoginResult
    {
        [JsonProperty("code")]
        public string Code { get; set; } = "";

        [JsonProperty("message")]
        public string Message { get; set; } = "";

        [JsonProperty("ttl")]
        public string Ttl { get; set; } = "";

        [JsonProperty("data")]
        public AccountLoginResultData Data { get; set; }
    }


    public class AccountLoginResultData
    {
        [JsonProperty("mid")]
        public string Mid { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 硬币数量
        /// </summary>
        [JsonProperty("coins")]
        public string Conins { get; set; }
        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("face")]
        public string Face_Image { get; set; }
        [JsonProperty("sex")]
        public string Sex { get; set; }
        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("silence")]
        public string Silence { get; set; }
        [JsonProperty("vip")]
        public Vip MyVIp { get; set; }

    }



    public class Vip
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("status")]
        public string Status {get;set;}

        [JsonProperty("label")]
        public VipLabel Label { get; set; }
        /// <summary>
        /// 大会员到期时间
        /// </summary>
        [JsonProperty("due_date")]
        public string Vip_Stop { get; set; }

    }

    public class Official
    {
        [JsonProperty("role")]
        public string Official_Type { get; set; }
        [JsonProperty("title")]
        public string Text { get; set; }
    }


    public class VipLabel
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("label_theme")]
        public string Vip_Type { get; set; }

        [JsonProperty("text_color")]
        public string Text_Fore { get; set; }

        [JsonProperty("bg_color")]
        public string Text_Back { get; set; }
    }

}
