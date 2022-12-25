using BiliBiliAPI;
using BiliBiliAPI.Account.Dynamic;
using BiliBiliAPI.BiliLive;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.Settings;
using BiliBiliAPI.Models.Videos;
using BiliBiliAPI.PGC;
using BiliBiliAPI.Region;
using BiliBiliAPI.Search;
using BiliBiliAPI.TopLists;
using BiliBiliAPI.TopVideos;
using BiliBiliAPI.User;
using BiliBiliAPI.Video;
using BiliBiliAPI.WebHome;
using System.Security.Cryptography;
using BiliBiliAPI.Account;
using BiliBiliAPI.Comment;
using BiliBiliAPI.Models.Account.Dynamic;
using static BiliBiliAPI.PGC.PGC;
using BiliBiliAPI.Grpc.Service;
using Bilibili.Main.Community.Reply.V1;
using System;

namespace BilibiliTest
{
    public static class Program
    {
        static AccountToken token = AccountSettings.Read();
        static PublicSearch Search = new PublicSearch();
        public static  async Task Main(string[] args)
        {
            HttpProvider provider = new HttpProvider(BiliBiliAPI.BiliBiliArgs.TokenSESSDATA);
            #region 初始化账号信息，此处为存储活跃的账号信息
            BiliBiliArgs.TokenSESSDATA = token;
            BiliBiliAPI.Grpc.Apis.Token = token;
            #endregion

            #region 初始化视频相关
            //UserVideo user = new UserVideo();
            //Video video = new Video();
            //TopListVideo topvideo = new TopListVideo();
            //var bv = await video.GetVideosContent("BV1894y1X763", VideoIDType.BV);
            //#endregion
            //UserVideo UVideo = new UserVideo();
            //var result =  await UVideo.CoinsVideo(1, bv.Data.Aid, false);
            //Console.WriteLine(result.Data.Guide.Title);
            #endregion
            #region 选择其他漫游服务器
            ////Apis.AddHost(); 添加一个漫游服务器
            //Apis.Select("MyTest");
            #endregion
            #region 检查视频是否是用户收藏
            //Console.WriteLine((await user.CoinsVideo(1, bv.Data.Aid)).Data.Guide.Title);
            //string url = $"http://api.bilibili.com/x/v3/fav/folder/created/list-all?up_mid={token.Mid}";
            //var a = await Test.Go(url);
            //Users users = new Users();
            //var b = await users.GetFavourites(bv.Data.Aid);
            //foreach (var item in b.Data.List)
            //{
            //    if (item.FavState == "1")
            //        Console.WriteLine($"视频:  【{bv.Data.Title}】  存在于  【{item.Title}】  收藏夹中");

            //    var value = await users.GetFavMedios(item, 20);
            //    foreach (var item2 in value.Data.Items)
            //    {
            //        Console.WriteLine(item.Title);
            //    }
            //}

            #endregion

            #region 手机号码登陆
            //PhoneLogin login = new();
            ////1.首先获得支持的国家列表和代码
            //var result = await login.GetCounityList();
            ////2.利用获得代码对手机号进行处理，进行发送验证码
            //Console.WriteLine($"默认国家为:{result.Data.Default.DisplayName}，地区号码为：{result.Data.Default.Code}");
            //var result2 = await login.PostSMSSend("1", "19569979932");
            //Console.WriteLine("验证码发送成功");
            //Console.WriteLine("输入验证码");
            //string key = Console.ReadLine();
            //Console.WriteLine($"{await login.PostSMSPoll(key,result2.Data.Captcha_Key,"19569979932","1")}");
            //Console.ReadKey();
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
            //Console.WriteLine(test2.Data.AllCount);
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
            //var text = await Test.PostGo(url, data);
            #endregion

            #region 获得排行榜
            //var list = await topvideo.GetTopVideo(Cid.Music, 7);
            //foreach (var item in list.Data.List)
            //{
            //    Console.WriteLine(item.Title);
            //}
            #endregion

            #region 搜索视频
            //var text = $"?search_type=video&keyword=崩坏3&page=5";
            //string uri = "http://api.bilibili.com/x/web-interface/search/type";
            //var str = await Search.SearchAnimation("电锯人", 1);
            //Console.WriteLine(str.Data.Items.Count);
            #endregion

            #region 获得视频简介
            // var result = await video.GetVideoDesc(bv.Data.Bvid, VideoIDType.BV);
            //Console.WriteLine(result.Data);
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



            #region 获得每周必看列表和视频
            //EveryoneWeek Weak = new EveryoneWeek();
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
            //Console.WriteLine($"共{a.Data.Count}个分区");
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
            //MustWatch Watch = new MustWatch();
            //var str = await Watch.GetVideos();
            //foreach (var item in str.Data.List)
            //{
            //    Console.WriteLine(item.Title);
            //}
            #endregion


            #region 热搜排行
            //https://api.bilibili.com/x/web-interface/search/square?limit=到第几个
            //SearchSquare searchSquare = new();
            //var result = await searchSquare.GetSearchHotRank(10);
            //foreach (var item in result.Data.Trending.List)
            //{
            //    Console.WriteLine(item.ShowName);
            //}
            #endregion

            #region 搜索建议
            //https://s.search.bilibili.com/main/suggest?func=suggest&suggest_type=accurate&sub_type=tag&main_ver=v1&userid=108534711&special_acc_num=1&topic_acc_num=1&upuser_acc_num=3&tag_num=11&term=刀剑神域
            //SearchSquare searchSquare = new();
            //var result = await searchSquare.GetSearchSuggest("不要笑挑战");
            //foreach (var item in result.Result.Values)
            //{
            //    Console.WriteLine(item.Value);
            //}
            #endregion

            #region 动态头部信息
            //MyDynamic Dynamic = new();
            //var list = await Dynamic.GetDynamicUp_UpDateList();
            //Console.WriteLine($"正在直播的有{list.Data.LiveInfo.Count}个");
            //foreach (var item in list.Data.LiveInfo.Items)
            //{
            //    Console.WriteLine($"{item.UpName}正在直播，标题为:{item.Title}");
            //}
            //Console.WriteLine("等等，你还有一些动态信息");
            //var updatelist = list.Data.UpList.Where((p) => p.IsUpDate == true).ToList();
            //Console.WriteLine($"在这几天里，共有{updatelist.Count()}个UP主有了一些重要信息");
            //foreach (var item in updatelist)
            //{
            //    Console.WriteLine(item.UpName);
            //}
            #endregion

            #region 获得个人页面的信息
            //Users users = new Users();
            //var user2 = await users.GetUser("797614");
            #endregion

            #region 获得全部的动态
            //MyDynamic Dynamic = new();
            //int index = 1;
            //string offset = "";
            //Console.WriteLine("输入回车获得下一页动态，输入N结束获取");
            //while (Console.ReadLine() != "N")
            //{
            //    Console.WriteLine("输入回车获得下一页动态，输入N结束获取");
            //    var value = await Dynamic.GetDynamic(MyDynamic.DynamicEnum.All,offset,index);
            //    if(value != null)
            //    {
            //        Console.WriteLine(value.Data.OffSet);
            //        foreach (var item in value.Data.DynamicList)
            //        {
            //            if(item.DynamicType == "DYNAMIC_TYPE_LIVE_RCMD")
            //            {
            //                string a = "fdsaf";
            //            }
            //        }
            //    }
            //    if(value.Data.OffSet != null)
            //    {
            //        offset= value.Data.OffSet;
            //    }
            //    index++;
            //}
            #endregion


            #region 获得电影的基本信息
            //BiliBiliAPI.PGC.PGC movie = new();
            //var result2 = await movie.GetPGC("704873", PGCEnum.EPID);
            //Console.WriteLine(result2.Result.Title);


            #endregion

            #region 获得电影的流媒体信息
            //BiliBiliAPI.PGC.PGC PGCVIDEO = new();
            //var str = await PGCVIDEO.GetPGCVideo(result2.Result.Episodes[0], PGCVideoEnum.EPID);
            //Console.WriteLine(str);
            #endregion

            #region 新首页API测试
            //WebHomeData webHome = new();
            //var result = await webHome.GetWebHomeVideo(30);
            #endregion


            #region 直播间信息流
            //LiveControl biliControl = new(23138275);
            //await biliControl.OnConnect();
            #endregion
            #region 追番操作
            //PGCAnimationFollow PGC = new();
            //var add = await PGC.PostAddPGCAnimationFollow("417");
            //Console.WriteLine(add.Result.Toast);
            //
            //var result = await PGC.PostDelPGCAnimationFollow("471");
            //Console.WriteLine(result.Result.Toast);

            #endregion

            #region 个人空间新API
            //Space MySpace = new();
            //var result = await MySpace.GetSpace("2142762");
            //string next = "0";
            //foreach (var item in result.Data.SpaceSeries.SpaceSeriesItems)
            //{
            //    while (true)
            //    {
            //        string id = item.ID;
            //        //获得个人空间
            //        var result2 = await MySpace.GetSpaceSeries("2142762", id, next);
            //        if (result2 != null)
            //        {
            //            Console.WriteLine(result2.Data.Item[0].Title);
            //            next = result2.Data.Next.ToString();
            //            continue;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //   
            //}
            //Console.ReadKey();

            #endregion

            #region B站旧首页推荐修复失败……(额，就是用安卓key失败，安卓TVkey正常)
            //Video video = new();
            //var r = await video.GetHomeVideo();
            #endregion

            #region 添加到稍后再看API
            //UserVideo UV = new();
            //var result = await UV.AddHistoryToView("221542003");
            //Console.WriteLine(result.Code);
            //Console.ReadKey();
            #endregion

            #region 视频评论区API

            //VideoComment coment = new();
            //int i = 1;
            //while (true)
            //{
            //    var result = await coment.GetComment("260858060", i).ConfigureAwait(false);
            //    Console.WriteLine($"获得第{i}页数据");
            //    i++;
            //}
            #endregion

            #region 使用grpc获得评论区信息
            //var result = await provider.SendData<MainListReply>(
            //    BiliBiliAPI.Grpc.Apis.GrpcReply,
            //    new MainListReq()
            //    {
            //        Cursor = new CursorReq()
            //        {
            //            Next = 1
            //        },
            //        Oid = 521501521,
            //        Type = 1,
            //    });

            //foreach (var item in result.Result.Replies)
            //{
            //    Console.WriteLine(item.Content.Message);
            //}


            #endregion
            #region 使用grpc获得稿件详细信息
            var data = new Bilibili.App.View.V1.ViewReq()
            {
                Bvid = "BV1j44y1f7gU"
            };
            var result2 = await provider.SendData<Bilibili.App.View.V1.ViewReply>(
                BiliBiliAPI.Grpc.Apis.GrpcViewDetail, data
                );
            Console.WriteLine(result2.Result.Arc.Title);
            Console.Write(result2.Result.Arc.Author.Name);
            #endregion

            #region 使用grpc获得视频的播放地址
            var data2 = new Bilibili.App.Playurl.V1.PlayViewReq()
            {
                Aid=result2.Result.Arc.Aid,
                Cid = result2.Result.Pages[0].Page.Cid,
                Download=2,
                Fourk=true,
                Qn=120,
                Fnval=4048,
                Fnver=0,
            };
            Bilibili.App.Playurl.V1.PlayViewReq url = new Bilibili.App.Playurl.V1.PlayViewReq()
            {
                Aid = 902417700,
                Cid = 886955631,
                Download = 0,
                Fourk = true,
                Qn = 116,
                Fnval = 4048,
                Fnver = 0,
                PreferCodecType = Bilibili.App.Playurl.V1.CodeType.Code264
            };
            var result4 = await provider.SendData<Bilibili.App.Playurl.V1.PlayViewReply>(BiliBiliAPI.Grpc.Apis.GrpcViewPlayConfig, url);
            #endregion
            Console.ReadKey();
        }

    }
}