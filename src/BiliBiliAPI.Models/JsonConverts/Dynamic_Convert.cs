using BiliBiliAPI.Models.Account.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.JsonConverts
{
    public sealed class Dynamic_DrawItem_Convert : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            //只转换DrawItem类型
            if(objectType == typeof(DrawItem))
            {
                return true;
            }
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DrawItem drawItem = new() {Tags = new() };
            var jobj = serializer.Deserialize<JObject>(reader);
            drawItem.Width = int.Parse(jobj["width"].ToString());
            drawItem.Size = double.Parse(jobj["size"].ToString());
            drawItem.Height = int.Parse(jobj["height"].ToString());
            drawItem.Cover = jobj["src"].ToString();
            JArray ja = JArray.FromObject(jobj["tags"]);
            foreach (var tag in ja)
            {
                drawItem.Tags.Add(tag);
            }
            return drawItem;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public sealed class Dynamic_Desc_Convert : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if(objectType == typeof(DescNodes))
            {
                return true;
            }
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DescNodes drawItem = new();
            var jobj = serializer.Deserialize<JObject>(reader);
            drawItem.OrigeText = jobj["orig_text"].ToString();
            drawItem.Rid = jobj.GetValue("rid") == null?null:jobj["rid"].ToString();
            drawItem.Text = jobj["text"].ToString();
            drawItem.Type = jobj["type"].ToString();
            if(jobj.GetValue("emoji") != null)
            {
                Emoji emo = new Emoji();
                JObject jo = JObject.FromObject(jobj["emoji"]);
                emo.Cover = jo["icon_url"].ToString();
                emo.Text = jo["text"].ToString();
                emo.Size = jo["size"].ToString();
                emo.Type = jo["type"].ToString();
                drawItem.Emoji = emo;
            }
            return drawItem;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    
}