using BilibiliAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BilibiliAPI
{
    public static class WebFormat
    {
        public static AccountToken UrlToClass(string url)
        {
            var utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(url);
            var myurl = utf8.GetString(utfBytes, 0, utfBytes.Length);
            Uri uri = new Uri(myurl);
            var collection = HttpUtility.ParseQueryString(uri.Query)!;
            var result = new AccountToken()
            {
                DedeUserId = collection["DedeUserID"]!,
                DedeUserid_MD5 = collection["DedeUserID__ckMd5"]!,
                Expires = collection["Expires"]!,
                SECCDATA = collection["SESSDATA"]!,
                Bili_JCT = collection["bili_jct"]!
                ,URL = collection["gourl"]!
            };

            return result;
        }


        public static string UrlToString(string url)
        {
            var utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(url);
            var myurl = utf8.GetString(utfBytes, 0, utfBytes.Length);
            Uri uri = new Uri(myurl);
            var collection = HttpUtility.ParseQueryString(uri.Query)!;
            return $"DedeUserID={collection["DedeUserID"]!};" +
                $"DedeUserID__ckMd5={collection["DedeUserID__ckMd5"]!};" +
                $"Expires={collection["Expires"]!};" +
                $"SESSDATA={collection["SESSDATA"]!};" +
                $"bili_jct={collection["bili_jct"]!};";
        }
    }
}
