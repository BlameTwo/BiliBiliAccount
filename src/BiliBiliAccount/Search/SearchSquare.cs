using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BiliBiliAPI.Search
{
    /// <summary>
    /// 搜索建议
    /// </summary>
    public class SearchSquare
    {
        MyHttpClient HttpClient = new();
        /// <summary>
        /// 获得热搜排行
        /// </summary>
        /// <param name="number">热搜最大限制</param>
        /// <returns></returns>
        public async Task<ResultCode<SearchHotRankData>> GetSearchHotRank(int number)
        {
            string url = $"https://api.bilibili.com/x/web-interface/search/square?limit={number}";
            return JsonConvert.ReadObject<SearchHotRankData>(await HttpClient.GetResults(url));
        }

        /// <summary>
        /// 搜索建议
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<SearchSuggestData> GetSearchSuggest(string keyword)
        {
            try
            {
                string url = $"https://s.search.bilibili.com/main/suggest?func=suggest&suggest_type=accurate&sub_type=tag&main_ver=v1&userid=108534711&bangumi_acc_num=1&special_acc_num=1&topic_acc_num=1&upuser_acc_num=3&tag_num=10&special_num=10&bangumi_num=10&upuser_num=3&term={keyword}&rnd=0.4120868569076672&buvid=3D0AE328BAD4804AE492C710221022160f0VHGRE8w0gPXftuGc3jQ&spmid=0";
                var result = JsonConvert.Deserialize<SearchSuggestData>(System.Text.RegularExpressions.Regex.Unescape(await HttpClient.GetStringAsync(url)));
                return result;
            }
            catch (Exception)
            {
                return null;
            }
           
        }
    }
}
