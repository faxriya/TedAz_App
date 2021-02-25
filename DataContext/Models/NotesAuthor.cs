using System;
using System.Collections.Generic;

#nullable disable

namespace TedAz.Data.Models
{
    public partial class NotesAuthor
    {
        public int AuthorId { get; set; }
        public string AuthorUrl { get; set; }
        public string AuthorName { get; set; }
        public string AuthorAvatar { get; set; }
        public int? AuthorSubscribers { get; set; }
        public string AuthorNickName { get; set; }
    }
}
