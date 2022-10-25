using BiliBiliAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.TopVideos
{
    public class TopListVideo
    {
        MyHttpClient HttpClient = new MyHttpClient();

        public async Task<ResultCode<BiliBiliAPI.Models.TopList.Videos>> GetTopVideo(Cid cid,int day)
        {
            string Url = "";
            if (cid == Cid.All)
            {
                Url = $"https://api.bilibili.com/x/web-interface/ranking/v2?rid=0&type=all";
            }
            else
            {
                Url = $"https://api.bilibili.com/x/web-interface/ranking/v2?rid={(int)cid}&day={day}";
            }
            
            return JsonConvert.ReadObject<BiliBiliAPI.Models.TopList.Videos>(await HttpClient.GetResults(Url));
        }
    }
}
