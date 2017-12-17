using FreelanceSite.Services.ServiceModels.Admin;
using System.Collections.Generic;

namespace FreelanceSite.Services.Models
{
    public class AdminUsersListingViewModel
    {
        public IEnumerable<SingleUserListingViewModel> Users { get; set; }
        
        public IEnumerable<RoleViewModel> Roles { get; set; }
    }
}
