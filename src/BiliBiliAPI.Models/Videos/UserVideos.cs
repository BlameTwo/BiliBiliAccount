using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Videos
{
    public class LikeToast
    {
        [JsonProperty("toast")]
        public string TipText { get; set; }
    }

    public class UserVideos
    {
        
    }
}
