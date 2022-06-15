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
        /// <param name="query"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<object> Search(string query,string uri= "http://api.bilibili.com/x/web-interface/search/type")
        {
            return await HttpClient.GetResults(uri + query);
        }

        /// <summary>
        /// 搜索视频
        /// </summary>
        /// <param name="KeyWord">关键字</param>
        /// <param name="pagesize">页数</param>
        /// <param name="Order">排序方式</param>
        /// <param name="Duration">时长：All:0  <10min:1  10-30min:2  30min-1hour:3    >1hour:4</param>
        /// <param name="Tids">视频的分区</param>
        /// <returns></returns>
        public async Task<object> SearchVideo(string KeyWord, string pagesize,string Order=null, string Duration = null, string Tids = null)
        {
            return await Search($"?search_type=video&keyword={KeyWord}&order={Order}&duration={Duration}&tids={Tids}&page={pagesize}");
        }

        /// <summary>
        /// 搜索番剧，不分国产和海外
        /// </summary>
        /// <param name="KeyWord">关键字</param>
        /// <param name="PageSize">页数</param>
        /// <returns></returns>
        public async Task<object> SearchAnimation(string KeyWord,string PageSize)
        {
            return await Search($"?search_type=media_bangumi&keyword={KeyWord}&page={PageSize}");
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
