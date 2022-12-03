using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.Account
{

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
        /// 性别，文字
        /// </summary>
        [JsonProperty("sex")]
        public string Sex { get; set; } = "";


        /// <summary>
        /// 等级
        /// </summary>
        [JsonProperty("level")]
        public string Level { get; set; } = "";


        /// <summary>
        /// 用户是否被封禁，0为正常，1为封禁
        /// </summary>
        [JsonProperty("silence")]
        public string Silence { get; set; } = "";

        /// <summary>
        /// 大会员信息
        /// </summary>
        [JsonProperty("vip")]
        public Vip MyVIp { get; set; } = new Vip();

        /// <summary>
        /// 经验信息
        /// </summary>
        [JsonProperty("level_exp")]
        public Level_Exp Exp { get; set; } = new Level_Exp();

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
        public string Status { get; set; } = "";

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

        [JsonProperty("desc")]public string Desc { get; set; }

        [JsonProperty("type")]public string Type { get; set; }
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



    public class Level_Exp
    {
        /// <summary>
        /// 当前等级
        /// </summary>
        [JsonProperty("current_level")]
        public string Level { get; set; } = null;

        /// <summary>
        /// 当前的等级从多少经验开始
        /// </summary>
        [JsonProperty("current_min")]
        public string Crrent_Min { get; set; } = "0";

        /// <summary>
        /// 当前账户的经验
        /// </summary>
        [JsonProperty("current_exp")]
        public string Current_Exp { get; set; } = "0";

        /// <summary>
        /// 下一个等级需要多少经验
        /// </summary>
        [JsonProperty("next_exp")]
        public string Next_Exp { get; set; } = "0";
    }
}
