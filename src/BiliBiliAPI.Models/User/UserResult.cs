using BiliBiliAPI.Models.Account;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.User
{
    public class FavouritesData
    {
        /// <summary>
        /// 收藏夹详情
        /// </summary>
        [JsonProperty("list")]
        public List<FavoritesDataList> List { get; set; }

        /// <summary>
        /// 收藏夹总数量
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class FavoritesDataList
    {
        /// <summary>
        /// 收藏ID，收藏夹原始id+创建者mid尾号2位
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 收藏夹原始ID
        /// </summary>
        [JsonProperty("fid")]
        public string Fid { get; set; }

        /// <summary>
        /// 创建者Mid
        /// </summary>
        [JsonProperty("mid")]
        public string Mid { get; set; }

        /// <summary>
        /// 不明
        /// </summary>
        [JsonProperty("attr")]
        public string attr { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 查找一个视频号是否存在于某个收藏夹，存在则是1，不存在为0
        /// </summary>
        [JsonProperty("fav_state")]
        public string FavState { get; set; }

        /// <summary>
        /// 收藏夹中视频的数量
        /// </summary>
        [JsonProperty("media_count")]
        public string Media_Count { get; set; }
    }


    public class FavoriteData: FavoritesDataList
    {
        /// <summary>
        /// 封面
        /// </summary>
        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("upper")]
        public Upper Upper { get; set; }

        /// <summary>
        /// 封面图类别
        /// </summary>
        [JsonProperty("cover_type")]
        public string Conver_Type { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("intro")]
        public string By { get; set; }

        /// <summary>
        /// 创建时间，为时间戳，tick类型
        /// </summary>
        [JsonProperty("ctime")]
        public long Ctime { get; set; }


        /// <summary>
        /// 收藏时间，为时间戳，tick类型
        /// </summary>
        [JsonProperty("mtime")]
        public long Mtime { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("fav_state")]
        public string Fav_State { get; set; }

        [JsonProperty("like_state")]
        public string Like_State { get; set; }

        /// <summary>
        /// 收藏夹点赞收藏播放详细信息
        /// </summary>
        [JsonProperty("cnt_info")]
        public cnt_info Cnt_info { get; set; }
    }

    public class MediasItem
    {
        [JsonProperty("info")]
        public FavoriteData Info { get; set; }
        [JsonProperty("medias")]
        public List<Favorite_MediasItem> Items { get; set; }
        [JsonProperty("has_more")]
        public bool Has_More { get; set; }
    }

    public class Favorite_MediasItem: FavoriteData
    {
        [JsonProperty("id")]
        public int ID { get; set; }


        [JsonProperty("type")]
        public int Type { get; set; }


        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 视频分P数量
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// 音频或视频时长
        /// </summary>
        [JsonProperty("duration")]
        public int duration { get; set; }

        /// <summary>
        /// 跳转URL
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }


        /// <summary>
        /// 收藏时间
        /// </summary>
        [JsonProperty("fav_time")]
        public int Fav_Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bv_id")]
        public string BV_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bvid")]
        public string BVID { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("ogv")]
        public string ogv { get; set; }


        [JsonProperty("ugc")]
        public Ugc ugc { get; set; }

    }

    public class Ugc
    {
        /// <summary>
        /// 第一P视频的cid
        /// </summary>
        public int first_cid { get; set; }

    }


    public class cnt_info
    {
        /// <summary>
        /// 收藏夹被收藏的数量
        /// </summary>
        [JsonProperty("collect")]
        public string collect { get; set; }

        /// <summary>
        /// 收藏夹被播放的数量，不包含本人
        /// </summary>
        [JsonProperty("play")]
        public string Play { get; set; }

        /// <summary>
        /// 收藏夹被点赞数量，不包括本人
        /// </summary>
        [JsonProperty("thumb_up")]
        public string Likes { get; set; }

        /// <summary>
        /// 收藏夹分享数量，不包含本人
        /// </summary>
        [JsonProperty("share")]
        public string Share { get; set; }
    }


    public class Upper
    {
        [JsonProperty("mid")]
        public string Mid { get; set;}

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("face")]
        public string Face { get; set; }

        [JsonProperty("followed")]
        public string Followed { get; set; }

        /// <summary>
        /// 会员类别，0无会员，1月度会员，2年度及以上会员
        /// </summary>
        [JsonProperty("vip_type")]
        public string VIP { get; set; }

        /// <summary>
        /// 会员开通状态，1为正常，0为不正常
        /// </summary>
        [JsonProperty("vip_statue")]
        public string Vip_Statue { get; set; }
    }


    public class UpData
    {
        [JsonProperty("mid")]public string Mid { get; set; } = ""; 
        [JsonProperty("name")]public string Name { get; set; } = "";
        [JsonProperty("sign")] public string Sign { get; set; } = "";

        /// <summary>
        /// 硬币数量
        /// </summary>
        [JsonProperty("coins")] public string Conins { get; set; } = "";

        /// <summary>
        /// 生日
        /// </summary>
        [JsonProperty("birthday")] public string Birthday { get; set; } = "";

        /// <summary>
        /// 头像链接
        /// </summary>
        [JsonProperty("face")] public string Face_Image { get; set; } = "";


        /// <summary>
        /// 性别，文字
        /// </summary>
        [JsonProperty("sex")] public string Sex { get; set; } = "";




        /// <summary>
        /// 用户是否被封禁，0为正常，1为封禁
        /// </summary>
        [JsonProperty("silence")] public string Silence { get; set; } = "";

        /// <summary>
        /// 大会员信息
        /// </summary>
        [JsonProperty("vip")] public Vip MyVIp { get; set; } = new Vip();


        /// <summary>
        /// 经验信息
        /// </summary>
        [JsonProperty("level_info")] public Level_Exp Exp { get; set; }


        [JsonProperty("level")] public int Level { get; set; }

        [JsonProperty("face_nft")] public bool FaceNft { get; set; }

        [JsonProperty("top_photo")] public string Top_Photo { get; set; }

        [JsonProperty("fans_badge")] public string Fans_Badge { get; set; }

        [JsonProperty("fans_medal")] public FansMedal Fans_Medal { get; set; }

        [JsonProperty("official")] public Official OfficialP { get; set; }

        [JsonProperty("school")] public School School{get;set;}
    }
    public class School
    {
        [JsonProperty("name")]public string Name { get; set; }  
    }
    public class FansMedal
    {
        [JsonProperty("show")]public bool Show { get; set; }
        [JsonProperty("wear")]public bool Wear { get; set; }

        [JsonProperty("medal")]public Fans_Medal medal { get; set; }
    }

    public class Fans_Medal
    {
        /// <summary>
        /// 自己的mid
        /// </summary>
        [JsonProperty("mid")]public int Mid { get; set; }

        /// <summary>
        /// 被粉的up主mid
        /// </summary>
        [JsonProperty("target_id")]public int UpMid { get; set; }

        /// <summary>
        /// 粉丝勋章等级
        /// </summary>
        [JsonProperty("medal_id")]public int FattorMid { get; set; }

        /// <summary>
        /// 粉丝勋章等级
        /// </summary>
        [JsonProperty("level")]public int TargetLevel { get; set; }

        /// <summary>
        /// 粉丝勋章名称
        /// </summary>
        [JsonProperty("medal_name")]public string Name { get; set; }

        [JsonProperty("medal_color")]public string Color { get; set; }

        /// <summary>
        /// 当前经验值
        /// </summary>
        [JsonProperty("intimacy")]public int LiveLevel { get; set; }

        /// <summary>
        /// 粉丝勋章升级到下一级的经验值
        /// </summary>
        [JsonProperty("next_intimacy")]public int NextLiveLevel { get; set; }

        /// <summary>
        /// 每日亲密度上线
        /// </summary>
        [JsonProperty("day_limit")]public int DayLimit { get; set; }

        /// <summary>
        /// 今日获得的亲密度
        /// </summary>
        [JsonProperty("today_feed")]public int DayFeedOk { get; set; }

        /// <summary>
        /// 是否穿戴该勋章
        /// </summary>
        [JsonProperty("wearing_status")]public int IsWearing { get; set; }
    }
}
