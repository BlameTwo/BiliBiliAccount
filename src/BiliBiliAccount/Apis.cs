﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI
{
    public static class Apis
    {
        static HostManager HostManager;
        static Host Host = null;
        static Apis()
        {
            HostManager = HostManager.GetDefault();

            //使用Select选择一个提前预备好的Host
            Select("Default");
        }

        public static string NowSelect = "";

        public static void Select(string name)
        {
            foreach (var item in HostManager)
            {
                if (item.Key == name)
                {
                    Host = item.Value;
                }
            }
        }

        public static void AddHost(string key,Host value)
        {
            HostManager.Add(key, value);
        }


        public static string LIVE_WEB_SOCKET_IP = "wss://broadcastlv.chat.bilibili.com/sub";

        /// <summary>
        /// 个人信息
        /// </summary>
        public static string ACCOUNT_INFO_API = "https://api.bilibili.com/x/space/myinfo";

        /// <summary>
        /// 获得二维码接口
        /// </summary>
        public static string LOGIN_QRKEY_GET = "https://passport.bilibili.com/x/passport-tv-login/qrcode/auth_code";

        

        /// <summary>
        /// 验证二维码接口
        /// </summary>
        public static string LOGIN_QRKEY_POLL = "https://passport.bilibili.com/x/passport-tv-login/qrcode/poll";

        /// <summary>
        /// 获得密码登录密钥
        /// </summary>
        public static string LOGIN_PASSWD_GET_KEY = "https://passport.bilibili.com/api/oauth2/getKey";

        /// <summary>
        /// 获得个人登录信息
        /// </summary>
        public static string APP_LOGIN_NAV = "http://api.bilibili.com/x/web-interface/nav";
        /// <summary>
        /// 密码登录接口
        /// </summary>
        public static string LOGIN_PASSWD_LOGIN = "https://passport.bilibili.com/x/passport-login/oauth2/login";

        //MyAPI
        /// <summary>
        /// 获得一个MID的关注数量
        /// </summary>
        public static string MY_FOLLOW_API = "http://api.bilibili.com/x/msgfeed/unread";

        /// <summary>
        /// 获得登录用户的消息
        /// </summary>
        public static string MY_TIP_COUNT = "http://api.bilibili.com/x/msgfeed/unread";

        /// <summary>
        /// 获得登录信息的私信
        /// </summary>
        public static string MY_LETTER_COUNT = "http://api.vc.bilibili.com/session_svr/v1/session_svr/single_unread";

        /// <summary>
        /// 获得一个MID的播放数量
        /// </summary>
        public static string UP_VIEWCOUNT_API = "http://api.bilibili.com/x/space/upstat";


        /// <summary>
        /// 获得一个MID的相片数量
        /// </summary>
        public static string UP_IMAGECOUNT = "http://api.vc.bilibili.com/link_draw/v1/doc/upload_count";

        /// <summary>
        /// 动态头部信息API
        /// </summary>
        public static string MY_DYNAMIC_UPLIST = "https://api.bilibili.com/x/polymer/web-dynamic/v1/portal";

        /// <summary>
        /// 动态API
        /// </summary>
        public static string MY_DYNAMIC = "https://api.bilibili.com/x/polymer/web-dynamic/v1/feed/all";

        /// <summary>
        /// 电影详细信息API
        /// </summary>
        public static string MOVIE_SESSION = "http://api.bilibili.com/pgc/view/web/season";

        /// <summary>
        /// 分区图标API
        /// </summary>
        public static string TID_ICON = "https://app.bilibili.com/x/v2/region/index";




        public static string SEARCH
        {
            get
            {
                if (Host.SearchHost == null)
                {
                    return $"https://app.bilibili.com/x/v2/search";
                }
                else
                {
                    return $"{Host!.SearchHost!}/x/v2/search";
                }
            }
        }

        /// <summary>
        /// 搜索属性API，包含漫游服务
        /// </summary>
        public static string SEARCH_TYPE
        {
            get
            {
                if (Host.SearchHost == null)
                {
                    return $"https://app.bilibili.com/x/v2/search/type";
                }
                else
                {
                    return $"{SEARCH}/type";
                }
            }
        }

        /// <summary>
        /// 联想搜索API
        /// </summary>
        public static string SEARCH_DEFAULT = "https://api.bilibili.com/x/web-interface/search/default";

        /// <summary>
        /// 热搜API
        /// </summary>
        public static string SEARCH_HOTLIST = "https://api.bilibili.com/x/web-interface/search/square";

        /// <summary>
        /// 搜索建议API
        /// </summary>
        public static string SEARCH_SUGGEST = "https://s.search.bilibili.com/main/suggest";

        /// <summary>
        /// 每周必看的时间表API
        /// </summary>
        public static string EVERYWEEK_TITLE = "https://api.bilibili.com/x/web-interface/popular/series/list";

        /// <summary>
        /// 每周必看的视频列表API
        /// </summary>
        public static string EVERYWEEK_VIDEOLIST = "https://api.bilibili.com/x/web-interface/popular/series/one";

        /// <summary>
        /// 音乐排行榜的时间表API
        /// </summary>
        public static string MUSICRANK_DATE = "https://api.bilibili.com/x/copyright-music-publicity/toplist/all_period?&list_type=1";

        /// <summary>
        /// 音乐排行榜视频列表
        /// </summary>
        public static string MUSICRANK_LIST = "https://api.bilibili.com/x/copyright-music-publicity/toplist/music_list";


        /// <summary>
        /// 每周必看的api
        /// </summary>
        public static string MUSTWASATCH_LIST = "https://api.bilibili.com/x/web-interface/popular/precious";

        /// <summary>
        /// 排行榜API
        /// </summary>
        public static string TOPLIST = "https://api.bilibili.com/x/web-interface/ranking/v2";

        /// <summary>
        /// 获得一个mid的详细信息，如果为自己则包含一些隐私信息
        /// </summary>
        public static string USER = "https://api.bilibili.com/x/space/acc/info";

        /// <summary>
        /// 登录后的一些信息
        /// </summary>
        public static string MySESSION = "https://api.bilibili.com/x/space/myinfo";

        /// <summary>
        /// 弹幕服务器的地址
        /// </summary>
        public static string DANMAKUFILE = "http://comment.bilibili.com";


        /// <summary>
        /// 点赞视频
        /// </summary>
        public static string LIKEVIDEO = "http://app.bilibili.com/x/v2/view/like";

        /// <summary>
        /// 获得视频硬币数量
        /// </summary>
        public static string GETVIDEOCOINS = "http://api.bilibili.com/x/web-interface/archive/coins";

        /// <summary>
        /// 投币视频
        /// </summary>
        public static string APPSETVIDEOCOINS = "https://app.bilibili.com/x/v2/view/coin/add";

        public static string WEBSETVIDEOCOINS = "https://api.bilibili.com/x/web-interface/coin/add";

        /// <summary>
        /// 上传播放进度
        /// </summary>
        public static string SETVIDEOPROGRESS = "http://api.bilibili.com/x/v2/history/report";

        public static string SETFAVORITEVIDEO = "https://api.bilibili.com/x/v3/fav/resource/batch-deal";

        public static string GETPGCVIDEO = "http://api.bilibili.com/pgc/player/web/playurl";


        public static string WEB_HOME = "https://api.bilibili.com/x/web-interface/index/top/feed/rcmd";

        /// <summary>
        /// 追番API
        /// </summary>
        public static string PGC_ANIMATION_FOLLOW_Delete = "https://api.bilibili.com/pgc/app/follow/del";

        public static string PGC_ANIMATION_FOLLOW_ADD = "https://api.bilibili.com/pgc/app/follow/add";

        /// <summary>
        /// 支持的手机号码列表
        /// </summary>
        public static string LOGIN_PHONE_LIST = "https://passport.bilibili.com/x/passport-login/country";

        /// <summary>
        /// 发送短信验证码
        /// </summary>
        public static string LOGIN_PHONE_SEND = "https://passport.bilibili.com/x/passport-login/sms/send";

        /// <summary>
        /// 短信验证码登录
        /// </summary>
        public static string LOGIN_PHONE_POLL = "https://passport.bilibili.com/x/passport-login/login/sms";

        /// <summary>
        /// 手机个人空间API
        /// </summary>
        public static string SPACE = "https://app.bilibili.com/x/v2/space";

        /// <summary>
        /// 个人空间下的Series值列表视频
        /// </summary>
        public static string SPACE_SERIES = "https://app.biliapi.net/x/v2/space/series";

        /// <summary>
        /// 添加到稍后再看
        /// </summary>
        public static string ADD_HISTORY_TOPVIEW = "https://api.bilibili.com/x/v2/history/toview/add";

        /// <summary>
        /// 视频评论API
        /// </summary>
        public static string VIDEO_COMMENT = "http://api.bilibili.com/x/v2/reply/main";

        /// <summary>
        /// 给评论点赞API
        /// </summary>
        public static string SET_COMMENT_STAUTE = "https://api.bilibili.com/x/v2/reply/action";

        /// <summary>
        ///获得历史记录
        /// </summary>
        public static string ACCOUNT_HISTORY_LIST = "http://api.bilibili.com/x/web-interface/history/cursor";

        /// <summary>
        /// 删除其中一个历史记录
        /// </summary>
        public static string ACCOUNT_HISTORY_DELETE = "http://api.bilibili.com/x/v2/history/delete";

        /// <summary>
        /// 清空历史记录
        /// </summary>
        public static string ACCOUNT_HISTORY_DELETEALL = "http://api.bilibili.com/x/v2/history/clear";

        /// <summary>
        /// 停用历史记录
        /// </summary>
        public static string ACCOUNT_HISTORY_CLOSE = "http://api.bilibili.com/x/v2/history/shadow/set";

        /// <summary>
        /// 历史记录状态
        /// </summary>
        public static string ACCOUNT_HISTORY_STATE = "http://api.bilibili.com/x/v2/history/shadow";
    
        public static string ACCOUNT_UnLogin="https://passport.bilibili.com/x/passport-login/revoke";

        /// <summary>
        /// 刷新token的接口
        /// </summary>
        public static string RefreshToken = "https://passport.bilibili.com/api/v2/oauth2/refresh_token";
    }
}
