using BiliBiliAPI.Grpc.Interface;
using BiliBiliAPI.Grpc.Tools;
using Google.Protobuf;
using Grpc.Core;
using Protos.Grpc.Header;
using Protos.Header;
using System.Runtime.CompilerServices;

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
                 + $"(Linux; U; Android {header.Os_Version}; {header.Os_Company} {header.Os_Name}) {header.App_Version} "
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
        }).ToByteArray().ToBase64();
    }

    public string GetMetadataBin()
    {
        var req = new Protos.Header.Metadata();
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
        return (new Protos.Header.Device()
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
        return (new Network()
        {
            Type= Network.Types.TYPE.Wifi,
            Oid= NetWork_Oid
            ,Tf =  Network.Types.TF.Unknown
        }).ToByteArray().ToBase64();
    }

    public string GetRestrictionBin()
    {
        return (new Restriction()).ToByteArray().ToBase64();
    }

    public string GetLocaleBin()
    {
        return (new Locale()
        {
            CLocale = new Locale.Types.LocaleIds()
            {
                Language = this.Language,
                Region= this.Region
            },
            SLocale= new Locale.Types.LocaleIds()
            {
                Language = this.Language,
                Region= this.Region
            }
        }).ToByteArray().ToBase64();
    }
    #endregion
    
}