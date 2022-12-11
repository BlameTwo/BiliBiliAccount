using BiliBiliAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Movie
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

        public enum PGCEnum
        {
            SSID,
            EPID,
        }
    }
}
