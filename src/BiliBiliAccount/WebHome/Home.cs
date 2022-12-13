using BiliBiliAPI.Models;
using BiliBiliAPI.Models.HomeVideo;
using BiliBiliAPI.Models.Search;
using BiliBiliAPI.Tools;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiliBiliAPI.WebHome;

public class WebHomeData
{
    HttpTools HttpTools = new();

    /// <summary>
    /// 新首页
    /// </summary>
    /// <param name="maxcount"></param>
    /// <returns></returns>
    public async Task<ResultCode<BiliBiliAPI.Models.HomeVideo.HomeData>> GetWebHomeVideo(int maxcount)
    {
        var model =  JsonConvert.ReadObject<HomeData>(await HttpTools.GetResults(Apis.WEB_HOME+ $"?fresh_idx=1&feed_version=V1&fresh_type=4&ps={maxcount}&plat=1", HttpTools.ResponseEnum.Web));
        foreach (var item in model.Data.Items)
        {
            if (string.IsNullOrWhiteSpace(item.Title))
            {
                model.Data.Items.Remove(item);
            }
        }
        return model;
    }
}

