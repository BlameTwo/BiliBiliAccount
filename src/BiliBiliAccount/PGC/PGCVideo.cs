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
    public class PGCVideo
    {
        private HttpTools HttpClient = new HttpTools();
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
    }
    public enum PGCVideoEnum
    {
        EPID, Cid
    }
}
