using BiliBiliAPI.ApiTools;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Search;
using BiliBiliAPI.Tools;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Account;
public class UnLogin:HttpTools
{

    public async Task<ResultCode<object>> Go()
    {
        string cookiestring="";
        cookiestring += BiliBiliArgs.TokenSESSDATA.cookies.Cookies[0].Name +"="+ BiliBiliArgs.TokenSESSDATA.cookies.Cookies[0].Value+"&";
        for (int i = 1; i < BiliBiliArgs.TokenSESSDATA.cookies.Cookies.Count; i++)
        {
            cookiestring += $"{BiliBiliArgs.TokenSESSDATA.cookies.Cookies[i].Name}={BiliBiliArgs.TokenSESSDATA.cookies.Cookies[i].Value}&";
        }
        string content = $"{cookiestring}mid={BiliBiliArgs.TokenSESSDATA.Mid}&s_locale=zh_CN&build=6540300&buvid=XZDEEDED30DFC73BDE8D55B6151EC9355BAAC";
        return JsonConvert.ReadObject<object>(await PostResults(Apis.ACCOUNT_UnLogin, 
            content, ResponseEnum.App)
            );
    }

    public async override Task<string> PostResults(string url, string postContent, ResponseEnum responseEnum, Dictionary<string, string> keyValues = null, bool isclear = false)
    {
        if (!string.IsNullOrEmpty(postContent))
        {
            postContent += "&access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA + "&appkey=" + ApiProvider.LoginKey.Appkey + "&mobi_app=android&device=android&version="
                + ApiProvider.version + "&actionKey=appkey&platform=android&ts=" + ApiProvider.TimeSpanSeconds;
        }
        else
            postContent += "access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA + "&appkey=" + ApiProvider.LoginKey.Appkey + "&mobi_app=android_comic&device=android&version="
                + ApiProvider.version + "&actionKey=appkey&platform=android&ts=" + ApiProvider.TimeSpanSeconds;
        postContent += "&sign=" + ApiProvider.GetSign(postContent, ApiProvider.LoginKey);
        StringContent stringContent = new StringContent(postContent, Encoding.UTF8, "application/x-www-form-urlencoded");
        AppClient.DefaultRequestHeaders.Add("cookie", BiliBiliArgs.TokenSESSDATA.CookieString);
        var response = await AppClient.PostAsync(url, stringContent);
        response.EnsureSuccessStatusCode();
        var encodeResults = await response.Content.ReadAsByteArrayAsync();
        return Encoding.UTF8.GetString(encodeResults, 0, encodeResults.Length);
    }
}