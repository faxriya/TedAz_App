using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TedAzApp.DataContext.Models
{
    public partial class RootViewModel
    {
        //public int RootId { get; set; }
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
        [Column(TypeName = "datetime2")]
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
        public int ChannelId { get; set; }
        public string ChannelUrl { get; set; }
        public string ChannelName { get; set; }
        public string ChannelNickName { get; set; }
        public string ChannelAvatar { get; set; }
        public int? ChannelSubscribers { get; set; }
        public int AuthorId { get; set; }
        public string AuthorUrl { get; set; }
        public string AuthorName { get; set; }
        public string AuthorAvatar { get; set; }
        public int? AuthorSubscribers { get; set; }
        public string AuthorNickName { get; set; }
        public int RootReposts { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime RootAddedAt { get; set; }
       
        public int count { get; set; }
    }
}
