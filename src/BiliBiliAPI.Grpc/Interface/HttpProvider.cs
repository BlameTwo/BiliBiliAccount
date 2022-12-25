using BiliBiliAPI.Grpc.Model;
using Google.Protobuf;

namespace BiliBiliAPI.Grpc.Interface;

public interface IHttpProvider
{
    /// <summary>
    /// 发送数据
    /// </summary>
    /// <param name="url"></param>
    /// <param name="message"></param>
    /// <typeparam name="T">定义返回的类型</typeparam>
    Task<GrpcResultCode<T>> SendData<T>(string url, IMessage message)
        where T : IMessage<T>, new()
        ;

        
}