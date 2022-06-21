using BiliBiliAPI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.User
{
    /// <summary>
    /// 用户面板信息
    /// </summary>
    public class Users
    {
        ///
        private MyHttpClient HttpClient = new MyHttpClient();

        /// <summary>
        /// 获得用户的基本信息
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public async Task<UserResult> GetUser(string mid)
        {
            string url = $"http://api.bilibili.com/x/space/acc/info?mid={mid}";
            return JsonConvert.ReadObject<UserResult>(await HttpClient.GetResults(url));
        }
    }
}
