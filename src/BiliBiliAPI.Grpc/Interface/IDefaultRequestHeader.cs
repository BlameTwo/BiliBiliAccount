namespace BiliBiliAPI.Grpc.Interface;

public interface IDefaultRequestHeader
{
    #region 属性

    string Version { get;  }
    string Os_Version { get;  }
    string Os_Company { get;  }
    string Os_Name { get;  }
    string App_Version { get; }
    int Build { get;  }
    string Channel { get; }
    int NetWork_Type { get; }
    int NetWork_TF { get;}
    string NetWork_Oid { get; }
    string Cronet { get; }
    string Buvid { get;}
    string Mobiapp { get; }
    string Platform { get; }
    string Env { get;}
    int Appid { get;}
    string Region { get;}
    string Language { get; }

    #endregion

    #region 方法

    string GetFawkesreqBin();
    string GetMetadataBin();
    string GetDeviceBin();
    string GetNetworkBin();
    string GetRestrictionBin();
    string GetLocaleBin();


    #endregion

}