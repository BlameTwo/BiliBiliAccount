using BiliBiliAPI.ApiTools;
using BiliBiliAPI.Models.Account;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI
{
    //public sealed class HttpTools : IDisposable
    //{
    //    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(8);
    //    public HttpTools()
    //    {
    //        var clientHandler = new HttpClientHandler();
    //        clientHandler.ServerCertificateCustomValidationCallback += (sender, cert, chaun, ssl) => { return true; };
            
    //        HttpClient = new HttpClient(clientHandler) { Timeout = Timeout };
    //        HttpClient.DefaultRequestHeaders.Referrer = new Uri("http://www.bilibili.com/");
    //    }
    //    HttpClient HttpClient = new();
    //    public async Task<string> GetUserResult(string url, string mid,ApiKeyInfo apiKeyInfo = null)
    //    {
    //        try
    //        {
    //            var myhttp = new HttpClient();
    //            if (apiKeyInfo == null)
    //                apiKeyInfo = ApiProvider.AndroidTVKey;
    //            myhttp.DefaultRequestHeaders.Add("Cookie", BiliBiliArgs.TokenSESSDATA.CookieString);
    //            myhttp.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36 Edg/107.0.1418.62");
                
    //            myhttp.DefaultRequestHeaders.Add("referer", $"https://space.bilibili.com/{mid}");
    //            HttpResponseMessage hr = await myhttp.GetAsync(url).ConfigureAwait(false);
                
    //            hr.EnsureSuccessStatusCode();
    //            var encodeResults = await hr.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
    //            string str = Encoding.UTF8.GetString(encodeResults, 0, encodeResults.Length);
    //            return str;
    //        }
    //        catch (Exception ex)
    //        {

    //            Debug.WriteLine(ex.Message);
    //            return string.Empty;
    //        }
    //    }



    //    public async Task<string> GetResults(string url, ApiKeyInfo apiKeyInfo = null, string type = "&platform=android&device=android&actionKey=appkey&build=5442100&mobi_app=android_comic",bool IsAcess = true)
    //    {
    //        try
    //        {
    //            if (apiKeyInfo == null)
    //                apiKeyInfo = ApiProvider.AndroidTVKey;
    //            if (url.IndexOf("?") > -1)
    //                url += (IsAcess == true ? "&access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA : "") + "&appkey=" + apiKeyInfo.Appkey + type + "&ts=" + ApiProvider.TimeSpanSeconds;
    //            else
    //                url += (IsAcess == true ? "?access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA : "") + "&appkey=" + apiKeyInfo.Appkey + type + "&ts=" + ApiProvider.TimeSpanSeconds;
    //            url += (IsAcess == true ? "&sign=" + ApiProvider.GetSign(url, apiKeyInfo):"");
    //            HttpResponseMessage hr = await HttpClient.GetAsync(url).ConfigureAwait(false);
    //            hr.Headers.Add("referer", "https:bilibili.com");
    //            hr.Headers.Add("Accept_Encoding", "gzip,deflate");
    //            hr.EnsureSuccessStatusCode();
    //            var encodeResults = await hr.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
    //            string str =  Encoding.UTF8.GetString(encodeResults, 0, encodeResults.Length);
    //            return str;
    //        }
    //        catch (Exception ex)
    //        {

    //            Debug.WriteLine(ex.Message);
    //            return string.Empty;
    //        }
    //    }

    //    public async Task<string> GetResults(string url, string cookie, ApiKeyInfo apiKeyInfo = null)
    //    {
    //        return await Task.Run(async () =>
    //        {
    //            try
    //            {
    //                if (apiKeyInfo == null)
    //                    apiKeyInfo = ApiProvider.AndroidKey;
    //                if (url.IndexOf("?") > -1)
    //                    url += "&access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA + "&appkey=" + apiKeyInfo.Appkey + "&platform=android&device=android&actionKey=appkey&build=5442100&mobi_app=android_comic&ts=" + ApiProvider.TimeSpanSeconds;
    //                else
    //                    url += "?access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA + "&appkey=" + apiKeyInfo.Appkey + "&platform=android&device=android&actionKey=appkey&build=5442100&mobi_app=android_comic&ts=" + ApiProvider.TimeSpanSeconds;
    //                url += "&sign=" + ApiProvider.GetSign(url, apiKeyInfo);

    //                HttpResponseMessage hr = await HttpClient.GetAsync(url).ConfigureAwait(false);

    //                hr.Headers.Add("Cookie", cookie);
    //                hr.EnsureSuccessStatusCode();
    //                var encodeResults = await hr.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
    //                return Encoding.UTF8.GetString(encodeResults, 0, encodeResults.Length);
    //            }
    //            catch (Exception ex)
    //            {

    //                Debug.WriteLine(ex.Message);
    //                return string.Empty;
    //            }
    //        });
    //    }

    //    public async Task<string> GetStringAsync(string url)
    //    {
    //        using HttpClient HttpClient = new HttpClient();
    //        return await HttpClient.GetStringAsync(url);
    //    }
    //    public async Task<Stream> GetImageStream(Uri url)
    //    {
    //        try
    //        {
    //            HttpResponseMessage hr = await HttpClient.GetAsync(url).ConfigureAwait(false);
    //            hr.EnsureSuccessStatusCode();
    //            return await hr.Content.ReadAsStreamAsync().ConfigureAwait(false);
    //        }
    //        catch (Exception ex)
    //        {

    //            Debug.WriteLine(ex.Message);
                
    //            return default;
    //        }
    //    }


    //    public async Task<string> PostResults(string url, string postContent, ApiKeyInfo apiKeyInfo = null)
    //    {
    //        try
    //        {
    //            if (apiKeyInfo == null)
    //                apiKeyInfo = ApiProvider.AndroidTVKey;
    //            if (!string.IsNullOrEmpty(postContent))
    //            {
                   
    //                postContent += "&access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA + "&appkey=" + apiKeyInfo.Appkey + "&mobi_app=android_comic&device=android&version="
    //                    + ApiProvider.version + "&actionKey=appkey&platform=android&ts=" + ApiProvider.TimeSpanSeconds;
    //            }
    //            else
    //                postContent += "access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA + "&appkey=" + apiKeyInfo.Appkey + "&mobi_app=android_comic&device=android&version="
    //                    + ApiProvider.version + "&actionKey=appkey&platform=android&ts=" + ApiProvider.TimeSpanSeconds;
    //            postContent += "&sign=" + ApiProvider.GetSign(postContent, apiKeyInfo);
    //            StringContent stringContent = new StringContent(postContent, Encoding.UTF8, "application/x-www-form-urlencoded");
    //            var response = await HttpClient.PostAsync(url, stringContent);
    //            response.EnsureSuccessStatusCode();
    //            var encodeResults = await response.Content.ReadAsByteArrayAsync();
    //            return Encoding.UTF8.GetString(encodeResults, 0, encodeResults.Length);
    //        }
    //        catch (Exception ex)
    //        {
    //            Debug.WriteLine(ex.Message);
    //            return "";
    //        }
    //    }
        
    //    public void Dispose()
    //    {
    //        try
    //        {
    //            HttpClient.Dispose();
    //        }
    //        catch { }
    //    }
    //}
}
