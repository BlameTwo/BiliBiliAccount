
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliAPI
{
    public static class JsonConvert
    {
        public  static T ReadObject<T>(string data)
        {
            JsonReader reader = new JsonTextReader(new StringReader(data));
            JsonSerializer jsonSerializer = new JsonSerializer();
            var d = jsonSerializer.Deserialize<T>(reader);
            return d;
        }
    }
}
