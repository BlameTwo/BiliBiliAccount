using BiliBiliAPI.Models;
using BiliBiliAPI.Models.TopList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.TopLists
{
    public class MustWatch
    {
        MyHttpClient HttpClient = new();

        public async Task<ResultCode<MustWatchData>> GetVideos()
        {
            string url = "https://api.bilibili.com/x/web-interface/popular/precious";

            return JsonConvert.ReadObject<MustWatchData>( await HttpClient.GetResults(url));
        }
    }
}
