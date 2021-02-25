using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHM.TedAzApp.Models.Structs
{
    public struct YouScanApiLinks
    {
        public const string ListTopicsLink = @"https://api.youscan.io/api/external/topics/?apiKey={0}";
        public const string StatisticsSentimentLink = @"https://api.youscan.io/api/external/topics/{0}/statistics/sentiments?apiKey={1}&from={2}&to={3}";
        public const string StatisticsSentimentByRegionsLink = @"https://api.youscan.io/api/external/topics/{0}/statistics/regions-sentiments?apiKey={1}&from={2}&to={3}&size=1000";
        public const string StatisticsSentimentBySourcesLink = @"https://api.youscan.io/api/external/topics/{0}/statistics/sources-sentiments?apiKey={1}&from={2}&to={3}&size=1000";
        public const string StatisticsSentimentBySourcesAndRegionsLink = @"https://api.youscan.io/api/external/topics/{0}/statistics/regions-sources-sentiments?apiKey={1}&from={2}&to={3}&sourcesSize=1000&regionsSize=1000";
        public const string StatisticsWordcloudLink = @"https://api.youscan.io/api/external/topics/{0}/statistics/words?apiKey={1}&from={2}&to={3}&size=1000";
        public const string StatisticsHistogramLink = @"https://api.youscan.io/api/external/topics/{0}/statistics/histogram?apiKey={1}&from={2}&to={3}";
        public const string StatisticsTrendsLink = @"https://api.youscan.io/api/external/topics/{0}/statistics/trends?apiKey={1}&from={2}&to={3}";
        public const string StatisticsGendersLink = @"https://api.youscan.io/api/external/topics/{0}/statistics/genders?apiKey={1}&from={2}&to={3}";
        public const string StatisticsAgesLink = @"https://api.youscan.io/api/external/topics/{0}/statistics/ages?apiKey={1}&from={2}&to={3}";
        public const string StatisticsUrlsLink = @"https://api.youscan.io/api/external/topics/{0}/statistics/links?apiKey={1}&from={2}&to={3}&sort=count";
    }
}
