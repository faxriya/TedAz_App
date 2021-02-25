using System;
using System.Collections.Generic;

#nullable disable

namespace TedAz.Data.Models
{
    public partial class NotesRoot
    {
        public int RootI { get; set; }
        public string RootCountry { get; set; }
        public string RootRegion { get; set; }
        public string RootCity { get; set; }
        public int? RootTopicId { get; set; }
        public string RootTopicName { get; set; }
        public long? RootMentionId { get; set; }
        public string RootSourceName { get; set; }
        public int? RootAuthorId { get; set; }
        public int? RootChannelId { get; set; }
        public string RootTitle { get; set; }
        public string RootText { get; set; }
        public string RootUrl { get; set; }
        public DateTime? RootPublished { get; set; }
        public string RootSentiment { get; set; }
        public string RootLanguage { get; set; }
        public string RootPostType { get; set; }
        public string RootResourceType { get; set; }
        public bool? RootSpam { get; set; }
        public string RootPostId { get; set; }
        public string RootParentPostId { get; set; }
        public string RootDiscussionId { get; set; }
        public int? RootLikes { get; set; }
        public int? RootComments { get; set; }
        public int? RootEngagement { get; set; }
        public int? RootThemeId { get; set; }
        public string RootThemeName { get; set; }
    }
}
