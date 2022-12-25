using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;

namespace BiliBiliAPI.Grpc.Model;
public class GrpcResultCode<T> where T :IMessage
{
    /// <summary>
    /// 创建默认的返回参数
    /// </summary>
    /// <param name="result"></param>
    /// <param name="message"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static GrpcResultCode<T> Create(T result,string message,int code=0)
    {
        return new GrpcResultCode<T>()
        {
            Result = result,
            Message = message,
            Code = code
        };
    }
    
    public int Code { get; set; }
    
    public string Message { get; set; }
    
    public T Result { get; set; }
}
