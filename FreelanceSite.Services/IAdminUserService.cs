using FreelanceSite.Services.Models;
using System.Collections.Generic;

namespace FreelanceSite.Services
{
    public interface IAdminUserService
    {
        IEnumerable<SingleUserListingViewModel> All();
        void ChangeRoleName(string userId,string roleName);
    }
}
