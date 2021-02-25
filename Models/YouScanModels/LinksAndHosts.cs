using MHM.TedAzApp.Models.YouScanBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHM.TedAzApp.Models.YouScanModels
{
    public class LinksAndHosts
    {
        public int totalCount { get; set; }
        public Link[] links { get; set; }
        public Host[] hosts { get; set; }
    }

    public class Link : LinksAndHostsBaseModel
    {
        public LinkSentiment sentiment { get; set; }
    }

    public class Host : LinksAndHostsBaseModel
    {
        public HostSentiment sentiment { get; set; }
    }
    public class LinkSentiment
    {
        public LinksAndHostsSentimentValueBaseModel[] values { get; set; }
        public int otherCount { get; set; }
    }

    public class HostSentiment
    {
        public LinksAndHostsSentimentValueBaseModel[] values { get; set; }
        public int otherCount { get; set; }
    }
}
