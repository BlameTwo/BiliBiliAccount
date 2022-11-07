using BiliBiliAPI.Models;
using BiliBiliAPI.Models.TopList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.TopLists
{
    public class EveryoneWeak
    {
        MyHttpClient HttpClient = new MyHttpClient();
        /// <summary>
        /// 获得每周必看得每一期标题
        /// </summary>
        /// <returns></returns>
        public async Task<ResultCode<EveryoneList>> GetWeekList()
        {
            string url = "https://api.bilibili.com/x/web-interface/popular/series/list";
            return JsonConvert.ReadObject<EveryoneList>(await HttpClient.GetResults(url));
        }


        public async Task<ResultCode<WeekItem>> GetWeekTopList(int number)
        {
            string url = $"https://api.bilibili.com/x/web-interface/popular/series/one?number={number}";
            return JsonConvert.ReadObject<WeekItem>(await HttpClient.GetResults(url));
        }
    }
}
