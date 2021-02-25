using System;
using System.Collections.Generic;

#nullable disable

namespace TedAz.Data.Models
{
    public partial class NotesChannel
    {
        public int ChannelId { get; set; }
        public string ChannelUrl { get; set; }
        public string ChannelName { get; set; }
        public string ChannelNickName { get; set; }
        public string ChannelAvatar { get; set; }
        public int? ChannelSubscribers { get; set; }
    }
}
