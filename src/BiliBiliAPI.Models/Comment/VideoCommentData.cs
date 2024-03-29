﻿using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.Account.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Comment;
public class VideoCommentData
{
    [JsonProperty("control")] public CommentControl Control { get; set; }

    [JsonProperty("replies")] public List<Comments> CommentLists { get; set; }
}

public class Comments
{
    [JsonProperty("rpid")] public string ID { get; set; }

    /// <summary>
    /// 获得回复评论的回调ID
    /// </summary>
    [JsonProperty("oid")] public string Oid { get; set; }


    [JsonProperty("replies")] 
    public List<Comments> CommentLists { get; set; }

    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("mid")] public string Mid { get; set; }

    [JsonProperty("root")] public long Root { get; set; }

    [JsonProperty("parent")] public long Parent { get; set; }
    [JsonProperty("dialog")] public long Dialog { get; set; }

    [JsonProperty("count")] public long Count { get; set; }

    [JsonProperty("rcount")] public long Rcount { get; set; }

    [JsonProperty("state")] public long State { get; set; }

    [JsonProperty("fansgrade")] public string Fansgrade { get; set; }

    [JsonProperty("attr")] public long Attr { get; set; }

    [JsonProperty("ctime")] public long CreateTime { get; set; }

    [JsonProperty("rpid_str")] public string ID_Str { get; set; }

    [JsonProperty("like")] public long Likes { get; set; }

    [JsonProperty("action")] public long Action { get; set; }

    [JsonProperty("member")] public CommentUp Up { get; set; }

    [JsonProperty("content")] public CommentContent Content { get; set; }

    [JsonProperty("reply_control")] public ReplyControl ReplyControl { get; set; }

    [JsonProperty("card_label")] public List<Comment_Card_label> CardLabel { get; set; }
}

[JsonConverter(typeof(Comment_Card_LabelConvert))]
public class Comment_Card_label
{
    public Comment_Card_labelItem Items { get; set; } = new();
}


public class Comment_Card_labelItem
{
    [JsonProperty("rpid")] public string Rpid { get; set; }
    [JsonProperty("text_content")] public string Content { get; set; }
}

public class Comment_Card_LabelConvert : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {

    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JObject jo = JObject.Load(reader);
        Comment_Card_label label = new Comment_Card_label();
        label.Items = new();
        label.Items.Content = (string)jo.GetValue("text_content") ?? "";
        label.Items.Rpid = (string)jo.GetValue("rpid") ?? "";
        return label;
    }

    public override bool CanConvert(Type objectType)
    {
        return true;
    }
}

public class ReplyControl
{
    [JsonProperty("up_like")] public bool UpLike { get; set; }

    [JsonProperty("sub_reply_entry_text")] public string SubReplayEntry { get; set; }

    [JsonProperty("sub_reply_title_text")] public string SubReplayTitle { get; set; }
    [JsonProperty("time_desc")] public string Time_Desc { get; set; }

    [JsonProperty("location")] public string Location { get; set; }
}

public class CommentUp
{
    [JsonProperty("mid")] public string Mid { get; set; }

    [JsonProperty("uname")] public string Name { get; set; }

    [JsonProperty("sex")] public string Sex { get; set; }

    [JsonProperty("sign")] public string Sign { get; set; }

    [JsonProperty("avatar")] public string Cover { get; set; }

    /// <summary>
    /// 楼层
    /// </summary>
    [JsonProperty("rank")] public string Rank { get; set; }

    [JsonProperty("face_nft_now")] public long FaceNFT { get; set; }

    [JsonProperty("is_senior_member")] public long is_senior_member { get; set; }

    [JsonProperty("level_info")] public Level_Exp Level { get; set; }

    [JsonProperty("pendant")] public Pendant Pendant { get; set; }

    [JsonProperty("nameplate")] public CommentNamePlate CommentNamePlate { get; set; }

    [JsonProperty("official_verify")] public Official_verify Official_Verify { get; set; }

    [JsonProperty("vip")] public CommentVip Vip { get; set; }

}


