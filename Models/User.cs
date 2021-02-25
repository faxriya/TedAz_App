using Microsoft.AspNetCore.Identity;

namespace TedAzApp.Models
{
    public class User : IdentityUser
    {
        public int TopicId { get; set; }
    }
}
