using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models
{
    public class ResultCode<T>
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("ttl")]
        public string TTl { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }


    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class BiliTypeAttribute : System.Attribute
    {
        public Type Type;

        public BiliTypeAttribute(Type type)
        {
            this.Type = type;
        }
    }
}
