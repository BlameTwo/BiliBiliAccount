using BiliBiliAPI.ApiTools;
using BiliBiliAPI.Models.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Video
{
    public class Danmaku
    {
        public async Task<DanmakuText> GetDanmakuTest(string cid)
        {
            string url = $"{Apis.DANMAKUFILE}/{cid}.xml";
            return XmlConvert.GetXml<DanmakuText>(await ApiProvider.GetHtml(url));
        }


        public async Task<string> GetDanmakuString(string cid)
        {
            string url = $"http://comment.bilibili.com/{cid}.xml";
            return await ApiProvider.GetHtml(url);
        }

        public async Task<List<FormatDanmakuTextModel>> GetFormatDanmakuText(DanmakuText Text)
        {
            return await Task.Run(() =>
            {
                var list = new List<FormatDanmakuTextModel>();
                foreach (var item in Text.Texts)
                {
                    string[] format = item.P.Split(",");
                    FormatDanmakuTextModel model = new FormatDanmakuTextModel();
                    model.Time = double.Parse(format[0]);
                    model.DanmakuType = format[1];
                    model.FontSize = int.Parse(format[2]);
                    model.Color = int.Parse(format[3]);
                    model.CreateTime = int.Parse(format[4]);
                    model.DanmakuTypeSw = format[5];
                    model.MidHash = format[6];
                    model.Dmid = format[7];
                    model.Level = format[8];
                    model.Text = item.Text;
                    list.Add(model);
                }
                return list;
            });
        }

        
    }
}
