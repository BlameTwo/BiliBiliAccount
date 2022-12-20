using System.Collections.Generic;
using Newtonsoft.Json;

namespace BiliBiliAPI.Models.Account.PhoneLoginModel;

public class CounityList
{
   [JsonProperty("default")]public CounityItem Default { get; set; }

   [JsonProperty("list")]public List<CounityItem> Lists { get; set; }
}


public class CounityItem
{
   [JsonProperty("id")]public int ID { get; set; }
   
   [JsonProperty("country_code")]public string Code { get; set; }
   
   [JsonProperty("cname")]public string DisplayName { get; set; }
}