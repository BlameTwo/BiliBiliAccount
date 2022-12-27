using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Account.History
{

    /// <summary>
    /// 历史记录信息
    /// </summary>    
    public class History
    {
        HttpTools HttpTools = new();

        public async Task<ResultCode<HistoryData>> GetHistory(Cursor current, int ps, GetHistoryType type)
        {
            string content = $"?max={current.Max}&view_at={current.View_At}&business={current.Business}&ps={ps}&type={HistoryTools.Convert(type)}";
            var result = await HttpTools.GetResults(Apis.ACCOUNT_HISTORY_LIST + content, HttpTools.ResponseEnum.Web);
            return JsonConvert.ReadObject<HistoryData>(result);
        }

        public async Task<ResultCode<object>> DeleteKidHistory(string Kid)
        {
            string bilijct = "";
            foreach (var item in BiliBiliArgs.TokenSESSDATA.cookies.Cookies)
            {
                if (item.Name == "bili_jct")
                {
                    bilijct += item.Value;
                }
            }

            /*请注意这里的bili_jct，在使用登录方法是务必要保存上这个cookie，并且和请求头上的bili_jct一致，不然会出现csrf校验失败的错误！*/
            string content = $"csrf={bilijct}&kid={Kid}";
            string result = await HttpTools.PostResults(Apis.ACCOUNT_HISTORY_DELETE, content, HttpTools.ResponseEnum.Web);
            return JsonConvert.ReadObject<object>(result);
        }

        public async Task<ResultCode<object>> DeleteAllHistory()
        {
            string bilijct = "";
            foreach (var item in BiliBiliArgs.TokenSESSDATA.cookies.Cookies)
            {
                if (item.Name == "bili_jct")
                {
                    bilijct += item.Value;
                }
            }

            /*请注意这里的bili_jct，在使用登录方法是务必要保存上这个cookie，并且和请求头上的bili_jct一致，不然会出现csrf校验失败的错误！*/
            string content = $"csrf={bilijct}";
            string result = await HttpTools.PostResults(Apis.ACCOUNT_HISTORY_DELETEALL, content, HttpTools.ResponseEnum.Web);
            return JsonConvert.ReadObject<object>(result);
        }


        public async Task<ResultCode<object>> CloseHistory(bool flage)
        {
            string bilijct = "";
            foreach (var item in BiliBiliArgs.TokenSESSDATA.cookies.Cookies)
            {
                if (item.Name == "bili_jct")
                {
                    bilijct += item.Value;
                }
            }
            string switchstring = flage ? "true" : "false";
            /*请注意这里的bili_jct，在使用登录方法是务必要保存上这个cookie，并且和请求头上的bili_jct一致，不然会出现csrf校验失败的错误！*/
            string content = $"csrf={bilijct}&switch={switchstring}";
            string result = await HttpTools.PostResults(Apis.ACCOUNT_HISTORY_DELETEALL, content, HttpTools.ResponseEnum.Web);
            return JsonConvert.ReadObject<object>(result);
        }

        /// <summary>
        /// 获得历史记录状态
        /// </summary>
        /// <returns></returns>
        public async Task<ResultCode<object>> GetHistoryState() 
        {
            string result = await HttpTools.GetResults(Apis.ACCOUNT_HISTORY_STATE, HttpTools.ResponseEnum.Web);
            return JsonConvert.ReadObject<object>(result);
        } 

    }
}
