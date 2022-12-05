using BiliBiliAPI.ApiTools;
using BiliBiliAPI.Models;
using BiliBiliAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.TopVideos
{
    public class TopListVideo
    {
        HttpTools HttpClient = new HttpTools();

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
            var text = "device_name=iPad206&device=pad&bulid=6235200&mobi_app=iphone&platform=ios&pull=true";
            return JsonConvert.ReadObject<BiliBiliAPI.Models.TopList.Videos>(await HttpClient.GetResults(Url, HttpTools.ResponseEnum.App,null,true,text));
        }

        public async Task<ResultCode<BiliBiliAPI.Models.TopList.Videos>> GetTopVideo(int cid, int day)
        {
            string Url = "";
                Url = $"https://api.bilibili.com/x/web-interface/ranking/v2?rid={cid}&day={day}";
            var text = "device_name=iPad206&device=pad&bulid=6235200&mobi_app=iphone&platform=ios&pull=true";
            return JsonConvert.ReadObject<BiliBiliAPI.Models.TopList.Videos>(await HttpClient.GetResults(Url, HttpTools.ResponseEnum.App, null, true, text));
        }
    }
}
