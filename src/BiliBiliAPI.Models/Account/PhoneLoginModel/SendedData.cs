using Newtonsoft.Json;

namespace BiliBiliAPI.Models.Account.PhoneLoginModel;

public class SendedData
{
    [JsonProperty("is_new")]public bool IsNew { get; set; }
    
    [JsonProperty("captcha_key")]public string Captcha_Key { get; set; }
    
    [JsonProperty("recaptcha_url")]public string recaptcha_url { get; set; }
}