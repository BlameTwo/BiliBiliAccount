using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BilibiliAPI.Models
{
    public class AccountLoginArg
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("ts")]
        public string Ts { get; set; }

        [JsonProperty("data")]
        public AccountLoginData Data { get; set; }
    }

    public class AccountLoginData
    {
        [JsonProperty("url")]
        public string PicUrl { get; set; }

        [JsonProperty("oauthKey")]
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
        public string DedeUserId { get; set; } = "";
        public string DedeUserid_MD5 { get; set; } = "";
        public string Expires { get; set; } = "";
        public string SECCDATA { get; set; } = "";
        public string Bili_JCT { get; set; } = "";
        public string URL { get; set; } = "";
    }



}
