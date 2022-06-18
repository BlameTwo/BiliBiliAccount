using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models
{
    public class AccountLoginResult
    {
        [JsonProperty("code")]
        public string Code { get; set; } = "";

        [JsonProperty("message")]
        public string Message { get; set; } = "";

        [JsonProperty("ttl")]
        public string Ttl { get; set; } = "";

        [JsonProperty("data")]
        public AccountLoginResultData Data { get; set; }
    }


    public class AccountLoginResultData
    {
        [JsonProperty("mid")]
        public string Mid { get; set; } = "";
        [JsonProperty("name")]
        public string Name { get; set; } = "";
        [JsonProperty("sign")]
        public string Sign { get; set; } = "";

        /// <summary>
        /// 硬币数量
        /// </summary>
        [JsonProperty("coins")]
        public string Conins { get; set; } = "";

        /// <summary>
        /// 生日
        /// </summary>
        [JsonProperty("birthday")]
        public string Birthday { get; set; } = "";

        /// <summary>
        /// 头像链接
        /// </summary>
        [JsonProperty("face")]
        public string Face_Image { get; set; } = "";

        /// <summary>
        /// 性别，0私密，1男，2女
        /// </summary>
        [JsonProperty("sex")]
        public string Sex { get; set; } = "";


        /// <summary>
        /// 等级
        /// </summary>
        [JsonProperty("level")]
        public string Level { get; set; } = "";


        /// <summary>
        /// 用户是否被封禁
        /// </summary>
        [JsonProperty("silence")]
        public string Silence { get; set; } = "";

        /// <summary>
        /// 大会员信息
        /// </summary>
        [JsonProperty("vip")]
        public Vip MyVIp { get; set; } = new Vip();

    }



    public class Vip
    {
        /// <summary>
        /// 0为无，1月度，2年度
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = "";

        /// <summary>
        /// 0无，1有
        /// </summary>
        [JsonProperty("status")]
        public string Status {get;set;} = "";

        /// <summary>
        /// 会员类型
        /// </summary>
        [JsonProperty("label")]
        public VipLabel Label { get; set; } = new VipLabel();
        /// <summary>
        /// 大会员到期时间
        /// </summary>
        [JsonProperty("due_date")]
        public string Vip_Stop { get; set; } = "";




    }

    public class Official
    {
        [JsonProperty("role")]
        public string Official_Type { get; set; } = "";
        [JsonProperty("title")]
        public string Text { get; set; } = "";
    }


    public class VipLabel
    {
        /// <summary>
        /// 会员文字
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; } = "";

        /// <summary>
        /// 会员类型
        /// </summary>

        [JsonProperty("label_theme")]
        public string Vip_Type { get; set; } = "";

        /// <summary>
        /// 文字颜色
        /// </summary>
        [JsonProperty("text_color")]
        public string Text_Fore { get; set; } = "";

        /// <summary>
        /// 背景颜色
        /// </summary>

        [JsonProperty("bg_color")]
        public string Text_Back { get; set; } = "";
    }

}
