﻿using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.User;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.User
{
    /// <summary>
    /// 用户面板信息
    /// </summary>
    public class Users
    {
        ///
        private MyHttpClient HttpClient = new MyHttpClient();

        /// <summary>
        /// 获得用户的基本信息
        /// </summary>
        /// <param name="mid">用户的mid</param>
        /// <returns></returns>
        public async Task<ResultCode<AccountLoginResultData>> GetUser(string mid)
        {
            string url = $"http://api.bilibili.com/x/space/acc/info?mid={mid}";
            return JsonConvert.ReadObject<AccountLoginResultData>(await HttpClient.GetResults(url));
        }


        public async Task<ResultCode<FavouritesData>> GetFavourites(string aid = "")
        {
            if(BiliBiliArgs.TokenSESSDATA != null)
            {
                string url = $"http://api.bilibili.com/x/v3/fav/folder/created/list-all?up_mid={BiliBiliArgs.TokenSESSDATA.Mid}&rid={aid}";
                return JsonConvert.ReadObject<FavouritesData>(await HttpClient.GetResults(url));
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


        public async Task<ResultCode<FavoriteData>> GetFavourite(FavoritesDataList Data)
        {
            var url = $"http://api.bilibili.com/x/v3/fav/folder/info?media_id={Data.ID}";
            return JsonConvert.ReadObject<FavoriteData>(await HttpClient.GetResults(url));  
        }

        public async Task<ResultCode<MediasItem>> GetFavMedios(FavoritesDataList Data, int pagesize)
        {
            string url = $"http://api.bilibili.com/x/v3/fav/resource/list?media_id={Data.ID}&ps={pagesize}";
            return JsonConvert.ReadObject<MediasItem>(await HttpClient.GetResults(url));
        }
    }
}