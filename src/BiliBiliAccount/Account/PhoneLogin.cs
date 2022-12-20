using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BiliBiliAPI.ApiTools;
using BiliBiliAPI.Models;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.Account.PhoneLoginModel;
using BiliBiliAPI.Tools;

namespace BiliBiliAPI.Account;


/// <summary>
/// 手机号码登录
/// </summary>
public class PhoneLogin
{
    private LoginTool LoginTool = new();
    
    /// <summary>
    /// 获得支持的国家列表
    /// </summary>
    /// <returns></returns>
    public async Task<ResultCode<CounityList>> GetCounityList()
    {
        string content = "buvid=XYF2F19FA588E96DC2E9A62B358F164A3C5A7";
        string result = await LoginTool.Get(Apis.LOGIN_PHONE_LIST, content);
        return JsonConvert.ReadObject<CounityList>(result);
    }

    /// <summary>
    /// 发送手机验证码
    /// </summary>
    /// <returns></returns>
    public async Task<ResultCode<SendedData>> PostSMSSend(string cid,string phone)
    {
        string content = $"buvid=XYF2F19FA588E96DC2E9A62B358F164A3C5A7&build=6780300&device_tourist_id=20769902851549&cid={cid}&tel={phone}";
        string result = await LoginTool.Post(Apis.LOGIN_PHONE_SEND, content);
        return JsonConvert.ReadObject<SendedData>(result);
    }

    /// <summary>
    /// 验证验证码
    /// </summary>
    /// <param name="key"></param>
    /// <param name="captcha_key"></param>
    /// <param name="tel"></param>
    /// <param name="cid"></param>
    /// <returns></returns>
    public async Task<ResultCode<AccountToken>> PostSMSPoll(string key,string captcha_key,string tel,string cid)
    {
        string content =  $"login_session_id=9554832f714aeb8b4f77c89c171f7565&code={key}&captcha_key={captcha_key}&tel={tel}&cid={cid}";
        string result = await LoginTool.Post(Apis.LOGIN_PHONE_POLL, content);
        return JsonConvert.ReadObject<AccountToken>(result);
    }
}