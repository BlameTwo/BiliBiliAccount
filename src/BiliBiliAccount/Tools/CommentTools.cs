using BiliBiliAPI.ApiTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Tools
{
    public class CommentTools:HttpTools
    {
        public async override Task<string> PostResults(string url, string postContent, ResponseEnum responseEnum, Dictionary<string, string> keyValues = null, bool isclear = false)
        {
            HttpClient HttpClient = new HttpClient(); HttpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 BiliDroid/5.24.0 (bbcallen@gmail.com)");
            HttpClient.DefaultRequestHeaders.Add("x-bili-aurora-zone", "sh001");
            HttpClient.DefaultRequestHeaders.Add("APP-KEY", "android64");
            HttpClient.DefaultRequestHeaders.Add("x-bili-aurora-eid", "UF0CT1ADD1IDXA==");
            var OldWebClient2 = AppClient;
            AppClient = isclear == true ?
                AppClient = new() :
                OldWebClient2;
            if (!string.IsNullOrEmpty(postContent))
            {
                postContent += "&access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA + "&appkey=" + ApiProvider.AndroidTVKey.Appkey + "&version="
                    + ApiProvider.version + "&ts=" + ApiProvider.TimeSpanSeconds;
            }
            else
                postContent += "access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA + "&appkey=" + ApiProvider.AndroidTVKey.Appkey + "&version="
                    + ApiProvider.version + "&ts=" + ApiProvider.TimeSpanSeconds;
            postContent += "&sign=" + ApiProvider.GetSign(postContent, ApiProvider.AndroidTVKey);
            StringContent stringContent = new StringContent(postContent, Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await AppClient.PostAsync(url, stringContent);
            response.EnsureSuccessStatusCode();
            var encodeResults = await response.Content.ReadAsByteArrayAsync();
            return Encoding.UTF8.GetString(encodeResults, 0, encodeResults.Length);
        }
    }
}
