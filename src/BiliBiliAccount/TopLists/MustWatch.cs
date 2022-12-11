using BiliBiliAPI.Models;
using BiliBiliAPI.Models.TopList;
using BiliBiliAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.TopLists
{
    public class MustWatch
    {
        HttpTools HttpClient = new();

        public async Task<ResultCode<MustWatchData>> GetVideos()
        {

            return JsonConvert.ReadObject<MustWatchData>( await HttpClient.GetResults(Apis.MUSTWASATCH_LIST, HttpTools.ResponseEnum.App));
        }
    }
}
