using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI
{
    /// <summary>
    /// B站分区
    /// </summary>
    public enum Cid
    {
        All = 999,

        #region 动画相关
        Douga = 1,
        MAD_AMV = 24,
        MMD_3D = 25,
        Vioce = 47,
        garage_kit = 210,
        tokusatsu = 86,
        acgntalks = 253,
        other = 27,
        #endregion
        
        #region 番剧相关
        /// <summary>
        /// 动画
        /// </summary>
        Animation = 13,

        /// <summary>
        /// 动画资讯
        /// </summary>
        Anmiation_Infomation = 51,

        /// <summary>
        /// 官方延伸
        /// </summary>
        Anmiation_Offical = 152,

        /// <summary>
        /// 完结动画
        /// </summary>
        Animation_finish=32,

        /// <summary>
        /// 连载动画
        /// </summary>
        Animation_serial =33,
        #endregion

        #region 国创相关
        /// <summary>
        /// 国创主分区
        /// </summary>
        Chinese = 167,
        /// <summary>
        /// 国创动画
        /// </summary>
        ChineseAnimation= 153,
        /// <summary>
        /// 国创原创相关
        /// </summary>
        Chinese_A_Original=168,
        /// <summary>
        /// 布袋戏
        /// </summary>
        Chinese_puppetry = 169,
        /// <summary>
        /// 国创资讯
        /// </summary>
        Chinese_information =170,

        /// <summary>
        /// 动态漫画和广播剧
        /// </summary>
        Chinese_motioncomic =195,
        #endregion

        #region 音乐
        Music = 3,
        Music_original = 28,
        Music_Cover = 31,
        VU = 30,
        Music_perform = 59,
        Music_MV=193,
        Music_Live =29,
        Music_other = 130,
        Music_commentary = 243,
        Music_Tutorial = 244,
        #endregion

        #region 舞蹈
        Dance = 129,
        Dance_Otaku = 20,
        /// <summary>
        /// 舞蹈综合
        /// </summary>
        Dance_Three_D = 154,

        Dance_HipHop = 198,
        
        Dance_Star= 199,
        Dance_China=200,
        #endregion

        #region 游戏
        Game = 4,
        #endregion

        #region 知识
        knowledge = 36,
        #endregion

        #region 科技
        Tech= 188,
        #endregion

        #region 运动
        Sports = 234,
        #endregion

        #region 汽车
        Car = 223,
        #endregion

        #region 生活
        Life = 160,
        #endregion

        #region 美食
        Food = 211,
        #endregion

        #region 动画
        Animal =217,
        #endregion

        #region 鬼畜
        Kichiku = 119,
        #endregion

        #region 时尚
        Fashion = 155,
        #endregion

        #region 娱乐
        Ent = 5,

        #endregion

        #region 影视
        Cinephile = 181,
        #endregion

        #region 纪录片
        Documentary = 177,
        #endregion

        #region 电影
        Movie = 23,
        #endregion


        #region 电视剧
        TV = 11,
        ChineseTV = 185,
        UnChineseTV = 187
        #endregion
    }


    public struct CidFormat
    {
        public string FromEnum(Cid cid)
        {
            switch (cid)
            {
                case Cid.All:
                    return "全站";
                case Cid.Douga:
                    return "动画";
                case Cid.MAD_AMV:
                    return "动画MAD~AMV";
                case Cid.MMD_3D:
                    return "动画MMD~3D";
                case Cid.Vioce:
                    return "动画衍生";
                case Cid.garage_kit:
                    return "手办~模型";
                case Cid.tokusatsu:
                    return "特摄";
                case Cid.acgntalks:
                    return "动画杂谈";
                case Cid.other:
                    return "动画综合";
                case Cid.Animation:
                    return "番剧不可用";
                case Cid.Anmiation_Infomation:
                    return "番剧资讯";
                case Cid.Anmiation_Offical:
                    return "官方延伸";
                case Cid.Animation_finish:
                    return "完结动画";
                case Cid.Animation_serial:
                    return "连载动画";
                case Cid.Chinese:
                    return "国创";
                case Cid.ChineseAnimation:
                    return "国产动画";
                case Cid.Chinese_A_Original:
                    return "国产二创";
                case Cid.Chinese_puppetry:
                    return "布袋戏";
                case Cid.Chinese_information:
                    return "国产资讯";
                case Cid.Chinese_motioncomic:
                    return "动态漫画~广播剧";
                case Cid.Music:
                    return "音乐";
                case Cid.Music_original:
                    return "原创音乐";
                case Cid.Music_Cover:
                    return "翻唱";
                case Cid.VU:
                    return "VOCALOID·UTAU";
                case Cid.Music_perform:
                    return "演奏";
                case Cid.Music_MV:
                    return "MV";
                case Cid.Music_Live:
                    return "音乐现场";
                case Cid.Music_other:
                    return "音乐综合";
                case Cid.Music_commentary:
                    return "乐评盘点";
                case Cid.Music_Tutorial:
                    return "音乐教学";
                case Cid.Dance:
                    return "舞蹈";
                case Cid.Dance_Otaku:
                    return "宅舞";
                case Cid.Dance_Three_D:
                    return "舞蹈综合";
                case Cid.Dance_HipHop:
                    return "街舞";
                case Cid.Dance_Star:
                    return "明星舞蹈";
                case Cid.Dance_China:
                    return "中国舞蹈";
                case Cid.Game:
                    return "游戏";
                case Cid.knowledge:
                    return "知识";
                case Cid.Tech:
                    return "科技";
                case Cid.Sports:
                    return "运动";
                case Cid.Car:
                    return "汽车";
                case Cid.Life:
                    return "生活";
                case Cid.Food:
                    return "食物";
                case Cid.Animal:
                    return "动物";
                case Cid.Kichiku:
                    return "鬼畜";
                case Cid.Fashion:
                    return "时尚";
                case Cid.Ent:
                    return "娱乐";
                case Cid.Documentary:
                    return "纪录片";
                case Cid.Movie:
                    return "电影";
                case Cid.TV:
                    return "电视剧";
                case Cid.ChineseTV:
                    return "国产剧";
                case Cid.UnChineseTV:
                    return "海外电视剧";
                default:
                    return "什么也没有~";
            }
        }
    }
}
