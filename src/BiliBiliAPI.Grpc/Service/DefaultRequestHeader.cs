using BiliBiliAPI.Grpc.Interface;

namespace BiliBiliAPI.Grpc.Service;

public class DefaultRequestHeader:IDefaultRequestHeader
{
    public static DefaultRequestHeader Create()
    {
        return new DefaultRequestHeader()
        {
            Version = "2.1.0",
            Os_Version = "11",
            Os_Company = "Xiaomi",
            Os_Name = "MIUI",
            App_Version = "6.7.0",
            Build = 6070600,
            Channel = "bilibili140",
            NetWork_Type = 1,
            NetWork_TF = 0,
            NetWork_Oid = "46007",
            Cronet = "1.21.0",
            Buvid = "XZFD48CFF1E68E637D0DF11A562468A8DC314",
            Mobiapp = "android",
            Platform = "android"
            ,Env = "prod",
            Appid = "1",
            Region = "CN",
            Language = "zh"
        };
    }
    
    /// <summary>
    /// 创建请求UA
    /// </summary>
    /// <param name="header">自定义请求头，默认为默认设置</param>
    /// <returns></returns>
    public static string CreateUA(DefaultRequestHeader header = null)
    {
        if(header == null)
            header = DefaultRequestHeader.Create();
        
        var ua = $"Dalvik/{header.Version} "
                 + $"(Linux; U; Android {header.Os_Version}; {header.Os_Company} {header.Os_Name}) {header.App_Version} "
                 + $"os/android model/{header.Os_Company} mobi_app/android build/{header.Build} "
                 + $"channel/{header.Channel} innerVer/{header.Build} osVer/{header .Os_Version} "
                 + $"network/{header.NetWork_Type}";
        return ua;
    }
    public string Version { get; set; }
    public string Os_Version { get; set; }
    public string Os_Company { get; set; }
    public string Os_Name { get; set;}
    public string App_Version { get; set;}
    public int Build { get; set;}
    public string Channel { get; set;}
    public int NetWork_Type { get;set; }
    public int NetWork_TF { get;set; }
    public string NetWork_Oid { get;set; }
    public string Cronet { get;set; }
    public string Buvid { get;set; }
    public string Mobiapp { get;set; }
    public string Platform { get;set; }
    public string Env { get;set; }
    public string Appid { get;set; }
    public string Region { get;set; }
    public string Language { get; set;}
}