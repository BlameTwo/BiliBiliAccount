using BilibiliAPI.Account;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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


        public static string GetHtml(string url)
        {
            string htmlCode;
            HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            webRequest.Timeout = 6000;
            webRequest.Method = "GET";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:75.0) Gecko/20100101 Firefox/75.0";
            webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            webRequest.Referer = "https://www.bilibili.com/";
            
            HttpWebResponse webResponse = null;
            webResponse = (System.Net.HttpWebResponse)webRequest.GetResponse();

            //获取目标网站的编码格式
            string contentype = webResponse.Headers["Content-Type"];
            Regex regex = new Regex("charset\\s*=\\s*[\\W]?\\s*([\\w-]+)", RegexOptions.IgnoreCase);
            if (webResponse.ContentEncoding.ToLower() == "gzip")//如果使用了GZip则先解压
            {
                using (System.IO.Stream streamReceive = webResponse.GetResponseStream())
                {
                    using (System.IO.Compression.GZipStream zipStream = new System.IO.Compression.GZipStream(streamReceive, System.IO.Compression.CompressionMode.Decompress))
                    {

                        //匹配编码格式
                        if (regex.IsMatch(contentype))
                        {
                            Encoding ending = Encoding.GetEncoding(regex.Match(contentype).Groups[1].Value.Trim());
                            using (StreamReader sr = new System.IO.StreamReader(zipStream, ending))
                            {
                                htmlCode = sr.ReadToEnd();
                            }
                        }
                        else
                        {
                            using (StreamReader sr = new System.IO.StreamReader(zipStream, Encoding.UTF8))
                            {
                                htmlCode = sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            else if (webResponse.ContentEncoding.ToLower() == "deflate")
            {
                using (System.IO.Stream streamReceive = webResponse.GetResponseStream())
                {
                    using (System.IO.Compression.DeflateStream zipStream = new System.IO.Compression.DeflateStream(streamReceive, System.IO.Compression.CompressionMode.Decompress))
                    {

                        //匹配编码格式
                        if (regex.IsMatch(contentype))
                        {
                            Encoding ending = Encoding.GetEncoding(regex.Match(contentype).Groups[1].Value.Trim());
                            using (StreamReader sr = new System.IO.StreamReader(zipStream, ending))
                            {
                                htmlCode = sr.ReadToEnd();
                            }
                        }
                        else
                        {
                            using (StreamReader sr = new System.IO.StreamReader(zipStream, Encoding.UTF8))
                            {
                                htmlCode = sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            else
            {
                using (System.IO.Stream streamReceive = webResponse.GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(streamReceive, Encoding.Default))
                    {
                        htmlCode = sr.ReadToEnd();
                    }
                }
            }
            return htmlCode;
        }

        public static string ConvertISO88591ToEncoding(string srcString, Encoding dstEncode)
        {

            string sResult;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Encoding ISO88591Encoding = Encoding.GetEncoding("ISO-8859-1");
            Encoding GB2312Encoding = Encoding.GetEncoding("gb2312"); //这个地方很特殊，必须利用GB2312编码
            byte[] srcBytes = ISO88591Encoding.GetBytes(srcString);

            //将原本存储ISO-8859-1的字节数组当成GB2312转换成目标编码(关键步骤)
            byte[] dstBytes = Encoding.Convert(GB2312Encoding, dstEncode, srcBytes);

            char[] dstChars = new char[dstEncode.GetCharCount(dstBytes, 0, dstBytes.Length)];

            dstEncode.GetChars(dstBytes, 0, dstBytes.Length, dstChars, 0);//利用char数组存储字符
            sResult = new string(dstChars);
            return sResult;

        }
    }
}
