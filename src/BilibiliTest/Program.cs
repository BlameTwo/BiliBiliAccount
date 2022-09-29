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
            //把视频的基本信息API修改为以下，相对应的类也改了，明天改2022.9.29留
            var bv = await video.GetVideosContent("BV1Cg411u7Xr", Video.VideoIDType.BV);
            string url = $"https://app.bilibili.com/x/v2/view?aid={bv.Data.Aid}";
            string a = await Test.Go(url);
            Console.ReadLine();
        }
    }
}