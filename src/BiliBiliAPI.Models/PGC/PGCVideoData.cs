using BiliBiliAPI.Models.Videos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.PGC
{
    public class PGCVideoData
    {
        [JsonProperty("code")]public int Code { get; set; }

        [JsonProperty("message")]public string Message { get; set; }

        [JsonProperty("result")]public PGCVideoResult Result { get; set; }
    }

    public class PGCVideoResult: VideoInfo
    {
        [JsonProperty("is_preview")]public int Is_Preview { get; set; }

        [JsonProperty("video_project")]public bool VideoProJect { get; set; }

        [JsonProperty("type")]public string Type { get; set; }

        /// <summary>
        /// 当前大会员状态，可以使用这个判断是否能播放流
        /// </summary>
        [JsonProperty("vip_status")]public int VipStatus { get; set; }

        [JsonProperty("vip_type")]public int Vip_Type { get; set; }

        [JsonProperty("record_info")]public RecordInfo Record_Info { get; set; }

        [JsonProperty("is_drm")]public bool IsDrm { get; set; }

        [JsonProperty("no_rexcode")]public int NoRexcode { get; set; }

        [JsonProperty("has_paid")] public bool Has_Paid { get; set; }

        [JsonProperty("status")]public int Status { get; set; }
    }

    public class RecordInfo
    {
        [JsonProperty("record_icon")]public string Icon { get; set; }

        [JsonProperty("record")]public string Record { get; set; }
    }
}
