using BiliBiliAPI.Models.Account;

namespace BiliBiliAPI.Grpc;

public class Apis
{
    /// <summary>
    /// grpc服务器
    /// </summary>
    public const string grpcserver = "https://grpc.biliapi.net";
    
    /// <summary>
    /// grpc账号存储位置,限制程序集内访问
    /// </summary>
    internal static AccountToken Token =new ();
    
    /// <summary>
    /// 评论的地址
    /// </summary>
    public  const string GrpcReply = grpcserver+"/bilibili.main.community.reply.v1.Reply/MainList";
}