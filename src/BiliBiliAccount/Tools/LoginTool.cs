using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BiliBiliAPI.ApiTools;

namespace BiliBiliAPI.Tools;

public class LoginTool
{
    private HttpClient HttpClient = new();

    public async Task<string> Get(string url,string content)
    {
        //增加基础参数
        content += "&appkey=" + ApiProvider.LoginKey.Appkey + "&mobi_app=android&device=android&version="
                   + ApiProvider.version + "&actionKey=appkey&platform=android&ts=" + ApiProvider.TimeSpanSeconds;
        //增加签名
        content += "&sign=" + ApiProvider.GetSign(content, ApiProvider.LoginKey);
        string GetUrl = url +"?"+ content;
        var response = await HttpClient.GetAsync(GetUrl);
        response.EnsureSuccessStatusCode();
        var encodeResults = await response.Content.ReadAsByteArrayAsync();
        return System.Text.Encoding.UTF8.GetString(encodeResults, 0, encodeResults.Length);
    }

    public async Task<string> Post(string url, string content)
    {
        //增加基础参数
        content += "&appkey=" + ApiProvider.LoginKey.Appkey + "&mobi_app=android"+ "&platform=android&ts=" + ApiProvider.TimeSpanSeconds;
        //增加签名
        content += "&sign=" + ApiProvider.GetSign(content, ApiProvider.LoginKey);
        string GetUrl = url + "?" + content;
        var response = await HttpClient.PostAsync(GetUrl,new StringContent(content));
        response.EnsureSuccessStatusCode();
        var encodeResults = await response.Content.ReadAsByteArrayAsync();
        return System.Text.Encoding.UTF8.GetString(encodeResults, 0, encodeResults.Length);
    }
}