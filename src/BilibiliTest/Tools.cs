using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliTest
{
    public static class Tools
    {
        public static string Deflate(this string strsource)
        {
            byte[] buffer = Convert.FromBase64String(strsource);
            using(MemoryStream ms = new MemoryStream())
            {
                ms.Write(buffer, 0, buffer.Length);
                ms.Position = 0;
                using(System.IO.Compression.DeflateStream stream = new System.IO.Compression.DeflateStream(ms, System.IO.Compression.CompressionMode.Decompress
                    ))
                {
                    stream.Flush();
                    int nSize = 16 * 1024 + 256;
                    byte[] deco = new byte[nSize];
                    int NSizeIncept = stream.Read(deco, 0, nSize);
                    stream.Close();
                    return System.Text.Encoding.UTF8.GetString(deco,0,NSizeIncept);
                }
            }
        }
    }
}
