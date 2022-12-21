using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BiliBiliAPI.ApiTools;

namespace BiliBiliAPI.Tools;

public class SpaceHttp:HttpTools
{

    /// <summary>
    /// 重写请求方式，重点不加默认的BuildString
    /// </summary>
    /// <returns></returns>
    public override async Task<string> GetResults(string url, ResponseEnum responseEnum, Dictionary<string, string> keyValues = null, bool IsAcess = true,
        string BuildString = "&platform=android&device=android&actionKey=appkey&build=5442100&mobi_app=android_comic")
    {
        if (url.IndexOf("?") > -1)
            url += (IsAcess == true ? "&access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA : "") + "&appkey=" + ApiProvider.AndroidKey.Appkey  + "&ts=" + ApiProvider.TimeSpanSeconds;
        else
            url += (IsAcess == true ? "?access_key=" + BiliBiliArgs.TokenSESSDATA.SECCDATA : "") + "&appkey=" + ApiProvider.AndroidKey.Appkey  + "&ts=" + ApiProvider.TimeSpanSeconds;
        url += (IsAcess == true ? "&sign=" + ApiProvider.GetSign(url, ApiProvider.AndroidKey) : "");
        //AppClient.DefaultRequestHeaders.Add("Cookie", BiliBiliArgs.TokenSESSDATA.CookieString);
        HttpResponseMessage apphr = await AppClient.GetAsync(url).ConfigureAwait(false);
        apphr.Headers.Add("Accept_Encoding", "gzip,deflate");
        apphr.EnsureSuccessStatusCode();
        var appencodeResults = await apphr.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
        string appstr = Encoding.UTF8.GetString(appencodeResults, 0, appencodeResults.Length);
        return appstr;
    }
}