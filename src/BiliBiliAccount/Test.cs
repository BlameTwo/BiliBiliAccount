using BilibiliAPI.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI
{
    public static class Test
    {

        private static MyHttpClient HttpClient = new MyHttpClient();
        /// <summary>
        /// 测试接口
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<string> Go(string url)
        {
            return await Task.Run(async () =>
            {
                string str = await HttpClient.GetResults(url);
                return str;
            });
        }

        public static async Task<string> PostGo(string url,string content)
        {
            return await Task.Run(async () =>
            {
                return await HttpClient.PostResults(url,content);
            });
        }
    }
}
