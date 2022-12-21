using BiliBiliAPI.Models.Account.Dynamic;
using BiliBiliAPI.Models.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Account
{
    /// <summary>
    /// 内容太多不好分析
    /// </summary>
    public class SpaceData
    {
        [JsonProperty("card")]public UpData SpaceCard { get; set; }

        [JsonProperty("images")] public Images Images { get; set; }
        [JsonProperty("live")] public Live Live { get; set; }

        [JsonProperty("archive")] public SpaceArchive SpaceArchive{get;set;}

        [JsonProperty("series")] public SpaceSeries SpaceSeries { get; set; }

        [JsonProperty("guard")]public SpaceGuard SpaceGuard { get; set; }

        [JsonProperty("elec")]public SpaceElec SpaceElec { get; set; }

        [JsonProperty("ugc_season")]public Space_UGC_Season Space_UGC_Season { get; set; }
    }


    

}
public class Space_UGC_Season
{
    [JsonProperty("count")] public int Count { get; set; }
    [JsonProperty("item")] public List<Space_UGC_Season_Item> Space_UGC_Season_Items { get; set; }

}
public class Space_UGC_Season_Item
{
    [JsonProperty("season_id")]public string Season_id { get; set; }

    [JsonProperty("title")]public string Title { get; set; }

    [JsonProperty("cover")]public string Cover { get; set; }

    [JsonProperty("param")]public string Param { get; set; }

    [JsonProperty("goto")]public string Goto { get; set; }

    [JsonProperty("length")]public string Length { get; set; }

    [JsonProperty("duration")]public string Duration { get; set; }

    [JsonProperty("play")]public long Play { get; set; }

    [JsonProperty("danmaku")]public string Danmaku { get; set; }

    [JsonProperty("count")]public string Count { get; set; }

    [JsonProperty("mtime")]public string MTime { get; set; }
}

public class SpaceElec
{
    [JsonProperty("count")] public int Count { get; set; }

    [JsonProperty("show")] public bool Show { get; set; }

    [JsonProperty("list")] public List<SpaceElecItem> List { get; set; }
}

public class SpaceElecItem
{
    [JsonProperty("pay_mid")] public string Pay_Mid { get; set; }

    [JsonProperty("rank")] public string Rank { get; set; }

    [JsonProperty("mid")] public string Mid { get; set; }

    [JsonProperty("uname")] public string Name { get; set; }

    [JsonProperty("avatar")] public string Cover { get; set; }

    [JsonProperty("vip_info")] public SpaceElecItemVipInfo VipInfo { get; set; }
}

public class SpaceElecItemVipInfo
{
    [JsonProperty("vipType")] public int VipType { get; set; }

    [JsonProperty("vipStatus")] public int VipStatus { get; set; }

    [JsonProperty("vipDueMsec")] public int vipDueMsec { get; set; }
}

public class SpaceArchive
{
    [JsonProperty("item")] public List<SpaceArchiveItem> Items { get; set; }
}
public class SpaceArchiveItem
{
    [JsonProperty("title")] public string Title { get; set; }

    [JsonProperty("subtitle")] public string SubTitle { get; set; }

    [JsonProperty("tname")] public string TName { get; set; }

    [JsonProperty("cover")] public string Cover { get; set; }

    [JsonProperty("param")] public string Aid { get; set; }

    [JsonProperty("goto")] public string GoTo { get; set; }

    [JsonProperty("duration")] public int Duration { get; set; }

    [JsonProperty("is_popular")] public bool IsPopular { get; set; }

    [JsonProperty("is_steins")] public bool IsSteins { get; set; }

    [JsonProperty("play")] public string Play { get; set; }
    [JsonProperty("danmaku")] public string Danmaku { get; set; }

    [JsonProperty("ctime")] public long CreateTime { get; set; }

    [JsonProperty("author")] public string UpName { get; set; }
}

public class SpaceSeries
{
    [JsonProperty("item")] public List<SpaceSeriesItem> SpaceSeriesItems { get; set; }
}

public class SpaceSeriesItem
{
    [JsonProperty("series_id")] public string ID { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

}

public class SpaceGuard
{
    [JsonProperty("desc")] public string Desc { get; set; }
    [JsonProperty("item")] public List<SpaceGuardItem> Item { get; set; }
}

public class SpaceGuardItem
{
    [JsonProperty("mid")] public string Mid { get; set; }

    [JsonProperty("face")] public string Face { get; set; }
}

public class Live
{
    [JsonProperty("link")] public string Link { get; set; }
    [JsonProperty("url")] public string Url { get; set; }

    [JsonProperty("title")] public string Title { get; set; }
    [JsonProperty("liveStatus")] public int LiveStatus { get; set; }

    [JsonProperty("cover")] public string Cover { get; set; }

    [JsonProperty("roomid")] public string RoomId { get; set; }

    [JsonProperty("online")] public int OnLine { get; set; }

    [JsonProperty("online_hidden")] public int OnLine_Hidden { get; set; }
}

public class Images
{
    [JsonProperty("imgUrl")] public string BackImage { get; set; }

    [JsonProperty("night_imgurl")] public string Night_BackImage { get; set; }
}


public class SeriesData
{
    [JsonProperty("next")] public int Next { get; set; }

    [JsonProperty("item")]public List<SeriesDataItem> Item { get; set; }
}

public class SeriesDataItem :
    SpaceArchiveItem
{
    [JsonProperty("first_cid")]public int First_Cid { get; set; }

    [JsonProperty("bvid")]public string Bvid { get; set; }
}