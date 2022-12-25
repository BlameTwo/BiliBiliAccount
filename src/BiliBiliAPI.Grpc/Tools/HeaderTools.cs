using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Grpc.Tools
{
    public static class HeaderTools
    {
        public static string ToBase64(this byte[] data)
        {
            return Convert.ToBase64String(data);
        }    
    }
}
