using BiliBiliAPI;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.Movie;
using BiliBiliAPI.Models.Settings;
using BiliBiliAPI.Models.Videos;
using BiliBiliAPI.Region;
using BiliBiliAPI.Search;
using BiliBiliAPI.TopLists;
using BiliBiliAPI.TopVideos;
using BiliBiliAPI.Video;
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
            //var a = await video.GetVideo(bv.Data, VideoIDType.AV);
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

            #region 获得视频简介
            // var result = await video.GetVideoDesc(bv.Data.Bvid, VideoIDType.BV);
            #endregion

            #region 标签相关
            // 标签搜索，channel_id为搜索频道，Tag的Tag_Type为new是为频道，Tag的Tag_Type为common时为普通搜索
            //标签搜索：https://api.bilibili.com/x/web-interface/web/channel/multiple/list?channel_id=10242316&sort_type=hot&offset=&page_size=30
            //标签年份搜索：https://api.bilibili.com/x/web-interface/web/channel/featured/list?channel_id=25483&filter_type=2022&offset=&page_size=30
            //热度搜索  https://api.bilibili.com/x/web-interface/web/channel/multiple/list?channel_id=7945544&sort_type=hot&offset=389814532_1667725405&page_size=30
            //三十天内  https://api.bilibili.com/x/web-interface/web/channel/multiple/list?channel_id=7945544&sort_type=view&offset=944748123_17905658123&page_size=30
            //标签最新更新：https://api.bilibili.com/x/web-interface/web/channel/multiple/list?channel_id=7945544&sort_type=new&offset=&page_size=30
            //foreach (var item in bv.Data.Tag)
            //{
            //    Console.WriteLine($"{item.Name}    {item.ID}   {item.Uri}");
            //}
            #endregion


            //关注操作
            //https://github.com/SocialSisterYi/bilibili-API-collect/blob/6c844133afa9663dc46502af993809060875adb3/user/relation.md#%E6%93%8D%E4%BD%9C%E7%94%A8%E6%88%B7%E5%85%B3%E7%B3%BB

            #region 搜索电影
            // var result = await Search.SearchMovie("天气之子", 1);
            #endregion
            #region 获得电影的基本信息
            //BilibiliAPI.Movie.Movie movie = new BilibiliAPI.Movie.Movie();
            //var result = await movie.GetMovie("33343", BilibiliAPI.Movie.Movie.MovieEnum.SSID);
            #endregion

            #region 获得每周必看列表和视频
            //EveryoneWeak Weak = new EveryoneWeak();
            //var result = await Weak.GetWeekList();
            //foreach (var item in result.Data.List)
            //{
            //    var result2 = await Weak.GetWeekTopList(item.Number);
            //    Console.WriteLine(result2);
            //}
            #endregion

            #region 获得分区索引
            //TidRegion region = new TidRegion();
            //var a = await region.GetTidIcon();
            #endregion

            #region 获得音乐排行榜
            //MusicRank Rank = new MusicRank();
            //var result = await Rank.GetRankList();
            //foreach (var item in result.Data.YearData)
            //{
            //    Console.WriteLine($"循环年份为：{item.Year}");
            //    foreach (var item2 in item.MusicRankItem)
            //    {
            //        var result2 = await Rank.GetMusics(item2.ID);
            //        Console.WriteLine($"第{item2.priod}期,共计{result2.Data.Items.Count}个音乐上榜");
            //    }
            //}
            //Console.WriteLine(result);
            #endregion

            #region 获得搜索前的搜索关键字推荐
            //BiliBiliAPI.Search.DefaultSearch defaultSearch = new BiliBiliAPI.Search.DefaultSearch();
            //var str = await defaultSearch.GetDefault();
            //Console.WriteLine(str.Data.Title);
            #endregion

            #region 入站必看
            MustWatch Watch = new MustWatch();
            var str = await Watch.GetVideos();
            foreach (var item in str.Data.List)
            {
                Console.WriteLine(item.Title);
            }
            #endregion
            Console.ReadLine();
        }
    }
}