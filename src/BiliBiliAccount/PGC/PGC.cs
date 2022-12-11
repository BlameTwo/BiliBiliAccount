using BiliBiliAPI.Models;
using BiliBiliAPI.Models.PGC;
using BiliBiliAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.PGC
{
    public class PGC
    {
        HttpTools HttpClient = new HttpTools();

        /// <summary>
        /// 获得电影基本信息
        /// </summary>
        /// <param name="SSID">电影的Session_id</param>
        /// <returns></returns>
        public async Task<BiliBiliAPI.Models.PGC.PGC> GetPGC(string id,PGCEnum movieEnum)
        {

            string url = "";
            switch (movieEnum)
            {
                case PGCEnum.SSID:
                    url = $"{Apis.MOVIE_SESSION}?season_id={id}";
                    break;
                case PGCEnum.EPID:
                    url = $"{Apis.MOVIE_SESSION}?ep_id={id}";
                    break;
            }
            if(url != null)
            {
                return JsonConvert.Deserialize<BiliBiliAPI.Models.PGC.PGC>(await HttpClient.GetResults(url, HttpTools.ResponseEnum.App));
            }
            else
            {
                return null;
            }
        }

        public async Task<PGCVideoData> GetPGCVideo(Episodes pgccontent, PGCVideoEnum pGCVideoEnum, int dashEnum = 0, FnvalEnum fnvalEnum = FnvalEnum.FLV)
        {
            string key = pGCVideoEnum == PGCVideoEnum.Cid ? "cid" : "ep_id";
            string value = pGCVideoEnum == PGCVideoEnum.Cid ? pgccontent.Cid : pgccontent.Epid;
            string url = $"{Apis.GETPGCVIDEO}?{key}={value}&mid={BiliBiliArgs.TokenSESSDATA.Mid}&otype=json&platform=web&fnval=4048&fnver=0&fourk=1";
            if(dashEnum == 0)
                url += "&qn=64";
            else
                url +=$"qn={dashEnum}";
            return JsonConvert.Deserialize<PGCVideoData>(await HttpClient.GetResults(url, HttpTools.ResponseEnum.App));
        }
        
        public enum PGCVideoEnum
        {
            EPID, Cid
        }
        public enum PGCEnum
        {
            SSID,
            EPID,
        }
    }
}
