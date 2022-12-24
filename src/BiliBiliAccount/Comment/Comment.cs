using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Comment;
using BiliBiliAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Comment
{
    public class Comment
    {
        CommentTools CommentClient = new();

        /// <summary>
        /// 点赞评论，oid详情：https://github.com/SocialSisterYi/bilibili-API-collect/blob/master/comment/readme.md#%E8%AF%84%E8%AE%BA%E5%8C%BA%E7%B1%BB%E5%9E%8B%E4%BB%A3%E7%A0%81
        /// </summary>
        /// <param name="islike"></param>
        /// <param name="rpid"></param>
        /// <param name="oid"></param>
        /// <returns></returns>
        public async Task<ResultCode<CommentReturnData>> LikeComment(bool islike, string rpid, string oid,CommentType commentType)
        {
            int action = islike ? 1 : 0;
            string content = $"build=7110300&rpid={rpid}&oid={oid}&action={action}&from=7&platform=android&mobi_app=android&=alifenfa&ordering=heat&scene=main&type={(int)commentType}";
            return JsonConvert.ReadObject<CommentReturnData>(await CommentClient.PostResults(Apis.SET_COMMENT_STAUTE, content, HttpTools.ResponseEnum.App));
        }


    }

    public enum CommentType
    {
        AVVideo = 1,
        HuaTi=2,
        HuoDong=4,
        LitterVideo=5,
        BlackHouseTitle=6,
        PublicTip=7,
        LiveHuoDong=8,
        PictureDynamic=11,
        Read=12,
        TextAndDynamic=17,
        Class=33,
        Book2D=22
    }
}
