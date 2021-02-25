using MHM.TedAzApp.Models.YouScanBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHM.TedAzApp.Models.YouScanModels
{
    public class Trends
    {
        public Trend[] trends { get; set; }
    }
    public class Trend
    {
        public string name { get; set; }
        public int count { get; set; }
        public HistogramDate[] dates { get; set; }
        public BaseYouScanResponse[] sources { get; set; }
        public Country[] countries { get; set; }
        public BaseYouScanResponse[] sentiment { get; set; }
    }

    public class Country:BaseYouScanResponse
    {
        public BaseYouScanResponse[] regions { get; set; }
    }
}
