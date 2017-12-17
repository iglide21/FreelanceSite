namespace FreelanceSite.Web.Areas.Admin.Controllers
{
    using FreelanceSite.Entities;
    using FreelanceSite.Services;
    using FreelanceSite.Services.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using FreelanceSite.Services.ServiceModels.Admin;

    public class UsersController : AdminController
    {
        private readonly IAdminUserService users;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public UsersController(IAdminUserService users, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.users = users;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var models = this.users.All();

            var roles = this.roleManager
                .Roles
                .Select(r => new RoleViewModel
                {
                    Name = r.Name
                })
                .ToList();

            return this.View(new AdminUsersListingViewModel
            {
                Users = models,
                Roles = roles
            });
        }

        public async Task<IActionResult> AddToRole(AdminAddUserToRoleViewModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var user = await this.userManager.FindByIdAsync(model.UserId);

            this.users.ChangeRoleName(model.UserId, model.Role);

            var userExists = user != null;

            if (!roleExists || !userExists)
            {
                this.ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.All));
            }

            await this.userManager.AddToRoleAsync(user, model.Role);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
