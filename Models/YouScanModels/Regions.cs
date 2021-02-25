using MHM.TedAzApp.Models.YouScanBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHM.TedAzApp.Models.YouScanModels
{
    public class Regions
    {
        public Regions[] regions { get; set; }
    }

    public class Region : BaseYouScanResponse
    {
        public BaseYouScanResponse[] sentiments { get; set; }
    }
}
