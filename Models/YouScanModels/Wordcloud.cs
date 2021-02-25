using MHM.TedAzApp.Models.YouScanBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHM.TedAzApp.Models.YouScanModels
{
    public class Wordcloud
    {
        public Word[] words { get; set; }
    }
    public class Word : BaseYouScanResponse
    {
    }
}
