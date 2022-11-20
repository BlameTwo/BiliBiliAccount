using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliBiliAPI.Models.TopList
{
    public class MusicRankList
    {
        public List<YearData> YearData { get; set; }
    }

    public class MusicRankListItem
    {
        public string ID { get; set; }

        public string priod { get; set; }

        public string publish_time { get; set; }
    }

    public class YearData
    {
        public string Year { get; set; }
        public List<MusicRankListItem> MusicRankItem { get; set; }
    }
}
