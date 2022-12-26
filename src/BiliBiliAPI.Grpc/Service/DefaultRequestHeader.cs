using Bilibili.Metadata.Fawkes;
using BiliBiliAPI.Grpc.Interface;
using BiliBiliAPI.Grpc.Tools;
using Google.Protobuf;
using Grpc.Core;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace BiliBiliAPI.Grpc.Service;

public class DefaultRequestHeader:IDefaultRequestHeader
{
    /// <summary>
    /// 创建默认的请求头
    /// </summary>
    /// <returns></returns>
    public static DefaultRequestHeader Create()
    {
        return new DefaultRequestHeader()
        {
            Version = "2.1.0",
            Os_Version = "6",
            Os_Company = "Xiaomi",
            Os_Name = "MIUI",
            App_Version = "6.7.0",
            Build = 7110300,
            Channel = "alifenfa",
            NetWork_Type = 2,
            NetWork_TF = 0,
            NetWork_Oid = "46007",
            Cronet = "1.21.0",
            Buvid = "XYF2F19FA588E96DC2E9A62B358F164A3C5A7",
            Mobiapp = "android",
            Platform = "android"
            ,Env = "prod",
            Appid = 1,
            Region = "CN",
            Language = "zh"
        };
    }
    
    /// <summary>
    /// 创建默认请求UA
    /// </summary>
    /// <param name="header">自定义请求头，默认为默认设置</param>
    /// <returns></returns>
    public static string CreateUA(DefaultRequestHeader header = null)
    {
        if(header == null)
            header = DefaultRequestHeader.Create();
        
        var ua = $"Dalvik/{header.Version} "
                 + $"(Linux; U; Android {header.Os_Version}; {header.Os_Company} {header.Os_Name} Build/V417IR) {header.App_Version} "
                 + $"os/android model/{header.Os_Company} mobi_app/android build/{header.Build} "
                 + $"channel/{header.Channel} innerVer/{header.Build} osVer/{header .Os_Version} "
                 + $"network/{header.NetWork_Type}";
        return ua;
    }

    #region 继承属性

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
    public int Appid { get;set; }
    public string Region { get;set; }
    public string Language { get; set;}
    #endregion

    #region 继承方法

    public string GetFawkesreqBin()
    {
        return (new FawkesReq()
        {
            Appkey = Mobiapp,
            Env = Env,
            SessionId= "dedf8669"
        }).ToByteArray().ToBase64();
    }

    public string GetMetadataBin()
    {
        var req = new Bilibili.Metadata.Metadata();
        req.MobiApp=Mobiapp;
        req.Platform=Platform;
        req.AccessKey = Apis.Token.SECCDATA;
        req.Build= Build;
        req.Channel= Channel;
        req.Buvid= Buvid;
        return req.ToByteArray().ToBase64();
    }

    public string GetDeviceBin()
    {
        return (new Bilibili.Metadata.Device.Device()
        {
            AppId = this.Appid,
            Brand = this.Os_Company,
            Channel = Channel,
            MobiApp = Mobiapp,
            Build = Build,
            Model = Os_Name,
            Osver = Os_Version,
            Buvid = Buvid,
            Platform = Platform,
        }).ToByteArray().ToBase64();
    }

    public string GetNetworkBin()
    {
        return (new Bilibili.Metadata.Network.Network()
        {
            Type= Bilibili.Metadata.Network.NetworkType.Wifi,
            Oid= NetWork_Oid
            ,Tf = Bilibili.Metadata.Network.TFType.TfUnknown
        }).ToByteArray().ToBase64();
    }

    public string GetRestrictionBin()
    {
        return (new Bilibili.Metadata.Restriction.Restriction()).ToByteArray().ToBase64();
    }

    public string GenTraceId()
    {
        var t = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        var x = string.Format("{0:x}", t).Substring(0, 6);
        var randBytes = new byte[26 / 2];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randBytes);
        }
        var r = string.Join("", randBytes.Select(b => b.ToString("x2")));
        var xBiliTraceId = string.Format("{0}{1}:{2}{3}:0:0", r, x, r, x);
        return xBiliTraceId;
    }
    public string GetLocaleBin()
    {
        return (new Bilibili.Metadata.Locale.Locale()
        {
            CLocale = new Bilibili.Metadata.Locale.LocaleIds()
            {
                Language = this.Language,
                Region= this.Region
            },
            SLocale= new Bilibili.Metadata.Locale.LocaleIds()
            {
                Language = this.Language,
                Region= this.Region
            }
        }).ToByteArray().ToBase64();
    }
    #endregion
    
}