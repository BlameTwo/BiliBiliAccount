using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI
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
        综合 = 27,
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
}
