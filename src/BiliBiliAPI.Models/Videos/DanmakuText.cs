using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BiliBiliAPI.Models.Videos
{

    [XmlRoot("i")]
    public class DanmakuText
    {
        [XmlElement("chatserver")]
        public string Server { get; set; }

        [XmlElement("chatid")]
        public string ID { get; set; }

        [XmlElement("mission")]
        public string Mission { get; set; }

        [XmlElement("maxlimit")]
        public int Total { get; set; }

        [XmlElement("state")]
        public string State { get; set; }

        [XmlElement("real_name")]
        public string Real_Name { get; set; }

        [XmlElement("source")]
        public string Source { get; set; }

        [XmlElement("d")]
        public List<Texts> Texts { get; set; }
    }

    public class Texts
    {
        [XmlAttribute("p")]
        public string P { get; set; }

        [XmlText()]
        public string Text { get; set; }

        
    }

    public class FormatDanmakuTextModel
    {
        public double Time { get; set; }

        public string DanmakuType { get; set; }

        public int FontSize { get; set; }
        /// <summary>
        /// 十进制颜色值
        /// </summary>
        public int Color { get; set; }

        public int CreateTime { get; set; }

        /// <summary>
        /// 弹幕池
        /// </summary>
        public string DanmakuTypeSw { get; set; }

        public string MidHash { get; set; }

        public string Dmid { get; set; }

        /// <summary>
        /// 屏蔽等级
        /// </summary>
        public string Level { get; set; }

        public string Text { get; set; }
    }

}
