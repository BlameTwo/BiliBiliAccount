using BiliBiliAPI.ApiTools;
using BiliBiliAPI.Models.Region;
using BiliBiliAPI.Tools;
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
        HttpTools HttpClient = new HttpTools();


        public async Task<TidList> GetTidIcon()
        {
            string url = $"{Apis.TID_ICON}?build={Current.Build}";
            return JsonConvert.Deserialize<TidList> (await HttpClient.GetResults(url, HttpTools.ResponseEnum.App,null,false, "&mobi_app=android&platform=android"));
        }
    }
}