[JsonConverter(typeof(EmoteConvert))]
public class CommentContent
{
    [JsonProperty("message")] public string Message { get; set; }

    [JsonProperty("members")] public List<object> Members { get; set; }

    public Emote Emote { get; set; }

    [JsonProperty("max_line")] public long MaxLine { get; set; }
}

public class Emote
{

    public List<EmoteItem> Items { get; set; }
}

public class EmoteItem
{
    [JsonProperty("id")] public string ID { get; set; }

    [JsonProperty("package_id")] public string PackageID { get; set; }

    [JsonProperty("state")] public long State { get; set; }

    [JsonProperty("type")] public long Type { get; set; }

    [JsonProperty("attr")] public long Attr { get; set; }

    [JsonProperty("text")] public string Text { get; set; }

    [JsonProperty("url")] public string EmoteUrl { get; set; }

    [JsonProperty("meta")] public Meta Meta { get; set; }

    [JsonProperty("mtime")] public string Mtime { get; set; }

    [JsonProperty("jump_title")] public string JumpText { get; set; }
}

public class Meta
{
    [JsonProperty("size")] public string Size { get; set; }
}

public class EmoteConvert : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return true;
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JObject jo = JObject.Load(reader);
        CommentContent content = new()
        {
            Emote = new() { Items = new() }
        };
        content.MaxLine = (long)jo.GetValue("max_line");
        content.Message = (string)jo.GetValue("message");
        if (jo["emote"] == null) return content;        //这里设置一个出口表明没有表情包
        JObject emote = JObject.FromObject(jo["emote"]);
        foreach (var item in emote.Children())
        {
            foreach (var item2 in item.Children())
            {
                EmoteItem value = new EmoteItem()
                {
                    ID = (string)item2["id"],
                    PackageID = (string)item2["package_id"],
                    State = (long)item2["state"],
                    Type = (long)item2["type"],
                    Attr = (long)item2["attr"],
                    Meta = new()
                    {
                        Size = (string)item2["meta"]["size"]
                    },
                    Text = (string)item2["text"],
                    EmoteUrl = (string)item2["url"],
                    Mtime = (string)item2["mtime"],
                    JumpText = (string)item2["jump_title"]
                };
                content.Emote.Items.Add(value);
            }
        }
        return content;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}

public class CommentVip
{
    [JsonProperty("vipType")] public long VipType { get; set; }

    [JsonProperty("vipDueDate")] public long VipDate { get; set; }

    [JsonProperty("dueRemark")] public string Remark { get; set; }

    [JsonProperty("accessStatus")] public long AccessStatus { get; set; }

    [JsonProperty("vipStatus")] public long VipStatus { get; set; }

    [JsonProperty("vipStatusWarn")] public string VipStatusWarn { get; set; }

    [JsonProperty("themeType")] public long ThemeType { get; set; }

    [JsonProperty("label")] public Comment_Vip_Label Label { get; set; }


}

public class Comment_Vip_Label
{
    public string path { get; set; }

    public string text { get; set; }
    public string label_theme { get; set; }

    public string text_color { get; set; }

    public string bg_style { get; set; }

    public string bg_color { get; set; }

    public string border_color { get; set; }

    public bool use_img_label { get; set; }

    public string img_label_uri_hans { get; set; }
    public string img_label_uri_hant { get; set; }

    public string img_label_uri_hans_static { get; set; }

    public string img_label_uri_hant_static { get; set; }
}

public class CommentNamePlate
{
    [JsonProperty("nid")] public long Nid { get; set; }

    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("image")] public string Image { get; set; }

    [JsonProperty("image_small")] public string Small_Image { get; set; }

    [JsonProperty("level")] public string Level { get; set; }
    [JsonProperty("condition")] public string Condition { get; set; }

}

public class CommentControl
{
    [JsonProperty("root_input_text")]
    public string Title { get; set; }

    [JsonProperty("answer_guide_text")]
    public string SubTitle { get; set; }
}

public class CommentReturnData
{
    [JsonProperty("suc_pic")] public string Suc_Pic { get; set; }
    [JsonProperty("suc_toast")]public string Suc_Toast { get; set; }
}
