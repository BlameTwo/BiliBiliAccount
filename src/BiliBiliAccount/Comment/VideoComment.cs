using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Comment;
using BiliBiliAPI.Tools;
using System.Threading.Tasks;

namespace BiliBiliAPI.Comment
{
    public class VideoComment
    {
        HttpTools HttpClient = new();
        public async Task<ResultCode<VideoCommentData>> GetComment(string aid, int pagesize,string mod = "2",int ps = 20)
        {
            string content = $"?type=1&next={pagesize}&oid={aid}&ps={ps}&mod={mod}";
            var result = await HttpClient.GetResults(Apis.VIDEO_COMMENT + content, HttpTools.ResponseEnum.App);
            return JsonConvert.ReadObject<VideoCommentData>(result);
        }
    }
}
