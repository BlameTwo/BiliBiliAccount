
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
    }
}
