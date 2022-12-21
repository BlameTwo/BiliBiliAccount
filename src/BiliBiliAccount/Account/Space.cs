using System.Threading.Tasks;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Tools;

namespace BiliBiliAPI.Account;

public class Space
{
    private SpaceHttp SpaceHttp = new();

    /// <summary>
    /// 获得一个Up主的个人空间
    /// </summary>
    /// <param name="mid"></param>
    /// <param name="order">pubdate或click,为简略的动态视频的筛选</param>
    /// <param name="sort">desc或asc，为简略的动态视频的筛选排序</param>
    /// <returns></returns>
    public async Task<ResultCode<SpaceData>> GetSpace(string mid,string order="click",string sort="desc")
    {
        string content = $"?build=6780300&mobi_app=android&platform=android&vmid={mid}&order={order}&sort={sort}";
        var result =  await SpaceHttp.GetResults(Apis.SPACE + content, HttpTools.ResponseEnum.App, null,true);
        return JsonConvert.ReadObject<SpaceData>(result);
    }

    /// <summary>
    /// 查询空间页的Series视频列表
    /// </summary>
    /// <param name="mid"></param>
    /// <param name="series_id"></param>
    /// <param name="next"></param>
    /// <param name="sort"></param>
    /// <returns></returns>
    public async Task<ResultCode<SeriesData>> GetSpaceSeries(string mid,string series_id,string next,string sort="desc")
    {
        string content = $"?build=6780300&mobi_app=android&platform=android&vmid={mid}&sort={sort}&series_id={series_id}&next={next}&ps=10&qn=32";
        var result = await SpaceHttp.GetResults(Apis.SPACE_Series+ content, HttpTools.ResponseEnum.App);
        return JsonConvert.ReadObject<SeriesData>(result);
    }
}