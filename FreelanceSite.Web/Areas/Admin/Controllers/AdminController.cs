using FreelanceSite.Infrastructure.Constants;

namespace FreelanceSite.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static GlobalConstants;

    [Area("Admin")]
    [Authorize(Roles = AdministratorRole)]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
