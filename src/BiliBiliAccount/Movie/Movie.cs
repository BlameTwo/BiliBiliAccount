using BiliBiliAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Movie
{
    public class Movie
    {
        HttpTools HttpClient = new HttpTools();
        /// <summary>
        /// 获得电影基本信息
        /// </summary>
        /// <param name="SSID">电影的Session_id</param>
        /// <returns></returns>
        public async Task<BiliBiliAPI.Models.Movie.Movie> GetMovie(string id,MovieEnum movieEnum)
        {

            string url = "";
            switch (movieEnum)
            {
                case MovieEnum.SSID:
                    url = $"{Apis.MOVIE_SESSION}?season_id={id}";
                    break;
                case MovieEnum.EPID:
                    url = $"{Apis.MOVIE_SESSION}?ep_id={id}";
                    break;
            }
            if(url != null)
            {
                return JsonConvert.Deserialize<BiliBiliAPI.Models.Movie.Movie>(await HttpClient.GetResults(url, HttpTools.ResponseEnum.App));
            }
            else
            {
                return null;
            }
        }

        public enum MovieEnum
        {
            SSID,
            EPID,
        }
    }
}
