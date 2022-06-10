using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.Models
{
    public class AccountLoginResult
    {
        [JsonProperty("code")]
        public string Code { get; set; } = "";

        [JsonProperty("status")]
        public string Status { get; set; } = "";

        [JsonProperty("ts")]
        public string TS { get; set; } = "";
    }


    public class AccountLoginResultData
    {

    }
}
