using MHM.TedAzApp.Models.YouScanBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHM.TedAzApp.Models.YouScanModels
{
    public class Histogram : HistogramBaseModel
    {
        public HistogramDate[] dates { get; set; }
        public int totalCount { get; set; }
    }
    public class HistogramDate:HistogramBaseModel
    {
        public DateTime key { get; set; }
        public int count { get; set; }
    }
}
