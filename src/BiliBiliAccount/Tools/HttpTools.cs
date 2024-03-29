﻿using BiliBiliAPI.ApiTools;
using BiliBiliAPI.Models.Account;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Tools
{
    public class HttpTools
    {
        //Web认证方式
        HttpClient WebClient = new();
        //App认证方式
        protected HttpClient AppClient = new();

        public enum ResponseEnum { App,Web}


        public HttpTools()
        {
            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback += (sender, cert, chaun, ssl) => { return true; };
            WebClient = new HttpClient(clientHandler) { Timeout = Timeout };
            AppClient = new HttpClient(clientHandler) { Timeout = Timeout };
            WebClient.DefaultRequestHeaders.Referrer = new Uri("http://www.bilibili.com/");
            AppClient.DefaultRequestHeaders.Referrer = new Uri("http://www.bilibili.com/");
            WebClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 BiliDroid/5.24.0 (bbcallen@gmail.com)");
            WebClient.DefaultRequestHeaders.Add("x-bili-aurora-zone", "sh001");
            WebClient.DefaultRequestHeaders.Add("APP-KEY", "android64");
            WebClient.DefaultRequestHeaders.Add("x-bili-aurora-eid", "UlMFQVcABlAH");
            AppClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 BiliDroid/5.24.0 (bbcallen@gmail.com)");
            AppClient.DefaultRequestHeaders.Add("x-bili-aurora-zone", "sh001");
            AppClient.DefaultRequestHeaders.Add("APP-KEY", "android64");
            AppClient.DefaultRequestHeaders.Add("x-bili-aurora-eid", "UlMFQVcABlAH");
        }
        
        
        public virtual async Task<string> GetResults(string url,ResponseEnum responseEnum,Dictionary<string,string> keyValues =null, bool IsAcess = true,string BuildString= "&platform=android&device=android&actionKey=appkey&build=5442100&mobi_app=android_comic")
        {
            switch (responseEnum)
            {
                case ResponseEnum.App:
                    if (url.IndexOf("?") > -1)
                        url += (IsAcess == true ? "&access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA : "") + "&appkey=" + ApiProvider.AndroidTVKey.Appkey + BuildString + "&ts=" + ApiProvider.TimeSpanSeconds;
                    else
                        url += (IsAcess == true ? "?access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA : "") + "&appkey=" + ApiProvider.AndroidTVKey.Appkey + BuildString + "&ts=" + ApiProvider.TimeSpanSeconds;
                    url += (IsAcess == true ? "&sign=" + ApiProvider.GetSign(url, ApiProvider.AndroidTVKey) : "");
                    //AppClient.DefaultRequestHeaders.Add("Cookie", BiliBiliArgs.TokenSESSDATA.CookieString);
                    
                    HttpResponseMessage apphr = await AppClient.GetAsync(url).ConfigureAwait(false);
                    apphr.EnsureSuccessStatusCode();
                    var appencodeResults = await apphr.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    string appstr = Encoding.UTF8.GetString(appencodeResults, 0, appencodeResults.Length);
                    return appstr;
                case ResponseEnum.Web:
                    if(BiliBiliArgs.TokenSESSDATA.CookieString != null)
                    {
                        WebClient.DefaultRequestHeaders.Add("Cookie",  BiliBiliArgs.TokenSESSDATA.CookieString);
                    }
                    
                    if (keyValues != null)
                    {
                        foreach (var item in keyValues)
                        {
                            WebClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                        }
                    }
                    HttpResponseMessage webhr = await WebClient.GetAsync(url).ConfigureAwait(false);
                    webhr.EnsureSuccessStatusCode();
                    var webencodeResults = await webhr.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    string webstr = Encoding.UTF8.GetString(webencodeResults, 0, webencodeResults.Length);
                    return webstr;
            }
            return null;
        }


        public virtual async Task<string> GetStringAsync(string url)
        {
            using HttpClient HttpClient = new HttpClient();
            return await HttpClient.GetStringAsync(url);
        }

        public virtual async Task<string> PostResults(string url, string postContent, ResponseEnum responseEnum, Dictionary<string, string> keyValues = null,bool isclear=false)
        {
            switch (responseEnum)
            {
                case ResponseEnum.App:
                    HttpClient HttpClient = new HttpClient();
                    var OldWebClient2 = AppClient;
                    AppClient = isclear == true ? 
                        AppClient = new() : 
                        OldWebClient2;
                    if (!string.IsNullOrEmpty(postContent))
                    {
                        postContent += "&access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA + "&appkey=" + ApiProvider.AndroidTVKey.Appkey + "&mobi_app=android&device=android&version="
                            + ApiProvider.version + "&actionKey=appkey&platform=android&ts=" + ApiProvider.TimeSpanSeconds;
                    }
                    else
                        postContent += "access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA + "&appkey=" + ApiProvider.AndroidTVKey.Appkey + "&mobi_app=android_comic&device=android&version="
                            + ApiProvider.version + "&actionKey=appkey&platform=android&ts=" + ApiProvider.TimeSpanSeconds;
                    postContent += "&sign=" + ApiProvider.GetSign(postContent, ApiProvider.AndroidTVKey);
                    StringContent stringContent = new StringContent(postContent, Encoding.UTF8, "application/x-www-form-urlencoded");
                    var response = await AppClient.PostAsync(url, stringContent);
                    response.EnsureSuccessStatusCode();
                    var encodeResults = await response.Content.ReadAsByteArrayAsync();
                    return Encoding.UTF8.GetString(encodeResults, 0, encodeResults.Length);
                case ResponseEnum.Web:
                    var OldWebClient = WebClient;
                    WebClient = isclear == true ? WebClient = new() : OldWebClient;
                    WebClient.DefaultRequestHeaders.Add("Cookie", BiliBiliArgs.TokenSESSDATA.CookieString);
                    if(keyValues != null)
                    {
                        foreach (var item in keyValues)
                        {
                            WebClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                        }
                    }
                    StringContent stringContent2 = new StringContent(postContent, Encoding.UTF8, "application/x-www-form-urlencoded");
                    HttpResponseMessage webhr = await WebClient.PostAsync(url,stringContent2).ConfigureAwait(false);
                    webhr.EnsureSuccessStatusCode();
                    var webencodeResults = await webhr.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    string webstr = Encoding.UTF8.GetString(webencodeResults, 0, webencodeResults.Length);
                    return webstr;
                    break;
            }
            return null;
        }

        
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(8);
    }
}
