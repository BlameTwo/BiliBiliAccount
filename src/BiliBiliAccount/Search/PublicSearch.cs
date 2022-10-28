using BilibiliAPI.ApiTools;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.Search
{
    public class PublicSearch
    {
        MyHttpClient HttpClient = new MyHttpClient();
        /// <summary>
        /// 自带参数搜索
        /// </summary>
        /// <param name="query">参数</param>
        /// <param name="uri">目标主机</param>
        /// <returns></returns>
        public async Task<string> Search(string query, bool isacceyc =true,string uri= "https://app.bilibili.com/x/v2/search")
        {
             return await HttpClient.GetResults(uri + query, ApiProvider.AndroidTVKey, "&mobi_app=iphone&order=totalrank&platform=ios", isacceyc);
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
            var value = await Search($"?keyword={KeyWord}&pn={PageSize}&order={GetOrder(order)}&ps=20&duration={duration}");
            return JsonConvert.ReadObject<SearchVideo>(value);
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


        public async Task<ResultCode<SearchAnimation>> SearchAnimation(string KeyWord,int PageSize)
        {
            var value =  await Search($"?keyword={KeyWord}&pn={PageSize}&ps=20&type=7&build=5520400",false, "https://app.bilibili.com/x/v2/search/type");

            return JsonConvert.ReadObject<SearchAnimation>(value);
        }

        /// <summary>
        /// 搜索专栏
        /// </summary>
        /// <param name="KeyWord">关键字</param>
        /// <param name="Order">排序方式</param>
        /// <param name="Category_id">分区筛选</param>
        /// <returns></returns>
        public async Task<object> SearchDocument(string KeyWord,string Order, string Category_id)
        {
            return await Search($"?search-type=article&keyword={KeyWord}&order={Order}&category_id={Category_id}");
        }
    }
}
