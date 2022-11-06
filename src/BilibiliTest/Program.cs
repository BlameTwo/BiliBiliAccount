using BilibiliAPI;
using BilibiliAPI.Search;
using BilibiliAPI.TopVideos;
using BilibiliAPI.User;
using BilibiliAPI.Video;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.Movie;
using BiliBiliAPI.Models.Settings;
using BiliBiliAPI.Models.Videos;
using System.Security.Cryptography;

namespace BilibiliTest
{
    public static class Program
    {
        static AccountToken token = AccountSettings.Read();
        static PublicSearch Search = new PublicSearch();
        public static  async Task Main(string[] args)
        {
            #region 初始化视频相关
            UserVideo user = new UserVideo();
            BiliBiliArgs.TokenSESSDATA = token;
            Video video = new Video();
            TopListVideo topvideo = new TopListVideo();
            var bv = await video.GetVideosContent("BV1Jg411a7jt", VideoIDType.BV);
            #endregion
            foreach (var item in bv.Data.Tag)
            {
                Console.WriteLine($"{item.Name}    {item.ID}   {item.Uri}");
            }
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

            #region 获得视频清晰度列表
            //var download = await video.GetVideo(bv.Data, VideoIDType.AV);
            #endregion
            #region 获得视频在线信息
            //var test2 = await video.GetVideoOnline(bv.Data);
            #endregion

            #region 获得首页推荐
            //var result = await video.GetHomeVideo();
            //Console.WriteLine($"获得推荐共计{result.Data.Item.Count}个视频");
            #endregion

            #region 获得视频弹幕
            //Danmaku danmaku = new Danmaku();
            //var result = await danmaku.GetDanmakuTest(bv.Data.First_Cid);
            #endregion

            #region 上传播放历史
            //string url = $"http://api.bilibili.com/x/v2/history/report";
            //string data = $"aid={bv.Data.Aid}&cid={bv.Data.First_Cid}&progress={5}&platform=android";
            //var text = await Test.PostGo(url,data);
            #endregion

            #region 获得排行榜
            // var list = await topvideo.GetTopVideo(Cid.Music,7);
            #endregion

            #region 搜索视频
            // var text = $"?search_type=video&keyword=崩坏3&page=5";
            // string uri = "http://api.bilibili.com/x/web-interface/search/type";
            // var str = await Search.SearchAnimation("夏日重现",1);
            #endregion

            // 标签搜索，channel_id为搜索频道，Tag的Tag_Type为new是为频道，Tag的Tag_Type为common时为普通搜索
            //标签搜索：https://api.bilibili.com/x/web-interface/web/channel/multiple/list?channel_id=10242316&sort_type=hot&offset=&page_size=30
            //标签年份搜索：https://api.bilibili.com/x/web-interface/web/channel/featured/list?channel_id=25483&filter_type=2022&offset=&page_size=30
            //热度搜索  https://api.bilibili.com/x/web-interface/web/channel/multiple/list?channel_id=7945544&sort_type=hot&offset=389814532_1667725405&page_size=30
            //三十天内  https://api.bilibili.com/x/web-interface/web/channel/multiple/list?channel_id=7945544&sort_type=view&offset=944748123_17905658123&page_size=30
            //标签最新更新：https://api.bilibili.com/x/web-interface/web/channel/multiple/list?channel_id=7945544&sort_type=new&offset=&page_size=30
            #region 搜索电影
            // var result = await Search.SearchMovie("天气之子", 1);
            #endregion
            #region 获得电影的基本信息
            //BilibiliAPI.Movie.Movie movie = new BilibiliAPI.Movie.Movie();
            //var result = await movie.GetMovie("33343", BilibiliAPI.Movie.Movie.MovieEnum.SSID);
            #endregion
            Console.ReadLine();
        }
    }
}