using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BiliBiliAPI.Models
{
    public class AccountLoginArg
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("tt1")]
        public string TT1 { get; set; }

        [JsonProperty("data")]
        public AccountLoginData Data { get; set; }
    }

    public class AccountLoginData
    {
        [JsonProperty("url")]
        public string PicUrl { get; set; }

        [JsonProperty("auth_code")]
        public string QRKey { get; set; }
    }

    public class LoginTrueString
    {
        public string Body { get; set; }
        public Checkenum Check { get; set; }

        /// <summary>
        /// 返回的Cookie信息
        /// </summary>
        public string Cookie { get; set; }

    }

    /// <summary>
    /// 检查状态
    /// </summary>
    public enum Checkenum
    {
        /// <summary>
        /// 超时
        /// </summary>
        OnTime,
        /// <summary>
        /// Post错误
        /// </summary>
        Post,
        /// <summary>
        /// 不知名报错
        /// </summary>
        NULL,
        /// <summary>
        /// 登录成功
        /// </summary>
        Yes,
        /// <summary>
        /// 未扫码
        /// </summary>
        No,
        /// <summary>
        /// 扫了码未确定
        /// </summary>
        YesOrNo
    }

    /// <summary>
    /// 登录cookie
    /// </summary>
    public class AccountToken
    {
        [JsonProperty("mid")]
        public string DedeUserId { get; set; } = "";

        [JsonProperty("access_token")]
        public string SECCDATA { get; set; } = "";


        [JsonProperty("refresh_token")]
        public string RefToken { get; set; } 

        [JsonProperty("expires_in")]
        public string Expires_in { get; set; }
        [JsonProperty("token_info")]
        public AccountToken Info { get; set; }

        [JsonProperty("cookie_info")]
        public AccountTokenCookies cookies { get; set; }


        [JsonProperty("sso")]
        public string[] SSO { get; set; }
    }

    public class AccountTokenCookies
    {
        [JsonProperty("cookies")]
        public List<Cookie> Cookies { get; set; }

        [JsonProperty("domains")]
        public string[] Domains { get; set; }

    }

    public class Cookie
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("http_only")]
        public string Http_Only { get; set; }

        [JsonProperty("expires")]
        public string Expires { get; set; }
    }


}
