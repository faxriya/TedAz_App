using Microsoft.AspNetCore.Identity;

namespace TedAzApp.Models
{
    public class Role : IdentityRole
    {
        public bool IsChecked { get; set; }
        public Role(IdentityRole input, bool isChecked)
        {
            Id = input.Id;
            Name = input.Name;
            NormalizedName = input.NormalizedName;
            ConcurrencyStamp = input.ConcurrencyStamp;
            IsChecked = isChecked;
        }
    }
}
