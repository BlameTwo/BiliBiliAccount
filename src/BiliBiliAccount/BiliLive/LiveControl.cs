using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using WebSocketSharp;


// 参考：https://github.com/xiaoyaocz/AllLive

namespace BiliBiliAPI.BiliLive
{
    public class LiveControl
    {
        public event EventHandler<CloseEvent> OnClose;
        public event EventHandler<MessageEvent> OnMessageEvent;
        public event EventHandler<LiveEvent> LiveEvent;
        public event EventHandler<ErrorEvent> OnError;

        int HeartBeatTime = 60 * 1000;

        System.Timers.Timer timer;
        WebSocket _server { get; set; }

        public int Roomid { get; }

        public LiveControl(int roomid)
        {
            Roomid = roomid;
            _server = new(Apis.LIVE_WEB_SOCKET_IP);
            timer = new System.Timers.Timer(HeartBeatTime);
            timer.Elapsed += TimerChanged;
            _server.OnOpen += Opened;
            _server.OnMessage += _server_OnMessage;
            _server.OnClose += _server_OnClose;
        }

        private void _server_OnClose(object? sender, CloseEventArgs e)
        {
            OnClose.Invoke(this, new CloseEvent() { Message = e.Reason });
        }

        private void _server_OnMessage(object? sender, MessageEventArgs e)
        {
            try
            {
                ParseData(e.RawData);
            }
            catch (Exception ex)
            {
                OnError.Invoke(this, new ErrorEvent() { Message= ex.Message });
            }
        }

        public async Task OnConnect()
        {
            await Task.Run(() =>
            {
                _server.Connect();
            });
        }

        private void TimerChanged(object? sender, ElapsedEventArgs e)
        {
            _server.SendAsync(EncodeData("233", 2), (a) =>
            {
                //此处回调一个是否发送成功
                if (a == false)
                    OnError.Invoke(this, new ErrorEvent() { Message = "信息发送失败" });
            });
        }

        private void Opened(object? sender, EventArgs e)
        {
            _server.Send(EncodeData(Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                roomid = Roomid,
                uid = 0
            }), 7));
            timer.Start();
        }



        private void ParseData(byte[] data)
        {
            //协议版本。0为JSON，可以直接解析；1为房间人气值,Body为4位Int32；2为压缩过Buffer，需要解压再处理
            int protocolVersion = BitConverter.ToInt32(new byte[4] { data[7], data[6], 0, 0 }, 0);
            //操作类型。3=心跳回应，内容为房间人气值；5=通知，弹幕、广播等全部信息；8=进房回应，空
            int operation = BitConverter.ToInt32(data.Skip(8).Take(4).Reverse().ToArray(), 0);
            //内容
            var body = data.Skip(16).ToArray();
            if (operation == 3)
            {
                var online = BitConverter.ToInt32(body.Reverse().ToArray(), 0);
            }
            else if (operation == 5)
            {

                if (protocolVersion == 2)
                {
                    body = DecompressData(body);

                }
                var text = Encoding.UTF8.GetString(body);
                var textLines = Regex.Split(text, "[\x00-\x1f]+").Where(x => x.Length > 2 && x[0] == '{').ToArray();
                foreach (var item in textLines)
                {
                    OnMessageEvent.Invoke(this, new MessageEvent()
                    {
                        Message = item
                    });
                }
            }
        }


        /// <summary>
        /// 对数据进行编码
        /// </summary>
        /// <param name="msg">文本内容</param>
        /// <param name="action">2=心跳，7=进房</param>
        /// <returns></returns>
        private byte[] EncodeData(string msg, int action)
        {
            var data = Encoding.UTF8.GetBytes(msg);
            //头部长度固定16
            var length = data.Length + 16;
            var buffer = new byte[length];
            using (var ms = new MemoryStream(buffer))
            {

                //数据包长度
                var b = BitConverter.GetBytes(buffer.Length).ToArray().Reverse().ToArray();
                ms.Write(b, 0, 4);
                //数据包头部长度,固定16
                b = BitConverter.GetBytes(16).Reverse().ToArray();
                ms.Write(b, 2, 2);
                //协议版本，0=JSON,1=Int32,2=Buffer
                b = BitConverter.GetBytes(0).Reverse().ToArray(); ;
                ms.Write(b, 0, 2);
                //操作类型
                b = BitConverter.GetBytes(action).Reverse().ToArray(); ;
                ms.Write(b, 0, 4);
                //数据包头部长度,固定1
                b = BitConverter.GetBytes(1).Reverse().ToArray(); ;
                ms.Write(b, 0, 4);
                //数据
                ms.Write(data, 0, data.Length);
                var _bytes = ms.ToArray();
                ms.Flush();
                return _bytes;
            }

        }


        /// <summary>
        /// 解码数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private byte[] DecompressData(byte[] data)
        {
            using (MemoryStream outBuffer = new MemoryStream())
            using (System.IO.Compression.DeflateStream compressedzipStream = new System.IO.Compression.DeflateStream(new MemoryStream(data, 2, data.Length - 2), System.IO.Compression.CompressionMode.Decompress))
            {

                byte[] block = new byte[1024];
                while (true)
                {
                    int bytesRead = compressedzipStream.Read(block, 0, block.Length);
                    if (bytesRead <= 0)
                        break;
                    else
                        outBuffer.Write(block, 0, bytesRead);
                }
                compressedzipStream.Close();
                return outBuffer.ToArray();
            }


        }
    }
}
