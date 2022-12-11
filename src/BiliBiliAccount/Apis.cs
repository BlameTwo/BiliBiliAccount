using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI
{
    public static class Apis
    {
        static HostManager HostManager;
        static Host Host=null;
        static Apis()
        {
            HostManager = HostManager.GetDefault();

            //使用Select选择一个提前预备好的Host
            Select("MyTest");
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
                if(Host.SearchHost == null)
                {
                    return $"https://app.bilibili.com/x/v2/search";
                }
                else
                {
                    return $"{Host!.SearchHost ?? "wc出错了"}/x/v2/search";
                }
            }
        }

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
    }


}
