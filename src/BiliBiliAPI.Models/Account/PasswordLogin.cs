using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Account
{

    public class PasswordLoginData
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("url")]
        public string GoUrl { get; set; }


        [JsonProperty("cookie_info")]
        public string Cookie_Info { get; set; }


        [JsonProperty("token_info")]
        public string Token_Info { get; set; }

        [JsonProperty("sso")]
        public string SSO { get; set; }
    }
}
