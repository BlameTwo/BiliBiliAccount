using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using BiliBiliAPI.Models.Account;
namespace BiliBiliAPI.Models.Settings
{
    public static class AccountSettings
    {
        /// <summary>
        /// 我的文档
        /// </summary>
        public static readonly string AccountPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string DirPath= AccountPath + "\\BiliBiliSettings";
        public static string FilePath = DirPath + "\\Account.json";
        public static AccountToken Read()
        {
            Init();
            if (File.Exists(FilePath))
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string text = reader.ReadToEnd();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<AccountToken>(text)!;
                }
            }
            else
            {
                return null;
            }
            
        }


        static void Init()
        {
            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }
        }

        public static void Write(AccountToken args)
        {
            Init();
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(args);
            File.WriteAllText(FilePath,str);
        }

        public static void Delete()
        {
            File.Delete(FilePath);
        }
    }
}
