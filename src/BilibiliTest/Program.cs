using BilibiliAPI;
using BilibiliAPI.User;
using BilibiliAPI.Video;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.Settings;
using System.Security.Cryptography;

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
            var bv = await video.GetVideosContent("BV15z4y1Z734", VideoIDType.BV);


            #region 检查视频是否是用户收藏
            //Console.WriteLine((await user.CoinsVideo(1,bv.Data.Aid)).Data.Guide.Title);
            //string url = $"http://api.bilibili.com/x/v3/fav/folder/created/list-all?up_mid={token.Mid}";
            //var a = await Test.Go(url);
            //Users users = new Users();
            //var b = await users.GetFavourites(bv.Data.Aid);
            //foreach (var item in b.Data.List)
            //{
            //    if (item.FavState == "1")
            //        Console.WriteLine($"视频:  【{bv.Data.Title}】  存在于  【{item.Title}】  收藏夹中");

            //    var a = await users.GetFavMedios(item,20);
            //}

            #endregion

            #region 下载视频
            //var a = await video.GetVideo(bv.Data, VideoIDType.AV, DashEnum.Dash4K);
            //Console.WriteLine(a.Data.Durl[0].Url);
            //DownLoad downLoad = new DownLoad();
            //downLoad.DownLoadAsync(a.Data.Durl[0].Url);
            #endregion

            #region 获得视频在线信息
            //var test2 = await video.GetVideoOnline(bv.Data);
            #endregion

            #region 获得首页推荐
            var result = await video.GetHomeVideo();
            #endregion
            Console.WriteLine($"获得推荐共计{result.Data.Item.Count}个视频");
            Console.ReadLine();
        }
    }
}