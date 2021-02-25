using MHM.TedAzApp.Models.YouScanBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHM.TedAzApp.Models.YouScanModels
{
    public class RegionSourceSentiment
    {
        public RegionSource[] regions { get; set; }
    }

    public class RegionSource : BaseYouScanResponse
    {
        public Source[] sources { get; set; }
    }
}
