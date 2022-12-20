using Newtonsoft.Json;

namespace BiliBiliAPI.Models.PGC;

public class PGCFollowData
{
    [JsonProperty("code")]public string Code { get; set; }

    [JsonProperty("message")]public string Message { get; set; }

    [JsonProperty("result")]public PGCFollowResult Result { get; set; }
}

public class PGCFollowResult
{
    [JsonProperty("fmid")] public int Fmid { get; set; }

    [JsonProperty("relation")] public bool Relation { get; set; }

    [JsonProperty("reverse_live_res")] public int reverse_live_res { get; set; }

    [JsonProperty("status")] public int Status { get; set; }

    [JsonProperty("toast")] public string Toast { get; set; }
}