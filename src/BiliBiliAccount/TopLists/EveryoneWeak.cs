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
    public class EveryoneWeek
    {
        HttpTools HttpClient = new HttpTools();
        /// <summary>
        /// 获得每周必看得每一期标题
        /// </summary>
        /// <returns></returns>
        public async Task<ResultCode<EveryoneList>> GetWeekList()
        {
            return JsonConvert.ReadObject<EveryoneList>(await HttpClient.GetResults(Apis.EVERYWEEK_TITLE, HttpTools.ResponseEnum.App));
        }


        public async Task<ResultCode<WeekItem>> GetWeekTopList(int number)
        {
            return JsonConvert.ReadObject<WeekItem>(await HttpClient.GetResults(Apis.EVERYWEEK_VIDEOLIST+$"?number={number}", HttpTools.ResponseEnum.App));

        }
    }
}
