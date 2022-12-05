using BiliBiliAPI.ApiTools;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Search;
using BiliBiliAPI.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Search
{
    public class PublicSearch
    {
        HttpTools HttpClient = new HttpTools();
        /// <summary>
        /// 自带参数搜索
        /// </summary>
        /// <param name="query">参数</param>
        /// <param name="uri">目标主机</param>
        /// <returns></returns>
        public async Task<string> Search(string query, bool isacceyc = false,string uri= "https://app.bilibili.com/x/v2/search")
        {
             return await HttpClient.GetResults(uri + query, HttpTools.ResponseEnum.App,null,isacceyc, "&mobi_app=iphone&platform=ios&build=5520400");
        }

        /// <summary>
        /// 搜索视频
        /// </summary>
        /// <param name="KeyWord">关键字</param>
        /// <param name="PageSize">页数</param>
        /// <param name="order">排序方式</param>
        /// <param name="duration">时长</param>
        /// <returns></returns>
        public async Task<ResultCode<SearchVideo>> GetVideo(string KeyWord, int PageSize, OrderBy order, int duration)
        {
            var value = await Search($"?keyword={KeyWord}&pn={PageSize}&order={GetOrder(order)}&ps=20&duration={duration}&device=phone&mobi_app=iphone");
            
            var result =  JsonConvert.ReadObject<SearchVideo>(value);

            return result;
        }

        private string GetOrder(OrderBy order)
        {
            switch (order)
            {
                case OrderBy.Default:
                    return "default";
                case OrderBy.view:
                    return "view";
                case OrderBy.pubdate:
                    return "pubdate";
                case OrderBy.danmaku:
                    return "danmaku";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 搜索番剧
        /// </summary>
        /// <param name="KeyWord">番剧关键字</param>
        /// <param name="PageSize">页数</param>
        /// <returns></returns>
        public async Task<ResultCode<SearchAnimation_Movie>> SearchAnimation(string KeyWord,int PageSize)
        {
            var value =  await Search($"?keyword={KeyWord}&pn={PageSize}&ps=20&type=7&build=5520400",false, "https://app.bilibili.com/x/v2/search/type");

            var result =  JsonConvert.ReadObject<SearchAnimation_Movie>(value);
            if(result.Data.Items != null)
            {
                foreach (var item in result.Data.Items)
                {
                    if (item.Episodes == null)
                        continue;
                    if (item.Episodes.Count > 25)
                    {
                        item.Episodes = item.Episodes.Take(26).ToList();
                    }
                }
            }
            return result;
        }

        

        public async Task<ResultCode<SearchAnimation_Movie>> SearchMovie(string keyword,int PageSize)
        {
            var value = await Search($"?keyword={keyword}&pn={PageSize}&ps=20&type=8&build=5520400",false, "https://app.bilibili.com/x/v2/search/type");
            return JsonConvert.ReadObject<SearchAnimation_Movie>(value);
        }
    }
}
