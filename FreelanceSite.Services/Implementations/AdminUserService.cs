using AutoMapper.QueryableExtensions;
using FreelanceSite.Data;
using FreelanceSite.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace FreelanceSite.Services.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly FreelanceSiteDbContext db;

        public AdminUserService(FreelanceSiteDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SingleUserListingViewModel> All()
            => this.db
                .Users
                .ProjectTo<SingleUserListingViewModel>()
                .ToList();

        public void ChangeRoleName(string userId,string roleName)
        {
            var user = this.db
                .Users.
                SingleOrDefault(u => u.Id == userId);

            user.Role = roleName;

            db.SaveChanges();
        }
    }
}
