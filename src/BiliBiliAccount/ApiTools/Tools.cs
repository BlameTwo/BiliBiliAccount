using BiliBiliAPI.Models.Account;
using PCLCrypto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI.ApiTools
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
    }
}
