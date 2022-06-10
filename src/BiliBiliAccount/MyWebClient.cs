using BilibiliAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI
{
    public static class MyWebClient
    {
        public enum DataType { XML,JSON}

        public static Task<string> Get(string url,DataType dataType)
        {
            return Task.Run(() =>
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
                req.ContentType = dataType == DataType.JSON ? "application/json" : "application/xml";
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                using (StreamReader read = new StreamReader(stream))
                {
                    return read.ReadToEnd();
                }
            });
        }

        public static Task<string> Get(string url,DataType dataType, string data)
        {
            return Task.Run(() =>
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
                req.ContentType = dataType == DataType.JSON ? "application/json" : "application/xml";
                
                req.Headers.Add("cookie", data);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                using (StreamReader read = new StreamReader(stream))
                {
                    return read.ReadToEnd();
                }
            });
        }

        public static Task<PostModel> Post(string url, Dictionary<string, string> dic)
        {
            return Task.Run(() =>
            {
                PostModel model = new PostModel();
                string result = "";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/xml";
                #region 添加Post 参数
                StringBuilder builder = new StringBuilder();
                int i = 0;
                foreach (var item in dic)
                {
                    if (i > 0)
                        builder.Append("&");
                    builder.AppendFormat("{0}={1}", item.Key, item.Value);
                    i++;
                }
                byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
                req.ContentLength = data.Length;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }
                #endregion
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
                var cookie = resp.Headers["Set-Cookie"];
                if (cookie != null)
                {
                    model.Cookies = cookie;
                }
                model.Body = result;
                return model;
            });
        }
    }
}
