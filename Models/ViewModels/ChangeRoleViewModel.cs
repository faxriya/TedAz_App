using System.Collections.Generic;

namespace TedAzApp.Models.ViewModels
{
    public class ChangeRoleViewModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<Role> AllRoles { get; set; }
        public ChangeRoleViewModel()
        {
            AllRoles = new List<Role>();
        }
    }
}
