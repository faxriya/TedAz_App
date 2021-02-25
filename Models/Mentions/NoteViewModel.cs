using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static TedAzApp.Extensions.Extension;

namespace TedAzApp.Models
{
    public class NoteViewModel
    {
        public class Author
        {
            public string url { get; set; }
            public string name { get; set; }
            public string nickname { get; set; }
            public string avatarUrl { get; set; }
            public int subscribers { get; set; }
        }

        public class Channel
        {
            public string url { get; set; }
            public string name { get; set; }
            public string nickname { get; set; }
            public string avatarUrl { get; set; }
            public int subscribers { get; set; }
        }
        public class Root
        {
            public string country { get; set; }
            public string region { get; set; }
            public string city { get; set; }
            public int topicId { get; set; }
            public string topicName { get; set; }
            public int themeId { get; set; }
            public string themeName { get; set; }
            public long mentionId { get; set; }
            public string sourceName { get; set; }
            [NoUddtColumn]
            public Author author { get; set; }
            [NoUddtColumn]
            public Channel channel { get; set; }
            public string title { get; set; }
            public string text { get; set; }
            public string url { get; set; }
            [Column(TypeName = "datetime2")]
            public DateTime published { get; set; }
            public string sentiment { get; set; }
            public string language { get; set; }
            public string postType { get; set; }
            public string resourceType { get; set; }
            public bool spam { get; set; }
            [NoUddtColumn]
            public List<object> tags { get; set; }
            public string postId { get; set; }
            public string parentPostId { get; set; }
            public string discussionId { get; set; }
            public int likes { get; set; }
            public int comments { get; set; }
            public int engagement { get; set; }
            [Column(TypeName = "datetime2")]
            public DateTime addedAt { get; set; }
            public int reposts { get; set; }

        }

    }
}
