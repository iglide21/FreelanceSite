using FreelanceSite.Infrastructure.Constants;

namespace FreelanceSite.Web.Areas.Admin.Controllers
{
    using FreelanceSite.Entities;
    using FreelanceSite.Services;
    using FreelanceSite.Services.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using FreelanceSite.Services.ServiceModels.Admin;

    using static GlobalConstants;
    using FreelanceSite.Web.Controllers;

    public class UsersController : AdminController
    {
        private readonly IAdminUserService users;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UsersController(IAdminUserService users,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.users = users;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
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
            var allRoles = AllRoles();

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

            foreach (var item in allRoles)
            {
                if (await this.userManager.IsInRoleAsync(user, item))
                {
                    await this.userManager.RemoveFromRoleAsync(user, item);
                }
            }

            await this.userManager.AddToRoleAsync(user, model.Role);

            if (this.User.Identity.Name == user.UserName)
            {
                await signInManager.SignOutAsync();
                return RedirectToAction(nameof(HomeController.Index), "Home", new { area=""});
            }

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
