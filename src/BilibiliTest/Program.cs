using BilibiliAPI;
using BilibiliAPI.Video;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.Settings;

namespace BilibiliTest
{
    public static class Program
    {
        static AccountToken token = AccountSettings.Read();
        public static  async Task Main(string[] args)
        {
            BiliBiliArgs.TokenSESSDATA = token;
            Video video = new Video();
            var bv = await video.GetVideosContent("BV1Cg411u7Xr", Video.VideoIDType.BV);
            UserVideo vid = new UserVideo();
            var c =  await vid.LikeVideo(true,bv.Data.Aid);
            Console.WriteLine(c.Data.TipText);
            Console.ReadLine();
        }
    }
}