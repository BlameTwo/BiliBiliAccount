using BiliBiliAPI.Models.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BiliBiliAPI.Region
{
    public class TidRegion
    {
        MyHttpClient HttpClient = new MyHttpClient();


        public async Task<TidList> GetTidIcon()
        {
            string url = "https://app.bilibili.com/x/v2/region/index?build=5520400";
            return JsonConvert.Deserialize<TidList> (await HttpClient.GetResults(url, null, "&mobi_app=android&platform=android", false));
        }
    }
}
