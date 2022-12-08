
using BiliBiliAPI.Models.JsonConverts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Account.Dynamic
{
    public class DynamicData
    {
        [JsonProperty("has_more")]public bool IsMore { get; set; }
        [JsonProperty("offset")]public string OffSet { get; set; }

        [JsonProperty("update_num")]public int UpDateNum { get; set; }

        [JsonProperty("items")]public List<DynamicDataList> DynamicList { get; set; }
    }

    public class DynamicDataList
    {
        [JsonProperty("basic")]public DynamicList_Basic Basic { get; set; }
        [JsonProperty("id_str")]public string ID { get; set; }

        [JsonProperty("modules")]public DynamicList_Modules Modules { get; set; }
        [JsonProperty("type")]public string DynamicType { get; set; }

        [JsonProperty("visible")]public bool IsVisible { get; set; }
    }

    public class DynamicList_Modules
    {
        [JsonProperty("module_stat")]public Module_Stat State { get; set; }

        [JsonProperty("module_author")]public Module_Author Module_Author { get; set; }

        [JsonProperty("module_dynamic")]public Module_Dynamic Module_More { get; set; }
    }

    public class Module_Dynamic
    {
        [JsonProperty("additional")]public Additional Additional { get; set; }
        [JsonProperty("topic")]public object Topic { get; set; }

        [JsonProperty("desc")]public Module_Desc Desc { get; set; }

        [JsonProperty("major")]public Module_major Module_Major { get; set; }
    }

    public class Module_major
    {
        [JsonProperty("type")]public string Type { get; set; }

        [JsonProperty("draw")]public Major_Draw Draw { get; set; }

        [JsonProperty("archive")]public Major_Acrchive Major_Acrchive { get; set; }
    }

    public class Major_Acrchive
    {
        [JsonProperty("aid")]public string Aid { get; set; }

        [JsonProperty("bvid")]public string Bvid { get; set; }

        [JsonProperty("cover")]public string Cover { get; set; }

        [JsonProperty("desc")]public string Desc { get; set; }

        [JsonProperty("disable_preview")]public int DisablePreview { get; set; }

        [JsonProperty("duration_text")]public string Duration { get; set; }

        [JsonProperty("jump_url")]public string JumpUrl { get; set; }

        [JsonProperty("title")]public string Title { get; set; }

        [JsonProperty("type")]public int Type { get; set; }

        [JsonProperty("stat")]public AV_Stat State { get; set; }

    }

    public class AV_Stat
    {
        [JsonProperty("danmaku")]public string DanmakuCount { get; set; }
        [JsonProperty("play")]public string ViewCount { get; set; }

    }

    public class Major_Draw
    {
        [JsonProperty("id")]public string ID { get; set; }

        [JsonProperty("items")]public List<DrawItem> DrawItems { get; set; }
    }


    [JsonConverter(typeof(Dynamic_DrawItem_Convert))]
    public class DrawItem
    {
        [JsonProperty("height")]public int Height { get; set; }
        [JsonProperty("size")]public double Size { get; set; }
        [JsonProperty("src")]public string Cover { get; set; }
        [JsonProperty("width")]public int Width { get; set; }

        [JsonProperty("tags")]public List<object> Tags { get; set; }
    }

    public class Module_Desc
    {
        [JsonProperty("rich_text_nodes")]public List<DescNodes> Text_Nodes { get; set; } 
        [JsonProperty("text")]public string Text { get; set; }
    }

    [JsonConverter(typeof(Dynamic_Desc_Convert))]
    public class DescNodes
    {
        [JsonProperty("emoji")] public Emoji Emoji { get; set; }
        [JsonProperty("orig_text")] public string OrigeText { get; set; }
        [JsonProperty("rid")] public string Rid { get; set; }
        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("type")]public string Type { get; set; }
    }

    public class Emoji
    {
        [JsonProperty("icon_url")]public string Cover { get; set; }

        [JsonProperty("size")]public string Size { get; set; }

        [JsonProperty("text")]public string Text { get; set; }

        [JsonProperty("type")]public string Type { get; set; }
    }

    public class Additional
    {
        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("reserve")] public Reserve Reserve { get; set; }

    }

    public class Reserve
    {
        [JsonProperty("jump_url")]public string Jump_Url { get; set; }

        [JsonProperty("reserve_total")]public int Total { get; set; }

        [JsonProperty("rid")]public long Rid { get; set; }

        [JsonProperty("state")]public int State { get; set; }

        [JsonProperty("stype")]public int Stype { get; set; }

        [JsonProperty("title")]public string title { get; set; }

        [JsonProperty("up_mid")]public string Up_Mid { get; set; }

        [JsonProperty("desc1")]public Reserve_Desc Desc1 { get; set; }
        [JsonProperty("desc2")]public Reserve_Desc Desc2 { get; set; }
    }

    public class Reserve_Desc
    {
        [JsonProperty("style")]public int Style { get; set; }
        [JsonProperty("text")]public string Text { get; set; }
    }

    public class Module_Author
    {
        [JsonProperty("face")]public string Cover { get;set; }
        [JsonProperty("face_nft")]public bool Face_NFT { get; set; }
        [JsonProperty("following")]public bool Following { get; set; }

        [JsonProperty("jump_url")]public string JumpUrl { get; set; }

        [JsonProperty("lable")]public string Lable { get; set; }

        [JsonProperty("mid")]public string Mid { get; set; }

        [JsonProperty("name")]public string Name { get; set; }

        [JsonProperty("pub_action")]public string Dynamic_Message { get; set; }

        [JsonProperty("pub_location_text")]public string Pub_Location_Text { get; set; }
        [JsonProperty("pub_time")]public string Dynamic_Time { get; set; }

        [JsonProperty("pub_ts")]public string Dynamic_DateTime { get;set; }

        [JsonProperty("type")]public string UpType { get; set; }

        [JsonProperty("vip")]public Vip Vip { get; set; }

        [JsonProperty("official_verify")]public Official_verify Official_Verify { get; set; }

        [JsonProperty("pendant")]public Pendant Pendant { get; set; }
    }

    public class Pendant
    {
        [JsonProperty("expire")]public int Expire { get; set; }
        [JsonProperty("image")]public string Image { get; set; }
        [JsonProperty("image_enhance")]public string Image_Enhance { get; set; }
        [JsonProperty("name")]public string Name { get;set; }
        [JsonProperty("pid")]public string Pid { get; set; }
    }

    public class Official_verify
    {
        [JsonProperty("desc")]public string Desc { get;set; }

        [JsonProperty("type")]public int Type { get; set; }
    }

    public class Module_Stat
    {

        [JsonProperty("comment")]public Comment Comment { get; set; }

        [JsonProperty("forward")]public Comment Forward { get; set; }

        [JsonProperty("like")]public Like Like { get; set; }
    }

    public class Like:Comment
    {
        [JsonProperty("status")]public bool Status { get; set; }
    }

    public class Comment
    {
        [JsonProperty("count")]public int Count { get; set; }
        [JsonProperty("forbidden")]public bool Forbidden { get;set; }

    }

    public class DynamicList_Basic
    {
        [JsonProperty("comment_id_str")] public string BasicID { get; set; }

        [JsonProperty("comment_type")]public int CommentType { get; set; }

        [JsonProperty("rid_str")]public string Rid { get; set; }

        [JsonProperty("like_icon")]public Basic_Icon Icon { get; set; }
    }

    public class Basic_Icon
    {
        [JsonProperty("action_url")]public string ActionUid { get; set; }

        [JsonProperty("end_url")]public string EndUrl { get; set; }

        [JsonProperty("id")]public int ID { get; set; }

        [JsonProperty("start_url")]public string StartUrl { get; set; }
    }
}
