namespace FreelanceSite.Web.Controllers
{
    using FreelanceSite.Services;
    using FreelanceSite.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IWorkService works;

        public HomeController(IWorkService works)
        {
            this.works = works;
        }

        public IActionResult Index()
        {
            var projects = this.works.AllActiveProjects();

            if (projects.ToList().Count < 4)
            {
                return this.View(projects);
            }

            return View(projects.Take(4));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
