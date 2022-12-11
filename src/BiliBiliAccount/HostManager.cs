using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI
{
    public class Host
    {
        /// <summary>
        /// 搜索Host地址
        /// </summary>
        public string SearchHost
        {
            get; set;
        }


        /// <summary>
        /// 详情Host地址
        /// </summary>
        public string DataHost
        {
            get; set;
        }
    

        /// <summary>
        /// 播放Host地址
        /// </summary>
        public string PlayHost
        {
            get;set;    
        }
    }



    public class HostManager:Dictionary<string,Host>
    {
        public static HostManager GetDefault()
        {
            HostManager host = new HostManager();
            host.Add("Default", new Host()
            {
                SearchHost = "https://xn--2vrub.plus",
                DataHost= "https://xn--2vrub.plus",
                PlayHost= "https://xn--2vrub.plus"
            });
            return host;
        }


        /// <summary>
        /// 从文件中读取Host列表
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static HostManager ReadFile(string path)
        {
            return null;
        }
    }
}
