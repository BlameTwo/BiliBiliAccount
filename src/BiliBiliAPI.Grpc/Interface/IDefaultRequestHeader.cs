namespace BiliBiliAPI.Grpc.Interface;

public interface IDefaultRequestHeader
{
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
    string Appid { get;}
    string Region { get;}
    string Language { get; }

}