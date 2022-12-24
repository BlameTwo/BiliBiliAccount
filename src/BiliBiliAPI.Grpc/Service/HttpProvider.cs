using BiliBiliAPI.Grpc.Interface;
using Google.Protobuf;

namespace BiliBiliAPI.Grpc.Service;

public class HttpProvider:IHttpProvider
{
    public void SendData<T>(string url, IMessage message) where T : IMessage
    {
        
    }
}