using MHM.TedAzApp.Models.YouScanBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHM.TedAzApp.Models.YouScanModels
{
    public class Sources
    {
        public Source[] sources { get; set; }
    }

    public class Source : BaseYouScanResponse
    {
        public BaseYouScanResponse[] sentiments { get; set; }
    }
}
