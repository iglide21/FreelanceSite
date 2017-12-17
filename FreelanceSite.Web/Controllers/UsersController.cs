namespace FreelanceSite.Web.Controllers
{
    using FreelanceSite.Services;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly IUserService users;

        public UsersController(IUserService users)
        {
            this.users = users;
        }

        public IActionResult Details(string username)
        {
            var user = this.users.GetUserDetails(username);

            return this.View(user);
        }
    }
}
