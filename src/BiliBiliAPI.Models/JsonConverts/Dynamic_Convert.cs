using BiliBiliAPI.Models.Account.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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

    public sealed class Dynamic_Live_Convert : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(Live_Content))
            {
                return true;
            }
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //真怪了，没办法序列化，只能老办法了，寄！
            //if (reader.Value == null) return null;
            //var value = serializer.Deserialize<Live_Content>(reader);
            //return value;
            if (reader.Value == null) return null;
            Live_Content live = new();
            JObject jo = JObject.Parse(reader.Value.ToString());
            live.Type = (int)jo["type"];
            JObject liveinfo = JObject.FromObject(jo["live_play_info"]);
            JObject Watch = JObject.FromObject(liveinfo["watched_show"]);
            live.LiveInfo = new Live_Info()
            {
                Parent_Area_ID = (int)liveinfo["parent_area_id"],
                AreaName = (string)liveinfo["parent_area_name"],
                Room_id = (string)liveinfo["room_id"],
                Live_Status = (int)liveinfo["live_status"],
                Room_Type = (int)liveinfo["room_type"],
                Link = (string)liveinfo["link"],
                LiveScreenType = (int)liveinfo["live_screen_type"],
                LiveStartTime = (string)liveinfo["live_start_time"],
                Room_PaidType = (int)liveinfo["room_paid_type"],
                Title = (string)liveinfo["title"],
                OnLine = (int)liveinfo["online"],
                Area_Name = (string)liveinfo["area_name"],
                Area_id = (int)liveinfo["area_id"],
                LiveID = (string)liveinfo["live_id"],
                Cover = (string)liveinfo["cover"],
                PlayType = (string)liveinfo["play_type"],
                Uid= (string)liveinfo["uid"],
                Watch_Show = new Watch_Show()
                {
                    Icon = (string)Watch["icon"],
                    Switch = (bool)Watch["switch"],
                    Num = (int)Watch["num"],
                    ViewCount = (string)Watch["text_small"],
                    ViewCountTwo = (string)Watch["text_large"],
                    IconLocation = (string)Watch["icon_location"],
                    Icon_Web = (string)Watch["icon_web"]
                }
            };
            return live;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}