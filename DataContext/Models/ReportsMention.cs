using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TedAzApp.DataContext.Models
{
    public class ReportsMention
    {

        public string RootPublishedDate { get; set; }
        public string RootPublishedTime { get; set; }
        public string RootTitle { get; set; }
        public string RootText { get; set; }
        public string RootPostType { get; set; }
        public string RootUrl { get; set; }
        public string RootSentiment { get; set; }
        public string AuthorName { get; set; }
        public string AuthorUrl { get; set; }
        public int? AuthorSubscribers { get; set; }
        public string RootSourceName { get; set; }
        public string ChannelName { get; set; }
        public string ChannelUrl { get; set; }
        public int? ChannelSubscribers { get; set; }
        public string RootResourceType { get; set; }
        public string RootCountry { get; set; }
        public int? RootLikes { get; set; }
        public int? RootComments { get; set; }
        public int? RootReposts { get; set; }
        public string RootImageUrl { get; set; }

    }
}
