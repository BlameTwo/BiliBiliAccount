using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.BiliLive
{
    interface ILiveMessage
    {
        string Message { get; set; }
    }

    public class LiveEvent : ILiveMessage
    {
        public string Message { get; set; }
    }

    public class CloseEvent: ILiveMessage
    {
        public string Message
        {
            get;set;    
        }

    }

    public class MessageEvent : ILiveMessage
    {
        public string Message { get; set; } 
    }

    public class ErrorEvent: ILiveMessage
    {
        public string Message { get; set; } 
    }
}
