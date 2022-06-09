using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.Models
{
    public class AccountLoginArg
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("ts")]
        public string Ts { get; set; }

        [JsonProperty("data")]
        public AccountLoginData Data { get; set; }
    }

    public class AccountLoginData
    {
        [JsonProperty("url")]
        public string PicUrl { get; set; }

        [JsonProperty("oauthKey")]
        public string QRKey { get; set; }
    }
}
