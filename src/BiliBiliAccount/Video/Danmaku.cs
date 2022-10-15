using BilibiliAPI.ApiTools;
using BiliBiliAPI.Models.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.Video
{
    public class Danmaku
    {
        public async Task<DanmakuText> GetDanmakuTest(string cid)
        {
            string url = $"http://comment.bilibili.com/{cid}.xml";
            return await XmlConvert.GetXml<DanmakuText>(ApiProvider.GetHtml(url));
        }
    }
}
