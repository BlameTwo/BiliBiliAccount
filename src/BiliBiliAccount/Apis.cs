using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI
{
    public struct Apis
    {
        //AccountAPI
        
        /// <summary>
        /// 个人信息
        /// </summary>
        public const string ACCOUNT_INFO_API = "https://api.bilibili.com/x/space/myinfo";

        //LoginAPI

        /// <summary>
        /// 获得二维码接口
        /// </summary>
        public const string LOGIN_QRKEY_GET = "https://passport.bilibili.com/x/passport-tv-login/qrcode/auth_code";

        /// <summary>
        /// 验证二维码接口
        /// </summary>
        public const string LOGIN_QRKEY_POLL = "https://passport.bilibili.com/x/passport-tv-login/qrcode/poll";

        /// <summary>
        /// 获得密码登录密钥
        /// </summary>
        public const string LOGIN_PASSWD_GET_KEY = "https://passport.bilibili.com/api/oauth2/getKey";

        /// <summary>
        /// 密码登录接口
        /// </summary>
        public const string LOGIN_PASSWD_LOGIN = "https://passport.bilibili.com/x/passport-login/oauth2/login";

        //MyAPI
        /// <summary>
        /// 获得一个MID的关注数量
        /// </summary>
        public const string MY_FOLLOW_API = "http://api.bilibili.com/x/msgfeed/unread";

        /// <summary>
        /// 获得登录用户的消息
        /// </summary>
        public const string MY_TIP_COUNT = "http://api.bilibili.com/x/msgfeed/unread";

        /// <summary>
        /// 获得登录信息的私信
        /// </summary>
        public const string MY_LETTER_COUNT = "http://api.vc.bilibili.com/session_svr/v1/session_svr/single_unread";

        /// <summary>
        /// 获得一个MID的播放数量
        /// </summary>
        public const string UP_VIEWCOUNT_API = "http://api.bilibili.com/x/space/upstat";


        /// <summary>
        /// 获得一个MID的相片数量
        /// </summary>
        public const string UP_IMAGECOUNT = "http://api.vc.bilibili.com/link_draw/v1/doc/upload_count";

        /// <summary>
        /// 动态头部信息API
        /// </summary>
        public const string MY_DYNAMIC_UPLIST = "https://api.bilibili.com/x/polymer/web-dynamic/v1/portal";

        /// <summary>
        /// 动态API
        /// </summary>
        public const string MY_DYNAMIC = "https://api.bilibili.com/x/polymer/web-dynamic/v1/feed/all";
    }
}
