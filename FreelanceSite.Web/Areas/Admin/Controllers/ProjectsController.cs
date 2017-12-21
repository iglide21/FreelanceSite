using FreelanceSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceSite.Web.Areas.Admin.Controllers
{
    public class ProjectsController : AdminController
    {
        private readonly IWorkService projects;

        public ProjectsController(IWorkService works)
        {
            this.projects = works;
        }

        public IActionResult All()
        {
            var projects = this.projects.AllProjects();

            return this.View(projects);
        }

        public IActionResult Delete(int? id)
        {
            this.projects.Remove(id);

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Activate(int? id)
        {
            this.projects.Activate(id);

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Deactivate(int? id)
        {
            this.projects.Deactivate(id);

            return this.RedirectToAction(nameof(All));
        }
    }
}
