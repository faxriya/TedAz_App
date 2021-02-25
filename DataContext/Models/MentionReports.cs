using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TedAzApp.DataContext.Models
{
    public class MentionReport
    {
        public string PostDate { get; set; }
        public string PostTime { get; set; }
        public string PostSavedAt { get; set; }
        public string PostTitle { get; set; }
        public string PostText { get; set; }
        public string PostUrl { get; set; }
        public string PostSentiment { get; set; }
        public string PostAuthor { get; set; }
        public string AuthorsProfile { get; set; }
        public int? AuthorsSubscribersCount { get; set; }
        public string PostDemography { get; set; }
        public int? AuthorsAge { get; set; }
        public string PostSource { get; set; }
        public string PostPublicationPlace { get; set; }
        public string PostPublicationPlaceProfile { get; set; }
        public int? PostPublicationPlaceSubscribersCount { get; set; }
        public string PostSourceType { get; set; }
        public string PostCountry { get; set; }
        public string PostRegion { get; set; }
        public string PostCity { get; set; }

        public string PostNotes { get; set; }
        public int? PostReactionsSum { get; set; }
        public int? PostLikesCount { get; set; }
        public int? PostLoveCount { get; set; }
        public int? PostHahaCount { get; set; }
        public int? PostWowCount { get; set; }
        public int? PostSadCount { get; set; }
        public int? PostAngryCount { get; set; }
        public int? PostDislikesCount { get; set; }
        public int? PostCommentsCount { get; set; }
        public int? PostRepostsCount { get; set; }
        public int? PostViewsCount { get; set; }
        public int? PostRatingCount { get; set; }
        public string PostImageUrl { get; set; }
        public string PostAssignedTo { get; set; }
        public string PostProcessed { get; set; }
    }
}