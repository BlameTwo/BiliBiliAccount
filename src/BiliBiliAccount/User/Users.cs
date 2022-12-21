using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.User;
using BiliBiliAPI.Tools;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.User
{
    /// <summary>
    /// 用户面板信息
    /// </summary>
    public class Users
    {
        ///
        private HttpTools HttpClient = new HttpTools();

        /// <summary>
        /// 获得用户的基本信息
        /// </summary>
        /// <param name="mid">用户的mid</param>
        /// <returns></returns>
        [Obsolete("此API仅限Web页面")]
        public async Task<ResultCode<UpData>> GetUser(string mid)
        {
            string url = $"{Apis.USER}?mid={mid}";
            var str = await HttpClient.GetResults(url, HttpTools.ResponseEnum.Web);
            return JsonConvert.ReadObject<UpData>(str);
        }

        public async Task<ResultCode<UpData>> GetMySession()
        {
            var str = await HttpClient.GetResults(Apis.MySESSION, HttpTools.ResponseEnum.App);
            return JsonConvert.ReadObject<UpData> (str);
        }


        public async Task<ResultCode<FavouritesData>> GetFavourites(string aid = "")
        {
            if(BiliBiliArgs.TokenSESSDATA != null)
            {
                string url = $"https://api.bilibili.com/x/v3/fav/folder/created/list-all?up_mid={BiliBiliArgs.TokenSESSDATA.Mid}&rid={aid}";
                return JsonConvert.ReadObject<FavouritesData>(await HttpClient.GetResults(url, HttpTools.ResponseEnum.App));
            }
            else
            {
                return new ResultCode<FavouritesData>()
                {
                    Code = "-400",
                    Message = "用户未登录"
                };
            }
        }

        /// <summary>
        /// 获得收藏夹元数据
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public async Task<ResultCode<FavoriteData>> GetFavourite(FavoritesDataList Data)
        {
            var url = $"https://api.bilibili.com/x/v3/fav/folder/info?media_id={Data.ID}";
            return JsonConvert.ReadObject<FavoriteData>(await HttpClient.GetResults(url, HttpTools.ResponseEnum.App));  
        }

        public async Task<ResultCode<MediasItem>> GetFavMedios(FavoritesDataList Data, int pagesize)
        {
            string url = $"https://api.bilibili.com/x/v3/fav/resource/list?media_id={Data.ID}&ps={pagesize}";
            return JsonConvert.ReadObject<MediasItem>(await HttpClient.GetResults(url, HttpTools.ResponseEnum.App));
        }
    }
}
