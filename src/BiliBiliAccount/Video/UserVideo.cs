using BiliBiliAPI.ApiTools;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Videos;
using BiliBiliAPI.Tools;
using BiliBiliAPI.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BiliBiliAPI.Tools.HttpTools;

namespace BiliBiliAPI.Video
{
    public class UserVideo
    {
        HttpTools HttpTools = new HttpTools();

        /// <summary>
        /// 点赞视频
        /// </summary>
        /// <param name="flage">是否点赞</param>
        /// <param name="aid">视频aid</param>
        /// <returns></returns>
        public async  Task<ResultCode<LikeToast>> LikeVideo(bool flage,string aid)
        {
            int fl = Convert.ToInt32(!flage);
            string content = $"aid={aid}&like={fl}";
            return JsonConvert.ReadObject<LikeToast>(await HttpTools.PostResults(Apis.LIKEVIDEO,content, HttpTools.ResponseEnum.App));
        }

        /// <summary>
        /// 获得视频的投币数量
        /// </summary>
        /// <param name="av_bv">视频号</param>
        /// <param name="type">视频的类型</param>
        /// <returns></returns>
        public async Task<ResultCode<VideoConis>> GetConis(string av_bv, VideoIDType type)
        {
            string url = "";
            switch (type)
            {
                case VideoIDType.AV:
                    url = $"{Apis.GETVIDEOCOINS}?aid={av_bv}";
                    break;
                case VideoIDType.BV:

                    url = $"{Apis.GETVIDEOCOINS}?bvid={av_bv}";
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrWhiteSpace(url))
            {
                return JsonConvert.ReadObject<VideoConis>(await HttpTools.GetResults(url, HttpTools.ResponseEnum.App));
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 投币视频
        /// </summary>
        /// <param name="multiply">投币数量</param>
        /// <param name="aid">视频aid</param>
        /// <param name="islike">是否同时点赞</param>
        /// <returns></returns>
        public async Task<ResultCode<VideoToConis>> CoinsVideo(int multiply,string aid, bool islike = false)
        {
            int like = islike ? 1 : 0;
            string content = $"aid={aid}&multiply={multiply}&select_like={like}";
            var result =  JsonConvert.ReadObject<VideoToConis>(await HttpTools.PostResults(Apis.APPSETVIDEOCOINS, content, HttpTools.ResponseEnum.App,null));
            return result;
        }

        /// <summary>
        /// 上传视频播放时间
        /// </summary>
        /// <param name="aid">视频aid</param>
        /// <param name="cid">视频cid</param>
        /// <param name="progress">视频进度</param>
        /// <returns></returns>
        public async Task<string> PostProgress(int aid,string cid,TimeSpan progress)
        {
            int hour = progress.Hours;int minute = progress.Minutes;
            int value2 = 0;
            if (hour > 0)
            {
                value2 = minute * 60 + (hour * 60) * 60;
            }else if(minute > 0)
            {
                value2 = minute * 60;
            }
            int value = int.Parse(progress.Seconds.ToString())+value2;
            string data = $"aid={aid}&cid={cid}&progress={value}&platform=android";
            return (await HttpTools.PostResults(Apis.SETVIDEOPROGRESS, data, HttpTools.ResponseEnum.App));
        }


        public async Task<string> AddOrDelFavorites(string aid,string addfavorite,bool addordel)
        {
            Users User = new();
            var list = await User.GetFavourites(aid);
            string Addstr = "";
            string Delstr = "";
            //首先把要操作的文件夹加进去
            if (addordel)
                Addstr += addfavorite;
            else
                Delstr += addfavorite;
            foreach (var item in list.Data.List)
            {
                if (item.ID == addfavorite)
                    continue;
                //如果之前收藏存在，且当前要操作的文件夹与id不符，则加入预备数据
                if (item.FavState == "1" && item.ID != addfavorite)
                {
                    Addstr += $",{item.ID}";
                }
                //如果之前收藏不存在，且和当前操作的文件夹id不服，则加入预备删除数据
                if (item.FavState == "0" && item.ID != addfavorite)
                {
                    Delstr += $",{item.ID}";
                }
            }
            string content = $"resources={aid}:2&add_media_ids={Addstr}&del_media_ids={Delstr}&build={Current.Build}";
            var value =  await HttpTools.PostResults(Apis.SETFAVORITEVIDEO,content, HttpTools.ResponseEnum.App);
            return value;
        }

        public async Task<ResultCode<object>> AddHistoryToView(string aid)
        {
            string content = $"build=6780300&aid={aid}";
            string result = await HttpTools.PostResults(Apis.ADD_HISTORY_TOPVIEW, content, ResponseEnum.App);
            return JsonConvert.ReadObject<object>(result);
        }
    }
}
