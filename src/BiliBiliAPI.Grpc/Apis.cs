using BiliBiliAPI.Models.Account;

namespace BiliBiliAPI.Grpc;

public class Apis
{
    /// <summary>
    /// grpc服务器
    /// </summary>
    const string grpcserver = "https://grpc.biliapi.net";
    const string apiserver = "https://app.bilibili.com";

    /// <summary>
    /// grpc账号存储位置,公开访问
    /// </summary>
    public static AccountToken Token =new ();
    
    /// <summary>
    /// 评论的地址
    /// </summary>
    public  const string GrpcReply = apiserver + "/bilibili.main.community.reply.v1.Reply/MainList";

    public const string GrpcViewDetail = apiserver + "/bilibili.app.view.v1.View/View";


    public const string GrpcViewPlayConfig = "https://app.bilibili.com/bilibili.app.playurl.v1.PlayURL/PlayView";

}