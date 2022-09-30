using BilibiliAPI;
using BilibiliAPI.Video;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.Settings;

namespace BilibiliTest
{
    public static class Program
    {
        static AccountToken token = AccountSettings.Read();
        public static  async Task Main(string[] args)
        {
            UserVideo user = new UserVideo();
            BiliBiliArgs.TokenSESSDATA = token;
            Video video = new Video();
            var bv = await video.GetVideosContent("BV1134y147LC", VideoIDType.BV);
            Console.WriteLine((await user.CoinsVideo(1,bv.Data.Aid)).Data.Guide.Title);
            Console.ReadLine();
        }
    }
}