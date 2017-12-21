using System;
using System.Collections.Generic;
using System.Text;
using FreelanceSite.Services.CommonViewModels;
using FreelanceSite.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace FreelanceSite.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly FreelanceSiteDbContext db;

        public UserService(FreelanceSiteDbContext db)
        {
            this.db = db;
        }

        public UserDetailsViewModel GetUserDetails(string username)
        => this.db
                .Users
                .Where(u => u.UserName == username)
                .ProjectTo<UserDetailsViewModel>()
                .FirstOrDefault();

        public void UpdateCompletedProjects(string ownerId)
        {
            var user = this.db
                           .Users
                           .SingleOrDefault(u => u.Id == ownerId);

            user.CompletedProjects += 1;

            this.db.SaveChanges();
        }
    }
}
