using Google.Protobuf;

namespace BiliBiliAPI.Grpc.Interface;

public interface IHttpProvider
{
    /// <summary>
    /// 发送数据
    /// </summary>
    /// <param name="url"></param>
    /// <param name="message"></param>
    /// <typeparam name="T"></typeparam>
    void SendData<T>(string url, IMessage message)
        where T : IMessage; //T的约束为Grpc服务的IMessage
}