using BilibiliAPI;
using BilibiliAPI.User;
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
            var bv = await video.GetVideosContent("BV1sg411y7cZ", VideoIDType.BV);
            //Console.WriteLine((await user.CoinsVideo(1,bv.Data.Aid)).Data.Guide.Title);
            //string url = $"http://api.bilibili.com/x/v3/fav/folder/created/list-all?up_mid={token.Mid}";
            //var a = await Test.Go(url);
            Users users = new Users();
            var b = await users.GetFavourites(bv.Data.Aid);
            foreach (var item in b.Data.List)
            {
                if (item.FavState == "1")
                    Console.WriteLine($"视频:  【{bv.Data.Title}】  存在于  【{item.Title}】  收藏夹中");

                var a = await users.GetFavMedios(item,20);
            }

            Console.ReadLine();
        }
    }
}