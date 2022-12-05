using BiliBiliAPI.Models;
using BiliBiliAPI.Models.TopList;
using BiliBiliAPI.Tools;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.TopLists
{
    /// <summary>
    /// 音乐排行榜
    /// </summary>
    public class MusicRank
    {
        HttpTools HttpClient = new HttpTools();
        public async Task<ResultCode<MusicRankList>> GetRankList()
        {
            string url = "https://api.bilibili.com/x/copyright-music-publicity/toplist/all_period?&list_type=1";
            string value =  await HttpClient.GetResults(url, HttpTools.ResponseEnum.App);
            JObject jo = JObject.Parse(value);
            ResultCode<MusicRankList> result = new ResultCode<MusicRankList>()
            {
                Code = jo["code"].ToString(),
                Message = jo["message"].ToString(),
                TTl = jo["ttl"].ToString(),
                Data = new MusicRankList() { YearData = new List<YearData>() }
            };
            JObject ja = JObject.Parse(jo["data"]["list"].ToString());
            foreach (JToken item in ja.Children())
            {
                YearData data = new YearData() { MusicRankItem = new List<MusicRankListItem>() };
                data.Year = item.Path;
                foreach (var item2 in item.Children())
                {
                    JArray ja2 = JArray.Parse(item2.ToString());
                    foreach (var item3 in ja2)
                    {
                        MusicRankListItem val = new MusicRankListItem();
                        val.ID = item3["ID"].ToString();
                        val.priod = item3["priod"].ToString();
                        val.publish_time = item3["publish_time"].ToString();
                        data.MusicRankItem.Add(val  );
                    }
                }
                result.Data.YearData.Add(data);
            }
            return result;
        }


        public async Task<ResultCode<MusicRankItem>> GetMusics(string music_id)
        {
            string url = $"https://api.bilibili.com/x/copyright-music-publicity/toplist/music_list?list_id={music_id}";
            return JsonConvert.ReadObject<MusicRankItem>(await HttpClient.GetResults(url, HttpTools.ResponseEnum.App));
        }
    }
}
