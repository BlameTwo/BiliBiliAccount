using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Comment;
using BiliBiliAPI.Tools;
using System.Threading.Tasks;

namespace BiliBiliAPI.Comment
{
    public class VideoComment
    {
        HttpTools HttpClient = new();
        Comment comment = new Comment();
        public async Task<ResultCode<VideoCommentData>> GetComment(string aid, int pagesize,string mod = "2",int ps = 20)
        {
            string content = $"?type=1&next={pagesize}&oid={aid}&ps={ps}&mod={mod}&type=1";
            var result = await HttpClient.GetResults(Apis.VIDEO_COMMENT + content, HttpTools.ResponseEnum.Web);
            return JsonConvert.ReadObject<VideoCommentData>(result);
        }

        public async Task<ResultCode<CommentReturnData>> SetCommentState(bool islike, string rpid, string oid)
        {
            return await comment.LikeComment(islike, rpid, oid, CommentType.AVVideo);
        }


    }
}
