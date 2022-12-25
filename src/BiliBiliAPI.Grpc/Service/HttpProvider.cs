using BiliBiliAPI.Grpc.Interface;
using BiliBiliAPI.Grpc.Model;
using BiliBiliAPI.Models.Account;
using BiliBiliAPI.Models.Search;
using Google.Protobuf;
using System.Net.Http.Headers;

namespace BiliBiliAPI.Grpc.Service;

public class HttpProvider:IHttpProvider
{
    DefaultRequestHeader Header = DefaultRequestHeader.Create();
    public HttpProvider(AccountToken token)
    {
        BiliBiliAPI.Grpc.Apis.Token = token;
    }

    public HttpProvider()
    {

    }


    public async Task<BiliBiliAPI.Grpc.Model.GrpcResultCode<T>> SendData<T>(string url, IMessage message)
        where T : IMessage<T>, new()
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback +=
        (sender, certificate, chain, errors) =>
        {
            return true;
        };
        HttpClient httpClient = new HttpClient(handler);
            //默认方式导入
            string ua = DefaultRequestHeader.CreateUA(Header);
            //httpClient.DefaultRequestHeaders.Add("User-Agent", ua);
            //httpClient.DefaultRequestHeaders.Add("APP-KEY", "android64");
            //httpClient.DefaultRequestHeaders.Add("x-bili-metadata-bin", Header.GetMetadataBin());
            httpClient.DefaultRequestHeaders.Add("x-bili-metadata-bin", "");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("identify_v1", Apis.Token.SECCDATA);
            //httpClient.DefaultRequestHeaders.Add("x-bili-device-bin", Header.GetDeviceBin());
            //httpClient.DefaultRequestHeaders.Add("x-bili-network-bin", Header.GetNetworkBin());
            //httpClient.DefaultRequestHeaders.Add("x-bili-restriction-bin", "");
            //httpClient.DefaultRequestHeaders.Add("x-bili-mid", Apis.Token.Mid);
            //httpClient.DefaultRequestHeaders.Add("x-bili-locale-bin", Header.GetLocaleBin());
            //httpClient.DefaultRequestHeaders.Add("x-bili-exps-bin", "CgIIAQ");
            //httpClient.DefaultRequestHeaders.Add("x-bili-aurora-eid", "UF0CT1ADD1IDXA==");
            //httpClient.DefaultRequestHeaders.Add("x-bili-trace-id", Header.GenTraceId());
            //httpClient.DefaultRequestHeaders.Add("x-bili-fawkes-req-bin", Header.GetFawkesreqBin());
            //httpClient.DefaultRequestHeaders.Add("grpc-accept-encoding", "identity");
            //httpClient.DefaultRequestHeaders.Add("env", "prod");
            //httpClient.DefaultRequestHeaders.Add("Transfer-Encoding", "chunked");
            //httpClient.DefaultRequestHeaders.Add("buvid", "XYF2F19FA588E96DC2E9A62B358F164A3C5A7");
            //httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            //httpClient.DefaultRequestHeaders.Add("TE", "trailers");
            //httpClient.DefaultRequestHeaders.Add("Host", "grpc.biliapi.net");
            var messbyte = message.ToByteArray();
            var stateBytes = new byte[] { 0, 0, 0, 0, (byte)messbyte.Length };
            byte[] bodyBytes = new byte[5 + messbyte.Length];
            stateBytes.CopyTo(bodyBytes, 0);
            messbyte.CopyTo(bodyBytes, 5);
            ByteArrayContent byteArrayContent = new ByteArrayContent(bodyBytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/grpc");
            byteArrayContent.Headers.ContentLength = bodyBytes.Length;
            var response = await httpClient.PostAsync(url, byteArrayContent);
            var data = await response.Content.ReadAsByteArrayAsync();
            if (data.Length > 5)
            {
                var result = new MessageParser<T>(() => new T());
                var resultdata = result.ParseFrom(data.Skip(5).ToArray());
                return new GrpcResultCode<T>()
                {
                    Result = resultdata,
                    Code = 0,
                    Message = "Ok"
                };
            }
            else
            {
                return new GrpcResultCode<T>()
                {
                    Code = -102,
                    Message = "Error!!!",
                };
            }
    }


}