using BiliBiliAPI.Models.Account;
using PCLCrypto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BiliBiliAPI.ApiTools
{
    public sealed class ApiProvider
    {
        public const string version = "3.0.0";
        public static ApiKeyInfo AndroidTVKey { get; } = new ApiKeyInfo("4409e2ce8ffd12b8", "59b43e04ad6965f34319062b478f83dd");

        public static ApiKeyInfo AndroidKey { get; } = new ApiKeyInfo("1d8b6e7d45233436", "560c52ccd288fed045859ed18bffd973");
        private static string _AccessKey;

        public static string ToMD5( string input)
        {
            try
            {
                var asymmetricKeyAlgorithmProvider = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(PCLCrypto.HashAlgorithm.Md5);
                var cryptographicKey = WinRTCrypto.CryptographicBuffer.ConvertStringToBinary(input, Encoding.UTF8);
                var hashData = asymmetricKeyAlgorithmProvider.HashData(cryptographicKey);
                return WinRTCrypto.CryptographicBuffer.EncodeToHexString(hashData);
            }
            catch { }
            return input;
        }

        public static string GetSign(string url, ApiKeyInfo apiKeyInfo = null)
        {
            try
            {
                if (apiKeyInfo == null) apiKeyInfo = AndroidTVKey;
                string str = url[(url.IndexOf("?", 4) + 1)..];
                List<string> list = str.Split('&').ToList();
                list.Sort();
                StringBuilder stringBuilder = new StringBuilder();
                foreach (string val in list)
                {
                    stringBuilder.Append(stringBuilder.Length > 0 ? "&" : string.Empty);
                    stringBuilder.Append(val);
                }
                stringBuilder.Append(apiKeyInfo.Secret);
                return ToMD5(stringBuilder.ToString()).ToLower();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "";
            }
        }
        public static long TimeSpanSeconds
        {
            get { return Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 8, 0, 0, 0)).TotalSeconds); }
        }

        /// <summary>
        /// XML转换实例的方法
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 字符编码的解压
        /// </summary>
        /// <param name="srcString"></param>
        /// <param name="dstEncode"></param>
        /// <returns></returns>
        public static string ConvertISO88591ToEncoding(string srcString, Encoding dstEncode)
        {

            string sResult;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Encoding ISO88591Encoding = Encoding.GetEncoding("ISO-8859-1");
            Encoding GB2312Encoding = Encoding.GetEncoding("gb2312"); 
            byte[] srcBytes = ISO88591Encoding.GetBytes(srcString);

            byte[] dstBytes = Encoding.Convert(GB2312Encoding, dstEncode, srcBytes);

            char[] dstChars = new char[dstEncode.GetCharCount(dstBytes, 0, dstBytes.Length)];

            dstEncode.GetChars(dstBytes, 0, dstBytes.Length, dstChars, 0);
            sResult = new string(dstChars);
            return sResult;

        }

    }

    public static class Tools
    {
        public static Dictionary<String, String> GetFormData(string formData)
        {
            try
            {
                string str = formData.Substring(formData.IndexOf('?') + 1);
                //将参数存入字符数组
                String[] dataArry = str.Split('&');

                //定义字典,将参数按照键值对存入字典中
                Dictionary<String, String> dataDic = new Dictionary<string, string>();
                //遍历字符数组
                for (int i = 0; i <= dataArry.Length - 1; i++)
                {
                    string dataParm = dataArry[i];
                    int dIndex = dataParm.IndexOf("=");
                    string key = dataParm.Substring(0, dIndex);
                    string value = dataParm.Substring(dIndex + 1, dataParm.Length - dIndex - 1);
                    string deValue = System.Web.HttpUtility.UrlDecode(value, System.Text.Encoding.GetEncoding("utf-8"));
                    //将参数以键值对存入字典
                    dataDic.Add(key, deValue);
                }
                return dataDic;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null!;
            }
        }
    }
}
