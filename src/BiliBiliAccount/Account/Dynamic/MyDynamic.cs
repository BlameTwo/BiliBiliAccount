
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account.Dynamic;
using BiliBiliAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Account.Dynamic
{
    public class MyDynamic
    {
        HttpTools HttpClient = new();
        public async Task<ResultCode<DynamicUp_UpDateList>> GetDynamicUp_UpDateList()
        {
            var str = await HttpClient.GetResults(Apis.MY_DYNAMIC_UPLIST, HttpTools.ResponseEnum.App);
            var value =  JsonConvert.ReadObject<DynamicUp_UpDateList>(str);
            return value;
        }

        public enum DynamicEnum
        {
            Video,All,AnimationPGC,Read
        }

        public async Task<ResultCode<DynamicData>> GetDynamic(DynamicEnum dynamicEnum,string offset="",int page=1)
        {
            string arg="";
            string type = "";
            string offsetarg = null;
            switch (dynamicEnum)
            {
                case DynamicEnum.Video:type = "video";break;
                case DynamicEnum.All:type= "all";break;
                case DynamicEnum.AnimationPGC:type = "pgc";break;
                case DynamicEnum.Read:type = "article";break;
            }
            if(page > 1)
            {
                offsetarg = offset;
            }
            string offsetvalue = offsetarg != null && page > 1 ? offsetarg:"";
            arg = $"?type={type}&timezone_offset=-480&offset={offsetvalue}&page={page}";
            return JsonConvert.ReadObject<DynamicData>(await HttpClient.GetResults($"{Apis.MY_DYNAMIC}{arg}", HttpTools.ResponseEnum.Web));
        }
    }
}
