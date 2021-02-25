using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHM.TedAzApp.Models.YouScanBaseModels
{
    public class LinksAndHostsBaseModel: LinksAndHostsSentimentValueBaseModel
    {
        public int totalEngagement { get; set; }
        public float avgEngagement { get; set; }
    }
}
