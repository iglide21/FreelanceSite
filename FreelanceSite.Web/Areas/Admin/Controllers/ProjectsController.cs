using FreelanceSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceSite.Web.Areas.Admin.Controllers
{
    public class ProjectsController : AdminController
    {
        private readonly IWorkService works;

        public ProjectsController(IWorkService works)
        {
            this.works = works;
        }

        public IActionResult All()
        {
            var projects = this.works.AllProjects();

            return this.View(projects);
        }
    }
}
