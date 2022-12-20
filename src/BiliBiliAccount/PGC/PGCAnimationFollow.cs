using System.Threading.Tasks;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.PGC;
using BiliBiliAPI.Tools;

namespace BiliBiliAPI.PGC;

public class PGCAnimationFollow
{
    private HttpTools HttpClient = new();

    /// <summary>
    /// 取消追番或追剧
    /// </summary>
    /// <param name="ssid"></param>
    /// <returns></returns>
    public async Task<PGCFollowData> PostDelPGCAnimationFollow(string ssid)
    {
        string content = $"season_id={ssid}";
        return JsonConvert.Deserialize<PGCFollowData>(await HttpClient.PostResults(Apis.PGC_ANIMATION_FOLLOW_Delete,content, HttpTools.ResponseEnum.App)) ;
        
    }

    /// <summary>
    /// 添加追番或追剧
    /// </summary>
    /// <param name="ssid"></param>
    /// <returns></returns>
    public async Task<PGCFollowData> PostAddPGCAnimationFollow(string ssid)
    {
        string content = $"season_id={ssid}";
        return JsonConvert.Deserialize<PGCFollowData>(await HttpClient.PostResults(Apis.PGC_ANIMATION_FOLLOW_ADD,content, HttpTools.ResponseEnum.App)) ;
    }
    
}